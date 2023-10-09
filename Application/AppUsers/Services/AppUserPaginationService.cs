using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Services
{
    public class AppUserPaginationService
    {
        public static IEnumerable<AppUser> DoPagination(IEnumerable<AppUser> users, int page)
        {
            // размер страницы по умолчанию
            int pageSize = 2;

            var count = users.Count();
            var items = users.Skip((page - 1) * pageSize).Take(pageSize);

            return items;
        }
    }
}
