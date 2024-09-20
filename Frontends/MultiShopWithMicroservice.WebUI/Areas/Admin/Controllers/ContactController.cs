using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CatalogDtos.ContactDtos;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.CategoryServices;
using MultiShopWithMicroservice.WebUI.Services.CatalogServices.ContactServices;
using System.Drawing.Printing;
using System.Net.Http;
using X.PagedList.Extensions;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index(int page=1)
        {
            ContactViewbagList();
            var values = await _contactService.GetAllContactAsync();
            int pageSize = 5;
            var pagedValues = values.ToPagedList(page, pageSize);
            int pagedCount = (pageSize * (page - 1));
            ViewBag.PageSize = pagedCount;

            return View(pagedValues);
        }


        public async Task<IActionResult> ChangeIsRead(string id)
        {
           var value= await _contactService.ChangeIsReadAsync(id);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContactAsync(id);
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
