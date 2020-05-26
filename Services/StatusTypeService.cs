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
    public class StatusTypeService : IStatusTypeRepository
    {
        private readonly APIContext _context;
        public StatusTypeService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddStatusType(StatusType statustype)
        {
            if (_context != null)
            {
                await _context.StatusType.AddAsync(statustype);
                await _context.SaveChangesAsync();
                return statustype.Status_Type_Id;
            }
            return 0;
        }

        public Task<int> DeleteStatusType(int? statustypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<StatusType> GetStatusTypeById(int? statustypeId)
        {
            if (_context != null)
            {
                return await _context.StatusType.Where(x => x.Status_Type_Id == statustypeId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<StatusType>> GetStatusTypes()
        {
            if (_context != null)
            {
                return await _context.StatusType.ToListAsync();
            }
            return null;
        }

        public Task UpdateStatusType(StatusType statustype)
        {
            throw new NotImplementedException();
        }
    }
}
