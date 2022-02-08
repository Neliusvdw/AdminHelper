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
    public class IndexModel : PageModel
    {
        private readonly AdminHelper.Data.AdminHelperContext _context;

        public IndexModel(AdminHelper.Data.AdminHelperContext context)
        {
            _context = context;
        }

        public IList<EmployeeModel> EmployeeModel { get;set; }

        public async Task OnGetAsync()
        {
            EmployeeModel = await _context.EmployeeModel.ToListAsync();
        }
    }
}
