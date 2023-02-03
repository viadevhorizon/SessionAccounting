using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

using SessionAccounting.Entities;
using SessionAccounting.Persistence;

namespace SessionAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly SAContext _context;

        public FacultyController(SAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetFacultiesWithGroups()
        {
            return await _context.Faculties.Include(f => f.Groups).ToListAsync();
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<Faculty>> GetFacultyWithGroups(Guid id)
        {
            var faculty = await _context.Faculties.Where(f => f.Id == id).Include(f => f.Groups).FirstOrDefaultAsync();

            if (faculty is null) { return NotFound(); }

            return faculty;

        }

        [HttpPost]
        public async Task AddFaculty(string name)
        {
            var faculty = new Faculty
            {
                Name = name,
                Groups = new List<Group>()
            };
            await _context.Faculties.AddAsync(faculty);

            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task<ActionResult> EditFaculty(Guid id, string name)
        {
            var faculty = await _context.Faculties.FindAsync(id);

            if (faculty is null)
            {
                return NotFound();
            }

            faculty.Name = name;

            _context.Faculties.Update(faculty);


            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteFaculty(Guid id)
        {
            var faculty = await _context.Faculties.FindAsync(id);

            if (faculty is null) return NotFound();

            _context.Faculties.Remove(faculty);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
