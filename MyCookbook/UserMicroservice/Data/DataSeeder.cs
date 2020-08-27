using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceAPI.Data.Entities;

namespace UserMicroserviceAPI.Data
{
    public class DataSeeder
    {
        public static void SeedData(UserContext _context)
        {
            _context.Database.EnsureCreated();

            AddUserRoles(_context);

            Constants.ROLE_ADMIN = _context.UserRoles
                        .Where(r => r.Name == Constants.ROLE_ADMIN_NAME)
                        .Select(r => r.Id).FirstOrDefault();
            Constants.ROLE_USER = _context.UserRoles
                        .Where(r => r.Name == Constants.ROLE_USER_NAME)
                        .Select(r => r.Id).FirstOrDefault();

            AddUsers(_context);

            _context.SaveChanges();
        }

        private static void AddUserRoles(UserContext _context)
        {
            var existingRoles = _context.UserRoles;
            foreach (var role in requiredRoles)
            {
                if (!existingRoles.Select(s => s.Name == role.Name).Any())
                {
                    _context.UserRoles.Add(role);
                }
            }

            _context.SaveChanges();
        }

        private static void AddUsers(UserContext _context)
        {
            var existingUsers = _context.Users;
            foreach (var user in requiredUsers)
            {
                if (!existingUsers.Select(s => s.Email == user.Email).Any())
                {
                    user.RoleId = _context.UserRoles
                        .Where(r => r.Name == Constants.ROLE_ADMIN_NAME)
                        .Select(r => r.Id)
                        .FirstOrDefault();
                    _context.Users.Add(user);
                }
            }

            _context.SaveChanges();
        }

        private static UserRole[] requiredRoles = new UserRole[]
        {
            new UserRole {
                Name = Constants.ROLE_ADMIN_NAME
            },
            new UserRole {
                Name = Constants.ROLE_USER_NAME
            }
        };

        private static User[] requiredUsers = new User[]
        {
            new User {
                FirstName = "Admin",
                LastName = "Admin",
                Address = "admin 12",
                Email = "admin@mycookbook.com",
                Password = "user123"
            }
        };
    }
}
