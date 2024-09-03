using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShopWithMicroservice.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //id = "66bb822f6f3ab271bf61ee23";
            var client = _httpClientFactory.CreateClient();

         

            if (id == null)
            {
               var responseMessage = await client.GetAsync("https://localhost:7070/api/Products");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                    return View(values);
                }
            }
            else
            {
                var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategoryByCategoryId?id=" + id);
                 
                var responseMessage2= await client.GetAsync("https://localhost:7070/api/Categories/" + id);
                
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultCategoryDto>(jsonData2);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                    ViewBag.ct = values.Count > 0 ? "Products in " + values2.CategoryName + " Category" : values2.CategoryName + " Category dont'have any product yet.";
                    return View(values);
                }
            }

           
            return View();
        }
    }
}
