using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserVM>> GetUsers();
        Task<UserVM> GetUserById(int? userId);
        Task<int> AddUser(UserVM user);

        User GetCurrentUser();
    }
}
