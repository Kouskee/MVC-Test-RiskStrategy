using Domain.Response;

namespace Service.Interfaces.Services
{
    internal interface IGetAllByCompany<T>
    {
        Task<BaseResponse<IEnumerable<T>>> GetAllByCompany(int id);
    }
}
