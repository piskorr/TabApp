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
    public class DeleteModel : PageModel
    {
        private readonly PagePersonContext _context;

        public DeleteModel(PagePersonContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _context.Worker.FindAsync(id);

            if (Worker != null)
            {
                _context.Worker.Remove(Worker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
