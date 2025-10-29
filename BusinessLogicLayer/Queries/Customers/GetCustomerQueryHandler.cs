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
        public Task<CustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _unitOfWork.Customers.GetCustomerById(request.id);
                if (customer == null)
                {
                    throw new Exception("Customer not found");
                }
                var customerDTO = new CustomerDTO
                {
                    Id = customer.Result.Id,
                    Name = customer.Result.Name,
                    Email = customer.Result.Email
                };

                return Task.FromResult(customerDTO);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
