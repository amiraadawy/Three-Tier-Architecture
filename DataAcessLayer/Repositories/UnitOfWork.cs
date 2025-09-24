using DataAcessLayer.Data;
using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IRepository<Customer> Customers { get; }
        public UnitOfWork(ApplicationDBContext context, IRepository<Customer> Customers)
        {
            _context = context;
            this.Customers = Customers;
        }
      

        public Task<int> SaveChangesAsync()
        {
          return   _context.SaveChangesAsync();
 
        }
    }
}
