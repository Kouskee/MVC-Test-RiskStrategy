using Service.Interfaces.Services;

namespace Service.Interfaces.Repositories
{
    internal interface IEmployeeRepository<T>: ICreateService<T>, IGetService<T>, IGetAllByCompany<T>, IEditService<T>, IDeleteSerivce
    {
    }
}
