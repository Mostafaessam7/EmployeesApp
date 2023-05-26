using EmployeesApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeesApp.Controllers
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }
    public class EmployeeController : Controller
    {
        HrDatabaseContext dbContext = new HrDatabaseContext();

        public IActionResult Index(string sortField, string currentSortField, SortDirection sortDirection,string searchByName)
        {
            var employees = GetEmployees();
            if(!string.IsNullOrEmpty(searchByName))
                employees=employees.Where(e=>e.EmployeeName.ToLower().Contains(searchByName.ToLower())).ToList();
            return View(this.SortEmployees(employees, sortField, currentSortField, sortDirection));

        }

        private List<Employee> GetEmployees()
        {
            var employees = (from emp in dbContext.Employees
                             join Department in dbContext.Departments on emp.DepartmentId equals Department.DepartmentId
                             select new Employee
                             {
                                 EmployeeID = emp.EmployeeID,
                                 EmployeeNumber = emp.EmployeeNumber,
                                 EmployeeName = emp.EmployeeName,
                                 DOB = emp.DOB,
                                 HiringDate = emp.HiringDate,
                                 GrossSalary = emp.GrossSalary,
                                 NetSalary = emp.NetSalary,
                                 DepartmentId = emp.DepartmentId,
                                 DepartmentName = Department.DepartmentName

                             }).ToList();
            return employees;
        }

        public IActionResult Create()
        {
            ViewBag.Department = this.dbContext.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee model)
        {
            ModelState.Remove("EmployeeID");
            ModelState.Remove("Department");
            ModelState.Remove("DepartmentName");

            if (ModelState.IsValid)
            {
                dbContext.Employees.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = this.dbContext.Departments.ToList();
            return View();
        }


        public IActionResult Edit(int Id)
        {
            Employee data = dbContext.Employees.Where(e => e.EmployeeID == Id).FirstOrDefault();
            ViewBag.Department = this.dbContext.Departments.ToList();
            return View("Create", data);
        }

        [HttpPost]
        public IActionResult Edit(Employee model)
        {
            ModelState.Remove("EmployeeID");
            ModelState.Remove("Department");
            ModelState.Remove("DepartmentName");

            if (ModelState.IsValid)
            {
                dbContext.Employees.Update(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Department = this.dbContext.Departments.ToList();
            return View("Create", model);
        }
        public IActionResult Delete(int Id)
        {
            Employee data = dbContext.Employees.Where(e => e.EmployeeID == Id).FirstOrDefault();
            if (data != null)
            {
                dbContext.Employees.Remove(data);
                dbContext.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        private List<Employee> SortEmployees(List<Employee> employees, string sortField, string currentSortField, SortDirection sortDirection)
        {
            if (string.IsNullOrEmpty(sortField))
            {
                ViewBag.SortField = "EmployeeNumber";
                ViewBag.SortDirection = SortDirection.Ascending;


            }
            else
            {
                if (currentSortField == sortField)
                    ViewBag.SortDirection = sortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
                else
                    ViewBag.SortDirection = SortDirection.Ascending;
                ViewBag.SortField = sortField;
            }


            var propertyInfo = typeof(Employee).GetProperty(ViewBag.SortField);
            if (ViewBag.SortDirection == SortDirection.Ascending)
                employees = employees.OrderBy(e => propertyInfo.GetValue(e, null)).ToList();
            else
                employees = employees.OrderByDescending(e => propertyInfo.GetValue(e, null)).ToList();
            return employees;





        }



    }
}
