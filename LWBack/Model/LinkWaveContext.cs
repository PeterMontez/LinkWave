using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LWBack.Model;

public partial class LinkWaveContext : DbContext
{
    public LinkWaveContext()
    {
    }

    public LinkWaveContext(DbContextOptions<LinkWaveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<ForumUser> ForumUsers { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PosPerm> PosPerms { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0013C\\SQLEXPRESS;Initial Catalog=LinkWave;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.ForumId).HasName("PK__Forums__E49CFD0B2AA3680A");

            entity.Property(e => e.ForumId).HasColumnName("Forum_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("Created_at");
            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ForumUser>(entity =>
        {
            entity.HasKey(e => e.AssociationId).HasName("PK__ForumUse__12E511F91587EDEB");

            entity.ToTable("ForumUser");

            entity.Property(e => e.AssociationId).HasColumnName("Association_id");
            entity.Property(e => e.ForumId).HasColumnName("Forum_id");
            entity.Property(e => e.PositionId).HasColumnName("Position_id");
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.Forum).WithMany(p => p.ForumUsers)
                .HasForeignKey(d => d.ForumId)
                .HasConstraintName("FK__ForumUser__Forum__3F466844");

            entity.HasOne(d => d.Position).WithMany(p => p.ForumUsers)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__ForumUser__Posit__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.ForumUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ForumUser__User___3E52440B");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__89B4589D5322FDDE");

            entity.Property(e => e.PermissionId).HasColumnName("Permission_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PosPerm>(entity =>
        {
            entity.HasKey(e => e.PosPermId).HasName("PK__PosPerm__59E1C83DD4A00C2A");

            entity.ToTable("PosPerm");

            entity.Property(e => e.PosPermId).HasColumnName("PosPerm_id");
            entity.Property(e => e.PermissionId).HasColumnName("Permission_id");
            entity.Property(e => e.PositionId).HasColumnName("Position_id");

            entity.HasOne(d => d.Permission).WithMany(p => p.PosPerms)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__PosPerm__Permiss__48CFD27E");

            entity.HasOne(d => d.Position).WithMany(p => p.PosPerms)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__PosPerm__Positio__49C3F6B7");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__3C3D9A7EF38A5CDF");

            entity.Property(e => e.PositionId).HasColumnName("Position_id");
            entity.Property(e => e.ForumId).HasColumnName("Forum_id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Forum).WithMany(p => p.Positions)
                .HasForeignKey(d => d.ForumId)
                .HasConstraintName("FK__Positions__Forum__3B75D760");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Posts__587ADB65475EB6D1");

            entity.Property(e => e.PostId).HasColumnName("Post_id");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ForumId).HasColumnName("Forum_id");
            entity.Property(e => e.Picture)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.Forum).WithMany(p => p.Posts)
                .HasForeignKey(d => d.ForumId)
                .HasConstraintName("FK__Posts__Forum_id__440B1D61");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Posts__User_id__4316F928");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__Ratings__BE49CCDDF0602E0D");

            entity.Property(e => e.RatingId).HasColumnName("Rating_id");
            entity.Property(e => e.PostId).HasColumnName("Post_id");
            entity.Property(e => e.Rating1).HasColumnName("Rating");
            entity.Property(e => e.UserId).HasColumnName("User_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Ratings__Post_id__4D94879B");

            entity.HasOne(d => d.User).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Ratings__User_id__4CA06362");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__206A9DF85B52CD71");

            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Picture)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
