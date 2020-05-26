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
    public class MilestonestoneDepartmentService : IMilestoneDepartmentrepository
    {
        private readonly APIContext _context;
        public MilestonestoneDepartmentService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddMilestoneDepartment(MilestoneDepartment milestonedepartment)
        {
            if (_context != null)
            {
                await _context.MilestoneDepartment.AddAsync(milestonedepartment);
                await _context.SaveChangesAsync();
                return milestonedepartment.Milestone_Department_ID;
            }
            return 0;
        }

        public Task<int> DeleteMilestoneDepartment(int? milestonedepartmentID)
        {
            throw new NotImplementedException();
        }

        public async Task<MilestoneDepartment> GetMilestoneDepartmentById(int? milestonedepartmentID)
        {
            if (_context != null)
            {
                return await _context.MilestoneDepartment.Where(x => x.Milestone_Department_ID == milestonedepartmentID).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<MilestoneDepartment>> GetMilestoneDepartments()
        {
            if (_context != null)
            {
                return await _context.MilestoneDepartment.ToListAsync();
            }
            return null;
        }

        public Task UpdateMilestoneDepartment(MilestoneDepartment milestonedepartment)
        {
            throw new NotImplementedException();
        }
    }
}
