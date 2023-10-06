using Application.AppUsers.Enums;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Services
{
    public class AppUserSortService
    {
        public static IQueryable<AppUser> DoSort(IQueryable<AppUser> users, AppUserSortState sortOrder)
        {
            switch (sortOrder)
            {
                case AppUserSortState.IdDesc:
                    users = users.OrderByDescending(s => s.Id);
                    break;
                case AppUserSortState.NameAsc:
                    users = users.OrderBy(s => s.DisplayName);
                    break;
                case AppUserSortState.NameDesc:
                    users = users.OrderByDescending(s => s.DisplayName);
                    break;
                case AppUserSortState.AgeAsc:
                    users = users.OrderBy(s => s.Age);
                    break;
                case AppUserSortState.AgeDesc:
                    users = users.OrderByDescending(s => s.Age);
                    break;
                case AppUserSortState.EmailAsc:
                    users = users.OrderBy(s => s.Age);
                    break;
                case AppUserSortState.EmailDesc:
                    users = users.OrderByDescending(s => s.Age);
                    break;
                default:
                    users = users.OrderBy(s => s.Id);
                    break;
            }

            return users;
        }
    }
}
