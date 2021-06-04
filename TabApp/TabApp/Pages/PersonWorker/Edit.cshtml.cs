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

        [BindProperty]
        public Person Person { get; set; }
        [BindProperty]
        public Worker Worker { get; set; }

        public EditModel(PagePersonContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.Person.FirstOrDefaultAsync(m => m.ID == id);
            Worker = await _context.Worker.FirstOrDefaultAsync(m => m.PersonID == id);

            if (Person == null)
            {
                return NotFound();
            }
            if (Worker == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Person).State = EntityState.Modified;
            _context.Attach(Worker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.ID))
                {
                    return NotFound();
                }
                else if (!WorkerExists(Person.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./WorkerList");
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.ID == id);
        }

        private bool WorkerExists(int id)
        {
            return _context.Worker.Any(e => e.PersonID == id);
        }
    }
}
