
using EFCore_Join_ManyToMany.Data.Context;
using EFCore_Join_ManyToMany.Data.Entities;
using EFCore_Join_ManyToMany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace EFCore_Join_ManyToMany.Controllers
{
    public class UserController : Controller
    {
        JoinDbContext _context;

        public UserController(JoinDbContext context)
        {
            _context = context;
        }

        public IActionResult UserList()
        {
            var users = _context.Users.Join(_context.UserRoles, user => user.Id, userRole => userRole.UserId, (user, userRole) => new
            {
                user,
                userRole
            }).Join(_context.Roles, two => two.userRole.RoleId, role => role.Id, (two, role) => new
            {
                two.user,
                two.userRole,
                role
            }).Select(x => new UserWithRoleNameListModel
            {
                Id = x.user.Id,
                Username = x.user.Username,
                RoleName = x.role.Name
            }).ToList();
            //Join ile birleþtirdiðimiz için rolü birden fazla olan kullanýcýlarý kaç tane rolü varsa rolleri farklý bir þekilde ayrý ayrý çeker. Yani bir kullanýcý için rolleri farklý olmak þartýyla birden fazla kayýt getirir.

            //Kullanýcýyý rolleri ile beraber tek bir kayýt olarak bu þekilde çekebilirsin.
            //List<UserWithRolesListModel> userList = new List<UserWithRolesListModel>();
            //var users2 = _context.Users.ToList();

            //foreach (var user in users2)
            //{
            //    var roles = _context.Roles.Include(r => r.UserRoles).Where(r => r.UserRoles.Any(ur => ur.UserId == user.Id)).ToList();

            //    userList.Add(new() { Id = user.Id, Username = user.Username, Roles = roles});

            //}

            return View(users);
        }

        public IActionResult AssignRole(int userId)
        {
            var userRoles = _context.Roles.Include(r => r.UserRoles).Where(r => r.UserRoles.Any(ur => ur.UserId == userId)).ToList();
            var roles = _context.Roles.ToList();

            RoleAssignSendModel model = new();

            List<RoleAssignListModel> list = new();

            foreach (var role in roles)
            {
                list.Add(new()
                {
                    Name = role.Name,
                    RoleId = role.Id,
                    Exist = userRoles.Contains(role)
                });
            }

            model.Roles = list;
            model.UserId = userId;

            return View(model);
        }

        [HttpPost]
        public IActionResult AssignRole(RoleAssignSendModel model)
        {
            //Role Ekleme => Seçilen role'nin ilgili user'da olmamasý gerekiyor.
            //Role Çýkarma => Seçilen role'nin ilgili user'da olmasý gerekiyor.

            var user = _context.Users.Find(model.UserId);
            var userRoles = _context.Roles.Include(r => r.UserRoles).Where(r => r.UserRoles.Any(ur => ur.UserId == model.UserId)).ToList();

            foreach (var role in model.Roles)
            {
                var assignRole = _context.Roles.Find(role.RoleId);

                if (role.Exist)
                {
                    if (!userRoles.Any(ur => ur.Name == role.Name))
                    {
                        _context.UserRoles.Add(new()
                        {
                            User = user,
                            Role = assignRole
                        });

                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (userRoles.Any(ur => ur.Name == role.Name))
                    {
                        var deleteUserRole = _context.UserRoles.FirstOrDefault(ur => ur.Role == assignRole && ur.User == user);
                        _context.UserRoles.Remove(deleteUserRole);

                        _context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("UserList");
        }

    }
}
