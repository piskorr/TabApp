using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

namespace TabApp.Pages_Invoice
{
    public class IndexModel : PageModel
    {
        private readonly PagePersonContext _context;

        public IndexModel(PagePersonContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoice { get;set; }

        public async Task OnGetAsync()
        {
            Invoice = await _context.Invoice.ToListAsync();
        }
    }
}
