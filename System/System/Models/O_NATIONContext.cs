using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace System.Models
{
    public partial class O_NATIONContext : DbContext
    {
        public O_NATIONContext()
        {
        }

        public O_NATIONContext(DbContextOptions<O_NATIONContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutU> AboutUs { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<CountryCity> CountryCities { get; set; } = null!;
        public virtual DbSet<CountryGroup> CountryGroups { get; set; } = null!;
        public virtual DbSet<CountryImage> CountryImages { get; set; } = null!;
        public virtual DbSet<CountryPurposePaper> CountryPurposePapers { get; set; } = null!;
        public virtual DbSet<Embassy> Embassies { get; set; } = null!;
        public virtual DbSet<Favorite> Favorites { get; set; } = null!;
        public virtual DbSet<Link> Links { get; set; } = null!;
        public virtual DbSet<Paper> Papers { get; set; } = null!;
        public virtual DbSet<Purpose> Purposes { get; set; } = null!;
        public virtual DbSet<Suggestion> Suggestions { get; set; } = null!;
        public virtual DbSet<TouristicPlace> TouristicPlaces { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserEmail> UserEmails { get; set; } = null!;
        public virtual DbSet<UserPhone> UserPhones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NJ8KFPN;Initial Catalog=O_NATION;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AboutU>(entity =>
            {
                entity.HasKey(e => e.AboutUsId)
                    .HasName("PK__ABOUT_US__14521528C2CC178F");

                entity.ToTable("ABOUT_US");

                entity.Property(e => e.AboutUsId).HasColumnName("About_Us_ID");

                entity.Property(e => e.OurApp)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("Our_APP");

                entity.Property(e => e.WhoAreWe)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("Who_Are_We");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENT");

                entity.Property(e => e.CommentId).HasColumnName("Comment_ID");

                entity.Property(e => e.CommentData)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Comment_Data");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.UserPhoto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("User_Photo");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__COMMENT__Country__4E88ABD4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__COMMENT__User_ID__4F7CD00D");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.CountryContinent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Country_Continent");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Country_Name");

                entity.Property(e => e.CountryNotes)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("Country_Notes");
            });

            modelBuilder.Entity<CountryCity>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.CountryCity1 })
                    .HasName("PK__COUNTRY___0A4335149C4B9B0A");

                entity.ToTable("COUNTRY_CITIES");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.CountryCity1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Country_City");

                entity.Property(e => e.CityImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("City_Image");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryCities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COUNTRY_C__Count__3B75D760");
            });

            modelBuilder.Entity<CountryGroup>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.CountryGroup1 })
                    .HasName("PK__COUNTRY___B597CE1D1F6A12EF");

                entity.ToTable("COUNTRY_GROUP");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.CountryGroup1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Country_Group");

                entity.Property(e => e.CountyName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("County_Name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryGroups)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COUNTRY_G__Count__38996AB5");
            });

            modelBuilder.Entity<CountryImage>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.ImageId })
                    .HasName("PK__COUNTRY___03FC7F9DF5BD4F1A");

                entity.ToTable("COUNTRY_IMAGES");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.ImageId).HasColumnName("Image_ID");

                entity.Property(e => e.ImageData)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Image_Data");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryImages)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COUNTRY_I__Count__3E52440B");
            });

            modelBuilder.Entity<CountryPurposePaper>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.PaperId, e.PurposeId })
                    .HasName("PK__COUNTRY___53CACEC2B5A223DF");

                entity.ToTable("COUNTRY_PURPOSE_PAPER");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.PaperId).HasColumnName("Paper_ID");

                entity.Property(e => e.PurposeId).HasColumnName("Purpose_ID");

                entity.Property(e => e.Details)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.CountryPurposePapers)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COUNTRY_P__Count__60A75C0F");

                entity.HasOne(d => d.Paper)
                    .WithMany(p => p.CountryPurposePapers)
                    .HasForeignKey(d => d.PaperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COUNTRY_P__Paper__5EBF139D");

                entity.HasOne(d => d.Purpose)
                    .WithMany(p => p.CountryPurposePapers)
                    .HasForeignKey(d => d.PurposeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COUNTRY_P__Purpo__5FB337D6");
            });

            modelBuilder.Entity<Embassy>(entity =>
            {
                entity.HasKey(e => e.EmbassiesId)
                    .HasName("PK__EMBASSIE__54B2753C40F611BA");

                entity.ToTable("EMBASSIES");

                entity.Property(e => e.EmbassiesId).HasColumnName("Embassies_ID");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.EmbassiesFax)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Embassies_Fax");

                entity.Property(e => e.EmbassiesLocation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Embassies_Location");

                entity.Property(e => e.EmbassiesMail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Embassies_Mail");

                entity.Property(e => e.EmbassiesName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Embassies_Name");

                entity.Property(e => e.EmbassiesPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Embassies_Phone");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Embassies)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__EMBASSIES__Count__6383C8BA");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.FavoriteId })
                    .HasName("PK__FAVORITE__E77F3114A7E6C714");

                entity.ToTable("FAVORITE");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.FavoriteId).HasColumnName("Favorite_ID");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FAVORITE__Countr__4222D4EF");
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(e => e.LinksId)
                    .HasName("PK__LINKS__2AE55795199278D1");

                entity.ToTable("LINKS");

                entity.Property(e => e.LinksId).HasColumnName("Links_ID");

                entity.Property(e => e.Links)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.LinksTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Links_Title");

                entity.Property(e => e.PurposeId).HasColumnName("Purpose_ID");

                entity.HasOne(d => d.Purpose)
                    .WithMany(p => p.Links)
                    .HasForeignKey(d => d.PurposeId)
                    .HasConstraintName("FK__LINKS__Purpose_I__6B24EA82");
            });

            modelBuilder.Entity<Paper>(entity =>
            {
                entity.ToTable("PAPER");

                entity.Property(e => e.PaperId).HasColumnName("Paper_ID");

                entity.Property(e => e.PaperName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Paper_Name");

                entity.Property(e => e.PaperPlace)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Paper_Place");
            });

            modelBuilder.Entity<Purpose>(entity =>
            {
                entity.ToTable("PURPOSE");

                entity.Property(e => e.PurposeId).HasColumnName("Purpose_ID");

                entity.Property(e => e.PurposeName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Purpose_Name");

                entity.Property(e => e.PurposeType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Purpose_Type");
            });

            modelBuilder.Entity<Suggestion>(entity =>
            {
                entity.ToTable("SUGGESTION");

                entity.Property(e => e.SuggestionId).HasColumnName("Suggestion_ID");

                entity.Property(e => e.SuggestionDescription)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("Suggestion_Description");

                entity.Property(e => e.SuggestionTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Suggestion_Title");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Suggestions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__SUGGESTIO__User___66603565");
            });

            modelBuilder.Entity<TouristicPlace>(entity =>
            {
                entity.HasKey(e => new { e.CountryId, e.PlaceName })
                    .HasName("PK__TOURISTI__AD46DB9724ECF0D8");

                entity.ToTable("TOURISTIC_PLACES");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.PlaceName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Place_Name");

                entity.Property(e => e.PlaceImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Place_Image");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TouristicPlaces)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TOURISTIC__Count__44FF419A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("_USER");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.NewPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("New_Password");

                entity.Property(e => e.PurposeId).HasColumnName("Purpose_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");

                entity.Property(e => e.UserPhoto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("User_Photo");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK___USER__Country_I__4AB81AF0");

                entity.HasOne(d => d.Purpose)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PurposeId)
                    .HasConstraintName("FK___USER__Purpose_I__4BAC3F29");

                entity.HasMany(d => d.Papers)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserPaper",
                        l => l.HasOne<Paper>().WithMany().HasForeignKey("PaperId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__USER_PAPE__Paper__5AEE82B9"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__USER_PAPE__User___59FA5E80"),
                        j =>
                        {
                            j.HasKey("UserId", "PaperId").HasName("PK__USER_PAP__5E664E5054415147");

                            j.ToTable("USER_PAPER");

                            j.IndexerProperty<int>("UserId").HasColumnName("User_ID");

                            j.IndexerProperty<int>("PaperId").HasColumnName("Paper_ID");
                        });
            });

            modelBuilder.Entity<UserEmail>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Email })
                    .HasName("PK__USER_EMA__6AF081C3B5C3A702");

                entity.ToTable("USER_EMAIL");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEmails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USER_EMAI__User___5535A963");
            });

            modelBuilder.Entity<UserPhone>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PhoneNum })
                    .HasName("PK__USER_PHO__8731B683589F7A54");

                entity.ToTable("USER_PHONE");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Phone_Num");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPhones)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USER_PHON__User___52593CB8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
