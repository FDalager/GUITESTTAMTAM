using System;
using System.Collections.Generic;
using System.Text;
using GUI_EX2_Buffet.Data.DBModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GUI_EX2_Buffet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BreakfastReservations> BreakfastReservations { get; set; }
        public DbSet<CheckInStatus> CheckInStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<BreakfastReservations>().HasKey(Br => Br.Room);

            
            mb.Entity<CheckInStatus>()
                .HasOne(C => C.BreakfastReservation)
                .WithOne(C => C.CheckInStatuses)
                .HasForeignKey<BreakfastReservations>(C => C.Room);

            mb.Entity<CheckInStatus>().HasKey(C => C.Room);

            base.OnModelCreating(mb);
        }
    }
}
