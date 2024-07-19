using System;
using System.Linq;

using Microsoft.Extensions.Hosting;

namespace SalesSupportTool.Common.Helpers
{
    public static class LoggingHelper
    {
        private static readonly Type? _currentBackgroundService;

        static LoggingHelper()
        {
            _currentBackgroundService = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t => t.IsSubclassOf(typeof(BackgroundService)))
                .FirstOrDefault();
        }

        public static Type? GetBackgroundServiceType()
        {
            return _currentBackgroundService;
        }

        public static string GetCallerPrefix()
        {
            string? caller = GetBackgroundServiceType()?.Name;

            if (caller != null)
            {
                caller += ": ";
            }
            else
            {
                caller = "";
            }

            return caller;
        }
    }
}