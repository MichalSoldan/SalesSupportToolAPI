﻿using AutoMapper;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Polly;

using SalesSupportTool.Common.Models;
using SalesSupportTool.Infrastructure.WebApi.Helpers;
using SalesSupportTool.Infrastructure.WebApi.Providers;

using Swashbuckle.AspNetCore.SwaggerGen;

using System.Net.Http.Headers;
using System.Runtime.Serialization;

namespace SalesSupportTool.Infrastructure.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        private const string _defaultClientSettingsName = "DefaultClient";

        private const string ApiKeySchema = "ApiKey";

        public static void AddHttpClient(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment, string configName = _defaultClientSettingsName)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            HttpClientOptions options = new HttpClientOptions();
            HttpClientOptions defaultOptions = new HttpClientOptions();
            configuration.GetSection(configName).Bind(options);
            configuration.GetSection(_defaultClientSettingsName).Bind(defaultOptions);
            IMapper mapper = serviceProvider.GetRequiredService<IMapper>();
            options = mapper.Map(defaultOptions, options);

            if (options.UseAADToken != null && options.UseAADToken.Value)
            {
                IHttpClientBuilder httpClientBuilder = services.AddHttpClient(configName)
                    .ConfigureHttpClient((sp, client) =>
                    {
                        var tokenProvider = sp.GetRequiredService<AADTokenProvider>();
                        var token = tokenProvider.GetTokenAsync().GetAwaiter().GetResult();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        if (options.BaseAddress != null)
                        {
                            client.BaseAddress = options.BaseAddress;
                        }
                        if (options.Timeout != null)
                        {
                            client.Timeout = options.Timeout.Value;
                        }
                    }).AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(options.RetryCount ?? 0, retry => TimeSpan.FromSeconds(1)));
                if (environment.IsDevelopment()) // disable SSL/TLS certificate validation.
                {
                    httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() =>
                    {
                        HttpClientHandler handler = new HttpClientHandler
                        {
                            ServerCertificateCustomValidationCallback = (sender, certificate, chain, errors) => true
                        };
                        return handler;
                    });
                }
            }
            else
            {
                IHttpClientBuilder httpClientBuilder = services.AddHttpClient(configName)
                    .ConfigureHttpClient((serviceProvider, client) =>
                    {
                        if (options.BaseAddress != null)
                        {
                            client.BaseAddress = options.BaseAddress;
                        }
                        if (options.Timeout != null)
                        {
                            client.Timeout = options.Timeout.Value;
                        }
                        if (options.ApiKey != null)
                        {
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.ApiKey);
                        }
                        if (options.UserName != null)
                        {
                            client.DefaultRequestHeaders.Authorization = new BasicAuthenticationHeaderValue(options.UserName, options.Password);
                        }
                    })
                    .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(options.RetryCount ?? 0, retry => TimeSpan.FromSeconds(1)));
                if (environment.IsDevelopment())
                {
                    httpClientBuilder.ConfigurePrimaryHttpMessageHandler(() =>
                    {
                        HttpClientHandler handler = new HttpClientHandler
                        {
                            ServerCertificateCustomValidationCallback = (sender, certificate, chain, errors) => true
                        };
                        return handler;
                    });
                }
            }
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtAuthOptions jwtAuthOptions = new JwtAuthOptions();
            configuration.GetSection(JwtAuthOptions.SettingsName).Bind(jwtAuthOptions);

            services.AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(ApiKeySchema, o =>
                {
                    o.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = jwtAuthOptions.Issuer,
                            ValidAudience = jwtAuthOptions.Audience,
                            IssuerSigningKey = JwtTokenHelper.CreateSigningKey(jwtAuthOptions.Secret)
                        };
                });

            services.AddAuthorization(o =>
            {
                if (!jwtAuthOptions.Enabled)
                {
                    o.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAssertion(_ => true).Build();
                }
            });
        }

        public static void AddJwtSwaggerGen(this IServiceCollection services, IConfiguration configuration)
        {
            OAuth2Options oAuth2Options = new OAuth2Options();
            configuration.GetSection(OAuth2Options.SettingsName).Bind(oAuth2Options);

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference 
                            { 
                                Type = ReferenceType.SecurityScheme, 
                                Id = "Bearer" 
                            }
                        },
                        new List<string>()
                    }
                });

                c.SchemaFilter<EnumSchemaFilter>();
                c.UseInlineDefinitionsForEnums();

                // Register XML documentation files
                foreach (var xmlDocFile in Directory.EnumerateFiles(AppContext.BaseDirectory, "*.xml"))
                {
                    c.IncludeXmlComments(xmlDocFile);
                }
            });
        }

        public class EnumSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema model, SchemaFilterContext context)
            {
                if (context.Type.IsEnum)
                {
                    model.Enum.Clear();
                    foreach (string enumName in Enum.GetNames(context.Type))
                    {
                        System.Reflection.MemberInfo? memberInfo = context.Type.GetMember(enumName).FirstOrDefault(m => m.DeclaringType == context.Type);
                        EnumMemberAttribute? enumMemberAttribute = memberInfo == null
                         ? null
                         : memberInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false).OfType<EnumMemberAttribute>().FirstOrDefault();
                        string label = enumMemberAttribute == null || string.IsNullOrWhiteSpace(enumMemberAttribute.Value)
                         ? enumName
                         : enumMemberAttribute.Value;
                        model.Enum.Add(new OpenApiString(label));
                    }
                }
            }
        }

        public class ServiceCollectionExtensionsProfile : Profile
        {
            public ServiceCollectionExtensionsProfile()
            {
                this.CreateMap<HttpClientOptions, HttpClientOptions>()
                    .ForAllMembers(o => o.Condition((s, d, v) => v != null));
            }
        }
    }
}