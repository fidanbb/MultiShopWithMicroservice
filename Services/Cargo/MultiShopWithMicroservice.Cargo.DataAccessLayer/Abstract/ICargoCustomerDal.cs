﻿using MultiShopWithMicroservice.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShopWithMicroservice.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCustomerDal : IGenericDal<CargoCustomer>
    {
        Task<CargoCustomer> GetCargoCustomerByUserCustomerID(string userCustomerID);
    }
}
