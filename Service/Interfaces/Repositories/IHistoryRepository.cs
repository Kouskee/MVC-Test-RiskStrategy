using Service.Interfaces.Services;

namespace Service.Interfaces.Repositories
{
    internal interface IHistoryRepository<T>: IGetAllByCompany<T>
    {
    }
}
