using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ScriptureJournal2.Models
{
    public class Scripture
{
    public int ID { get; set; }
    public string Book { get; set; }
    public int Chapter { get; set; }
    public int Verse { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateAdded { get; set; }
    public string JournalEntry { get; set; }
    public string Note { get; set; }
}
}
