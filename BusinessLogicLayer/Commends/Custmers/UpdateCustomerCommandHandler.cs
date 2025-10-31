using DataAcessLayer.Entities;
using DataAcessLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Commends.Custmers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
           Customer customer=new Customer 
           {
               Id = request.Id,
               Name = request.Name,
               Email = request.Email,
               Phone = request.Phone,
               Address = request.Address
           };
            _unitOfWork.Customers.UpdateCustomer(customer);
           return await  _unitOfWork.SaveChangesAsync()>0;
        }
    }
}
