using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppDB.YourOutputDirectory;

public partial class ConcordiaContext : DbContext
{
    public ConcordiaContext()
    {
    }

    public ConcordiaContext(DbContextOptions<ConcordiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Partecipant> Partecipants { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Scientist> Scientists { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Concordia;Integrated Security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07D46A892B");

            entity.Property(e => e.CommentId)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Text).IsUnicode(false);

            entity.HasOne(d => d.Task).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__TaskId__403A8C7D");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Members__3214EC077D1CED43");

            entity.HasIndex(e => e.ScientistId, "UQ__Members__BF9045331357F6B9").IsUnique();

            entity.Property(e => e.CreatorId)
                .HasMaxLength(24)
                .IsUnicode(false);

            entity.HasOne(d => d.Scientist).WithOne(p => p.Member)
                .HasForeignKey<Member>(d => d.ScientistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Members__Scienti__48CFD27E");
        });

        modelBuilder.Entity<Partecipant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partecip__3214EC07FB40ADFF");

            entity.HasOne(d => d.Task).WithMany(p => p.Partecipants)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Partecipa__TaskI__4316F928");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prioriti__3214EC07D0094CB5");

            entity.HasIndex(e => e.Color, "UQ__Prioriti__E11D384558F8D0B9").IsUnique();

            entity.HasIndex(e => e.Label, "UQ__Prioriti__EDBE0C584D9BA04E").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Label)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Scientist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Scientis__3214EC07E850C00A");

            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.FamilyName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GivenName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__States__3214EC07D1D3F24D");

            entity.HasIndex(e => e.Name, "UQ__States__737584F6F07E9122").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ListId)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3214EC076EEC41E5");

            entity.Property(e => e.CardId)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Priority).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__PriorityI__49C3F6B7");

            entity.HasOne(d => d.State).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tasks__StateId__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
