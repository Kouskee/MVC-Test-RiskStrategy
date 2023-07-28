using Domain.Response;

namespace Service.Interfaces.Services
{
    internal interface ICreateService<T>
    {
        Task<BaseResponse<int>> Create(T entity);
    }
}
