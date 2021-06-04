using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

namespace TabApp.Pages_PersonWorker
{
    public class DeleteModel : PageModel
    {
        private readonly PagePersonContext _context;

        public DeleteModel(PagePersonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonWorker PersonWorker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonWorker = await _context.PersonWorker.FirstOrDefaultAsync(m => m.ID == id);

            if (PersonWorker == null)
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

            PersonWorker = await _context.PersonWorker.FindAsync(id);

            if (PersonWorker != null)
            {
                _context.PersonWorker.Remove(PersonWorker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
