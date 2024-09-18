using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShopWithMicroservice.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "Home";
            ViewBag.directory2 = "Contact";
            ViewBag.directory3 = "Contact Us";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7070/api/");
            createContactDto.SendDate = DateTime.Now;
            createContactDto.IsRead = false;
            await client.PostAsJsonAsync("contacts", createContactDto);
            return RedirectToAction("Index");
        }
    }
}
