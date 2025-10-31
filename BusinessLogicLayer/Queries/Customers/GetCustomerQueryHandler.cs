using BusinessLogicLayer.DTOs;
using DataAcessLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Queries.Customers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCustomerQueryHandler(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
           
                var customer =await _unitOfWork.Customers.GetById(request.id);
                if (customer == null)
                {
                    throw new KeyNotFoundException("Customer not found");
                }
                var customerDTO = new CustomerDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    Email = customer.Email
                };

                return customerDTO;

           
        }
    }
}
