using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

namespace TabApp.Pages_Worker
{
    public class DetailsModel : PageModel
    {
        private readonly PagePersonContext _context;

        public DetailsModel(PagePersonContext context)
        {
            _context = context;
        }

        public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _context.Worker.FirstOrDefaultAsync(m => m.PersonID == id);

            if (Worker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
