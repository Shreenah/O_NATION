using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class CountryGroup
    {
        public int CountryId { get; set; }
        public string CountryGroup1 { get; set; } = null!;
        public string CountyName { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;
    }
}
