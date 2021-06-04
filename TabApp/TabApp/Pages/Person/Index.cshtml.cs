using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TabApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TabApp.Pages_Person
{
    public class IndexModel : PageModel
    {
        private readonly PagePersonContext _context;

        public IndexModel(PagePersonContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        

        public async Task OnGetAsync()
        {
            var persons = from p in _context.Person select p;
            if(!string.IsNullOrEmpty(SearchString))
            {
                persons = persons.Where(s => (s.Surname).ToLower().Contains(SearchString.ToLower()));
            }

            Person = await persons.ToListAsync() ;
        }
    }
}
