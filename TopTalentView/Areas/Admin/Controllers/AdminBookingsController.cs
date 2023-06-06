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
    public class AdminBookingsController : Controller
    {
        private readonly TopTalentContext _context;
        public INotyfService _notifyService { get; }
        public AdminBookingsController(TopTalentContext context, INotyfService notifyService)
        {
            _context = context;
            _notifyService = notifyService;
        }

        // GET: Admin/AdminBookings
        public async Task<IActionResult> Index()
        {
            var topTalentContext = _context.Bookings.Include(b => b.Talent).Include(b => b.User);
            return View(await topTalentContext.ToListAsync());
        }

        // GET: Admin/AdminBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Talent)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Admin/AdminBookings/Create
        public IActionResult Create()
        {
            ViewData["TalentId"] = new SelectList(_context.Talents, "TalentId", "TalentDescription");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserDescription");
            return View();
        }

        // POST: Admin/AdminBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CreateDate,BookingStatus,Description,UserId,TalentId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                _notifyService.Success("Tạo mới thành công");
                return RedirectToAction(nameof(Index));
            }
            ViewData["TalentId"] = new SelectList(_context.Talents, "TalentId", "TalentDescription", booking.TalentId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserDescription", booking.UserId);
            return View(booking);
        }

        // GET: Admin/AdminBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["TalentId"] = new SelectList(_context.Talents, "TalentId", "TalentDescription", booking.TalentId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserDescription", booking.UserId);
            return View(booking);
        }

        // POST: Admin/AdminBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,CreateDate,BookingStatus,Description,UserId,TalentId")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                    _notifyService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingId))
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
            ViewData["TalentId"] = new SelectList(_context.Talents, "TalentId", "TalentDescription", booking.TalentId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserDescription", booking.UserId);
            return View(booking);
        }

        // GET: Admin/AdminBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Talent)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Admin/AdminBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            _notifyService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
