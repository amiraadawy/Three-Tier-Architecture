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
    internal class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCustomersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var List = await _unitOfWork.Customers.GetCustomers();
            return List.Select(c => new CustomerDTO
            {
                Name = c.Name,
                Email = c.Email,
                Id = c.Id
            }
            );

        }
    }
}
