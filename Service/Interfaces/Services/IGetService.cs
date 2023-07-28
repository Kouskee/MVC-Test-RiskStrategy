using Domain.Response;

namespace Service.Interfaces.Services
{
    internal interface IGetService<T>
    {
        Task<BaseResponse<T>> Get(int id);
    }
}
