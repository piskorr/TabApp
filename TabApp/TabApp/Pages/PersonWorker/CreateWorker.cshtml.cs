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
    public class CreateWorkerModel : PageModel
    {
        private readonly PagePersonContext _context;

        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        public CreateWorkerModel(PagePersonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            ID = id;
            return Page();
        }

        [BindProperty]
        public Worker Worker { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            // if (!ModelState.IsValid)
            // {
                
            //     Console.WriteLine(Person.Name);
            //     return Page();
            // }
            
            _context.Worker.Add(Worker);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
