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
    public class ImageMasterTBsController : Controller
    {
        private readonly AppDBContext _context;

        public ImageMasterTBsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: ImageMasterTBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ImageMasterTB.ToListAsync());
        }

        // GET: ImageMasterTBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageMasterTB = await _context.ImageMasterTB
                .FirstOrDefaultAsync(m => m.Image_ID == id);
            if (imageMasterTB == null)
            {
                return NotFound();
            }

            return View(imageMasterTB);
        }

        // GET: ImageMasterTBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ImageMasterTBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Image_ID,Image_URl,Reference_ID,ReferenceTB_Name,Active_Flag,Delete_Flag,Priority")] ImageMasterTB imageMasterTB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imageMasterTB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imageMasterTB);
        }

        // GET: ImageMasterTBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageMasterTB = await _context.ImageMasterTB.FindAsync(id);
            if (imageMasterTB == null)
            {
                return NotFound();
            }
            return View(imageMasterTB);
        }

        // POST: ImageMasterTBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Image_ID,Image_URl,Reference_ID,ReferenceTB_Name,Active_Flag,Delete_Flag,Priority")] ImageMasterTB imageMasterTB)
        {
            if (id != imageMasterTB.Image_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imageMasterTB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageMasterTBExists(imageMasterTB.Image_ID))
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
            return View(imageMasterTB);
        }

        // GET: ImageMasterTBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imageMasterTB = await _context.ImageMasterTB
                .FirstOrDefaultAsync(m => m.Image_ID == id);
            if (imageMasterTB == null)
            {
                return NotFound();
            }

            return View(imageMasterTB);
        }

        // POST: ImageMasterTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageMasterTB = await _context.ImageMasterTB.FindAsync(id);
            _context.ImageMasterTB.Remove(imageMasterTB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageMasterTBExists(int id)
        {
            return _context.ImageMasterTB.Any(e => e.Image_ID == id);
        }
    }
}
