using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal2.Models;

namespace ScriptureJournal2.Data
{
    public class ScriptureJournal2Context : DbContext
    {
        public ScriptureJournal2Context (DbContextOptions<ScriptureJournal2Context> options)
            : base(options)
        {
        }

        public DbSet<ScriptureJournal2.Models.Scripture> Scripture { get; set; }
    }
}
