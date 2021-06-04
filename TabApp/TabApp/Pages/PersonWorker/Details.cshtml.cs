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

        public DetailsModel(PagePersonContext context)
        {
            _context = context;
        }

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
    }
}
