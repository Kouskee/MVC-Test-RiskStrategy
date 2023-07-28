using Domain.Response;

namespace Service.Interfaces.Services
{
    internal interface IDeleteSerivce
    {
        Task<BaseResponse<int>> Delete(int id);
    }
}
