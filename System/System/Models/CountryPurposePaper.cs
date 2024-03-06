using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class CountryPurposePaper
    {
        public int CountryId { get; set; }
        public int PaperId { get; set; }
        public int PurposeId { get; set; }
        public string? Details { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual Paper Paper { get; set; } = null!;
        public virtual Purpose Purpose { get; set; } = null!;
    }
}
