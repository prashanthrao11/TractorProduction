using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Data;
using TractorProduction.Web.Models;
using TractorProduction.Web.Repositories;
namespace TractorProduction.Web.Services
{
    public class LogDetailsService:ILogDetailsRepository
    {
        private readonly APIContext _context;
        public LogDetailsService(APIContext context)
        {
            _context = context;
        }
        public void Info(string message, string logger = "")
        {
            LogDetails obj = new LogDetails();
            obj.Created_Date = DateTime.Now;
            obj.Log_Type = "Info";
            obj.Log_Message = message;
            obj.Created_By = logger;
            _context.LogDetails.Add(obj);
            _context.SaveChanges();
        }
        public void Warning(string message, string logger = "")
        {
            LogDetails obj = new LogDetails();
            obj.Created_Date = DateTime.Now;
            obj.Log_Type = "Warning";
            obj.Log_Message = message;
            obj.Created_By = logger;
            _context.LogDetails.Add(obj);
            _context.SaveChanges();
        }
        public void Error(Exception ex, string logger = "")
        {
            try
            {
                LogDetails obj = new LogDetails();
                // Get stack trace for the exception with source file information
                var st = new StackTrace(ex, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();

                obj.Created_Date = DateTime.Now;
                obj.Log_Type = "Error";
                obj.Created_By = logger;
                obj.Log_Message = "Line Number = " + line.ToString() + Environment.NewLine + ex.Message;
                obj.Expection = ex.ToString();

                _context.LogDetails.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception ex1)
            {
                //string path = "";
                //System.IO.File.AppendAllText(path, "Exception on ********  " + DateTime.Now.ToString() + Environment.NewLine);
                //System.IO.File.AppendAllText(path, "Message:- " + ex1.Message + Environment.NewLine);
                //System.IO.File.AppendAllText(path, "Error:- " + ex1.ToString() + Environment.NewLine);
                //System.IO.File.AppendAllText(path, "***********************End ********" + Environment.NewLine);
            }
        }
    }
}
