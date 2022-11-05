using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Beverages_Softdrinks_InventorySystem.Models;
using InventoryManagement.Data;

namespace InventoryManagement.Pages.Delivered
{
    public class DetailsModel : PageModel
    {
        private readonly InventoryManagement.Data.InventoryManagementContext _context;

        public DetailsModel(InventoryManagement.Data.InventoryManagementContext context)
        {
            _context = context;
        }

      public DeliveredDetails DeliveredDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeliveredDetails == null)
            {
                return NotFound();
            }

            var delivereddetails = await _context.DeliveredDetails.FirstOrDefaultAsync(m => m.ID == id);
            if (delivereddetails == null)
            {
                return NotFound();
            }
            else 
            {
                DeliveredDetails = delivereddetails;
            }
            return Page();
        }
    }
}
