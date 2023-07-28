using Domain.Enums;
using Domain.Response;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces.Repositories;

namespace Service.Repositories
{
    public class HistoryRepository : IHistoryRepository<CompanyOrder>
    {
        private readonly CompanyContext _context;

        public HistoryRepository(CompanyContext context) { _context = context; }

        public async Task<BaseResponse<IEnumerable<CompanyOrder>>> GetAllByCompany(int id)
        {
            var baseResponse = new BaseResponse<IEnumerable<CompanyOrder>>();

            try
            {
                var hisoty = await _context.History.Where(h => h.CompanyId == id).ToListAsync();
                if (hisoty == null)
                {
                    baseResponse.Description = "История пуста";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }

                baseResponse.Data = hisoty!;
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<CompanyOrder>>()
                {
                    Description = $"[Get failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }
        }
    }
}
