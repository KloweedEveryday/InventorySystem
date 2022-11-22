using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Beverages_Softdrinks_InventorySystem.Models;

namespace InventoryManagement.Data
{
    public class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext (DbContextOptions<InventoryManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Beverages_Softdrinks_InventorySystem.Models.Personel_Details> Personel_Details { get; set; } = default!;

        private DbSet<InventoryManagementContext> dATAS;

        public DbSet<Beverages_Softdrinks_InventorySystem.Models.DeliveredDetails> DeliveredDetails { get; set; }
        public DbSet<InventoryManagementContext> DATAS { get => dATAS; set => dATAS = value; }
    }
}