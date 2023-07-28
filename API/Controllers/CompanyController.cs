using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyRepository _companyRepository;
        public CompanyController(CompanyRepository companyRepository) => _companyRepository = companyRepository;

        [HttpGet]
        public IActionResult Index()
        {
            return View("Companies");
        }

        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var response = await _companyRepository.GetAll();
            var json = JsonConvert.SerializeObject(response.Data);
            return Content(json, "application/json");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _companyRepository.Get(id);
            return View("CompanyDetails", response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Company entity)
        {
            if (ModelState.IsValid)
            {
                var response = await _companyRepository.Edit(entity);
                if (response.CodeStatus == CodeStatus.EntityNotFound)
                    return NotFound();
                else if (response.CodeStatus == CodeStatus.OK)
                    return View("Companies");
            }
            return BadRequest(ModelState);
        }
    }
}
