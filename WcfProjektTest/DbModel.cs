using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WcfProjektTest
{
    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<Cases> Cases { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cases>()
                .Property(e => e.lat)
                .IsUnicode(false);

            modelBuilder.Entity<Cases>()
                .Property(e => e.lng)
                .IsUnicode(false);

            modelBuilder.Entity<Cases>()
                .Property(e => e.contact_phone)
                .IsUnicode(false);

            modelBuilder.Entity<Cases>()
                .Property(e => e.contact_email)
                .IsUnicode(false);

            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Cases)
                .WithRequired(e => e.Categories)
                .HasForeignKey(e => e.category);

            modelBuilder.Entity<Users>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
