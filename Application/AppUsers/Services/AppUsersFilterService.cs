using Application.AppUsers.Enums;
using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.AppUsers.Services
{
    public class AppUsersFilterService
    {
        public static IQueryable<AppUser> DoFilter(IQueryable<AppUser> users, string Id, string name, int? age, string email)
        {
            if (!String.IsNullOrEmpty(Id))
                users = users.Where(u => u.Id == Id);
            if (!String.IsNullOrEmpty(name))
                users = users.Where(u => u.DisplayName!.Contains(name));
            if (age != null)
                users = users.Where(u => u.Age == age);
            if (!String.IsNullOrEmpty(email))
                users = users.Where(u => u.Email!.Contains(email));

            return users;
        }
    }
}
