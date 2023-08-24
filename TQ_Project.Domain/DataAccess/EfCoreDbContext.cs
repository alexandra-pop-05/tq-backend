using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TQ_Project.Domain.Entities;
using TQ_Project.Domain.Enums;

namespace TQ_Project.Domain.DataAccess;

public partial class EfCoreDbContext : DbContext
{
    public EfCoreDbContext()
    {
    }

    public EfCoreDbContext(DbContextOptions<EfCoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<KeyMilestone> KeyMilestones { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectMember> ProjectMembers { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersEvent> UsersEvents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-G6BRF6K;Database=TQ_Project;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07A495A8D4");

            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.City).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.JoinedAt).HasColumnType("date");
            entity.Property(e => e.Levels).HasMaxLength(255).HasConversion(new EnumToStringConverter<Levels>()); 
            entity.Property(e => e.Nickname).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255).HasConversion(new EnumToStringConverter<UserRole>());
            entity.Property(e => e.Type).HasMaxLength(255).HasConversion(new EnumToStringConverter<AuthRole>()); 

        });

        modelBuilder.Entity<UsersEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UsersEve__3214EC07140D3BF1");

            entity.HasOne(d => d.Event).WithMany(p => p.UsersEvents)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__UsersEven__Event__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.UsersEvents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__UsersEven__UserI__5070F446");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC07F536D819");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EventName).HasMaxLength(255);
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(255).HasConversion(new EnumToStringConverter<EventStatus>()); 
            entity.Property(e => e.ToDate).HasColumnType("date");
            entity.Property(e => e.Type).HasMaxLength(255).HasConversion(new EnumToStringConverter<EventType>()); 

        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC0736EE4F25");

            entity.ToTable("Document");

            entity.Property(e => e.Link).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Purpose).HasMaxLength(255);

            entity.HasOne(d => d.Project).WithMany(p => p.Documents)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Document__Projec__619B8048");
        });

        modelBuilder.Entity<KeyMilestone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KeyMiles__3214EC070B75DDF4");

            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.MilestoneName).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255).HasConversion(new EnumToStringConverter<KeyMilestoneStatus>());
            entity.Property(e => e.ToDate).HasColumnType("date");

            entity.HasOne(d => d.Project).WithMany(p => p.KeyMilestones)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__KeyMilest__Proje__656C112C");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC07F2F20A7E");

            entity.ToTable("Project");

            entity.HasIndex(e => e.ProjectName, "UQ__Project__BCBE781CA1E821E0").IsUnique();

            entity.Property(e => e.Client).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.ProjectName).HasMaxLength(255);
            entity.Property(e => e.ProjectStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasConversion(new EnumToStringConverter<ProjectStatus>());
            entity.Property(e => e.StartDate).HasColumnType("date");



            /* entity.HasOne(d => d.ProjectManager).WithMany(p => p.ProjectProjectManagers)
                 .HasForeignKey(d => d.ProjectManagerId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .HasConstraintName("FK__Project__Project__5629CD9C");

             entity.HasOne(d => d.TeamManager).WithMany(p => p.ProjectTeamManagers)
                 .HasForeignKey(d => d.TeamManagerId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .HasConstraintName("FK__Project__TeamMan__5535A963");*/

            entity.HasOne(d => d.ProjectManager).WithMany()
                .HasForeignKey(d => d.ProjectManagerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Project__Project__5629CD9C");

            entity.HasOne(d => d.TeamManager).WithMany()
                .HasForeignKey(d => d.TeamManagerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Project__TeamMan__5535A963");

        });

        modelBuilder.Entity<ProjectMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProjectM__3214EC07AEAF65CB");

            entity.HasOne(d => d.Project).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__ProjectMe__Proje__5AEE82B9");

            entity.HasOne(d => d.User).WithMany(p => p.ProjectMembers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__ProjectMe__UserI__59FA5E80");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Review__3214EC07F494330D");

            entity.ToTable("Review");

            entity.Property(e => e.FileName).HasMaxLength(255);
            entity.Property(e => e.UploadedOnDate).HasColumnType("date");

            //changed
            entity.HasOne(d => d.UploadedBy).WithMany(r=>r.UploadedReviews)
                .HasForeignKey(d => d.UploadedById)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Review__Uploaded__5DCAEF64");

            entity.HasOne(d => d.User).WithMany(r => r.ReceivedReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK__Review__UserId__5EBF139D");

            /* entity.HasOne(d => d.UploadedBy).WithMany(p => p.ReviewUploadedBies)
                 .HasForeignKey(d => d.UploadedById)
                 .OnDelete(DeleteBehavior.Restrict)
                 .HasConstraintName("FK__Review__Uploaded__5DCAEF64");

             entity.HasOne(d => d.User).WithMany(p => p.ReviewUsers)
                 .HasForeignKey(d => d.UserId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .HasConstraintName("FK__Review__UserId__5EBF139D");*/
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
