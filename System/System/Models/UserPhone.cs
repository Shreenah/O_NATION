using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class UserPhone
    {
        public int UserId { get; set; }
        public string PhoneNum { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
