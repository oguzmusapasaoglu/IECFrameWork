using IECFW.Caching.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using IECFW.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IECFW.Caching.Services
{
    public class MemCacheServices<TData> : IMemCacheServices<TData> where TData : BaseModel
    {
        IMemoryCache _cache;
        public MemCacheServices(IMemoryCache _memoryCache)
        {
            _cache = _memoryCache;
        }
        public void FillData(string cacheKey, IEnumerable<TData> data, DateTime? expiredDate = null)
        {
            if (_cache.Get(cacheKey).IsNullOrLessOrEqToZero())
                _cache.Remove(cacheKey);
            if (!expiredDate.HasValue)
                expiredDate = DateTime.Now.AddDays(1);

            _cache.Set(cacheKey, data, expiredDate.Value);
        }
        public IEnumerable<TData> GetAll(string cacheKey)
        {
            IEnumerable<TData> returnData;
            _cache.TryGetValue(cacheKey, out returnData);
            return returnData;
        }
        public TData GetSingle(string cacheKey)
        {
            IEnumerable<TData> returnData;
            _cache.TryGetValue(cacheKey, out returnData);
            return returnData.FirstOrDefault();
        }
        public void Remove(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }
        public bool IsExsist(string cacheKey)
        {
            return _cache.Get(cacheKey).IsNotNullOrEmpty();
        }
        public string GetCacheKey(string baseName)
        {
            return baseName + (DateTimeHelper.Now.GetDay() + 1).ToString();
        }
    }
}
