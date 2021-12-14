using IECFW.Caching.Interfaces;
using IECFW.Common.Base;

using IFW.Configrations;

using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IECFW.Caching.Services
{
    public class RedisCacheServices<TData> : IRedisCacheServices<TData> where TData : BaseModel
    {
        private IRedisClient client;
        private IRedisClient GetRedisClient()
        {
            client = new RedisClient(ConfigurationHelper.GetIFWAppConfiguration().RedisServer);
            return client;
        }
        public RedisCacheServices()
        {
            client = GetRedisClient();
        }
        public IEnumerable<TData> GetAll(string cacheKey)
        {
            return client.Get<IEnumerable<TData>>(cacheKey);
        }
        public TData GetSingle(string cacheKey)
        {
            return client.Get<TData>(cacheKey);
        }
        public void FillData(string cacheKey, IEnumerable<TData> data, DateTime? expiredDate = null)
        {
            if (client.GetAllKeys().Any(q => q == cacheKey))
                client.Remove(cacheKey);
            if (!expiredDate.HasValue)
                expiredDate = DateTime.Now.AddDays(1);

            client.Set(cacheKey, data, expiredDate.Value);
        }
        public void Remove(string cacheKey)
        {
            client.Remove(cacheKey);
        }
        public bool IsExsist(string cacheKey)
        {
            var AllKey = client.GetAllKeys();
            if (AllKey == null || AllKey.Count <= 0)
                return false;
            return AllKey.Exists(q => q == cacheKey);
        }
        public string GetCacheKey(string baseName)
        {
            return baseName + (DateTimeHelper.Now.GetDay() + 1).ToString();
        }
    }
}
