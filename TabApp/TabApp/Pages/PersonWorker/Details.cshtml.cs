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
    public class DetailsModel : PageModel
    {
        private readonly PagePersonContext _context;
        public Person _Person { get; set; }
        private Worker _Worker { get; set; }

        public DetailsModel(PagePersonContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _Person = await _context.Person.FirstOrDefaultAsync(m => m.ID == id);
            _Worker = await _context.Worker.FirstOrDefaultAsync(m => m.PersonID == id);

            if (_Person == null)
            {
                return NotFound();
            }
             if (_Worker == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
