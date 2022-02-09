using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vroom.Models
{
    public class VroomDbContext:IdentityDbContext<IdentityUser>
    {
        public VroomDbContext(DbContextOptions<VroomDbContext>options):base(options)
        {
        }
            public DbSet<BikeModel> BikeModels { get; set; }
            

    }
}
