using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScriptureJournal2.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using ScriptureJournal2.Data;

namespace ScriptureJournal2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScriptureJournal2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ScriptureJournal2Context>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Alma",
                        Chapter = 32,
                        Verse = 28,
                        JournalEntry = "Faith is like a seed.",
                        Note = "I like this verse because..."
                    },

                    new Scripture
                    {
                        Book = "Mosiah",
                        Chapter = 2,
                        Verse = 27,
                        JournalEntry = "Even as I had served...",
                        Note = "I like this verse because..."
                    },

                    new Scripture
                    {
                        Book = "1st Nehpi",
                        Chapter = 3,
                        Verse = 7,
                        JournalEntry = "I will go and do.",
                        Note = "I like this verse because..."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

