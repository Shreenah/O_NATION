using System;
using System.Collections.Generic;
using System.Models;



   
        

namespace System.Models
{
    public partial class Country
    {
        public Country()
        {
            Comments = new HashSet<Comment>();
            CountryCities = new HashSet<CountryCity>();
            CountryGroups = new HashSet<CountryGroup>();
            CountryImages = new HashSet<CountryImage>();
            CountryPurposePapers = new HashSet<CountryPurposePaper>();
            Embassies = new HashSet<Embassy>();
            Favorites = new HashSet<Favorite>();
            TouristicPlaces = new HashSet<TouristicPlace>();
            Users = new HashSet<User>();
        }

       
        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;
        public string? CountryContinent { get; set; }
        public string? CountryNotes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CountryCity> CountryCities { get; set; }
        public virtual ICollection<CountryGroup> CountryGroups { get; set; }
        public virtual ICollection<CountryImage> CountryImages { get; set; }
        public virtual ICollection<CountryPurposePaper> CountryPurposePapers { get; set; }
        public virtual ICollection<Embassy> Embassies { get; set; }
        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<TouristicPlace> TouristicPlaces { get; set; }
        public virtual ICollection<User> Users { get; set; }

      }
}


