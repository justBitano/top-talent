using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TopTalentView.Models
{
    public partial class TopTalentContext : DbContext
    {
        public TopTalentContext()
        {
        }

        public TopTalentContext(DbContextOptions<TopTalentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Talent> Talents { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-N2D8IS4\\SQLEXPRESS;Database=TopTalent;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("bookingID");

                entity.Property(e => e.BookingStatus).HasColumnName("bookingStatus");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("description");

                entity.Property(e => e.TalentId).HasColumnName("talentID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Talent)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TalentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Talent");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_User");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.ToTable("BookingDetail");

                entity.Property(e => e.BookingDetailId).HasColumnName("bookingDetailID");

                entity.Property(e => e.BookingId).HasColumnName("bookingID");

                entity.Property(e => e.Cash).HasColumnName("cash");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("endTime");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("startTime");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingDetail_Booking");
            });

            modelBuilder.Entity<Talent>(entity =>
            {
                entity.ToTable("Talent");

                entity.Property(e => e.TalentId).HasColumnName("talentID");

                entity.Property(e => e.TalentAddress)
                    .HasMaxLength(50)
                    .HasColumnName("talentAddress");

                entity.Property(e => e.TalentDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("talentDescription");

                entity.Property(e => e.TalentEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("talentEmail");

                entity.Property(e => e.TalentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("talentName");

                entity.Property(e => e.TalentPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("talentPassword");

                entity.Property(e => e.TalentPhone).HasColumnName("talentPhone");

                entity.Property(e => e.TalentStatus).HasColumnName("talentStatus");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(50)
                    .HasColumnName("userAddress");

                entity.Property(e => e.UserDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("userDescription");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("userPassword");

                entity.Property(e => e.UserPhone).HasColumnName("userPhone");

                entity.Property(e => e.UserStatus).HasColumnName("userStatus");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
