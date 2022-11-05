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

namespace InventoryManagement.Pages.Personel
{
    public class EditModel : PageModel
    {
        private readonly InventoryManagement.Data.InventoryManagementContext _context;

        public EditModel(InventoryManagement.Data.InventoryManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Personel_Details Personel_Details { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personel_Details == null)
            {
                return NotFound();
            }

            var personel_details =  await _context.Personel_Details.FirstOrDefaultAsync(m => m.ID == id);
            if (personel_details == null)
            {
                return NotFound();
            }
            Personel_Details = personel_details;
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

            _context.Attach(Personel_Details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Personel_DetailsExists(Personel_Details.ID))
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

        private bool Personel_DetailsExists(int id)
        {
          return _context.Personel_Details.Any(e => e.ID == id);
        }
    }
}
