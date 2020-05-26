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
    public class LogDetailsService : ILogDetailsRepository
    {
        private readonly APIContext _context;
        public LogDetailsService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddLogDetails(LogDetails logdetails)
        {
            if (_context != null)
            {
                await _context.LogDetails.AddAsync(logdetails);
                await _context.SaveChangesAsync();
                return logdetails.Log_ID;
            }
            return 0;
        }

        public Task<int> DeleteLogDetails(int? logdetailsId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<LogDetails>> GetLogDetails()
        {
            if (_context != null)
            {
                return await _context.LogDetails.ToListAsync();
            }
            return null;
        }

        public async Task<LogDetails> GetLogDetailsById(int? logdetailsId)
        {
            if (_context != null)
            {
                return await _context.LogDetails.Where(x => x.Log_ID == logdetailsId).FirstOrDefaultAsync();
            }
            return null;
        }

        public Task UpdateLogDetails(LogDetails logdetails)
        {
            throw new NotImplementedException();
        }
    }
}
