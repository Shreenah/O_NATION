using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class Suggestion
    {
        public string SuggestionId { get; set; }
        public string? SuggestionTitle { get; set; }
        public string? SuggestionDescription { get; set; }
        public string? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
