using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

namespace TabApp.Pages_Repair
{
    public class IndexModel : PageModel
    {
        private readonly PagePersonContext _context;

        public IndexModel(PagePersonContext context)
        {
            _context = context;
        }

        public IList<Repair> Repair { get;set; }
        public IList<Item> Items { get;set; }

        public async Task OnGetAsync()
        {
            Repair = await _context.Repair.ToListAsync();
            Items = await _context.Item.ToListAsync();
        }
    }
}
