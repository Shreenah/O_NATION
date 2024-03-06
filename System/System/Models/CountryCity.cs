using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class CountryCity
    {
        public int CountryId { get; set; }
        public string CountryCity1 { get; set; } = null!;
        public string? CityImage { get; set; }

        public virtual Country Country { get; set; } = null!;
    }
}
