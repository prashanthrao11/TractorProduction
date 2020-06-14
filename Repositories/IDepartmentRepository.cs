using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
    public interface IDepartmentRepository : IDisposable
    {
        Task<Response<List<Department>>> GetDepartments();
        Task<Response<Department>> GetDepartmentById(int? departmentId);
       
        Task<Response<int>> AddDepartment(Department department);
        Task<Response<int>> DeleteDepartment(int? departmentId);
        Task<Response<bool>> UpdateDepartment(Department department);
    }
}
