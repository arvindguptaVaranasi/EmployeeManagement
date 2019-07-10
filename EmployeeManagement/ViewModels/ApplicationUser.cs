using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.ViewModels
{
    public class ApplicationUser: IdentityUser
    {
        public string City { get; set; }
    }
}
