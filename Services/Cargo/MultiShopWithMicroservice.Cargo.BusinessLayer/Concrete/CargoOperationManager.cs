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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperationDal;

        public CargoOperationManager(ICargoOperationDal cargoOperationDal)
        {
            _cargoOperationDal = cargoOperationDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoOperationDal.DeleteAsync(id);
        }

        public async Task<List<CargoOperation>> TGetAllAsync()
        {
            return await _cargoOperationDal.GetAllAsync();
        }

        public async Task<CargoOperation> TGetByIdAsync(int id)
        {
            return await _cargoOperationDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(CargoOperation entity)
        {
            await _cargoOperationDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(CargoOperation entity)
        {
            await _cargoOperationDal.UpdateAsync(entity);
        }
    }
}
