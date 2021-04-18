﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bdForumDBImplement.DatabaseContext;

namespace bdForumDBImplement.Migrations
{
    [DbContext(typeof(ForumDatabase))]
    partial class ForumDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("bdForumDBImplement.Models.Like", b =>
                {
                    b.Property<string>("Visitorlogin")
                        .HasColumnName("visitorlogin")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Messageid")
                        .HasColumnName("messageid")
                        .HasColumnType("integer");

                    b.HasKey("Visitorlogin", "Messageid")
                        .HasName("like__pkey");

                    b.HasIndex("Messageid");

                    b.ToTable("like_");
                });

            modelBuilder.Entity("bdForumDBImplement.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnName("text")
                        .HasColumnType("character varying(20000)")
                        .HasMaxLength(20000);

                    b.Property<DateTime>("Time")
                        .HasColumnName("time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Topicname")
                        .IsRequired()
                        .HasColumnName("topicname_")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Visitorlogin")
                        .IsRequired()
                        .HasColumnName("visitorlogin")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Topicname");

                    b.HasIndex("Visitorlogin");

                    b.ToTable("message_");
                });

            modelBuilder.Entity("bdForumDBImplement.Models.Moderator", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnName("login")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Amountofhelp")
                        .HasColumnName("amountofhelp")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password_")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("TotalTime")
                        .HasColumnName("totalTime")
                        .HasColumnType("integer");

                    b.HasKey("Login")
                        .HasName("moderator_pkey");

                    b.ToTable("moderator");
                });

            modelBuilder.Entity("bdForumDBImplement.Models.Topic", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnName("name_")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Numberofmessages")
                        .HasColumnName("numberofmessages")
                        .HasColumnType("integer");

                    b.Property<int>("Numberofvisitors")
                        .HasColumnName("numberofvisitors")
                        .HasColumnType("integer");

                    b.HasKey("Name")
                        .HasName("topic_pkey");

                    b.ToTable("topic");
                });

            modelBuilder.Entity("bdForumDBImplement.Models.Visitor", b =>
                {
                    b.Property<string>("Login")
                        .HasColumnName("login")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Countmessages")
                        .HasColumnName("countmessages")
                        .HasColumnType("integer");

                    b.Property<int>("Decency")
                        .HasColumnName("decency")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password_")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("TotalTime")
                        .HasColumnName("totalTime")
                        .HasColumnType("integer")
                        .HasComment("Общее время");

                    b.HasKey("Login")
                        .HasName("visitor_pkey");

                    b.ToTable("visitor");
                });

            modelBuilder.Entity("bdForumDBImplement.Models.Like", b =>
                {
                    b.HasOne("bdForumDBImplement.Models.Message", "Message")
                        .WithMany("Like")
                        .HasForeignKey("Messageid")
                        .HasConstraintName("like__messageid_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("bdForumDBImplement.Models.Visitor", "VisitorloginNavigation")
                        .WithMany("Like")
                        .HasForeignKey("Visitorlogin")
                        .HasConstraintName("like__visitorlogin_fkey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bdForumDBImplement.Models.Message", b =>
                {
                    b.HasOne("bdForumDBImplement.Models.Topic", "TopicnameNavigation")
                        .WithMany("Message")
                        .HasForeignKey("Topicname")
                        .HasConstraintName("message__topicname__fkey")
                        .IsRequired();

                    b.HasOne("bdForumDBImplement.Models.Visitor", "VisitorloginNavigation")
                        .WithMany("Message")
                        .HasForeignKey("Visitorlogin")
                        .HasConstraintName("message__visitorlogin_fkey")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}