using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class CountryImage
    {
        public int CountryId { get; set; }
        public int ImageId { get; set; }
        public string ImageData { get; set; } = null!;

        public virtual Country Country { get; set; } = null!;
    }
}
