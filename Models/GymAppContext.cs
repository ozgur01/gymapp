using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GymApp.Models
{
    public partial class GymAppContext : DbContext
    {
        public GymAppContext()
        {
        }

        public GymAppContext(DbContextOptions<GymAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Gym> Gym { get; set; }
        public virtual DbSet<Membership> Membership { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=185.22.186.224;port=3306;user=root;password=Ass122...;database=GymApp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gym>(entity =>
            {
                entity.ToTable("Gym", "GymApp");

                entity.HasIndex(e => e.OwnerId)
                    .HasName("fk_Gym_1_idx");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Gym)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Gym_1");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.ToTable("Membership", "GymApp");

                entity.HasIndex(e => e.GymId)
                    .HasName("fk_Membership_2_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Membership_1_idx");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.GymId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserId).HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.Membership)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Membership_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Membership)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Membership_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "GymApp");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserTypeId)
                    .HasName("fk_User_1_idx");

                entity.HasIndex(e => e.Username)
                    .HasName("Username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IsConfirmed)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserTypeId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("fk_User_1");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType", "GymApp");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
