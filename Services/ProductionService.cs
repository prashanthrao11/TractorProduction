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
    public class ProductionService : BaseService, IProductionRepository
    {
       
        public ProductionService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddProduction(Production production)
        {
            try
            {
                if (production.Production_ID != 0)
                {
                    var productionDBItem = _context.Production.Find(production.Production_ID);
                    productionDBItem.Tractor_Part_Number = production.Tractor_Part_Number;
                    productionDBItem.Tractor_SAP_Series = production.Tractor_SAP_Series;
                    productionDBItem.Is_Change_Tractor = production.Is_Change_Tractor;
                    productionDBItem.Tractor_Series = production.Tractor_Series;
                    productionDBItem.Engine_Part_Number = production.Engine_Part_Number;
                    productionDBItem.Engine_Series = production.Engine_Series;
                    productionDBItem.Engine_SAP_Series = production.Engine_SAP_Series;
                    productionDBItem.Is_Change_Engine = production.Is_Change_Engine;
                    productionDBItem.Hydraulics_Part_Number = production.Hydraulics_Part_Number;
                    productionDBItem.Hydraulics_SAP_Series = production.Hydraulics_SAP_Series;
                    productionDBItem.Hydraulics_Series = production.Hydraulics_Series;
                    productionDBItem.Is_Change_Hydraulics = production.Is_Change_Hydraulics;
                    productionDBItem.Transmission_Part_Number = production.Transmission_Part_Number;
                    productionDBItem.Transmission_SAP_Series = production.Transmission_SAP_Series;
                    productionDBItem.Transmission_Series = production.Transmission_Series;
                    productionDBItem.Is_Change_Transmission = production.Is_Change_Transmission;
                    production.Modified_By = _user.GetCurrentUser().User_Name;
                    production.Modified_Date = DateTime.Now;
                    await _context.SaveChangesAsync();

                    //Raw
                }
                else
                {
                    production.Status_ID = _context.Status.Where(x => x.Status_Key == "ProcessInitiated").First().Status_ID;
                    production.Created_By = _user.GetCurrentUser().User_Name;
                    production.Created_Date = DateTime.Now;
                    await _context.Production.AddAsync(production);
                    await _context.SaveChangesAsync();

                    await _context.Database.ExecuteSqlRawAsync("EXEC USP_Insert_MilestonesAndApprovers {0}", production.Production_ID);

                }

                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = production.Production_ID
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
        public async Task<Response<List<Production>>> SearchProduction(Production production)
        {
            try
            {
                IQueryable<Production> qry = (from p in _context.Production
                                              from s in _context.Status.Where(x => x.Status_ID == p.Status_ID).DefaultIfEmpty()
                                              select new Production()
                                              {
                                                  Production_ID = p.Production_ID,
                                                  Tractor_Part_Number = p.Tractor_Part_Number,
                                                  Engine_Part_Number = p.Engine_Part_Number,
                                                  Hydraulics_Part_Number = p.Hydraulics_Part_Number,
                                                  Transmission_Part_Number = p.Transmission_Part_Number,
                                                  Created_By = p.Created_By,
                                                  Created_Date = p.Created_Date,
                                                  Status_ID = p.Status_ID,
                                                  Status = s.Status_Name
                                              });
                if (!string.IsNullOrEmpty(production.Tractor_Part_Number))
                {
                    qry = qry.Where(x => production.Tractor_Part_Number.Contains(x.Tractor_Part_Number));
                }
                if (!string.IsNullOrEmpty(production.Engine_Part_Number))
                {
                    qry = qry.Where(x => production.Engine_Part_Number.Contains(x.Engine_Part_Number));
                }
                if (!string.IsNullOrEmpty(production.Hydraulics_Part_Number))
                {
                    qry = qry.Where(x => production.Hydraulics_Part_Number.Contains(x.Hydraulics_Part_Number));
                }
                if (!string.IsNullOrEmpty(production.Transmission_Part_Number))
                {
                    qry = qry.Where(x => production.Transmission_Part_Number.Contains(x.Transmission_Part_Number));
                }
                var model = await qry.ToListAsync();
                return new Response<List<Production>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<Production>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<int>> DeleteProduction(int? productionID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Production>> GetProductionById(int? productionID)
        {
            try
            {
                var model =  await (
                    from p in _context.Production.Where(x => x.Production_ID == productionID)
                    from s in _context.Status.Where(x => x.Status_ID == p.Status_ID).DefaultIfEmpty()
                    select new Production()
                    {
                        Production_ID = p.Production_ID,
                        Date=p.Date,
                        Tractor_Part_Number = p.Tractor_Part_Number,
                        Tractor_SAP_Series = p.Tractor_SAP_Series,
                        Is_Change_Tractor = p.Is_Change_Tractor,
                        Tractor_Series = p.Tractor_Series,

                        Engine_Part_Number = p.Engine_Part_Number,
                        Engine_Series = p.Engine_Series,
                        Engine_SAP_Series = p.Engine_SAP_Series,
                        Is_Change_Engine = p.Is_Change_Engine,

                        Hydraulics_Part_Number = p.Hydraulics_Part_Number,
                        Hydraulics_SAP_Series = p.Hydraulics_SAP_Series,
                        Hydraulics_Series = p.Hydraulics_Series,
                        Is_Change_Hydraulics = p.Is_Change_Hydraulics,

                        Transmission_Part_Number = p.Transmission_Part_Number,
                        Transmission_SAP_Series = p.Transmission_SAP_Series,
                        Transmission_Series = p.Transmission_Series,
                        Is_Change_Transmission = p.Is_Change_Transmission,

                        Workflow_ID = p.Workflow_ID,

                        Created_By = p.Created_By,
                        Created_Date = p.Created_Date,
                        Status_ID = p.Status_ID,
                        Status = s.Status_Name
                    }).FirstAsync();
                return new Response<Production>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<Production>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<Production>>> GetProductions()
        {
            try
            {
                var model = await _context.Production.ToListAsync();
                return new Response<List<Production>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<Production>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<bool>> UpdateProduction(Production production)
        {
            try
            {
                var prodItem = _context.Production.Find(production.Production_ID);
                prodItem.Status_ID = production.Status_ID;
                prodItem.Tractor_Part_Number = production.Tractor_Part_Number;
                await _context.SaveChangesAsync();
                return new Response<bool>()
                {
                    IsSuccess = true,
                    Model = true
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<bool>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
