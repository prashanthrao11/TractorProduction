using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Data;
using TractorProduction.Web.Repositories;

namespace TractorProduction.Web.Services
{
    public class RoleService : IRoleRepository
    {
        private readonly APIContext _context;
        public RoleService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddRole(Models.Role role)
        {
            if (_context != null)
            {
                await _context.Role.AddAsync(role);
                await _context.SaveChangesAsync();
                return role.Role_ID;
            }
            return 0;
        }

        public Task<int> DeleteRole(int? roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.Role> GetRoleById(int? roleId)
        {
            if (_context != null)
            {
                return await _context.Role.Where(x => x.Role_ID == roleId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<Models.Role>> GetRoles()
        {
            if (_context != null)
            {
                return await _context.Role.ToListAsync();
            }
            return null;
        }

        public Task UpdateRole(Models.Role role)
        {
            throw new NotImplementedException();
        }
    }
}
