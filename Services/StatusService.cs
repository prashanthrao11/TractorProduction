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
    public class StatusService : BaseService, IStatusRepository
    {
       

        public StatusService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddStatus(Status status)
        {
            try
            {
                await _context.Status.AddAsync(status);
                await _context.SaveChangesAsync();
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = status.Status_ID
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

        public Task<Response<int>> DeleteStatus(int? statusID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Status>> GetStatusById(int? statusID)
        {
            try
            { 
                var model = await _context.Status.Where(x => x.Status_ID == statusID).FirstOrDefaultAsync();
                return new Response<Status>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<Status>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<Status>>> GetStatuss()
        {
            try
            {
                var model = await _context.Status.ToListAsync();
                return new Response<List<Status>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<Status>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateStatus(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
