using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp_Labb2.Data;
using Asp_Labb2.Models;

namespace Asp_Labb2.Controllers
{
    public class CourseTeachersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseTeachersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CourseTeachers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CourseTeachers.Include(c => c.Course).Include(c => c.StudentClass).Include(c => c.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CourseTeachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacher = await _context.CourseTeachers
                .Include(c => c.Course)
                .Include(c => c.StudentClass)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.CourseTeacherId == id);
            if (courseTeacher == null)
            {
                return NotFound();
            }

            return View(courseTeacher);
        }

        // GET: CourseTeachers/Create
        public IActionResult Create()
        {
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            ViewData["FkStudentClassId"] = new SelectList(_context.StudentClasses, "StudentClassId", "StudentClassName");
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherName");
            return View();
        }

        // POST: CourseTeachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseTeacherId,FkTeacherId,FkCourseId,FkStudentClassId")] CourseTeacher courseTeacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseTeacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseTeacher.FkCourseId);
            ViewData["FkStudentClassId"] = new SelectList(_context.StudentClasses, "StudentClassId", "StudentClassId", courseTeacher.FkStudentClassId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", courseTeacher.FkTeacherId);
            return View(courseTeacher);
        }

        // GET: CourseTeachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacher = await _context.CourseTeachers.FindAsync(id);
            if (courseTeacher == null)
            {
                return NotFound();
            }
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseTeacher.FkCourseId);
            ViewData["FkStudentClassId"] = new SelectList(_context.StudentClasses, "StudentClassId", "StudentClassId", courseTeacher.FkStudentClassId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", courseTeacher.FkTeacherId);
            return View(courseTeacher);
        }

        // POST: CourseTeachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseTeacherId,FkTeacherId,FkCourseId,FkStudentClassId")] CourseTeacher courseTeacher)
        {
            if (id != courseTeacher.CourseTeacherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseTeacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseTeacherExists(courseTeacher.CourseTeacherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkCourseId"] = new SelectList(_context.Courses, "CourseId", "CourseId", courseTeacher.FkCourseId);
            ViewData["FkStudentClassId"] = new SelectList(_context.StudentClasses, "StudentClassId", "StudentClassId", courseTeacher.FkStudentClassId);
            ViewData["FkTeacherId"] = new SelectList(_context.Teachers, "TeacherId", "TeacherId", courseTeacher.FkTeacherId);
            return View(courseTeacher);
        }

        // GET: CourseTeachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTeacher = await _context.CourseTeachers
                .Include(c => c.Course)
                .Include(c => c.StudentClass)
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.CourseTeacherId == id);
            if (courseTeacher == null)
            {
                return NotFound();
            }

            return View(courseTeacher);
        }

        // POST: CourseTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseTeacher = await _context.CourseTeachers.FindAsync(id);
            if (courseTeacher != null)
            {
                _context.CourseTeachers.Remove(courseTeacher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseTeacherExists(int id)
        {
            return _context.CourseTeachers.Any(e => e.CourseTeacherId == id);
        }
    }
}
