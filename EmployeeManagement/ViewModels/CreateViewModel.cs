using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.ViewModels
{
    public class CreateViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Dept? Department { get; set; }
        public List<IFormFile> Photo { get; set; }
    }
}
