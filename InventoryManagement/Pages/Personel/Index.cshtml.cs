using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beverages_Softdrinks_InventorySystem.Models;
using InventoryManagement.Data;

namespace InventoryManagement.Pages.Personel
{
    public class IndexModel : PageModel
    {
        private readonly InventoryManagement.Data.InventoryManagementContext _context;

        public IndexModel(InventoryManagement.Data.InventoryManagementContext context)
        {
            _context = context;
        }

        public IList<Personel_Details> Personel_Details { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Personel_Details != null)
            {
                Personel_Details = await _context.Personel_Details.ToListAsync();
            }
        }
    }
}
