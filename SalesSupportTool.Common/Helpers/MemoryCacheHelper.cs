using Microsoft.Extensions.Caching.Memory;

namespace SalesSupportTool.Common.Helpers
{
    /// <summary>
    /// Helper class for working with Memory Cache.
    /// </summary>
    public static class MemoryCacheHelper
    {
        public const string CACHE_PREFIX = "MemoryCache.";

        public const int CACHE_TIME_MINS = 10;

        /// <summary>
        /// Enum of supported CacheTypes.
        /// </summary>
        public enum CacheTypeEnum
        {
            MemoryCache
        }

        /// <summary>
        /// Builds a CacheKey based on various input parameters. 
        /// </summary>
        /// <param name="cacheName"></param>
        /// <param name="inputValues"></param>
        /// <returns>Cache key.</returns>
        public static string BuildCacheKey(string cacheName, params object[] inputValues)
        {
            return $"{CACHE_PREFIX}{cacheName}({String.Join(",", inputValues)})";
        }

        /// <summary>
        /// Builds a CacheKey based on various input parameters. 
        /// </summary>
        /// <param name="cacheType"></param>
        /// <param name="inputValues"></param>
        /// <returns>Cache key.</returns>
        public static string BuildCacheKey(CacheTypeEnum cacheType, params object[] inputValues)
        {
            string cacheName = Enum.GetName(typeof(CacheTypeEnum), cacheType);

            return BuildCacheKey(cacheName, inputValues);
        }

        /// <summary>
        /// Finds and returns all CacheKeys, which contain the query (case insensitive). 
        /// </summary>
        /// <param name="memCache"></param>
        /// <param name="query"></param>
        /// <returns>List of Cache Keys.</returns>
        public static List<string> FindCacheKeys(this IMemoryCache memCache, string query)
        {
            var cacheEntries = GetCacheKeys(memCache);

            if (cacheEntries != null)
            {
                var data = cacheEntries
                    .Where(key => key.Contains(query, StringComparison.InvariantCultureIgnoreCase))
                    .ToList();

                return data;
            }

            return new List<string>();
        }


        /// <summary>
        /// Finds and returns all CacheKeys of specific CacheType, which contain the query (case insensitive). 
        /// </summary>
        /// <param name="memCache"></param>
        /// <param name="cacheType">Type of Cache.</param>
        /// <param name="query"></param>
        /// <returns>List of Cache Keys from the cache.</returns>
        public static List<string> FindCacheKeys(this IMemoryCache memCache, CacheTypeEnum cacheType, string query = "")
        {
            string cacheName = Enum.GetName(typeof(CacheTypeEnum), cacheType);
            cacheName = $"{CACHE_PREFIX}{cacheName}(";

            var cacheEntries = GetCacheKeys(memCache);

            if (cacheEntries != null)
            {
                var data = cacheEntries
                    .Where(key =>
                    {
                        bool include = key.Contains(cacheName, StringComparison.InvariantCultureIgnoreCase);

                        if (!string.IsNullOrWhiteSpace(query))
                        {
                            include &= key.Contains(query, StringComparison.InvariantCultureIgnoreCase);
                        }

                        return include;
                    })
                    .ToList();

                return data;
            }

            return new List<string>();
        }

        /// <summary>
        /// Gets CacheKeys.
        /// </summary>
        /// <param name="memCache"></param>
        /// <returns>List of cache keys stored in the cache.</returns>
        public static List<string> GetCacheKeys(this IMemoryCache memCache)
        {
            var cacheEntries = GetCacheEntries(memCache);

            if (cacheEntries != null)
            {
                var data = cacheEntries.Select(i => i.Key.ToString()).ToList();

                return data;
            }

            return new List<string>();
        }

        /// <summary>
        /// Get all Cache Entries from the cache. <see cref="https://stackoverflow.com/questions/45597057/how-to-retrieve-a-list-of-memory-cache-keys-in-asp-net-core"/>
        /// </summary>
        /// <param name="memCache"></param>
        /// <returns>List of ICacheEntiry objects.</returns>
        public static List<ICacheEntry> GetCacheEntries(this IMemoryCache memCache)
        {
            // 2022-12-06
            // Updated to work with both .Net7 and previous versions.  Code can handle either version as-is.  
            // Remove code as needed for version you are not using if desired.

            // Define the collection object for scoping.  It is created as a dynamic object since the collection
            // method returns as an object array which cannot be used in a foreach loop to generate the list.
            dynamic cacheEntriesCollection = null;

            // This action creates an empty definitions container as defined by the class type.  
            // Pull the _coherentState field for .Net version 7 or higher.  Pull the EntriesCollection 
            // property for .Net version 6 or lower.    Both of these objects are defined as private, 
            // so we need to use Reflection to gain access to the non-public entities.  
            var cacheEntriesFieldCollectionDefinition = typeof(MemoryCache).GetField("_coherentState", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesPropertyCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);


            // .Net 6 or lower.  
            // In these versions of .Net, the EntriesCollection is a direct property of the MemoryCache type
            // definition, so we can populate our cacheEntriesCollection with the definition from Relection
            // and the values from our MemoryCache instance.
            if (cacheEntriesPropertyCollectionDefinition != null)
            {
                cacheEntriesCollection = cacheEntriesPropertyCollectionDefinition.GetValue(memCache);
            }

            // .Net 7 or higher.
            // Starting with .Net 7.0, the EntriesCollection object was moved to being a child object of
            // the _coherentState field under the MemoryCache type.  Same process as before with an extra step.
            // Populate the coherentState field variable with the definition from above using the data in
            // our MemoryCache instance.  Then use Reflection to gain access to the private property EntriesCollection.
            if (cacheEntriesFieldCollectionDefinition != null)
            {
                var coherentStateValueCollection = cacheEntriesFieldCollectionDefinition.GetValue(memCache);
                var entriesCollectionValueCollection = coherentStateValueCollection.GetType().GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                cacheEntriesCollection = entriesCollectionValueCollection.GetValue(coherentStateValueCollection);
            }

            // Define a new list we'll be adding the cache entries to
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                // Get the "Value" from the key/value pair which contains the cache entry   
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);

                // Add the cache entry to the list
                cacheCollectionValues.Add(cacheItemValue);
            }

            return cacheCollectionValues;
        }

        /// <summary>
        /// Removes CacheKeys by cache type and/or query (case insensitive)
        /// </summary>
        /// <param name="memCache"></param>
        /// <param name="cacheType"></param>
        /// <param name="query"></param>
        public static void RemoveKeys(this IMemoryCache memCache, CacheTypeEnum cacheType, string query = "")
        {
            var keysToRemove = FindCacheKeys(memCache, cacheType, query);

            keysToRemove.ForEach(key => memCache.Remove(key));
        }
    }
}