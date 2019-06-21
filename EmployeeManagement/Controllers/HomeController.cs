using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLServices;
using Model;
using EmployeeManagement.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;


namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {

        private IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;


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
        public ViewResult Details(int id)
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
        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            string uniqueFileName = null;

            // If the Photo property on the incoming model object is not null, then the user
            // has selected an image to upload.
            if (model.Photo != null)
            {
                // The image must be uploaded to the images folder in wwwroot
                // To get the path of the wwwroot folder we are using the inject
                // HostingEnvironment service provided by ASP.NET Core
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                // To make sure the file name is unique we are appending a new
                // GUID value and and an underscore to the file name
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                // Use CopyTo() method provided by IFormFile interface to
                // copy the file to wwwroot/images folder
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            Employee newEmployee = new Employee
            {
                Name = model.Name,
                Email = model.Email,
                Department = model.Department,
                // Store the file name in PhotoPath property of the employee object
                // which gets saved to the Employees database table
                PhotoPath = uniqueFileName
            };

            _employeeRepository.Add(newEmployee);
            return RedirectToAction("details", new { id = newEmployee.Id });            
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        //public JsonResult Index()
        //{
        //    return Json(new { id = 1, name = "pragim" });
        //}
    }
}