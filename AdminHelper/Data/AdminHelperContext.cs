#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AdminHelper.Pages.Models;
using AdminHelper.Models;

namespace AdminHelper.Data
{
    public class AdminHelperContext : DbContext
    {
        public AdminHelperContext (DbContextOptions<AdminHelperContext> options)
            : base(options)
        {
        }

        public DbSet<AdminHelper.Pages.Models.StockModel> StockModel { get; set; }

        public DbSet<AdminHelper.Models.EmployeeModel> EmployeeModel { get; set; }
    }
}
