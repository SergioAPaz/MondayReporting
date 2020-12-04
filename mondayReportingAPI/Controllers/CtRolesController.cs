using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mondayReportingAPI.Models;

namespace mondayReportingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CtRolesController : ControllerBase
    {
        private readonly DB_A6AF29_spaz123Context _context;

        public CtRolesController(DB_A6AF29_spaz123Context context)
        {
            _context = context;
        }

        // GET: api/CtRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtRole>>> GetCtRoles()
        {
            return await _context.CtRoles.ToListAsync();
        }

        // GET: api/CtRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CtRole>> GetCtRole(int id)
        {
            var ctRole = await _context.CtRoles.FindAsync(id);

            if (ctRole == null)
            {
                return NotFound();
            }

            return ctRole;
        }

        // PUT: api/CtRoles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtRole(int id, CtRole ctRole)
        {
            if (id != ctRole.Id)
            {
                return BadRequest();
            }

            _context.Entry(ctRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CtRoles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CtRole>> PostCtRole(CtRole ctRole)
        {
            _context.CtRoles.Add(ctRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCtRole", new { id = ctRole.Id }, ctRole);
        }

        // DELETE: api/CtRoles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CtRole>> DeleteCtRole(int id)
        {
            var ctRole = await _context.CtRoles.FindAsync(id);
            if (ctRole == null)
            {
                return NotFound();
            }

            _context.CtRoles.Remove(ctRole);
            await _context.SaveChangesAsync();

            return ctRole;
        }

        private bool CtRoleExists(int id)
        {
            return _context.CtRoles.Any(e => e.Id == id);
        }
    }
}
