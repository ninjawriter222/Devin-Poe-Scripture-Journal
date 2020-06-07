using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal2.Models;
using ScriptureJournal2.Data;

namespace ScriptureJournal2.Pages.Scriptures
{
    public class DetailsModel : PageModel
    {
        private readonly ScriptureJournal2.Data.ScriptureJournal2Context _context;

        public DetailsModel(ScriptureJournal2.Data.ScriptureJournal2Context context)
        {
            _context = context;
        }

        public Scripture Scripture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scripture = await _context.Scripture.FirstOrDefaultAsync(m => m.ID == id);

            if (Scripture == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
