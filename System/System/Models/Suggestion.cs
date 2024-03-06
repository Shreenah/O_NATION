using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class Suggestion
    {
        public int SuggestionId { get; set; }
        public string? SuggestionTitle { get; set; }
        public string? SuggestionDescription { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
