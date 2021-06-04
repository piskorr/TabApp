using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;

namespace TabApp.Pages_PersonWorker
{
    public class EditModel : PageModel
    {
        private readonly PagePersonContext _context;

        public EditModel(PagePersonContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PersonWorker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonWorkerExists(PersonWorker.ID))
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

        private bool PersonWorkerExists(int id)
        {
            return _context.PersonWorker.Any(e => e.ID == id);
        }
    }
}
