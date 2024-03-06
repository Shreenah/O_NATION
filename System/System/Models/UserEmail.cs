using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class UserEmail
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
