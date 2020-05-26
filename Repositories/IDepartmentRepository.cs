using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int? departmentId);
       
        Task<int> AddDepartment(Department department);
        Task<int> DeleteDepartment(int? departmentId);
        Task UpdateDepartment(Department department);
    }
}
