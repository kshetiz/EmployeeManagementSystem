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
           
           
            return View();
            
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            var position = _context.Position.ToList();
            ViewBag.position = position;
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(EmployeeViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction()) 
            {
                var peop = new People
                {
                    PersonId= Guid.NewGuid().ToString(),
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Address = model.Address,
                    Email = model.Email,

                };
                var detail = new Employee();
                    detail.EmployeeId = Guid.NewGuid().ToString();
                    detail.PersonId = peop.PersonId;
                    detail.PositionId = model.PositionId;
                    detail.Salary = model.Salary;
                    detail.StartDate = DateTime.UtcNow.AddHours(5).AddMinutes(45);
                    detail.EmployeeCode = model.EmployeeCode;
                    detail.IsDisabled = model.IsDisabled;

                var hisdetail = new EmployeeJobHistory
                {
                    EmployeeJobHistoryId= Guid.NewGuid().ToString(),
                    StartDate= detail.StartDate,
                    EmployeeId=detail.EmployeeId,
                    PositionId=model.PositionId,

            };
                _context.Peoples.Add(peop);
                _context.Employees.Add(detail);
                _context.EmployeeJobHistorys.Add(hisdetail);
                _context.SaveChanges();
                transaction.Commit();
                return RedirectToAction("Index");
            };
        }
        [HttpGet("Getall")]
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
                var employeeData = from e in _context.Employees.Where(x=> !x.IsDisabled)
                                   join p in _context.Peoples on e.PersonId equals p.PersonId  
                                   join per in _context.Position on e.PositionId equals per.PositionId
                                   
                                   select new EmployeeViewModel
                                   {
                                       FirstName=p.FirstName,
                                       Email = p.Email,
                                       EmployeeId = e.EmployeeId,
                                       PersonId = e.PersonId,
                                       PositionId = e.PositionId,
                                       Salary = e.Salary,
                                       StartDate = e.StartDate,
                                       PositionName=per.PositionName,
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
        [HttpGet("Edit/{ID}")]
        public IActionResult Edit(string id)
        {
            var data = _context.Employees.SingleOrDefault(x=>x.EmployeeId == id);
            var peop = _context.Peoples.FirstOrDefault(x => x.PersonId == data.PersonId);
            var edt = new EmployeeViewModel();
            edt.EmployeeId = data.EmployeeId;
            edt.FirstName = peop.FirstName;
            edt.LastName = peop.LastName;
            edt.EmployeeCode = data.EmployeeCode;


            return View(edt);
        }
        

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(string id)
        {
            var delemp = _context.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            delemp.IsDisabled = true;
            _context.Employees.Update(delemp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
