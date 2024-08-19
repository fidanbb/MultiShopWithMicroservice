using Microsoft.EntityFrameworkCore;
using MultiShopWithMicroservice.Cargo.DataAccessLayer.Abstract;
using MultiShopWithMicroservice.Cargo.DataAccessLayer.Concrete;
using MultiShopWithMicroservice.Cargo.DataAccessLayer.Repositories;
using MultiShopWithMicroservice.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _cargoContext = cargoContext;
        }

        public async Task<CargoCustomer> GetCargoCustomerByUserCustomerID(string userCustomerID)
        {
            var values = await _cargoContext.CargoCustomers.Where(x => x.UserCustomerId == userCustomerID).FirstOrDefaultAsync();
            return values;
        }
    }
}
