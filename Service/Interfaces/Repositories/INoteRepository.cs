using Service.Interfaces.Services;

namespace Service.Interfaces.Repositories
{
    internal interface INoteRepository<T> : IGetAllByCompany<T>, IDeleteSerivce
    {
    }
}
