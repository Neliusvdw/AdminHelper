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
using AdminHelper.Models;

namespace AdminHelper.Pages.Employee
{
    public class EditModel : PageModel
    {
        private readonly AdminHelper.Data.AdminHelperContext _context;

        public EditModel(AdminHelper.Data.AdminHelperContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmployeeModel EmployeeModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmployeeModel = await _context.EmployeeModel.FirstOrDefaultAsync(m => m.ID == id);

            if (EmployeeModel == null)
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

            _context.Attach(EmployeeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelExists(EmployeeModel.ID))
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

        private bool EmployeeModelExists(int id)
        {
            return _context.EmployeeModel.Any(e => e.ID == id);
        }
    }
}
