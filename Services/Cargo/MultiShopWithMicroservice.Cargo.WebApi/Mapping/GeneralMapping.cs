using AutoMapper;
using MultiShopWithMicroservice.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShopWithMicroservice.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShopWithMicroservice.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShopWithMicroservice.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShopWithMicroservice.Cargo.EntityLayer.Concrete;

namespace MultiShopWithMicroservice.Cargo.WebApi.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            // CargoCompany
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();

            // CargoCustomer
            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();

            // CargoDetail
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();

            // CargoOperation
            CreateMap<CargoOperation, CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, UpdateCargoOperationDto>().ReverseMap();
        }
    }
}
