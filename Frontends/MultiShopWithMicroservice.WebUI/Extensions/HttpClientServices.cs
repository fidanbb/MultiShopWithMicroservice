using MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers;
using MultiShopWithMicroservice.WebUI.Handlers;
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
using MultiShopWithMicroservice.WebUI.Services.Interfaces;
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
        }
    }
}
