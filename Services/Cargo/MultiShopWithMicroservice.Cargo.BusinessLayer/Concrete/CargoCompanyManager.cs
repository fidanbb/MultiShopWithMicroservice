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
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
        {
            _cargoCompanyDal = cargoCompanyDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoCompanyDal.DeleteAsync(id);
        }

        public async Task<List<CargoCompany>> TGetAllAsync()
        {
            return await _cargoCompanyDal.GetAllAsync();
        }

        public async Task<CargoCompany> TGetByIdAsync(int id)
        {
            return await _cargoCompanyDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(CargoCompany entity)
        {
            await _cargoCompanyDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(CargoCompany entity)
        {
            await _cargoCompanyDal.UpdateAsync(entity);
        }
    }
}
