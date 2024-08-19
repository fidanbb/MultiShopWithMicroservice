﻿using MultiShopWithMicroservice.Cargo.BusinessLayer.Abstract;
using MultiShopWithMicroservice.Cargo.DataAccessLayer.Abstract;
using MultiShopWithMicroservice.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.Cargo.BusinessLayer.Concrete
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoDetailDal.DeleteAsync(id);
        }

        public async Task<List<CargoDetail>> TGetAllAsync()
        {
            return await _cargoDetailDal.GetAllAsync();
        }

        public async Task<CargoDetail> TGetByIdAsync(int id)
        {
            return await _cargoDetailDal.GetByIdAsync(id);
        }

        public async Task TInsertAsync(CargoDetail entity)
        {
            await _cargoDetailDal.InsertAsync(entity);
        }

        public async Task TUpdateAsync(CargoDetail entity)
        {
            await _cargoDetailDal.UpdateAsync(entity);
        }
    }
}
