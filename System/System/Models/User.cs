using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace System.Models
{
    public partial class User : IdentityUser//<int>
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Suggestions = new HashSet<Suggestion>();
            UserEmails = new HashSet<UserEmail>();
            UserPhones = new HashSet<UserPhone>();
            Papers = new HashSet<Paper>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string? NewPassword { get; set; }
        public string? UserPhoto { get; set; }
        public int? Rating { get; set; }
        public int? CountryId { get; set; }
        public int? PurposeId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual Purpose? Purpose { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Suggestion> Suggestions { get; set; }
        public virtual ICollection<UserEmail> UserEmails { get; set; }
        public virtual ICollection<UserPhone> UserPhones { get; set; }

        public virtual ICollection<Paper> Papers { get; set; }
    }
}
