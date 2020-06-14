using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface ILogDetailsRepository
    {
        void Info(string message, string logger = "");
        void Warning(string message, string logger = "");

        void Error(Exception ex, string logger = "");
    }
}
