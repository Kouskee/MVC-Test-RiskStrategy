using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class NoteController : Controller
    {
        private readonly NoteRepository _noteRepository;
        public NoteController(NoteRepository noteRepository) => _noteRepository = noteRepository;

        [HttpGet]
        public async Task<IActionResult> GetByCompany(int id)
        {
            var response = await _noteRepository.GetAllByCompany(id);
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
            var response = await _noteRepository.Delete(id);
            if (response.CodeStatus == CodeStatus.EntityNotFound)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
