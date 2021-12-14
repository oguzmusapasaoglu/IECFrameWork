using IECFW.Common.Base;

using System;
using System.Collections.Generic;

namespace IECFW.Caching.Interfaces
{
    public interface IBaseCacheServices<TData> where TData : BaseModel
    {
        IEnumerable<TData> GetAll(string cacheKey);
        TData GetSingle(string cacheKey);
        void FillData(string cacheKey, IEnumerable<TData> data, DateTime? expiredDate = null);
        bool IsExsist(string cacheKey);
        void Remove(string cacheKey);
        string GetCacheKey(string baseName);
    }
}