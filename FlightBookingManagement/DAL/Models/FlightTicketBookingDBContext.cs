using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class FlightTicketBookingDBContext : DbContext
    {
        public FlightTicketBookingDBContext()
        {
        }

        public FlightTicketBookingDBContext(DbContextOptions<FlightTicketBookingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAirLine> TblAirLines { get; set; }
        public virtual DbSet<TblBooking> TblBookings { get; set; }
        public virtual DbSet<TblInventory> TblInventories { get; set; }
        public virtual DbSet<TblPassenger> TblPassengers { get; set; }
        public virtual DbSet<TblUserDetail> TblUserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=CTSDOTNET40;Database=FlightTicketBookingDB;User id=sa;password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAirLine>(entity =>
            {
                entity.HasKey(e => e.AirlineNo)
                    .HasName("PK__TblAirLi__DC47D173B8F7FCB9");

                entity.ToTable("TblAirLine");

                entity.Property(e => e.AirlineContactAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AirlineContactNo)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.AirlineCreatedOn).HasColumnType("date");

                entity.Property(e => e.AirlineIsActiveYn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("AirlineIsActiveYN")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AirlineUpdatedOn).HasColumnType("date");

                entity.Property(e => e.AirlineUploadLogo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBooking>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__tblBooki__73951AED4883CDEE");

                entity.ToTable("tblBooking");

                entity.Property(e => e.BookingCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.BookingEmailId).HasMaxLength(100);

                entity.Property(e => e.BookingFlightNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookingIsActiceYn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("BookingIsActiceYN");

                entity.Property(e => e.BookingMeal)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BookingName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BookingPnr)
                    .HasMaxLength(100)
                    .HasColumnName("BookingPNR");

                entity.Property(e => e.BookingSeatNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BookingUpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblInventory>(entity =>
            {
                entity.HasKey(e => e.FlightNumber)
                    .HasName("PK__TblInven__2EAE6F51EFDBAF44");

                entity.ToTable("TblInventory");

                entity.Property(e => e.FlightNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlighScheduleDays)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FlightCreatedOn).HasColumnType("date");

                entity.Property(e => e.FlightEndDateTime).HasColumnType("datetime");

                entity.Property(e => e.FlightFromPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightInstrumentUsed)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FlightIsActiveYn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("FlightIsActiveYN")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.FlightStartDateTime).HasColumnType("datetime");

                entity.Property(e => e.FlightToPlace)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FlightUpdatedOn).HasColumnType("date");
            });

            modelBuilder.Entity<TblPassenger>(entity =>
            {
                entity.HasKey(e => e.PassengerId)
                    .HasName("PK__tblPasse__88915FB0ED02A527");

                entity.ToTable("tblPassenger");

                entity.Property(e => e.PassengerCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.PassengerGender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassengerIsActiceYn)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PassengerIsActiceYN");

                entity.Property(e => e.PassengerMealType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PassengerPnr)
                    .HasMaxLength(100)
                    .HasColumnName("PassengerPNR");

                entity.Property(e => e.PassengerPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PassengerSeatNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PassengerUpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblUserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tbl_User__206D9170CD50C730");

                entity.ToTable("tbl_UserDetails");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.UserCreatedBy).HasColumnName("User_CreatedBy");

                entity.Property(e => e.UserCreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("User_CreatedOn");

                entity.Property(e => e.UserEmailid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Emailid");

                entity.Property(e => e.UserFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_FirstName");

                entity.Property(e => e.UserIsAdmin)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("User_IsAdmin")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UserIsDeleted).HasColumnName("User_IsDeleted");

                entity.Property(e => e.UserLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_LastName");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(50)
                    .HasColumnName("User_Password");

                entity.Property(e => e.UserPhoneNo)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("User_PhoneNo");

                entity.Property(e => e.UserUpdatedBy).HasColumnName("User_UpdatedBy");

                entity.Property(e => e.UserUpdatedOn)
                    .HasColumnType("date")
                    .HasColumnName("User_UpdatedOn");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
