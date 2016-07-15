using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using aspnet_core;

namespace aspnetcore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160715182947_migration")]
    partial class migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("aspnet_core.models.Course", b =>
                {
                    b.Property<string>("CourseId");

                    b.Property<int>("InstructorId");

                    b.Property<int>("Level");

                    b.Property<string>("Name");

                    b.Property<int?>("TeacherId")
                        .IsRequired();

                    b.HasKey("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("aspnet_core.models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("aspnet_core.models.Course", b =>
                {
                    b.HasOne("aspnet_core.models.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
