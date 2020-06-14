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
    public class AttachmentService : BaseService,IAttachmentRepository
    {  
        public AttachmentService(APIContext context,ILogDetailsRepository log,IUserRepository user) : base(context, log, user)
        {
           
        }
      
        public async Task<Response<List<AttachmentHeader>>> DeleteDoc(AttachmentHeader model)
        {
            try
            {
                model.Is_Active = false;
                _context.Update(model);
                await _context.SaveChangesAsync();
                var items = await _context.AttachmentHeader.Where(x => x.Attachment_Ref_ID == model.Attachment_Ref_ID && x.Is_Active == true).ToListAsync();
                return new Response<List<AttachmentHeader>>()
                {
                    IsSuccess = true,
                    Model = items
                };
            }
            catch(Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<AttachmentHeader>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<AttachmentHeader>>> GetAttachmentDocs(int productionId)
        {
            try
            {
                var model = await _context.AttachmentHeader.Where(x => x.Attachment_Ref_ID == productionId).ToListAsync();
                return new Response<List<AttachmentHeader>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch(Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<AttachmentHeader>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<AttachmentHeader>>> GetProductionMilestoneAttachments(int prodMilestoneId)
        {
            try
            {
                var model = await _context.AttachmentHeader.Where(x => x.Attachment_Ref_ID == prodMilestoneId && x.Is_Active == true).ToListAsync();
                return new Response<List<AttachmentHeader>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<AttachmentHeader>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<AttachmentDoc>> UploadDoc(AttachmentDoc model)
        {
            try
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

                return new Response<AttachmentDoc>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<AttachmentDoc>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
