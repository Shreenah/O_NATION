using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class Embassy
    {
        public int EmbassiesId { get; set; }
        public string EmbassiesName { get; set; } = null!;
        public string EmbassiesLocation { get; set; } = null!;
        public string? EmbassiesPhone { get; set; }
        public string? EmbassiesFax { get; set; }
        public string? EmbassiesMail { get; set; }
        public int? CountryId { get; set; }

        public virtual Country? Country { get; set; }
    }
}
