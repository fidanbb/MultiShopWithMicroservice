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
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext context) : base(context)
        {
        }
    }
}
