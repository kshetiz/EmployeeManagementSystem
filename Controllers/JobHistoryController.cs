using EmployeeManagement.Web.Models.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Entities;

namespace EmployeeManagementSystem.Controllers
{
    public class JobHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public JobHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.EmployeeJobHistorys.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult GetByID(string id) 
        {
            var data = _context.EmployeeJobHistorys.FirstOrDefault(x => x.EmployeeId == id);
          
           

            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var data = _context.EmployeeJobHistorys.FirstOrDefault(x => x.EmployeeJobHistoryId == id);
            var dataview = new EmployeeJobHistoryViewModel()
            {
                EmployeeJobHistoryId = data.EmployeeJobHistoryId,
                EmployeeId = data.EmployeeId,
                StartDate=data.StartDate,
                EndDate=data.EndDate,
                PositionId=data.PositionId,
            };
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(string id,EmployeeJobHistoryViewModel model)
        {
            var data = _context.EmployeeJobHistorys.FirstOrDefault(x => x.EmployeeJobHistoryId == id);
            var entitydata = new EmployeeJobHistoryViewModel()
            {
                EmployeeId = model.EmployeeId,
                EmployeeJobHistoryId = model.EmployeeJobHistoryId,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                PositionId = model.PositionId,

            };
            _context.Update(entitydata);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(string id)
        {
            var data = _context.EmployeeJobHistorys.SingleOrDefault(x => x.EmployeeJobHistoryId == id);
            _context.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
