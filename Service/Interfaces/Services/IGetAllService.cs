using Domain.Response;

namespace Service.Interfaces.Services
{
    internal interface IGetAllService<T>
    {
        Task<BaseResponse<IEnumerable<T>>> GetAll();
    }
}
