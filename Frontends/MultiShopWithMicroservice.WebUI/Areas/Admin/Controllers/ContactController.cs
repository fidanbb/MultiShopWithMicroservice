using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ContactDtos;
using System.Net.Http;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7070/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            ContactViewbagList();
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }


        public async Task<IActionResult> ChangeIsRead(string id)
        {
            await _client.GetAsync("contacts/ChangeIsRead/" + id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteContact(string id)
        {
            await _client.DeleteAsync("contacts?id=" + id);
            return RedirectToAction("Index");
        }

        void ContactViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Incoming Messages";
            ViewBag.v3 = "MessagesList";
            ViewBag.v0 = "Messages Operations";
        }

    }
}
