using IECFW.Common.Base;
namespace IECFW.Caching.Interfaces
{
    public interface IMemCacheServices<TData> : IBaseCacheServices<TData> where TData : BaseModel
    {
    }
}