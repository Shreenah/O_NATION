using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class TouristicPlace
    {
        public int CountryId { get; set; }
        public string PlaceName { get; set; } = null!;
        public string? PlaceImage { get; set; }

        public virtual Country Country { get; set; } = null!;
    }
}
