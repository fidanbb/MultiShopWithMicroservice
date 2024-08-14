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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AddressId);

            values.Detail1 = command.Detail1;
            values.Detail2 = command.Detail2;
            values.Description = command.Description;
            values.Country = command.Country;
            values.District = command.District;
            values.City = command.City;
            values.UserId = command.UserId;
            values.Name = command.Name;
            values.Surname = command.Surname;
            values.Email = command.Email;
            values.Phone = command.Phone;
            values.ZipCode = command.ZipCode;

            await _repository.UpdateAsync(values);
        }
    }
}
