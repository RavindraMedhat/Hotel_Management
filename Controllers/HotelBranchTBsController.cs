using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Management.Models;

namespace Hotel_Management.Controllers
{
    public class HotelBranchTBsController : Controller
    {
        private readonly AppDBContext _context;

        public HotelBranchTBsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: HotelBranchTBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotelBranchTB.ToListAsync());
        }

        // GET: HotelBranchTBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelBranchTB = await _context.HotelBranchTB
                .FirstOrDefaultAsync(m => m.Branch_ID == id);
            if (hotelBranchTB == null)
            {
                return NotFound();
            }

            return View(hotelBranchTB);
        }

        // GET: HotelBranchTBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelBranchTBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Branch_ID,Hotel_ID,Branch_Name,Branch_Description,Branch_Images,Branch_map_coordinate,Branch_Address,Branch_Contact_No,Branch_Email_Adderss,Branch_Contect_Person,Active_Flag,Delete_Flag,Priority")] HotelBranchTB hotelBranchTB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelBranchTB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelBranchTB);
        }

        // GET: HotelBranchTBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelBranchTB = await _context.HotelBranchTB.FindAsync(id);
            if (hotelBranchTB == null)
            {
                return NotFound();
            }
            return View(hotelBranchTB);
        }

        // POST: HotelBranchTBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Branch_ID,Hotel_ID,Branch_Name,Branch_Description,Branch_Images,Branch_map_coordinate,Branch_Address,Branch_Contact_No,Branch_Email_Adderss,Branch_Contect_Person,Active_Flag,Delete_Flag,Priority")] HotelBranchTB hotelBranchTB)
        {
            if (id != hotelBranchTB.Branch_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelBranchTB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelBranchTBExists(hotelBranchTB.Branch_ID))
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
            return View(hotelBranchTB);
        }

        // GET: HotelBranchTBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelBranchTB = await _context.HotelBranchTB
                .FirstOrDefaultAsync(m => m.Branch_ID == id);
            if (hotelBranchTB == null)
            {
                return NotFound();
            }

            return View(hotelBranchTB);
        }

        // POST: HotelBranchTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelBranchTB = await _context.HotelBranchTB.FindAsync(id);
            _context.HotelBranchTB.Remove(hotelBranchTB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelBranchTBExists(int id)
        {
            return _context.HotelBranchTB.Any(e => e.Branch_ID == id);
        }
    }
}
