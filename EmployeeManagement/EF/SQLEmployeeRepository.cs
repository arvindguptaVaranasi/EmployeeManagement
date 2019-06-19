using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLServices;
using Model;

namespace EmployeeManagement.EF
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee emp = context.Employees.Find(Id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return emp;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            Employee emp = context.Employees.Find(Id);
            return emp;
        }

        public Employee Update(Employee employeeChanges)
        {
            var emp = context.Employees.Attach(employeeChanges);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }
    }
}
