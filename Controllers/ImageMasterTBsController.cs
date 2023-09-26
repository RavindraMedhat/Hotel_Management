using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Management.Models;
using Hotel_Management.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Hotel_Management.Controllers
{
    public class ImageMasterTBsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IHostingEnvironment _IHostingEnvironment;


        public ImageMasterTBsController(AppDBContext context, IHostingEnvironment iHostingEnvironment)
        {
            _context = context;
            _IHostingEnvironment= iHostingEnvironment;
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
        public async Task<IActionResult> Create(ImageViewModel imageMasterViewTB)
        {

            if (ModelState.IsValid)
            {
                string uniquefilename = null;
                if(imageMasterViewTB.Image_URl != null)
                {
                    string uploadsfolder = Path.Combine(_IHostingEnvironment.WebRootPath, "images/hotels");

                    uniquefilename = Guid.NewGuid().ToString() + "_" + imageMasterViewTB.Reference_ID + "_" + imageMasterViewTB.Image_URl.FileName;
                    string filepath = Path.Combine(uploadsfolder, uniquefilename);

                    imageMasterViewTB.Image_URl.CopyTo(new FileStream(filepath, FileMode.Create));

                }
                ImageMasterTB im = new ImageMasterTB
                {
                    Image_URl = uniquefilename,
                    Reference_ID = imageMasterViewTB.Reference_ID,
                    ReferenceTB_Name = imageMasterViewTB.ReferenceTB_Name,
                    Active_Flag = imageMasterViewTB.Active_Flag,
                    Delete_Flag = imageMasterViewTB.Delete_Flag,
                    Priority = imageMasterViewTB.Priority
                };
                _context.Add(im);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details),new { id = im.Image_ID});
            }
            return View();
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
