using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.Models
{
    class JournalEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Entry { get; set; }
        public DateTime dateCreated { get; set; }

    }
}
