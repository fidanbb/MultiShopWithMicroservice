using Microsoft.AspNetCore.Mvc;
using MultiShopWithMicroservice.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShopWithMicroservice.WebUI.Services.CargoServices.CompanyServices;

namespace MultiShopWithMicroservice.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class CargoCompanyController : Controller
    {
        private readonly ICargoCompanyService _companyService;

        public CargoCompanyController(ICargoCompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            CargoCompaniesViewbagList();
            var values = await _companyService.GetCargoCompanyAllAsync();
            return View(values);
        }

        public IActionResult CreateCompany()
        {
            CargoCompaniesViewbagList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CreateCargoCompanyDto createCompanyDto)
        {
            await _companyService.CreateCargoCompanyAsync(createCompanyDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateCompany(int id)
        {
            CargoCompaniesViewbagList();
            var values = await _companyService.GetByIdCargoCompanyAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCompany(UpdateCargoCompanyDto updateCompanyDto)
        {
            await _companyService.UpdateCargoCompanyAsync(updateCompanyDto);
            return RedirectToAction("Index");
        }

        void CargoCompaniesViewbagList()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Cargo Companies";
            ViewBag.v3 = "CompanyList";
            ViewBag.v0 = "Company Operations";
        }
    }
}
