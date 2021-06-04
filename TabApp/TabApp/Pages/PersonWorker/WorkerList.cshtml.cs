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
    public class WorkerListModel : PageModel
    {
        private readonly PagePersonContext _context;
        private IList<Person> Persons { get; set; }
        private IList<Worker> Workers { get; set; }
        public IList<Person> PersonWorker = new List<Person>();

        public WorkerListModel(PagePersonContext context)
        {
            _context = context;
        }


        public async Task OnGetAsync()
        {
            Persons = await _context.Person.ToListAsync();
            Workers = await _context.Worker.ToListAsync();

            foreach (Person item in Persons)
            {
                
                if (item.Worker != null)
                {
                    PersonWorker.Add(item);
                }
            }
        }
    }
}
