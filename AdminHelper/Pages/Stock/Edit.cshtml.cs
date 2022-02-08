#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminHelper.Data;
using AdminHelper.Pages.Models;

namespace AdminHelper.Pages.Stock
{
    public class EditModel : PageModel
    {
        private readonly AdminHelper.Data.AdminHelperContext _context;

        public EditModel(AdminHelper.Data.AdminHelperContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StockModel StockModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StockModel = await _context.StockModel.FirstOrDefaultAsync(m => m.ID == id);

            if (StockModel == null)
            {
                return NotFound();
            }
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

            _context.Attach(StockModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockModelExists(StockModel.ID))
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

        private bool StockModelExists(int id)
        {
            return _context.StockModel.Any(e => e.ID == id);
        }
    }
}
