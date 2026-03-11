using Microsoft.AspNetCore.Mvc;
using Sarmiento_ELNET1_MVC.Data;
using Sarmiento_ELNET1_MVC.Models;

namespace Sarmiento_ELNET1_MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = _context.Students.ToList();
            return View(students);
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                bool idExists = _context.Students.Any(s => s.Id == student.Id);

                if (idExists)
                {
                    TempData["ErrorMessage"] = $"Student ID {student.Id} already exists. Please use a different ID.";
                    List<Student> currentStudents = _context.Students.ToList();
                    return View(currentStudents);
                }

                _context.Students.Add(student);
                _context.SaveChanges();

                TempData["SuccessMessage"] = $"Student {student.Name} has been added successfully.";
            }

            List<Student> students = _context.Students.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return RedirectToAction("Index");

            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return RedirectToAction("Index");

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                _context.SaveChanges();
                TempData["SuccessMessage"] = $"Student {student.Name} has been updated successfully.";
                return RedirectToAction("Index");
            }

            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                TempData["SuccessMessage"] = $"Student record has been removed successfully.";
            }

            return RedirectToAction("Index");
        }
    }
}