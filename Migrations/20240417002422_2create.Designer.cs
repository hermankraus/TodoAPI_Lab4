﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoAPI.dbContext;

#nullable disable

namespace TodoAPI.Migrations
{
    [DbContext(typeof(DbContextTodo))]
    [Migration("20240417002422_2create")]
    partial class _2create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.29");

            modelBuilder.Entity("TodoAPI.Entities.TodoItem", b =>
                {
                    b.Property<int>("Id_todo_item")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id_todo_item");

                    b.HasIndex("UserId");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            Id_todo_item = 1,
                            Description = "sacarlo a la noche",
                            Title = "pasear perro",
                            UserId = 1
                        },
                        new
                        {
                            Id_todo_item = 2,
                            Description = "lab4",
                            Title = "estudiar",
                            UserId = 2
                        },
                        new
                        {
                            Id_todo_item = 3,
                            Description = "xd",
                            Title = "comer",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TodoAPI.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "asdsa 123",
                            Email = "herman@gmail.com",
                            Name = "herman"
                        },
                        new
                        {
                            Id = 2,
                            Address = "asdsaasddasdsa 123",
                            Email = "u2@gmail.com",
                            Name = "u2"
                        },
                        new
                        {
                            Id = 3,
                            Address = "aaaaasdsaasddasdsa 123",
                            Email = "u3@gmail.com",
                            Name = "u3"
                        });
                });

            modelBuilder.Entity("TodoAPI.Entities.TodoItem", b =>
                {
                    b.HasOne("TodoAPI.Entities.User", "User")
                        .WithMany("TodoItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TodoAPI.Entities.User", b =>
                {
                    b.Navigation("TodoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
