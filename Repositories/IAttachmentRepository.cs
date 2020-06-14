using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
    public interface IAttachmentRepository : IDisposable
    {
        public Task<Response<List<AttachmentHeader>>> GetAttachmentDocs(int productionId);
        public Task<Response<List<AttachmentHeader>>> GetProductionMilestoneAttachments(int prodMilestoneId);
        public Task<Response<AttachmentDoc>> UploadDoc(AttachmentDoc model);
        public Task<Response<List<AttachmentHeader>>> DeleteDoc(AttachmentHeader model);
    }
}
