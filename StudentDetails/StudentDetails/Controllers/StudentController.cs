using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDetails.Data;
using StudentDetails.Models.Entities;

namespace StudentDetails.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var item = await _context.Students.ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Student stdnt)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(stdnt);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Student stdn)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(stdn);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stdn);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var item = await _context.Students.FindAsync(id);
            if (item != null)
            {
                _context.Students.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
