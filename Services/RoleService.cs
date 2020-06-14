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
    public class RoleService : BaseService, IRoleRepository
    {
      
        public RoleService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddRole(Models.Role role)
        {
            try
            {
                await _context.Role.AddAsync(role);
                await _context.SaveChangesAsync();
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = role.Role_ID
            };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<int>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<int>> DeleteRole(int? roleId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Role>> GetRoleById(int? roleId)
        {
            try
            {
                var model = await _context.Role.Where(x => x.Role_ID == roleId).FirstOrDefaultAsync();
                return new Response<Role>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<Role>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<Role>>> GetRoles()
        {
            try
            {
                var model= await _context.Role.ToListAsync();
                return new Response<List<Role>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<Role>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateRole(Models.Role role)
        {
            throw new NotImplementedException();
        }
    }
}
