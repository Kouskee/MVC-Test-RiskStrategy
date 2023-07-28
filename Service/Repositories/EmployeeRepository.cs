using Domain.Enums;
using Domain.Response;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces.Repositories;

namespace Service.Repositories
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        private readonly CompanyContext _context;

        public EmployeeRepository(CompanyContext context) { _context = context; }

        public async Task<BaseResponse<int>> Create(Employee entity)
        {
            var baseResponse = new BaseResponse<int>();

            try
            {
                _context.Employees.Add(entity);
                baseResponse.Data = await _context.SaveChangesAsync();
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>()
                {
                    Description = $"[Create failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }
        }

        public async Task<BaseResponse<Employee>> Get(int id)
        {
            var baseResponse = new BaseResponse<Employee>();

            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
                if (employee == null)
                {
                    baseResponse.Description = "Нет такого работника, но это пока";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }

                baseResponse.Data = employee!;
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Employee>()
                {
                    Description = $"[Get failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<Employee>>> GetAllByCompany(int id)
        {
            var baseResponse = new BaseResponse<IEnumerable<Employee>>();

            try
            {
                var employee = await _context.Employees.Where(e => e.CompanyId == id).ToListAsync();
                if (employee == null)
                {
                    baseResponse.Description = "Пусто";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }

                baseResponse.Data = employee!;
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Employee>>()
                {
                    Description = $"[Get failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }
        }

        public async Task<BaseResponse<int>> Edit(Employee entity)
        {
            var baseResponse = new BaseResponse<int>();

            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(g => g.Id == entity.Id);
                if (employee == null)
                {
                    baseResponse.Description = "Нельзя изменить то, чего нет";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }

                _context.Entry(entity).State = EntityState.Modified;
                baseResponse.Data = await _context.SaveChangesAsync();
                baseResponse.CodeStatus = CodeStatus.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<int>()
                {
                    Description = $"[Create failed] : {ex.Message}",
                    CodeStatus = CodeStatus.ServerError
                };
            }
        }

        public async Task<BaseResponse<int>> Delete(int id)
        {
            var baseResponse = new BaseResponse<int>();

            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
                if (employee == null)
                {
                    baseResponse.Description = "Нельзя удалить то, чего нет";
                    baseResponse.CodeStatus = CodeStatus.EntityNotFound;
                    return baseResponse;
                }
                _context.Employees.Remove(employee);
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
