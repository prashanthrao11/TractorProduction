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
    public class ProductionMilestoneService : BaseService, IProductionMilestoneRepository
    {
       
        public ProductionMilestoneService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> UpdateProductionMilestone(ProductionMilestonesVM model)
        {
            try
            {
                int userId = _user.GetCurrentUser().User_ID;
                var prodList = await (from pm in _context.ProductionMilestone
                                      from md in _context.MilestoneDepartment.Where(x => x.Milestone_Department_ID == pm.Milestone_Department_ID)
                                      from wpm in _context.WorkflowPhaseMilestone.Where(x => x.Milestone_ID == md.Milestone_ID)
                                      from ph in _context.ProductPhase.Where(x => x.Product_Phase_ID == wpm.Phase_ID)
                                      from d in _context.Department.Where(x => x.Department_ID == md.Department_ID)
                                      from du in _context.DepartmentUsers.Where(x => x.Department_ID == d.Department_ID)
                                      where du.User_ID == userId && pm.Production_ID == model.Production_ID
                                      select pm).ToListAsync();
                foreach (var item in prodList)
                {
                    var localItem = model.ProductionMilestones.Where(x => x.ProdMilestoneItem.Milestone_Department_ID == item.Milestone_Department_ID).FirstOrDefault();
                    if (item.Comments != localItem.ProdMilestoneItem.Comments || item.Status_ID != localItem.ProdMilestoneItem.Status_ID)
                    {
                        item.Comments = localItem.ProdMilestoneItem.Comments;
                        item.Status_ID = localItem.ProdMilestoneItem.Status_ID;
                        item.Modified_By = _user.GetCurrentUser().User_Name;
                        item.Modified_Date = DateTime.Now;
                        if (localItem.ProdMilestoneItem.Status_ID == 1 && localItem.ProdMilestoneItem.ActualDate == null)
                        {
                            item.ActualDate = DateTime.Now;
                        }
                    }
                }
                var res = await _context.SaveChangesAsync();
                CheckAndUpdateStatus(model.Production_ID);
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = res
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
            var totalItems = _context.ProductionMilestone.Where(x => x.Is_Active == true && x.Production_ID == id && x.Status_ID==0).Count();
            if (totalItems == 0)
            {
                var production =  _context.Production.Where(x => x.Production_ID == id).First();
                production.Status_ID = _context.Status.Where(x => x.Status_Key == "AwaitingApproval").First().Status_ID;
                production.Modified_By = _user.GetCurrentUser().User_Name;
                production.Modified_Date = DateTime.Now;
                _context.SaveChanges();
            }
        }
        public async Task<Response<List<ProductionMilestoneVM>>> GetProductionMilestones(int productionId)
        {
            try
            {
                int userId = _user.GetCurrentUser().User_ID;
                var model = await (from pm in _context.ProductionMilestone
                              from md in _context.MilestoneDepartment.Where(x => x.Milestone_Department_ID == pm.Milestone_Department_ID)
                              from wpm in _context.WorkflowPhaseMilestone.Where(x => x.Milestone_ID == md.Milestone_ID)
                              from ph in _context.ProductPhase.Where(x => x.Product_Phase_ID == wpm.Phase_ID)
                              from d in _context.Department.Where(x => x.Department_ID == md.Department_ID)
                              from du in _context.DepartmentUsers.Where(x => x.Department_ID == d.Department_ID && x.User_ID == userId).DefaultIfEmpty()
                              where pm.Production_ID == productionId
                              select new ProductionMilestoneVM()
                              {
                                  MilestoneItem = new WorkflowPhaseMilestone()
                                  {
                                      Milestone_ID = wpm.Milestone_ID,
                                      Milestone_Name = wpm.Milestone_Name,
                                      Milestone_Desc = wpm.Milestone_Desc,
                                      Phase_ID = wpm.Phase_ID
                                  },
                                  PhaseItem = new ProductPhase()
                                  {
                                      Product_Phase_ID = ph.Product_Phase_ID,
                                      Phase_Name = ph.Phase_Name
                                  },
                                  ProdMilestoneItem = new ProductionMilestone()
                                  {
                                      P_Approval_ID = pm.P_Approval_ID,
                                      Milestone_Department_ID = pm.Milestone_Department_ID,
                                      Comments = pm.Comments,
                                      Status_ID = pm.Status_ID,
                                      Production_ID = pm.Production_ID,
                                      TargetDate = pm.TargetDate,
                                      ActualDate = pm.ActualDate,
                                      Is_Active = pm.Is_Active,
                                      Modified_By = pm.Modified_By,
                                      Modified_Date = pm.Modified_Date
                                  },
                                  DeptItem = new Department()
                                  {
                                      Department_ID = d.Department_ID,
                                      Department_Name = d.Department_Name
                                  },
                                  IsDepartmentUser = (du == null ? false : true)
                              }).OrderBy(x => x.MilestoneItem.Milestone_Name).ToListAsync();
                return new Response<List<ProductionMilestoneVM>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<ProductionMilestoneVM>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
