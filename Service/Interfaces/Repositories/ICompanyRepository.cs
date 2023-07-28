using Service.Interfaces.Services;

namespace Service.Interfaces.Repositories
{
    internal interface ICompanyRepository<T> : IGetService<T>, IGetAllService<T>, IEditService<T>
    {
    }
}
