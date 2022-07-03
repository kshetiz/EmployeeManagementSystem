using EmployeeManagement.Web.Models.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Entities;

namespace EmployeeManagementSystem.Controllers
{
    public class PositionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PositionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data=_context.Position.ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(PositionViewModel model)
        {
            var viewmodel = new Position
            {
                PositionId = Guid.NewGuid().ToString(),
                PositionName=model.PositionName
            };
            
            _context.Position.Add(viewmodel);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Delete(string id)
        {
            var delete = _context.Position.SingleOrDefault(x=>x.PositionId==id);
                _context.Remove(delete);
                _context.SaveChanges();
                return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var data = _context.Position.SingleOrDefault(x => x.PositionId == id);
            var viewdata = new PositionViewModel
            {
                PositionId = data.PositionId,
                PositionName = data.PositionName
            };
            return View(viewdata);
        }
        [HttpPost]
        public IActionResult Edit(string id, PositionViewModel model)
        {
            var data = _context.Position.SingleOrDefault(x => x.PositionId == id);
            var viewdata = new PositionViewModel
            {
                PositionName = model.PositionName
            };
            _context.Update(viewdata);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
