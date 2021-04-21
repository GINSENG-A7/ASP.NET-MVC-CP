using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Lab1.Models
{
    public class ContextModel:DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Living> Livings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Apartments> Apartments { get; set; }
        public DbSet<AditionServices> AditionServices { get; set; }
        public DbSet<Photos> Photos { get; set; }
        public DbSet<ApartmentType> ApartmentTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        public ContextModel() : base("DefaultConnection")
        {
        }
    }
}