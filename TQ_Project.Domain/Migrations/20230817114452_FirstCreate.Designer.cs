﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

using Microsoft.EntityFrameworkCore.Migrations;
using TQ_Project.Domain.DataAccess;



#nullable disable

namespace TQ_Project.Domain.Migrations
{
    [DbContext(typeof(EfCoreDbContext))]
    [Migration("20230817114452_FirstCreate")]
    partial class FirstCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Purpose")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Document__3214EC0736EE4F25");

                    b.HasIndex("ProjectId");

                    b.ToTable("Document", (string)null);
                });

            modelBuilder.Entity("WebAPI.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("date");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("date");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Events__3214EC07F536D819");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WebAPI.Models.KeyMilestone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("date");

                    b.Property<string>("MilestoneName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("date");

                    b.HasKey("Id")
                        .HasName("PK__KeyMiles__3214EC070B75DDF4");

                    b.HasIndex("ProjectId");

                    b.ToTable("KeyMilestones");
                });

            modelBuilder.Entity("WebAPI.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Client")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("ProjectManagerId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectStatus")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<int>("TeamManagerId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Project__3214EC07F2F20A7E");

                    b.HasIndex("ProjectManagerId");

                    b.HasIndex("TeamManagerId");

                    b.HasIndex(new[] { "ProjectName" }, "UQ__Project__BCBE781CA1E821E0")
                        .IsUnique();

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("WebAPI.Models.ProjectMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__ProjectM__3214EC07AEAF65CB");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("WebAPI.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("UploadedById")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadedOnDate")
                        .HasColumnType("date");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Review__3214EC07F494330D");

                    b.HasIndex("UploadedById");

                    b.HasIndex("UserId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("FreeDaysLeft")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("date");

                    b.Property<string>("Levels")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Users__3214EC07A495A8D4");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebAPI.Models.UsersEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__UsersEve__3214EC07140D3BF1");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersEvents");
                });

            modelBuilder.Entity("WebAPI.Models.Document", b =>
                {
                    b.HasOne("WebAPI.Models.Project", "Project")
                        .WithMany("Documents")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__Document__Projec__619B8048");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WebAPI.Models.KeyMilestone", b =>
                {
                    b.HasOne("WebAPI.Models.Project", "Project")
                        .WithMany("KeyMilestones")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__KeyMilest__Proje__656C112C");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WebAPI.Models.Project", b =>
                {
                    b.HasOne("WebAPI.Models.User", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__Project__Project__5629CD9C");

                    b.HasOne("WebAPI.Models.User", "TeamManager")
                        .WithMany()
                        .HasForeignKey("TeamManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__Project__TeamMan__5535A963");

                    b.Navigation("ProjectManager");

                    b.Navigation("TeamManager");
                });

            modelBuilder.Entity("WebAPI.Models.ProjectMember", b =>
                {
                    b.HasOne("WebAPI.Models.Project", "Project")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__ProjectMe__Proje__5AEE82B9");

                    b.HasOne("WebAPI.Models.User", "User")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__ProjectMe__UserI__59FA5E80");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.Review", b =>
                {
                    b.HasOne("WebAPI.Models.User", "UploadedBy")
                        .WithMany("UploadedReviews")
                        .HasForeignKey("UploadedById")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__Review__Uploaded__5DCAEF64");

                    b.HasOne("WebAPI.Models.User", "User")
                        .WithMany("ReceivedReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__Review__UserId__5EBF139D");

                    b.Navigation("UploadedBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.UsersEvent", b =>
                {
                    b.HasOne("WebAPI.Models.Event", "Event")
                        .WithMany("UsersEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__UsersEven__Event__5165187F");

                    b.HasOne("WebAPI.Models.User", "User")
                        .WithMany("UsersEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__UsersEven__UserI__5070F446");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebAPI.Models.Event", b =>
                {
                    b.Navigation("UsersEvents");
                });

            modelBuilder.Entity("WebAPI.Models.Project", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("KeyMilestones");

                    b.Navigation("ProjectMembers");
                });

            modelBuilder.Entity("WebAPI.Models.User", b =>
                {
                    b.Navigation("ProjectMembers");

                    b.Navigation("ReceivedReviews");

                    b.Navigation("UploadedReviews");

                    b.Navigation("UsersEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
