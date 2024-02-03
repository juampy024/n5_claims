using Microsoft.EntityFrameworkCore;
using N5_API.Project.Models; // Assuming your entity classes are in this namespace
using System.Threading.Tasks;

namespace N5_API.Project.Repositories
{
    public partial class N5Context : DbContext
    {
        public N5Context(DbContextOptions<N5Context> options)
            : base(options)
        {

        }

        // DbSets for your entities
        public virtual DbSet<Person> Person { get; set; }

        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<PermissionEmployee> PermissionEmployee { get; set; }

        public virtual DbSet<Permission> Permission { get; set; }

        public virtual DbSet<PermissionType> PermissionType { get; set; }
        // Add DbSets for other entities like Person, Permission, etc.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(Entity => 
            {
                Entity.ToTable("Person");
                Entity.HasKey(e => e.Id);
                Entity.Property(e => e.Id).HasColumnName("Id");
                Entity.Property(e => e.FirstName).HasColumnName("FirstName");
                Entity.Property(e => e.LastName).HasColumnName("LastName");
                Entity.Property(e => e.CreationDate).HasColumnName("CreationDate");
                Entity.Property(e => e.LastUpdated).HasColumnName("LastUpdated");
                Entity.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
                Entity.Property(e => e.Deleted).HasColumnName("Deleted");
                Entity.Property(e => e.IsActive).HasColumnName("IsActive");
            });


            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.JobTitle).HasColumnName("JobTitle");
                entity.Property(e => e.Department).HasColumnName("Department");
                entity.Property(e => e.IsActive).HasColumnName("IsActive");
                entity.Property(e => e.Deleted).HasColumnName("Deleted");
                entity.Property(e => e.CreationDate).HasColumnName("CreationDate");
                entity.Property(e => e.LastUpdated).HasColumnName("LastUpdated");
                entity.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
                entity.Property(e => e.Id).HasColumnName("PersonId");
                entity.HasOne(d => d.Person)
                      .WithOne(p => p.Employee)
                      .HasForeignKey<Employee>(d => d.Id);

            });

            modelBuilder.Entity<PermissionEmployee>(entity =>
            {
                // Define la tabla
                entity.ToTable("PermissionEmployee");

                entity.HasKey(pe => new { pe.PermissionId, pe.EmployeeId });

                entity.HasOne(pe => pe.Employee)
                      .WithMany(e => e.PermissionEmployees) 
                      .HasForeignKey(pe => pe.EmployeeId);

                entity.HasOne(pe => pe.Permission)
                      .WithMany(p => p.PermissionEmployees) 
                      .HasForeignKey(pe => pe.PermissionId);

                entity.Property(pe => pe.IsActive).HasColumnName("IsActive");

            });


            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.ToTable("PermissionType");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.CreationDate).HasColumnName("CreationDate");
                entity.Property(e => e.LastUpdated).HasColumnName("LastUpdated");
            }); 


            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Description).HasColumnName("Description");
                entity.Property(e => e.IsActive).HasColumnName("IsActive");
                entity.Property(e => e.Deleted).HasColumnName("Deleted");
                entity.Property(e => e.CreationDate).HasColumnName("CreationDate");
                entity.Property(e => e.LastUpdated).HasColumnName("LastUpdated");
                entity.Property(e => e.DeletedDate).HasColumnName("DeletedDate");
                entity.Property(e => e.PermissionTypeId).HasColumnName("PermissionTypeId");

                entity.HasOne(d => d.PermissionType)
                      .WithMany(p => p.Permissions)
                      .HasForeignKey(d => d.PermissionTypeId);
                });
        }

    }
}
