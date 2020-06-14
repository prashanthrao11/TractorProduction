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
    public class StatusTypeService : BaseService, IStatusTypeRepository
    {
      

        public StatusTypeService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddStatusType(StatusType statustype)
        {
            try
            {
                await _context.StatusType.AddAsync(statustype);
                await _context.SaveChangesAsync();
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = statustype.Status_Type_Id
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

        public Task<Response<int>> DeleteStatusType(int? statustypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<StatusType>> GetStatusTypeById(int? statustypeId)
        {
            try
            {
                var model= await _context.StatusType.Where(x => x.Status_Type_Id == statustypeId).FirstOrDefaultAsync();
                return new Response<StatusType>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<StatusType>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<StatusType>>> GetStatusTypes()
        {
            try
            {
                var model= await _context.StatusType.ToListAsync();
                return new Response<List<StatusType>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<StatusType>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateStatusType(StatusType statustype)
        {
            throw new NotImplementedException();
        }
    }
}
