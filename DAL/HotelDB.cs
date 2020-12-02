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
        public virtual DbSet<CheckIn> CheckIn { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<Modifier> Modifier { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<CheckInGuest> CheckInGuest { get; set; }
        public virtual DbSet<CheckInServices> CheckInServices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Login)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Surname)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Patronymic)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .HasMany(e => e.CheckIn)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.LastEmployeeId);

            modelBuilder.Entity<CheckIn>()
                .HasMany(e => e.CheckInGuest)
                .WithRequired(e => e.CheckIn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CheckIn>()
                .HasMany(e => e.CheckInServices)
                .WithRequired(e => e.CheckIn)
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

            modelBuilder.Entity<Guest>()
                .Property(e => e.GuestDocument)
                .IsFixedLength();

            modelBuilder.Entity<Guest>()
                .HasMany(e => e.CheckInGuest)
                .WithRequired(e => e.Guest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Modifier>()
                .Property(e => e.ModifierName)
                .IsFixedLength();

            modelBuilder.Entity<Modifier>()
                .HasMany(e => e.Account)
                .WithRequired(e => e.Modifier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.CheckIn)
                .WithRequired(e => e.Room)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoomType>()
                .Property(e => e.TypeName)
                .IsFixedLength();

            modelBuilder.Entity<RoomType>()
                .HasMany(e => e.Room)
                .WithRequired(e => e.RoomType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.ServiceName)
                .IsFixedLength();

            modelBuilder.Entity<Service>()
                .HasMany(e => e.CheckInServices)
                .WithRequired(e => e.Service)
                .WillCascadeOnDelete(false);
        }
    }
}
