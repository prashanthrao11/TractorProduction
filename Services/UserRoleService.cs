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
    public class UserRoleService : BaseService, IUserRoleRepository
    {
      

        public UserRoleService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public Task<Response<int>> AddUserRole(UserRole userrole)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> DeleteUserRole(int? userroleID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserRole>> GetUserRoleById(int? userroleID)
        {
            try
            {
                var model= await _context.UserRole.Where(x => x.User_Role_ID == userroleID).FirstOrDefaultAsync();
                return new Response<UserRole>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<UserRole>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<UserRole>>> GetUserRoles()
        {
            try
            {
                var model = await _context.UserRole.ToListAsync();
                return new Response<List<UserRole>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<UserRole>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateUserRole(UserRole userrole)
        {
            throw new NotImplementedException();
        }
    }
}
