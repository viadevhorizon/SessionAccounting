using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionAccounting.Entities;
using SessionAccounting.Persistence;

namespace SessionAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly SAContext _context;

        public GroupController(SAContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroupsWithStudents()
        {
            return await _context.Groups.Include(f => f.Students).ToListAsync();
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<Group>> GetGroupWithStudents(Guid id)
        {
            var group = await _context.Groups.Where(f => f.Id == id).Include(f => f.Students).FirstOrDefaultAsync();

            if (group is null) return NotFound();

            return group;

        }

        [HttpPost]
        public async Task<ActionResult> AddGroup(string name, Guid facultyId)
        {
            var faculty = await _context.Faculties.Where(f => f.Id == facultyId).Include(f => f.Groups).FirstOrDefaultAsync();

            if (faculty is null) return BadRequest();

            var group = new Group()
            {
                Name = name,
                Students = new List<Student>(),
            };

            faculty.Groups.Add(group);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditGroup(Guid id, string name, Guid facultyId)
        {
            var group = await _context.Groups.FindAsync(id);

            if (group is null) return NotFound();

            group.Name = name;

            _context.Groups.Update(group);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGroup(Guid id)
        {
            var group = await _context.Groups.FindAsync(id);

            if (group is null) return NotFound();

            _context.Groups.Remove(group);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
