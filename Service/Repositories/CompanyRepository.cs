using Domain.Enums;
using Domain.Response;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces.Repositories;

namespace Service.Repositories
{
    public class CompanyRepository : ICompanyRepository<Company>
    {
        private readonly CompanyContext _context;
        public CompanyRepository(CompanyContext context) { _context = context; }

        public async Task<BaseResponse<Company>> Get(int id)
        {
            var baseResponse = new BaseResponse<Company>();

            try
            {
                var company = await _context.Companies
                    .Include(c => c.Employees)
                    .Include(c => c.History)
                    .Include(c => c.Notes)
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (company == null)
                {
                    baseResponse.Description = "Нет такой компании, но это пока";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }

                baseResponse.Data = company!;
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Company>()
                {
                    Description = $"[Get failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<Company>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Company>>();

            try
            {
                var company = await _context.Companies.ToListAsync();
                if (company.Count == 0)
                {
                    baseResponse.Description = "Пусто";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }

                baseResponse.Data = company;
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Company>>()
                {
                    Description = $"[Get failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }
        }

        public async Task<BaseResponse<int>> Edit(Company entity)
        {
            var baseResponse = new BaseResponse<int>();

            try
            {
                var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == entity.Id);
                if (company == null)
                {
                    baseResponse.Description = "Нельзя изменить то, чего нет";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }

                _context.Update(entity);
                baseResponse.Data = await _context.SaveChangesAsync();
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>()
                {
                    Description = $"[Edit failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }
        }
    }
}
