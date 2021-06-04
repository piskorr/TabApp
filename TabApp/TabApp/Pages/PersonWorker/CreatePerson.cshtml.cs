using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TabApp.Models;

namespace TabApp.Pages_PersonWorker
{
    public class CreatePersonModel : PageModel
    {
        private readonly PagePersonContext _context;

        public CreatePersonModel(PagePersonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // if (!ModelState.IsValid)
            // {
                
            //     Console.WriteLine(Person.Name);
            //     return Page();
            // }

            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CreateWorker",(new { id = Person.ID }));
            
        }
    }
}
