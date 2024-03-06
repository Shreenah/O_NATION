using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class Link
    {
        public int LinksId { get; set; }
        public string? LinksTitle { get; set; }
        public string? Links { get; set; }
        public int? PurposeId { get; set; }

        public virtual Purpose? Purpose { get; set; }
    }
}
