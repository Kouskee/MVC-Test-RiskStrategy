using Domain.Enums;
using Domain.Response;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces.Repositories;

namespace Service.Repositories
{
    public class NoteRepository : INoteRepository<CompanyNote>
    {
        private readonly CompanyContext _context;

        public NoteRepository(CompanyContext context) { _context = context; }

        public async Task<BaseResponse<IEnumerable<CompanyNote>>> GetAllByCompany(int id)
        {

            var baseResponse = new BaseResponse<IEnumerable<CompanyNote>>();

            try
            {
                var note = await _context.Notes.Where(n => n.CompanyId == id).ToListAsync();
                if (note == null)
                {
                    baseResponse.Description = "Записей нет";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }

                baseResponse.Data = note!;
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<CompanyNote>>()
                {
                    Description = $"[Get failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }

        }

        public async Task<BaseResponse<int>> Delete(int id)
        {
            var baseResponse = new BaseResponse<int>();

            try
            {
                var note = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
                if (note == null)
                {
                    baseResponse.Description = "Нельзя удалить то, чего нет";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }
                _context.Notes.Remove(note);
                baseResponse.Data = await _context.SaveChangesAsync();
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>()
                {
                    Description = $"[Delete failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }
        }
    }
}
