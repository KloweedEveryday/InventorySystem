using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Beverages_Softdrinks_InventorySystem.Models;
using InventoryManagement.Data;

namespace InventoryManagement.Pages.Delivered
{
    public class CreateModel : PageModel
    {
        private readonly InventoryManagement.Data.InventoryManagementContext _context;

        public CreateModel(InventoryManagement.Data.InventoryManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DeliveredDetails DeliveredDetails { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeliveredDetails.Add(DeliveredDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
