namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelDB : DbContext
    {
        public HotelDB()
            : base("name=HotelDB")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<Modifier> Modifier { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Login)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Guest)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Surname)
                .IsFixedLength();

            modelBuilder.Entity<Guest>()
                .Property(e => e.GuestName)
                .IsFixedLength();

            modelBuilder.Entity<Guest>()
                .Property(e => e.Patronymic)
                .IsFixedLength();

            modelBuilder.Entity<Guest>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Modifier>()
                .Property(e => e.ModifierName)
                .IsFixedLength();

            modelBuilder.Entity<Modifier>()
                .HasMany(e => e.Account)
                .WithRequired(e => e.Modifier)
                .WillCascadeOnDelete(false);
        }
    }
}
