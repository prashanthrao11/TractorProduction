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
    public class AttachmentService : IAttachmentRepository
    {
        private readonly APIContext _context;
        public AttachmentService(APIContext context)
        {
            _context = context;
        }
        public async Task<List<AttachmentHeader>> DeleteDoc(AttachmentHeader model)
        {
            model.Is_Active = false;
            _context.Update(model);
            await _context.SaveChangesAsync();
            return await _context.AttachmentHeader.Where(x => x.Attachment_Ref_ID == model.Attachment_Ref_ID && x.Is_Active == true).ToListAsync();
        }

        public async Task<List<AttachmentHeader>> GetAttachmentDocs(int productionId)
        {
            if (_context != null)
            {
                return await _context.AttachmentHeader.Where(x => x.Attachment_Ref_ID == productionId).ToListAsync();
            }
            return null;
        }

        public async Task<List<AttachmentHeader>> GetProductionMilestoneAttachments(int prodMilestoneId)
        {
            if (_context != null)
            {
                return await _context.AttachmentHeader.Where(x => x.Attachment_Ref_ID == prodMilestoneId && x.Is_Active==true).ToListAsync();
            }
            return null;
        }

        public async Task<AttachmentDoc> UploadDoc(AttachmentDoc model)
        {
            if (_context != null)
            {
                AttachmentHeader header = new AttachmentHeader();
                header = model.AttachmentHeaderItem;
                header.Is_Active = true;
                _context.AttachmentHeader.Add(header);
                await _context.SaveChangesAsync();

                AttachmentDetails details = new AttachmentDetails();
                details = model.AttachmentDetailsItem;
                details.Is_Active = true;
                details.Attachment_Header_ID = header.Attachment_Header_ID;

                _context.AttachmentDetails.Add(details);
                await _context.SaveChangesAsync();

            }
            return model;
        }
    }
}
