using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentManager.Domain.Entities;

namespace EquipmentManager.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}
