using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _employeeRepository.Get(id);
            if (response.CodeStatus == CodeStatus.EntityNotFound)
            {
                return NotFound();
            }

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var response = await _employeeRepository.Edit(employee);
                if (response.CodeStatus == CodeStatus.EntityNotFound)
                    return NotFound();
                else if (response.CodeStatus == CodeStatus.OK)
                {
                    string refererUrl = Request.Headers["Referer"].ToString();
                    return Redirect(refererUrl);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeRepository.Create(employee);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _employeeRepository.Get(id);
            if (response.CodeStatus == CodeStatus.EntityNotFound)
            {
                return NotFound();
            }

            return Json(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetByCompany(int id)
        {
            var response = await _employeeRepository.GetAllByCompany(id);
            if (response.CodeStatus == CodeStatus.EntityNotFound)
            {
                return NotFound();
            }
            var json = JsonConvert.SerializeObject(response.Data);
            return Content(json, "application/json");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _employeeRepository.Delete(id);
            if (response.CodeStatus == CodeStatus.EntityNotFound)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
