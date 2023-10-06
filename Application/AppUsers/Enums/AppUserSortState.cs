using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppUsers.Enums
{
    public enum AppUserSortState
    {
        IdAsc,      // по Id по возрастанию
        IdDesc,     // по Id по убыванию
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        AgeAsc,     // по возрасту по возрастанию
        AgeDesc,    // по возрасту по убыванию
        EmailAsc,   // по Email по возрастанию
        EmailDesc   // по Email по убыванию
    }
}
