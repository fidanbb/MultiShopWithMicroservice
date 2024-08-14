using MultiShopWithMicroservice.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShopWithMicroservice.Order.Application.Interfaces;
using MultiShopWithMicroservice.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                UserId = createAddressCommand.UserId,
                City = createAddressCommand.City,
                Country = createAddressCommand.Country,
                ZipCode = createAddressCommand.ZipCode,
                Description = createAddressCommand.Description,
                Detail1 = createAddressCommand.Detail1,
                Detail2 = createAddressCommand.Detail2,
                District = createAddressCommand.District,
                Name = createAddressCommand.Name,
                Surname = createAddressCommand.Surname,
                Email = createAddressCommand.Email,
                Phone = createAddressCommand.Phone,
                
            });
        }
    }
}
