using BusinessLogicLayer.DTOs;
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
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerDTO> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = new Customer
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address
            };
           
                int id = await _unitOfWork.Customers.Add(customer);
                await _unitOfWork.SaveChangesAsync();
                return new CustomerDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email
                };
           
        }
    }
}
