using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MvcSchool.Data;
using MvcSchool.Models;

namespace MvcSchool.Controllers
{

    public class LessonsController : Controller
    {
        private readonly MvcSchoolContext _context;
        private string? searchString;
        private string? lessonGenreVM;

        public LessonsController(MvcSchoolContext context)
        {
            _context = context;
        }

        // GET: Lessons
        // GET: Movies
        // GET: Movies
        public async Task<IActionResult> Index(string lessonGenre, string searchString)
        {
            if (_context.Lesson == null)
            {
                return Problem("Entity set 'MvcSchoolContext.Lesson'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Lesson
                                            orderby m.Genre
                                            select m.Genre;
            var lessons = from m in _context.Lesson
                         select m;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
               // lessons = lessons.Where(s => !string.IsNullOrEmpty(s.Title) &&
                                              //s.Title.ToUpper(CultureInfo.CurrentCulture)
                                                 // .Contains(searchString.ToUpper(CultureInfo.CurrentCulture)));
            }

            if (!string.IsNullOrEmpty(lessonGenre))
            {
                lessons = lessons.Where(x => x.Genre == lessonGenre);
            }

            var lessonGenreVM = new LessonGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Lessons = await lessons.ToListAsync()
            };

            return View(lessonGenreVM);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,StartTime,Location,Price")] Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.Id))
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
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson != null)
            {
                _context.Lesson.Remove(lesson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.Id == id);
        }
    }
}
