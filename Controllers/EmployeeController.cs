using EmployeeManagement.Web.Models.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Entities;
using System.Linq.Dynamic.Core;

namespace EmployeeManagementSystem.Controllers
{
    [Route("[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employee = from e in _context.Employees
                           join p in _context.Peoples
                           on e.PersonId equals p.PersonId
                           select new EmployeeViewModel {
                                Email = p.Email,
                                EmployeeId = e.EmployeeId,
                                PersonId = e.PersonId,
                                PositionId = e.PositionId,
                                Salary = e.Salary,
                                StartDate = e.StartDate,
                                EndDate = e.EndDate,
                                EmployeeCode = e.EmployeeCode,
                                IsDisabled = e.IsDisabled,
                           };
                           
            //var employeeToView = new List<EmployeeViewModel>();
            //foreach (var items in employee)
            //{
            //    var emp = new EmployeeViewModel();
            //    emp.EmployeeId = items.EmployeeId;
            //    emp.PersonId = items.PersonId;
            //    emp.PositionId = items.PositionId;
            //    emp.Salary = items.Salary;
            //    emp.StartDate = items.StartDate;
            //    emp.EndDate = items.EndDate;
            //    emp.EmployeeCode = items.EmployeeCode;
            //    emp.IsDisabled = items.IsDisabled;
                
            //    employeeToView.Add(emp);
            //}
            return View(employee);
            
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(EmployeeViewModel model)
            {
            var detail = new Employees();
            detail.EmployeeId = model.EmployeeId;
            detail.PersonId = model.PersonId;
            detail.PositionId = model.PositionId;
            detail.Salary = model.Salary;
            detail.StartDate = model.StartDate;
            detail.EndDate = model.EndDate;
            detail.EmployeeCode = model.EmployeeCode;
            detail.IsDisabled = model.IsDisabled;


            _context.Employees.Add(detail);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("GetAll")]
        public IActionResult GetallEmp()
        {
            return View();
        }

        [HttpPost("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault().ToLower();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var employeeData = from e in _context.Employees
                                   from p in _context.Peoples
                                   where e.PersonId == p.PersonId && e.IsDisabled==false
                                   select new EmployeeViewModel
                                   {
                                       Email = p.Email,
                                       EmployeeId = e.EmployeeId,
                                       PersonId = e.PersonId,
                                       PositionId = e.PositionId,
                                       Salary = e.Salary,
                                       StartDate = e.StartDate,
                                       EndDate = e.EndDate,
                                       EmployeeCode = e.EmployeeCode,
                                       IsDisabled = e.IsDisabled,
                                   }; 
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    employeeData = employeeData.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    employeeData = employeeData.Where(m => m.EmployeeCode.Contains(searchValue)
                                                           || m.Email.ToLower().Contains(searchValue));
                                                
                }
                recordsTotal = employeeData.Count();
                var data = employeeData.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id) {
            var delemp = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            delemp.IsDisabled = true;
            _context.Employees.Update(delemp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
