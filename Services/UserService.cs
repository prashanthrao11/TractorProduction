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
    public class UserService : IUserRepository
    {
        private readonly APIContext _context;
        public UserService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddUser(UserVM user)
        {
            if (_context != null)
            {
                if (user.User_ID == 0)
                {
                    /// this code for insert user, user role & departments.
                    
                    User userObj = new User();
                    userObj.User_Name = user.User_Name;
                    userObj.Email = user.Email;
                    userObj.Phone_Number = user.Phone_Number;
                    userObj.First_Name = user.First_Name;
                    userObj.Last_Name = user.Last_Name;
                    userObj.Is_Active = true;
                    _context.User.Add(userObj);
                    await _context.SaveChangesAsync();

                    user.User_ID = userObj.User_ID;

                    UserRole userRole = new UserRole();
                    userRole.User_ID = userObj.User_ID;
                    userRole.Role_ID = user.Role_ID;
                    userRole.Is_Active = true;

                    _context.UserRole.Add(userRole);
                    await _context.SaveChangesAsync();

                    List<DepartmentUsers> deptUserList = new List<DepartmentUsers>();

                    foreach(var deptIdStr in user.DepartmentIds.Split(","))
                    {
                        DepartmentUsers departmentUser = new DepartmentUsers();
                        departmentUser.User_ID = userObj.User_ID;
                        departmentUser.Department_ID = Convert.ToInt32(deptIdStr);
                        departmentUser.Is_Active = true;
                        deptUserList.Add(departmentUser);
                    }
                    _context.DepartmentUsers.AddRange(deptUserList);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var userObj = _context.User.Find(user.User_ID);
                    ///this code for delete user.

                    if (user.Is_Active == false)
                    {
                        userObj.Is_Active = false;
                        await _context.SaveChangesAsync();
                    }
                    /// this code for update user details
                    else
                    {
                        userObj.User_Name = user.User_Name;
                        userObj.Email = user.Email;
                        userObj.Phone_Number = user.Phone_Number;
                        userObj.First_Name = user.First_Name;
                        userObj.Last_Name = user.Last_Name;
                        userObj.Is_Active = true;
                        await _context.SaveChangesAsync();

                        UserRole userRole = _context.UserRole.Find(user.User_Role_ID);
                        userRole.User_ID = userObj.User_ID;
                        userRole.Role_ID = user.Role_ID;
                        userRole.Is_Active = true;
                        await _context.SaveChangesAsync();

                        var existingList = _context.DepartmentUsers.Where(x => x.User_ID == user.User_ID).ToList();
                        foreach (var eItem in existingList)
                        {
                            if (user.DepartmentIds.IndexOf(eItem.Department_ID.ToString()) == -1)
                            {
                                eItem.Is_Active = false;
                            }
                        }
                        await _context.SaveChangesAsync();

                        foreach (var deptIdStr in user.DepartmentIds.Split(','))
                        {
                            int deptId = Convert.ToInt32(deptIdStr);
                            var deptItem = _context.DepartmentUsers.Where(x => x.Department_ID == deptId && x.User_ID ==user.User_ID).FirstOrDefault();

                            if (deptItem == null)
                            {
                                DepartmentUsers department = new DepartmentUsers();
                                department.Department_ID = deptId;
                                department.User_ID = user.User_ID;
                                department.Is_Active = true;
                                _context.DepartmentUsers.Add(department);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                deptItem.Is_Active = true;
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    return user.User_ID;
                }
            }
            return user.User_ID;
        }

        public async Task<UserVM> GetUserById(int? userId)
        {
            if (_context != null)
            {
                return await _context.UserDetails.Where(x => x.User_ID == userId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<UserVM>> GetUsers()
        {
            if (_context != null)
            {
                return await _context.UserDetails.ToListAsync();
            }
            return null;
        }
        public async Task<UserVM> CurrentUser()
        {
            var userName = "prashanth.s@gmail.com";
            var user = await _context.User.Where(x => x.Email == userName).FirstAsync();
            var userRole = await _context.UserRole.Where(x => x.User_ID == user.User_ID).FirstAsync();
            var role = await _context.Role.Where(x => x.Role_ID == userRole.Role_ID).FirstAsync();
            return new UserVM()
            {
                User_ID = user.User_ID,
                User_Name = user.User_Name,
                Email = user.Email,
                Role_ID = userRole.Role_ID,
                Role_Name = role.Role_Name
            };
        }
        public User GetCurrentUser()
        {
            var userName = "prashanth.s@gmail.com";
            var user = _context.User.Where(x=>x.Email==userName).First();
            var userRole = _context.UserRole.Where(x => x.User_ID == user.User_ID).First();
            return new User()
            {
                User_ID = user.User_ID,
                User_Name = user.User_Name,
                Email = user.Email,
                Role_ID = userRole.Role_ID
            };
        }
    }
}
