using Domain.Response;

namespace Service.Interfaces.Services
{
    internal interface IEditService<T>
    {
        Task<BaseResponse<int>> Edit(T entity);
    }
}
