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
    public class DepartmentService : IDepartmentRepository
    {
        private readonly APIContext _context;
        public DepartmentService(APIContext context)
        {
            _context = context;
        }
        public Task<int> AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteDepartment(int? departmentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Department> GetDepartmentById(int? departmentId)
        {
            if (_context != null)
            {
                return await _context.Department.Where(x => x.Department_ID == departmentId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<Department>> GetDepartments()
        {
            if (_context != null)
            {
                return await _context.Department.ToListAsync();
            }
            return null;
        }

        public Task UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
