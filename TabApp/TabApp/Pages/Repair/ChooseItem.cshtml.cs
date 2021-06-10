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
    public class ChooseItemModel : PageModel
    {
        private readonly PagePersonContext _context;

        [BindProperty]
        public IList<Item> Item { get;set; }

        public ChooseItemModel(PagePersonContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Item = await _context.Item.ToListAsync();
        }
    }
}
