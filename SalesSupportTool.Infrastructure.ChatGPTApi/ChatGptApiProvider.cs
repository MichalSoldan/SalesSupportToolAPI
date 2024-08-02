using AutoMapper;
using SalesSupportTool.Domain.Interfaces;
using SalesSupportTool.Infrastructure.WebApi.Providers;
using DomainChatGpt = SalesSupportTool.Domain.Models.ChatGptApi;
using System.Net.Http;
using SalesSupportTool.Infrastructure.ChatGPTApi.Models;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace SalesSupportTool.Infrastructure.ChatGPTApi
{
    public class ChatGptApiProvider : BaseProvider, IChatGptApiProvider
    {
        public const string CLIENT_NAME = "ChatGptApiClient";

        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ChatGptApiProvider(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClient = httpClientFactory.CreateClient(CLIENT_NAME);
        }

        public async Task<DomainChatGpt.CompletionsResponse> Completions(string prompt, string model = "gpt-4o")
        {
            Dictionary<string, string> headerParams = new();

            string postBody = $@"
            {{
                ""model"": ""{model}"",
                ""response_format"": {{ 
                    ""type"": ""json_object"" 
                }},
                ""messages"": [
                    {{
                        ""role"": ""system"",
                        ""content"": ""{prompt}""
                    }}
                ]
            }}";

            HttpResponseMessage response = await CallApiAsync(_httpClient, $"/chat/completions", HttpMethod.Post, postBody, null, headerParams);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = System.Text.Json.JsonSerializer.Deserialize<CompletionsResponse>(content);

            var mappedData = _mapper.Map<DomainChatGpt.CompletionsResponse>(data);

            return mappedData;
        }

        public async Task<object> CompanyReview(string companyName, string model = "gpt-4o")
        {
            string prompt = GetCompanyReviewPromptEncoded(companyName);

            DomainChatGpt.CompletionsResponse data = await Completions(prompt, model);

            return data.choices.FirstOrDefault().message.content;
        }

        private string GetCompanyReviewPromptEncoded(string companyName)
        {
            string prompt = $@"
You are a business consultant determining whether a company meets an Ideal Customer Profile, who its competitors are, and finding similar companies with a similar profile. 
Your task is to provide precise, factual, verifiable information only from the allowed sources. 
Allowed sources are the company's website, which should always be the primary source, online media outlets, www.apollo.io, www.statista.com, www.dnb.com, www.craft.com, official business registries, and Wikipedia. 
Cite the exact URL for each piece of information. If various reputable sources provide incompatible information, always give absolute priority to the company's website. 
If a piece of information cannot be found or verified, still provide a response based on your business consultant's expertise, but always add ""speculative"" as a source instead of the URL.
Whenever available, provide specific figures and quantitative data.
Fill out the following company profile JSON template, addressing each area in detail. Use names of properties and comments behind // to understand what's needed:
{{
  ""companyName"": """", 								//Company Name
  ""companyWebsite"": """", 							//Company URL
  ""companyOverview"": {{
    ""conciseDescription"": """", 						//Concise description of the company's primary products/services
    ""vertical"": """", 								//Vertical (SIC or NAICS code if available)
    ""keyIndustriesAndMarketDomainsServed"": [], 		//Key industries and market domains served as array of strings
    ""primaryProduct"": ""Services"", 					//Return either Goods or Services
    ""estimatedNumberOfSKUs"": 0, 					    //Estimated number of SKUs or null if not applicable
    ""typeOfProducts"": """", 							//Type of products: ""off-the-shelf"" or do they ""require specification""?
    ""mainCustomerSegments"": """", 					//Main customer segments ""other businesses (OEM, users)"", ""resellers"", ""consumers""
    ""sizeOfMarket"": """", 							//Size of the market as string - number of potential clients (less than 100, 101-1000, over 1000)
    ""yearFounded"": 0, 								//Year founded as integer
    ""complexRelationshipWithClients"": true 			//true, if it typically provides maintenance of its products, training or additional services otherwise false
  }},
  ""companySizeAndLocations"": {{
    ""totalNumberOfEmployees"": 0, 					    //Total number of employees - as integer
    ""estimatedTurnover"": """", 						//Estimated turnover
    ""geographicHeadquarters"": """", 					//Geographic headquarters - string in format ""City, Country""
    ""otherMajorOfficeLocationsOrFacilities"": [],	    //Other major office locations or facilities as array of strings
    ""countriesOfOperation"": [],						//Countries of Operation - as array of strings. List max 50 major/most developed countries in EU or USA
    ""targetMarkets"": []								//Target markets - as array of strings. If more than 50 use one entry with word ""Global""
  }},
  ""ownershipAndCorporateStructure"": {{
    ""privatelyOrPubliclyHeld"": """", 					//Privately or publicly held
    ""parentCompaniesSubsidiariesJointVentures"": {{	
      ""parent"": """",									//Name of the parent
      ""subsidiaries"": []							    //Names of the subsidiaries as array of strings
    }},												    //Parent companies, subsidiaries, joint ventures
    ""recentMergersAcquisitionsDivestitures"": """" 	//Recent mergers, acquisitions, divestitures
  }},
  ""financialPerformance"": {{
    ""EBIT"": """",										//EBIT (most recent fiscal year)
    ""revenueGrowthRate"": """",						//Revenue growth rate (1-year and 3-year CAGR)
    ""profitabilityMetrics"": """", 					//Profitability metrics (gross margin, operating margin, net income)
    ""stockPriceAndMarketCap"": """"					//Stock price and market cap (if publicly traded)
  }},
  ""significantRecentDevelopments"": {{				
    ""majorNewProductLaunchesOrMarketEntries"": [{{	
      ""description"": """",
      ""date"": null
    }}],												//Major new product launches or market entries [date when published in yyyy-MM-dd format] as array of objects
    ""largeCustomerWinsOrPartnerships"": [{{			
      ""description"": """",
      ""date"": null
    }}],												//Large customer wins or partnerships [show date when published in yyyy-MM-dd format] as array of objects
    ""executiveLeadershipChanges"": [{{
      ""description"": """",
      ""date"": null
	}}], 											    //Executive leadership changes [show date when published in yyyy-MM-dd format] as array of objects
    ""acquisitions"": [{{
      ""description"": """",
      ""date"": null
	}}],												//Acquisitions [show date when published in yyyy-MM-dd format] as array of objects
    ""fundingRoundsOrIPO"": [{{
      ""description"": """",
      ""date"": null
	}}],												//Funding rounds or IPO [show date when published in yyyy-MM-dd format] as array of objects
    ""recentEventParticipation"": [{{
      ""description"": """",
      ""date"": null
    }}],												//Recent event participation [show date when published in yyyy-MM-dd format] as array of objects
    ""mediaMentions"": [{{
      ""description"": """",
      ""date"": null
    }}]												    //Max 10 media mentions in the past 12 months [show date when published in yyyy-MM-dd format] as array of objects
  }},												    //Significant Recent Developments (within past 12 months)
  ""onlineSalesChannels"": {{
    ""doesItHaveAnOnlineCatalog"": false,				//Does it have an online catalog? as boolean - true or false
    ""doesItHaveAClientLoginZone"": true,				//Does it have a client login zone? as boolean - true or false
    ""doesItHaveAnEshop"": false						//Does it have an Eshop or some Ecommerce solution? as boolean - true or false
  }},
  ""competitors"": [
    {{
      ""name"": """",
      ""website"": """"
    }}
  ],												    //Top 10 competitors on the relevant market, list a company name and company website URL (starting with http) for each competitor - as array of objects
  ""similarCompanies"": [
    {{
      ""name"": """",
      ""website"": """"
    }}
  ]													    //Top 10 companies in the DACH region, which are not competitors, but have a similar company overview and size; list a company name and company website URL (starting with http) for each company - as array of objects
}}

Please provide the completed company profile in the specified JSON format for {companyName}";

            var encodedText = JsonEncodedText.Encode(prompt);

            return encodedText.Value;
        }

        public class ChatGptApiMappingProfile : Profile
        {
            public ChatGptApiMappingProfile()
            {
                this.CreateMap<CompletionsResponse, DomainChatGpt.CompletionsResponse>();
                this.CreateMap<Choice, DomainChatGpt.Choice>();
                this.CreateMap<Message, DomainChatGpt.Message>();
                this.CreateMap<Usage, DomainChatGpt.Usage>();
            }
        }
    }
}
