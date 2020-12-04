using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MondayReporting2.Models;
using MondayReporting2.Models.MyModels;

namespace MondayReporting2.Controllers
{
    public class CT_UsersController : Controller
    {
        private readonly MyDBContext _context;

        public CT_UsersController(MyDBContext context)
        {
            _context = context;
        }

        // GET: CT_Users
        public async Task<IActionResult> Index()
        {
            var myDBContext = _context.CT_Users.Include(c => c.Role);
            return View(await myDBContext.ToListAsync());
        }

        // GET: CT_Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_Users = await _context.CT_Users
                .Include(c => c.Role)
                .FirstOrDefaultAsync(m => m.id == id);
            if (cT_Users == null)
            {
                return NotFound();
            }

            return View(cT_Users);
        }

        // GET: CT_Users/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.CT_Roles, "id", "Role");
            return View();
        }

        // POST: CT_Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,User,Password,LastAccess,Status,RoleId")] CT_Users cT_Users)
        {
            Encrypt encrypto = new Encrypt();

            if (ModelState.IsValid)
            {
                cT_Users.Password = encrypto.Encryptar(cT_Users.Password);
                _context.Add(cT_Users);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.CT_Roles, "id", "id", cT_Users.RoleId);
            return View(cT_Users);
        }

        // GET: CT_Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_Users = await _context.CT_Users.FindAsync(id);
            if (cT_Users == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.CT_Roles, "id", "id", cT_Users.RoleId);
            return View(cT_Users);
        }

        // POST: CT_Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,User,Password,LastAccess,Status,RoleId")] CT_Users cT_Users)
        {
            if (id != cT_Users.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cT_Users);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CT_UsersExists(cT_Users.id))
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
            ViewData["RoleId"] = new SelectList(_context.CT_Roles, "id", "id", cT_Users.RoleId);
            return View(cT_Users);
        }

        // GET: CT_Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_Users = await _context.CT_Users
                .Include(c => c.Role)
                .FirstOrDefaultAsync(m => m.id == id);
            if (cT_Users == null)
            {
                return NotFound();
            }

            return View(cT_Users);
        }

        // POST: CT_Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cT_Users = await _context.CT_Users.FindAsync(id);
            _context.CT_Users.Remove(cT_Users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CT_UsersExists(int id)
        {
            return _context.CT_Users.Any(e => e.id == id);
        }
    }
}
