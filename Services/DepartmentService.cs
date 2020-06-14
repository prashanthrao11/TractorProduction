using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Data;
using TractorProduction.Web.Models;
using TractorProduction.Web.Repositories;

namespace TractorProduction.Web.Services
{
    public class DepartmentService : BaseService, IDepartmentRepository
    {
     
        public DepartmentService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public Task<Response<int>> AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> DeleteDepartment(int? departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Department>> GetDepartmentById(int? departmentId)
        {
            try
            {
                var model = await _context.Department.Where(x => x.Department_ID == departmentId).FirstOrDefaultAsync();
                return new Response<Department>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<Department>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<Department>>> GetDepartments()
        {
            try
            {
                var model = await _context.Department.ToListAsync();
                return new Response<List<Department>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<Department>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
