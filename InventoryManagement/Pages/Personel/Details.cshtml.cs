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
    public class DetailsModel : PageModel
    {
        private readonly InventoryManagement.Data.InventoryManagementContext _context;

        public DetailsModel(InventoryManagement.Data.InventoryManagementContext context)
        {
            _context = context;
        }

      public Personel_Details Personel_Details { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personel_Details == null)
            {
                return NotFound();
            }

            var personel_details = await _context.Personel_Details.FirstOrDefaultAsync(m => m.ID == id);
            if (personel_details == null)
            {
                return NotFound();
            }
            else 
            {
                Personel_Details = personel_details;
            }
            return Page();
        }
    }
}
