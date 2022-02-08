#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AdminHelper.Data;
using AdminHelper.Pages.Models;

namespace AdminHelper.Pages.Stock
{
    public class CreateModel : PageModel
    {
        private readonly AdminHelper.Data.AdminHelperContext _context;

        public CreateModel(AdminHelper.Data.AdminHelperContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StockModel StockModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StockModel.Add(StockModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
