using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using bdForumDBImplement.Models;

namespace bdForumDBImplement.DatabaseContext
{
    public partial class ForumDatabase : DbContext
    {
        public ForumDatabase()
        {
        }
        public virtual DbSet<Like> Like { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Moderator> Moderator { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=Forum;Username=postgres;Password=1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(e => new { e.Visitorlogin, e.Messageid })
                    .HasName("like__pkey");

                entity.ToTable("like_");

                entity.Property(e => e.Visitorlogin)
                    .HasColumnName("visitorlogin")
                    .HasMaxLength(255);

                entity.Property(e => e.Messageid).HasColumnName("messageid");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Like)
                    .HasForeignKey(d => d.Messageid)
                    .HasConstraintName("like__messageid_fkey");

                entity.HasOne(d => d.VisitorloginNavigation)
                    .WithMany(p => p.Like)
                    .HasForeignKey(d => d.Visitorlogin)
                    .HasConstraintName("like__visitorlogin_fkey");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("message_");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasMaxLength(20000);

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Topicname)
                    .IsRequired()
                    .HasColumnName("topicname_")
                    .HasMaxLength(255);

                entity.Property(e => e.Visitorlogin)
                    .IsRequired()
                    .HasColumnName("visitorlogin")
                    .HasMaxLength(255);

                entity.HasOne(d => d.TopicnameNavigation)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.Topicname)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("message__topicname__fkey");

                entity.HasOne(d => d.VisitorloginNavigation)
                    .WithMany(p => p.Message)
                    .HasForeignKey(d => d.Visitorlogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("message__visitorlogin_fkey");
            });

            modelBuilder.Entity<Moderator>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("moderator_pkey");

                entity.ToTable("moderator");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.Amountofhelp).HasColumnName("amountofhelp");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password_")
                    .HasMaxLength(255);

                entity.Property(e => e.TotalTime).HasColumnName("totalTime");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("topic_pkey");

                entity.ToTable("topic");

                entity.Property(e => e.Name)
                    .HasColumnName("name_")
                    .HasMaxLength(255);

                entity.Property(e => e.Numberofmessages).HasColumnName("numberofmessages");

                entity.Property(e => e.Numberofvisitors).HasColumnName("numberofvisitors");
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("visitor_pkey");

                entity.ToTable("visitor");

                entity.Property(e => e.Login)
                    .HasColumnName("login")
                    .HasMaxLength(255);

                entity.Property(e => e.Countmessages).HasColumnName("countmessages");

                entity.Property(e => e.Decency).HasColumnName("decency");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password_")
                    .HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(255);

                entity.Property(e => e.TotalTime)
                    .HasColumnName("totalTime")
                    .HasComment("Общее время");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
