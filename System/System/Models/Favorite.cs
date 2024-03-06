using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
    }
}
