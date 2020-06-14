using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Data;
using TractorProduction.Web.Repositories;

namespace TractorProduction.Web.Services
{
    public class BaseService
    {
        protected readonly APIContext _context;
        protected readonly ILogDetailsRepository _log;
        protected readonly IUserRepository _user;
        public BaseService(APIContext context, ILogDetailsRepository log, IUserRepository user)
        {
            _context = context;
            _log = log;
            _user = user;
        }
        #region Dispose Object
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
