using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TabApp.Models;

namespace TabApp.Pages_Repair
{
    public class AddRepairModel : PageModel
    {
        private readonly PagePersonContext _context;

        public AddRepairModel(PagePersonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }


        // // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        // public async Task<IActionResult> OnPostAsync()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     _context.Repair.Add(Repair);
        //     await _context.SaveChangesAsync();

        //     return RedirectToPage("./Index");
        // }
    }
}
