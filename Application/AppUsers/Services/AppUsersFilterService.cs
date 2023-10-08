using Application.AppUsers.Enums;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity;
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
        public static IEnumerable<AppUser> DoFilter(IEnumerable<AppUser> users, string Id, string name, int? age, string email, string role)
        {
            if (!String.IsNullOrEmpty(Id))
                users = users.Where(u => u.Id == Id);
            if (!String.IsNullOrEmpty(name))
                users = users.Where(u => u.DisplayName!.Contains(name));
            if (age != null)
                users = users.Where(u => u.Age == age);
            if (!String.IsNullOrEmpty(email))
                users = users.Where(u => u.Email!.Contains(email));
            if (!String.IsNullOrEmpty(role))
                users = users.Where(u => u.Roles?.FirstOrDefault(r => r.Name == role)!= null);

            return users;
        }
    }
}
