﻿using MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers;
using MultiShopWithMicroservice.WebUI.Handlers;
using MultiShopWithMicroservice.WebUI.Services.BasketServices;
using MultiShopWithMicroservice.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShopWithMicroservice.WebUI.Services.CargoServices.CompanyServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.AboutServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.BrandServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.CategoryServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ContactServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.FeatureServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.OfferDiscountServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ProductServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.SpecialOfferServices;
using MultiShopWithMicroservice.WebUI.Services.CommentServices;
using MultiShopWithMicroservice.WebUI.Services.Concrete;
using MultiShopWithMicroservice.WebUI.Services.DiscountServices;
using MultiShopWithMicroservice.WebUI.Services.Interfaces;
using MultiShopWithMicroservice.WebUI.Services.MesageServices;
using MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderDetailServices;
using MultiShopWithMicroservice.WebUI.Services.OrderServices.OrderOrderingServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.CatalogStatisticsServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.CommentStatisticsServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.DiscountStatisticsServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.MessageStatisticsServices;
using MultiShopWithMicroservice.WebUI.Services.StatisticsServices.UserStatisticsServices;
using MultiShopWithMicroservice.WebUI.Settings;

namespace MultiShopWithMicroservice.WebUI.Extensions
{
    public static class HttpClientServices
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
            services.AddHttpClient<IIdentityService, IdentityService>();
            var serviceApiSettings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            services.AddHttpClient<IUserService, UserService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.IdentityServerUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


            services.AddHttpClient<ICategoryService, CategoryService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl+serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductService, ProductService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IFeatureService, FeatureService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IBrandService, BrandService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IAboutService, AboutService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<ICommentService, CommentService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Comment.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IContactService, ContactService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IBasketService, BasketService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Basket.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IDiscountService, DiscountService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Discount.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IOrderAddressService, OrderAddressService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Order.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IOrderOrderingService, OrderOrderingService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Order.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IOrderDetailService, OrderDetailService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Order.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IMessageService, MessageService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Message.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICargoCompanyService, CargoCompanyService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Cargo.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
            {
                opt.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Cargo.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICatalogStatisticsService, CatalogStatisticsService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Catalog.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IUserStatisticsService, UserStatisticsService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.IdentityServerUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICommentStatisticsService, CommentStatisticsService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Comment.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IMessageStatisticsService, MessageStatisticsService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Message.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IDiscountStatisticsService, DiscountStatisticsService>(o =>
            {
                o.BaseAddress = new Uri(serviceApiSettings.OcelotUrl + serviceApiSettings.Discount.Path);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        }
    }
}
