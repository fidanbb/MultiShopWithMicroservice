using MultiShopWithMicroservice.Cargo.BusinessLayer.Abstract;
using MultiShopWithMicroservice.Cargo.DataAccessLayer.Abstract;
using MultiShopWithMicroservice.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomerDal = cargoCustomerDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoCustomerDal.DeleteAsync(id);
        }

        public async Task<List<CargoCustomer>> TGetAllAsync()
        {
            return await _cargoCustomerDal.GetAllAsync();
        }

        public async Task<CargoCustomer> TGetByIdAsync(int id)
        {
            return await _cargoCustomerDal.GetByIdAsync(id);
        }

        public async Task<CargoCustomer> TGetCargoCustomerByUserCustomerID(string userCustomerID)
        {
            return await _cargoCustomerDal.GetCargoCustomerByUserCustomerID(userCustomerID);
        }

        public async Task TInsertAsync(CargoCustomer entity)
        {
            await _cargoCustomerDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(CargoCustomer entity)
        {
            await _cargoCustomerDal.UpdateAsync(entity);
        }
    }
}
