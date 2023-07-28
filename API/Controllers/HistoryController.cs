using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    public class HistoryController : Controller
    {
        private readonly HistoryRepository _historyRepository;
        public HistoryController(HistoryRepository historyRepository) => _historyRepository = historyRepository;
        
        [HttpGet]
        public async Task<IActionResult> GetByCompany(int id)
        {
            var response = await _historyRepository.GetAllByCompany(id);
            if (response.CodeStatus == CodeStatus.EntityNotFound)
            {
                return NotFound();
            }
            var json = JsonConvert.SerializeObject(response.Data);
            return Content(json, "application/json");
        }
    }
}
