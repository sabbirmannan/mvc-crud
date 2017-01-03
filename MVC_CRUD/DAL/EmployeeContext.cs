using MVC_CRUD.Models;
using System.Data.Entity;

namespace MVC_CRUD.DAL
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("EmployeeDB")
        {

        }

        public DbSet<Employee> Employees { get; set; }

    }
}
