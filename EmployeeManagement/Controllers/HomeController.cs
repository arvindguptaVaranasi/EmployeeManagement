using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLServices;
using Model;
using EmployeeManagement.ViewModels;
namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {

        private IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }
        public ViewResult Index()
        {
            // retrieve all the employees
            var model = _employeeRepository.GetAllEmployee();
            // Pass the list of employees to the view
            return View(model);            
            //return _employeeRepository.GetEmployee(1).Name;
        }
        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewBag.PageTitle = "Employee Details";

            // Instantiate HomeDetailsViewModel and store Employee details and PageTitle
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();   
        }
        //public JsonResult Index()
        //{
        //    return Json(new { id = 1, name = "pragim" });
        //}
    }
}