using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
   public interface IEmailTemplateRepository : IDisposable
    {
        Task<Response<List<EmailTemplate>>> GetEmailTemplates();
        Task<Response<EmailTemplate>> GetEmailTemplateById(int? emailtemplateId);
      
        Task<Response<int>> AddEmailTemplate(EmailTemplate emailtemplate);
        Task<Response<int>> DeleteEmailTemplate(int? emailtemplateID);
        Task<Response<bool>> UpdateEmailTemplate(EmailTemplate emailtemplate);
    }
}
