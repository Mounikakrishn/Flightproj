using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Searchmicroservices.Models
{
    public partial class AirlineDBContext : DbContext
    {
        public AirlineDBContext()
        {
        }

        public AirlineDBContext(DbContextOptions<AirlineDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAdmin> TbAdmins { get; set; }
        public virtual DbSet<TbAirline> TbAirlines { get; set; }
        public virtual DbSet<TbSchedule> TbSchedules { get; set; }
        public virtual DbSet<TbUser> TbUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET329;Initial Catalog=AirlineDB;User ID=sa;Password=pass@word1;Integrated Security=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbAdmin>(entity =>
            {
                entity.ToTable("TbAdmin");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<TbAirline>(entity =>
            {
                entity.HasKey(e => e.AirlineId);

                entity.ToTable("TbAirline");

                entity.Property(e => e.Address)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.AirlineLogo)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.AirlineName).HasMaxLength(100);

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TbSchedule>(entity =>
            {
                entity.HasKey(e => e.FlightIdnum);

                entity.ToTable("TbSchedule");

                entity.Property(e => e.Airlinename)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Enddatetime).HasColumnType("datetime");

                entity.Property(e => e.Fromplace)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Meal).HasMaxLength(50);

                entity.Property(e => e.Noofrows)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Scheduleddays)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Startdatetime).HasColumnType("datetime");

                entity.Property(e => e.Ticketprice)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Toplace)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.TbSchedules)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("FK_TbSchedule_TbAirline");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("TbUser");

                entity.Property(e => e.AirlineName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Cancelled)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Emailid)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Meal)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Pnr)
                    .HasMaxLength(100)
                    .HasColumnName("PNR")
                    .IsFixedLength(true);

                entity.Property(e => e.Seatnum)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
