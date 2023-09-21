using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_Management.Models;

namespace Hotel_Management.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options  ):base(options) 
        {

        }

        public DbSet<HotelTB> Hotels { get; set; }

        public DbSet<Hotel_Management.Models.HotelBranchTB> HotelBranchTB { get; set; }

        public DbSet<Hotel_Management.Models.ImageMasterTB> ImageMasterTB { get; set; }
    }
}
