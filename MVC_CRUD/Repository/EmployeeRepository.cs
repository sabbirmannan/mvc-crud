using MVC_CRUD.Abstract;
using MVC_CRUD.Models;

namespace MVC_CRUD.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {

    }

    public interface IEmployeeRepository : IRepository<Employee>
    { }
}
