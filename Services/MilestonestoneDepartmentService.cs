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
    public class MilestonestoneDepartmentService : BaseService, IMilestoneDepartmentrepository
    {
     
        public MilestonestoneDepartmentService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddMilestoneDepartment(MilestoneDepartment milestonedepartment)
        {
            try
            {
                await _context.MilestoneDepartment.AddAsync(milestonedepartment);
                await _context.SaveChangesAsync();
                var model =  milestonedepartment.Milestone_Department_ID;

                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = model
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

        public Task<Response<int>> DeleteMilestoneDepartment(int? milestonedepartmentID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<MilestoneDepartment>> GetMilestoneDepartmentById(int? milestonedepartmentID)
        {
            try
            {
                var model = await _context.MilestoneDepartment.Where(x => x.Milestone_Department_ID == milestonedepartmentID).FirstOrDefaultAsync();
                return new Response<MilestoneDepartment>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<MilestoneDepartment>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<MilestoneDepartment>>> GetMilestoneDepartments()
        {
            try
            {
                var model = await _context.MilestoneDepartment.ToListAsync();
                return new Response<List<MilestoneDepartment>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<MilestoneDepartment>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateMilestoneDepartment(MilestoneDepartment milestonedepartment)
        {
            throw new NotImplementedException();
        }
    }
}
