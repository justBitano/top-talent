using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TopTalentView.Models;

namespace TopTalentView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTalentsController : Controller
    {
        private readonly TopTalentContext _context;
        public INotyfService _notifyService { get; }
        public AdminTalentsController(TopTalentContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: Admin/AdminTalents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Talents.ToListAsync());
        }

        // GET: Admin/AdminTalents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents
                .FirstOrDefaultAsync(m => m.TalentId == id);
            if (talent == null)
            {
                return NotFound();
            }

            return View(talent);
        }

        // GET: Admin/AdminTalents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminTalents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TalentId,TalentEmail,TalentPassword,TalentName,TalentPhone,TalentAddress,TalentDescription,TalentStatus")] Talent talent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(talent);
                await _context.SaveChangesAsync();
                _notifyService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            return View(talent);
        }

        // GET: Admin/AdminTalents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents.FindAsync(id);
            if (talent == null)
            {
                return NotFound();
            }
            return View(talent);
        }

        // POST: Admin/AdminTalents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TalentId,TalentEmail,TalentPassword,TalentName,TalentPhone,TalentAddress,TalentDescription,TalentStatus")] Talent talent)
        {
            if (id != talent.TalentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(talent);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Cập nhập thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TalentExists(talent.TalentId))
                    {
                        _notifyService.Success("Có lỗi xãy ra");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(talent);
        }

        // GET: Admin/AdminTalents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var talent = await _context.Talents
                .FirstOrDefaultAsync(m => m.TalentId == id);
            if (talent == null)
            {
                return NotFound();
            }

            return View(talent);
        }

        // POST: Admin/AdminTalents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var talent = await _context.Talents.FindAsync(id);
            _context.Talents.Remove(talent);
            await _context.SaveChangesAsync();
            _notifyService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool TalentExists(int id)
        {
            return _context.Talents.Any(e => e.TalentId == id);
        }
    }
}
