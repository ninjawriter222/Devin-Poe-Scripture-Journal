using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal2.Models;
using ScriptureJournal2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ScriptureJournal2.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournal2.Data.ScriptureJournal2Context _context;

        public IndexModel(ScriptureJournal2.Data.ScriptureJournal2Context context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }
        public IList<Scripture> DateAdded { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString2 { get; set; }


        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from s in _context.Scripture
                                            orderby s.Book
                                            select s.Book;

            var scriptures1 = from s in _context.Scripture
                         select s;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures1 = scriptures1.Where(j => j.JournalEntry.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SearchString2))
            {
                scriptures1 = scriptures1.Where(i => i.DateAdded == Convert.ToDateTime(SearchString2));
            }
            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures1 = scriptures1.Where(x => x.Book == ScriptureBook);
            }
            Book = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures1.ToListAsync();
            DateAdded = await scriptures1.ToListAsync();
        }
    }
}
