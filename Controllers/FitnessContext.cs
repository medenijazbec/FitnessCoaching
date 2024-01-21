using Fitness.Classes;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;


namespace Fitness.Controllers
{
    public class FitnessContext : DbContext
    {
        public FitnessContext(DbContextOptions<FitnessContext> options)
        : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Fitness.Classes.DietItem>? DietItem { get; set; }
    }


}

