#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminHelper.Data;
using AdminHelper.Pages.Models;

namespace AdminHelper.Pages.Stock
{
    public class DeleteModel : PageModel
    {
        private readonly AdminHelper.Data.AdminHelperContext _context;

        public DeleteModel(AdminHelper.Data.AdminHelperContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StockModel = await _context.StockModel.FindAsync(id);

            if (StockModel != null)
            {
                _context.StockModel.Remove(StockModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
