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
    public class CreateRepairModel : PageModel
    {
        private readonly PagePersonContext _context;

        [BindProperty]
        public Repair Repair { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int ID { get; set; }

        [BindProperty]
        public Item Item { get; set; }


        public CreateRepairModel(PagePersonContext context)
        {
            _context = context;
        } 

        public IActionResult OnGetAsync(int id)
        {
            ID = id;                   
            Item =  _context.Item.FirstOrDefault(m => m.ID == ID);                        
            return Page();
        }       

        public async Task<IActionResult> OnPostAsync()
        {   
            _context.Repair.Add(Repair);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
