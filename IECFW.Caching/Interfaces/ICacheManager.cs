using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using IECFW.Common.Base;

namespace IECFW.Caching.Interfaces
{
    public interface ICacheManager<TModel> where TModel : BaseModel
    {
        string GetCacheKey(string baseName = "");
        IEnumerable<TModel> GetDataByFilter(Expression<Func<TModel, bool>> predicate);
        TModel GetSingleDataByFilter(Expression<Func<TModel, bool>> predicate);
        void FillData();
        void AddBulkData(IEnumerable<TModel> data);
        void AddSingleData(TModel data);
        void RemoveData(TModel data);
    }
}
