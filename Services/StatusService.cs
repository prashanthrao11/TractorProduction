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
    public class StatusService : IStatusRepository
    {
        private readonly APIContext _context;
        public StatusService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddStatus(Status status)
        {
            if (_context != null)
            {
                await _context.Status.AddAsync(status);
                await _context.SaveChangesAsync();
                return status.Status_ID;
            }
            return 0;
        }

        public Task<int> DeleteStatus(int? statusID)
        {
            throw new NotImplementedException();
        }

        public async Task<Status> GetStatusById(int? statusID)
        {
            if (_context != null)
            {
                return await _context.Status.Where(x => x.Status_ID == statusID).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<Status>> GetStatuss()
        {
            if (_context != null)
            {
                return await _context.Status.ToListAsync();
            }
            return null;
        }

        public Task UpdateStatus(Status status)
        {
            throw new NotImplementedException();
        }
    }
}
