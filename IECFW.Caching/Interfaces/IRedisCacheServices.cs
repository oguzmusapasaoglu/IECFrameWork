using IECFW.Common.Base;

namespace IECFW.Caching.Interfaces
{
    public interface IRedisCacheServices<TData> : IBaseCacheServices<TData> where TData : BaseModel
    {
    }
}
