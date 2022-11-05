using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beverages_Softdrinks_InventorySystem.Models;
using InventoryManagement.Data;

namespace InventoryManagement.Pages.Delivered
{
    public class EditModel : PageModel
    {
        private readonly InventoryManagement.Data.InventoryManagementContext _context;

        public EditModel(InventoryManagement.Data.InventoryManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeliveredDetails DeliveredDetails { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeliveredDetails == null)
            {
                return NotFound();
            }

            var delivereddetails =  await _context.DeliveredDetails.FirstOrDefaultAsync(m => m.ID == id);
            if (delivereddetails == null)
            {
                return NotFound();
            }
            DeliveredDetails = delivereddetails;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeliveredDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveredDetailsExists(DeliveredDetails.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeliveredDetailsExists(int id)
        {
          return _context.DeliveredDetails.Any(e => e.ID == id);
        }
    }
}
