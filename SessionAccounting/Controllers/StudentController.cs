using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionAccounting.Entities;
using SessionAccounting.Models;
using SessionAccounting.Persistence;

namespace SessionAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase

    {
        private readonly SAContext _context;

        public StudentController(SAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsWithExams()
        {
            return await _context.Students.Include(f => f.StudentAttendances).ThenInclude(s=>s.Exam).ToListAsync();
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<Student>> GetGroupWithStudents(Guid id)
        {
            var student = await _context.Students.Where(f => f.Id == id).Include(s => s.StudentAttendances)
                .ThenInclude(e => e.Exam).FirstOrDefaultAsync();

            if (student is null) return NotFound();

            return student;

        }

        [HttpPost]
        public async Task AddStudent([FromBody] StudentModel model)
        {
            var student = new Student
            {
                Lastname = model.Lastname,
                Firstname = model.Firstname,
                Patronymic = model.Patronymic
            };

            var group = await _context.Groups.Where(g=>g.Id == model.GroupId).Include(s=>s.Students).FirstOrDefaultAsync();

            group.Students.Add(student);

            await _context.SaveChangesAsync();
        }
    }
}
