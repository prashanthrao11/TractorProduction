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
    public class EmailTemplateService : BaseService, IEmailTemplateRepository
    {
     
        public EmailTemplateService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddEmailTemplate(EmailTemplate emailtemplate)
        {
            try
            {
                await _context.EmailTemplate.AddAsync(emailtemplate);
                await _context.SaveChangesAsync();
                var model = emailtemplate.Email_Template_ID;
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

        public Task<Response<int>> DeleteEmailTemplate(int? emailtemplateID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<EmailTemplate>> GetEmailTemplateById(int? emailtemplateId)
        {
            try
            {
                var model = await _context.EmailTemplate.Where(x => x.Email_Template_ID == emailtemplateId).FirstOrDefaultAsync();
                return new Response<EmailTemplate>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<EmailTemplate>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<EmailTemplate>>> GetEmailTemplates()
        {
            try
            {
                var model = await _context.EmailTemplate.ToListAsync();
                return new Response<List<EmailTemplate>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<EmailTemplate>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateEmailTemplate(EmailTemplate emailtemplate)
        {
            throw new NotImplementedException();
        }
    }
}
