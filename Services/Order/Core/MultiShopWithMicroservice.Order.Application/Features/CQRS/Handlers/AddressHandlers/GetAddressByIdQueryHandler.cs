using MultiShopWithMicroservice.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShopWithMicroservice.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShopWithMicroservice.Order.Application.Interfaces;
using MultiShopWithMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;
        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail1 = values.Detail1,
                District = values.District,
                UserId = values.UserId,
                Detail2 = values.Detail2,
                Description = values.Description,
                Name = values.Name,
                Surname = values.Surname,
                Email = values.Email,
                Phone = values.Phone,
                ZipCode = values.ZipCode,
                Country = values.Country,
                
            };
        }
    }
}
