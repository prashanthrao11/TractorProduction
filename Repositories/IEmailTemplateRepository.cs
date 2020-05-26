using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
   public interface IEmailTemplateRepository
    {
        Task<List<EmailTemplate>> GetEmailTemplates();
        Task<EmailTemplate> GetEmailTemplateById(int? emailtemplateId);
      
        Task<int> AddEmailTemplate(EmailTemplate emailtemplate);
        Task<int> DeleteEmailTemplate(int? emailtemplateID);
        Task UpdateEmailTemplate(EmailTemplate emailtemplate);
    }
}
