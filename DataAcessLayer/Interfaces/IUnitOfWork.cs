using DataAcessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Customer> Customers { get; }
        Task<int> SaveChangesAsync();
    }
}
