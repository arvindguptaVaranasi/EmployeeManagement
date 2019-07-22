using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class EditRoleViewModel
    {
        public List<string> UsersOfthisRole { get; set; }
        public EditRoleViewModel()
        {
            UsersOfthisRole = new List<string>();
        }
        public string Id { get; set; }
        public string RoleName { get; set; }

    }
}
