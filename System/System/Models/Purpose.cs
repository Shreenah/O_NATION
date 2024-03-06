using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class Purpose
    {
        public Purpose()
        {
            CountryPurposePapers = new HashSet<CountryPurposePaper>();
            Links = new HashSet<Link>();
            Users = new HashSet<User>();
        }

        public int PurposeId { get; set; }
        public string PurposeName { get; set; } = null!;
        public string PurposeType { get; set; } = null!;

        public virtual ICollection<CountryPurposePaper> CountryPurposePapers { get; set; }
        public virtual ICollection<Link> Links { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
