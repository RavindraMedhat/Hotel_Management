using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel_Management.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Hotel_Management.Controllers
{
    public class HotelTBsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;


        public HotelTBsController(AppDBContext context, IHostingEnvironment iHostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = iHostingEnvironment;
        }

        // GET: HotelTBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hotels.ToListAsync());
        }

        // GET: HotelTBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelTB = await _context.Hotels
                .FirstOrDefaultAsync(m => m.Hotel_ID == id);
            if (hotelTB == null)
            {
                return NotFound();
            }

            return View(hotelTB);
        }

        // GET: HotelTBs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelTBs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( HotelTB hotelTB,List<IFormFile> Photos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelTB);
                await _context.SaveChangesAsync();
                if (Photos != null && Photos.Count > 0)
                {
                    foreach (IFormFile photo in Photos)
                    {
                        String upfolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/hotels");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        String filePath = Path.Combine(upfolder, uniqueFileName);
                        using (var filesStrime = new FileStream(filePath, FileMode.Create))
                        {
                            photo.CopyTo(filesStrime);
                        }

                        ImageMasterTB im = new ImageMasterTB
                        {
                            Image_URl = uniqueFileName,
                            Reference_ID = hotelTB.Hotel_ID,
                            ReferenceTB_Name = "Hotel",
                            Active_Flag =true,
                            Delete_Flag = false,
                            Priority = 99
                        };
                        _context.Add(im);
                        await _context.SaveChangesAsync();

                    }

                }

                return RedirectToAction(nameof(Index));
            }
            return View(hotelTB);
        }

        // GET: HotelTBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelTB = await _context.Hotels.FindAsync(id);
            if (hotelTB == null)
            {
                return NotFound();
            }
            return View(hotelTB);
        }

        // POST: HotelTBs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Hotel_ID,Hotel_Name,Hotel_Description,Hotel_map_coordinate,Address,Contact_No,Email_Adderss,Contect_Person,Standard_check_In_Time,Standard_check_out_Time,Active_Flag,Delete_Flag,Priority")] HotelTB hotelTB)
        {
            if (id != hotelTB.Hotel_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelTB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelTBExists(hotelTB.Hotel_ID))
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
            return View(hotelTB);
        }

        // GET: HotelTBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelTB = await _context.Hotels
                .FirstOrDefaultAsync(m => m.Hotel_ID == id);
            if (hotelTB == null)
            {
                return NotFound();
            }

            return View(hotelTB);
        }

        // POST: HotelTBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelTB = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(hotelTB);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelTBExists(int id)
        {
            return _context.Hotels.Any(e => e.Hotel_ID == id);
        }
    }
}
