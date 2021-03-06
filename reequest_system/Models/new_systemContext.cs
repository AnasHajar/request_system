using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace reequest_system.Models
{
    public partial class new_systemContext : DbContext
    {
        public new_systemContext()
        {
        }

        public new_systemContext(DbContextOptions<new_systemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Collage> Collages { get; set; }
        public virtual DbSet<CollageMajor> CollageMajors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Exception> Exceptions { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<RequestList> RequestLists { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=new_system;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Collage>(entity =>
            {
                entity.HasKey(e => e.ClgId)
                    .HasName("PK__Collage__EF95C4096D6164E9");

                entity.ToTable("Collage");

                entity.Property(e => e.ClgId).HasColumnName("clg_id");

                entity.Property(e => e.ClgName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("clg_name");
            });

            modelBuilder.Entity<CollageMajor>(entity =>
            {
                entity.HasKey(e => e.MjrId)
                    .HasName("PK__collage___43D01D8E0D1DA0DC");

                entity.ToTable("collage_major");

                entity.Property(e => e.MjrId).HasColumnName("mjr_id");

                entity.Property(e => e.ClgId).HasColumnName("clg_id");

                entity.Property(e => e.MjrName)
                    .HasMaxLength(20)
                    .HasColumnName("mjr_name");

                entity.HasOne(d => d.Clg)
                    .WithMany(p => p.CollageMajors)
                    .HasForeignKey(d => d.ClgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => new { e.CrsDpt, e.CrsNum })
                    .HasName("PK__Course__638621906832320B");

                entity.ToTable("Course");

                entity.Property(e => e.CrsDpt)
                    .HasMaxLength(5)
                    .HasColumnName("crs_dpt");

                entity.Property(e => e.CrsNum).HasColumnName("crs_num");

                entity.Property(e => e.ClgId).HasColumnName("clg_id");

                entity.Property(e => e.CrsTitle)
                    .HasMaxLength(20)
                    .HasColumnName("crs_title");

                entity.Property(e => e.MjrId).HasColumnName("mjr_id");

                entity.HasOne(d => d.Clg)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.ClgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clg_FK_");

                entity.HasOne(d => d.Mjr)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.MjrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mjr_FK_");
            });

            modelBuilder.Entity<Exception>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("exceptions");

                entity.Property(e => e.RecId).HasColumnName("recId");

                entity.Property(e => e.CrsDpt)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("crs_dpt");

                entity.Property(e => e.CrsNum).HasColumnName("crs_num");

                entity.Property(e => e.Justification)
                    .HasMaxLength(200)
                    .HasColumnName("justification");

                entity.Property(e => e.JustifiedBy)
                    .HasMaxLength(10)
                    .HasColumnName("justifiedBy");

                entity.Property(e => e.JustifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("justifiedDate");

                entity.Property(e => e.Message)
                    .HasMaxLength(200)
                    .HasColumnName("message");

                entity.Property(e => e.RequestId).HasColumnName("requestId");

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("ssn");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SubmittedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("submitted_date");

                entity.HasOne(d => d.JustifiedByNavigation)
                    .WithMany(p => p.Exceptions)
                    .HasForeignKey(d => d.JustifiedBy)
                    .HasConstraintName("FK_exceptions_Faculty");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Exceptions)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_exceptions_Request_List");

                entity.HasOne(d => d.SsnNavigation)
                    .WithMany(p => p.Exceptions)
                    .HasForeignKey(d => d.Ssn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exceptions_Student");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Exceptions)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_exceptions_Status");

                entity.HasOne(d => d.Crs)
                    .WithMany(p => p.Exceptions)
                    .HasForeignKey(d => new { d.CrsDpt, d.CrsNum })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exceptions_Course");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.FcyId)
                    .HasName("PK__Faculty__0663F33112602FA8");

                entity.ToTable("Faculty");

                entity.Property(e => e.FcyId)
                    .HasMaxLength(10)
                    .HasColumnName("fcy_id");

                entity.Property(e => e.ClgId).HasColumnName("clg_id");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.FcyName)
                    .HasMaxLength(200)
                    .HasColumnName("fcy_name");

                entity.Property(e => e.FcyPsw)
                    .HasMaxLength(20)
                    .HasColumnName("fcy_psw");

                entity.Property(e => e.MjrId).HasColumnName("mjr_id");

                entity.Property(e => e.NationalityId)
                    .HasMaxLength(5)
                    .HasColumnName("Nationality_id");

                entity.Property(e => e.Phone)
                    .HasMaxLength(200)
                    .HasColumnName("phone");

                entity.HasOne(d => d.Clg)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.ClgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Clg_FK");

                entity.HasOne(d => d.Mjr)
                    .WithMany(p => p.Faculties)
                    .HasForeignKey(d => d.MjrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Mjr_FK");
            });

            modelBuilder.Entity<RequestList>(entity =>
            {
                entity.HasKey(e => e.RqstId)
                    .HasName("PK__Request___2E2342B94047F68A");

                entity.ToTable("Request_List");

                entity.Property(e => e.RqstId).HasColumnName("rqst_id");

                entity.Property(e => e.RqstName)
                    .HasMaxLength(200)
                    .HasColumnName("rqst_name");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("status_id");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Ssn)
                    .HasName("PK__Student__DDDF0AE76E00B33B");

                entity.ToTable("Student");

                entity.Property(e => e.Ssn)
                    .HasMaxLength(5)
                    .HasColumnName("ssn");

                entity.Property(e => e.ClgId).HasColumnName("clg_id");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.MjrId).HasColumnName("mjr_id");

                entity.Property(e => e.NationalityId)
                    .HasMaxLength(5)
                    .HasColumnName("Nationality_id");

                entity.Property(e => e.StName)
                    .HasMaxLength(200)
                    .HasColumnName("st_name");

                entity.Property(e => e.StPsw)
                    .HasMaxLength(20)
                    .HasColumnName("st_psw");

                entity.HasOne(d => d.Clg)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CFK");

                entity.HasOne(d => d.Mjr)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MjrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MFK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
