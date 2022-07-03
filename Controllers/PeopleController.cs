using EmployeeManagement.Web.Models.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Entities;
using System.Linq.Dynamic.Core;

namespace EmployeeManagementSystem.Controllers
{
    [Route("[Controller]")]
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{
        //    var person = _context.Peoples.ToList();
        //    var personToView = new List<PeopleViewModel>();
        //    foreach (var items in person)
        //    {
        //        var per = new PeopleViewModel();
        //        per.PersonId = items.PersonId;
        //        per.FirstName = items.FirstName;
        //        per.MiddleName = items.MiddleName;
        //        per.LastName = items.LastName;
        //        per.Address = items.Address;
        //        per.Email = items.Email;
        //        personToView.Add(per);
        //    }
        //    return View(personToView);
        //}
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        //public IActionResult Create(PeopleViewModel model)
        //{
        //    var detail = new People();
        //    detail.PersonId = model.PersonId;
        //    detail.FirstName = model.FirstName;
        //    detail.MiddleName = model.MiddleName;
        //    detail.LastName = model.LastName;
        //    detail.Address = model.Address;
        //    detail.Email = model.Email;

        //    _context.Peoples.Add(detail);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //[HttpGet("Edit/{Id}")]
        //public IActionResult Edit(int id)
        //{
        //    var detail = _context.Peoples.Where(x => x.PersonId == id).FirstOrDefault();
        //    var det = new PeopleViewModel();
        //    det.PersonId = detail.PersonId;
        //    det.FirstName = detail.FirstName;
        //    det.MiddleName = detail.MiddleName;
        //    det.LastName = detail.LastName;
        //    det.Address = detail.Address;
        //    det.Email = detail.Email;
            
        //    return View(det);
        //}
        //[HttpPost("EditPerson")]
        //public IActionResult Edit(PeopleViewModel model)
        //{
        //    var detail = _context.Peoples.Where(x => x.PersonId == model.PersonId).FirstOrDefault();
        //    detail.PersonId = model.PersonId;
        //    detail.FirstName = model.FirstName;
        //    detail.MiddleName = model.MiddleName;
        //    detail.LastName = model.LastName;
        //    detail.Address = model.Address;
        //    detail.Email = model.Email;
            

        //    _context.Peoples.Update(detail);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        [HttpGet("getAll")]
        public IActionResult IndexEk()
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
                var personData = (from temppeople in _context.Peoples select temppeople);
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    personData = personData.OrderBy(sortColumn + " " + sortColumnDirection);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    personData = personData.Where(m => m.FirstName.ToLower().Contains(searchValue)
                                                || m.LastName.ToLower().Contains(searchValue)
                                                || m.Address.ToLower().Contains(searchValue)
                                                || m.Email.ToLower().Contains(searchValue));
                }
                recordsTotal = personData.Count();
                var data = personData.Skip(skip).Take(pageSize).ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
