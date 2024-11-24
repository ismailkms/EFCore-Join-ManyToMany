using EFCore_Join_ManyToMany.Data.Context;
using EFCore_Join_ManyToMany.Data.Entities;
using EFCore_Join_ManyToMany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Join_ManyToMany.Controllers
{
    public class StudentController : Controller
    {
        JoinDbContext _context;

        public StudentController(JoinDbContext context)
        {
            _context = context;
        }
        public IActionResult StudentList()
        {
            var student = _context.Students.Include(s => s.Lessons).ToList();
            return View(student);
        }

        public IActionResult AssignLesson(int studentId)
        {
            var studentLessons = _context.Lessons.Include(l => l.Students).Where(l => l.Students.Any(s => s.Id == studentId)).ToList();
            var lessons = _context.Lessons.ToList();

            LessonAssignSendModel model = new();

            List<LessonAssignListModel> list = new();

            foreach (var lesson in lessons)
            {
                list.Add(new()
                {
                    Name = lesson.Name,
                    LessonId = lesson.Id,
                    Exist = studentLessons.Contains(lesson)
                });
            }

            model.Lessons = list;
            model.StudentId = studentId;

            return View(model);
        }

        [HttpPost]
        public IActionResult AssignLesson(LessonAssignSendModel model)
        {
            //Lesson Ekleme => Seçilen dersin ilgili student'ta olmaması gerekiyor.
            //Lesson Çıkarma => Seçilen dersin ilgili student'ta olması gerekiyor.

            var student = _context.Students.Include(s => s.Lessons).FirstOrDefault(s => s.Id == model.StudentId);
            var studentLessons = _context.Lessons.Include(l => l.Students).Where(l => l.Students.Any(s => s.Id == model.StudentId)).ToList();

            foreach (var lesson in model.Lessons)
            {
                var assignLesson = _context.Lessons.Find(lesson.LessonId);

                if (lesson.Exist)
                {
                    if (!studentLessons.Any(ur => ur.Name == lesson.Name))
                    {
                        student.Lessons.Add(assignLesson);

                        _context.SaveChanges();
                    }
                }
                else
                {
                    if (studentLessons.Any(ur => ur.Name == lesson.Name))
                    {
                        student.Lessons.Remove(assignLesson);

                        _context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("StudentList");
        }
    }
}
