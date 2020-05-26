using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
    public interface IAttachmentRepository
    {
        public Task<List<AttachmentHeader>> GetAttachmentDocs(int productionId);
        public Task<List<AttachmentHeader>> GetProductionMilestoneAttachments(int prodMilestoneId);
        public Task<AttachmentDoc> UploadDoc(AttachmentDoc model);
        public Task<List<AttachmentHeader>> DeleteDoc(AttachmentHeader model);
    }
}
