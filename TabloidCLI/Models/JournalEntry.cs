using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDateTime { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
