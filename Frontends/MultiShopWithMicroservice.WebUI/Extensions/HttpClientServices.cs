using MultiShopWithMicroservice.WebUI.Handlers;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.CategoryServices;
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
        }
    }
}
