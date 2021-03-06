﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Data;
using TractorProduction.Web.Models;
using TractorProduction.Web.Repositories;
namespace TractorProduction.Web.Services
{
    public class ProductionApprovalsService : BaseService, IProductionApprovalRepository
    {
       
        public ProductionApprovalsService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> UpdateProductionApprovals(ProductionApprovalVM model)
        {
            try
            {
                var list = await _context.ProductionApproval.Where(x => x.Production_ID == model.Production_ID).ToListAsync();
                foreach (var item in model.Items)
                {
                    var dbItem = list.Where(x => x.P_D_Approval_ID == item.P_D_Approval_ID).FirstOrDefault();
                    dbItem.Action_Status_ID = item.Action_Status_ID;
                    dbItem.Action_Comments = item.Action_Comments;
                }
                var result = await _context.SaveChangesAsync();
                CheckAndUpdateStatus(model.Production_ID);
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = result
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
        private void CheckAndUpdateStatus(int id)
        {
            var totalItems = _context.ProductionApproval.Where(x => x.Is_Active == true && x.Production_ID == id && x.Action_Status_ID == 0).Count();
            if (totalItems == 0)
            {
                var production = _context.Production.Where(x => x.Production_ID == id).First();
                production.Status_ID = _context.Status.Where(x => x.Status_Key == "AwaitingFinalApproval").First().Status_ID;
                production.Modified_By = _user.GetCurrentUser().User_Name;
                production.Modified_Date = DateTime.Now;
                _context.SaveChanges();
            }
        }
        public async Task<Response<List<ProductionApproval>>> GetProductionUserApprovals(int productionId)
        {
            try
            {
                int userId = _user.GetCurrentUser().User_ID;
                var result = await (from pa in _context.ProductionApproval.Where(x => x.Production_ID == productionId)
                                    from d in _context.Department.Where(x => pa.Department_ID == x.Department_ID)
                                    from r in _context.Role.Where(x => x.Role_ID == pa.Role_ID)
                                    from du in _context.DepartmentUsers.Where(x => x.Department_ID == d.Department_ID && x.Is_Active == true)
                                    from ur in _context.UserRole.Where(x => x.User_ID == userId && pa.Role_ID == x.Role_ID)
                                    where du.User_ID == userId
                                    select new ProductionApproval()
                                    {
                                        P_D_Approval_ID = pa.P_D_Approval_ID,
                                        Production_ID = pa.Production_ID,
                                        Action_Comments = pa.Action_Comments,
                                        Action_Status_ID = pa.Action_Status_ID,
                                        Role_ID = pa.Role_ID,
                                        Department_ID = pa.Department_ID,
                                        DepartmentName = d.Department_Name,
                                        RoleName = r.Role_Name,
                                        Is_Active = pa.Is_Active,
                                        Modified_By = pa.Modified_By,
                                    }).ToListAsync();
                result.ForEach(x => {
                    if (x.Action_Status_ID == 0) x.Action_Status = "";
                    else if (x.Action_Status_ID == 1) x.Action_Status = "Approved"; else x.Action_Status = "Rejected";
                });

                return new Response<List<ProductionApproval>>()
                {
                    IsSuccess = true,
                    Model = result
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<ProductionApproval>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<Response<List<ProductionApproval>>> GetProductionApprovals(int productionId)
        {
            try
            {
                int userId = _user.GetCurrentUser().User_ID;
                var result = await (from pa in _context.ProductionApproval.Where(x => x.Production_ID == productionId)
                                    from d in _context.Department.Where(x => pa.Department_ID == x.Department_ID)
                                    from r in _context.Role.Where(x => x.Role_ID == pa.Role_ID)
                                    from du in _context.DepartmentUsers.Where(x => x.Department_ID == d.Department_ID && x.Is_Active == true)
                                    select new ProductionApproval()
                                    {
                                        P_D_Approval_ID = pa.P_D_Approval_ID,
                                        Production_ID = pa.Production_ID,
                                        Role_ID = pa.Role_ID,
                                        Department_ID = pa.Department_ID,
                                        DepartmentName = d.Department_Name,
                                        RoleName = r.Role_Name,
                                        Action_By = pa.Action_By,
                                        Action_Comments = pa.Action_Comments,
                                        Is_Active = pa.Is_Active,
                                        Action_Status_ID = pa.Action_Status_ID,
                                        Action_Date = pa.Action_Date,
                                        Modified_By = pa.Modified_By
                                    }).ToListAsync();
                result.ForEach(x => {
                    if (x.Action_Status_ID == 0) x.Action_Status = "";
                    else if (x.Action_Status_ID == 1) x.Action_Status = "Approved"; else x.Action_Status = "Rejected";
                });
                return new Response<List<ProductionApproval>>()
                {
                    IsSuccess = true,
                    Model = result
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<ProductionApproval>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
