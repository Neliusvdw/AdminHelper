#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AdminHelper.Data;
using AdminHelper.Models;

namespace AdminHelper.Pages.Employee
{
    public class DetailsModel : PageModel
    {
        private readonly AdminHelper.Data.AdminHelperContext _context;

        public DetailsModel(AdminHelper.Data.AdminHelperContext context)
        {
            _context = context;
        }

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
    }
}
