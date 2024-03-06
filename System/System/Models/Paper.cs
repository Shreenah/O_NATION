using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class Paper
    {
        public Paper()
        {
            CountryPurposePapers = new HashSet<CountryPurposePaper>();
            Users = new HashSet<User>();
        }

        public int PaperId { get; set; }
        public string PaperName { get; set; } = null!;
        public string? PaperPlace { get; set; }

        public virtual ICollection<CountryPurposePaper> CountryPurposePapers { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
