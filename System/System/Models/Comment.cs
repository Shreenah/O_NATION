using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentData { get; set; } = null!;
        public string? UserPhoto { get; set; }
        public int? CountryId { get; set; }
        public int? UserId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual User? User { get; set; }
    }
}
