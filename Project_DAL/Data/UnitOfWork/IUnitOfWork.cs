using Project_DAL.Data.Repositories;
using Project_DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DAL.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> CategoryRepo { get; }
        IRepository<Customer> CustomerRepo { get; }
        IRepository<Description> DescriptionRepo { get; }
        IRepository<Location> LocationRepo { get; }
        IRepository<LocationCustomer> LocationCustomerRepo { get; }
        IRepository<Preview> PreviewRepo { get; }
        int Save();
    }

}
