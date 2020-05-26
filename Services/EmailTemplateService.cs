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
    public class EmailTemplateService : IEmailTemplateRepository
    {
        private readonly APIContext _context;
        public EmailTemplateService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddEmailTemplate(EmailTemplate emailtemplate)
        {
            if (_context != null)
            {
                await _context.EmailTemplate.AddAsync(emailtemplate);
                await _context.SaveChangesAsync();
                return emailtemplate.Email_Template_ID;
            }
            return 0;
        }

        public Task<int> DeleteEmailTemplate(int? emailtemplateID)
        {
            throw new NotImplementedException();
        }

        public async Task<EmailTemplate> GetEmailTemplateById(int? emailtemplateId)
        {
            if (_context != null)
            {
                return await _context.EmailTemplate.Where(x => x.Email_Template_ID == emailtemplateId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<EmailTemplate>> GetEmailTemplates()
        {
            if (_context != null)
            {
                return await _context.EmailTemplate.ToListAsync();
            }
            return null;
        }

        public Task UpdateEmailTemplate(EmailTemplate emailtemplate)
        {
            throw new NotImplementedException();
        }
    }
}
