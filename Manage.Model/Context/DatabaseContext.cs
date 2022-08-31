using System;
using Manage.Model.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Manage.Model.Context
{
   
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public string EncodingUTF8(string password)
        {
            Byte[] passBytes = Encoding.UTF8.GetBytes(password);
            string passE = "";
            foreach (byte b in passBytes)
                passE += b;
            return passE;
        }
        public virtual DbSet<HuAllowance> HuAllowances { get; set; }
        public virtual DbSet<HuBank> HuBanks { get; set; }
        public virtual DbSet<HuBankBranch> HuBankBranches { get; set; }
        public virtual DbSet<HuContract> HuContracts { get; set; }
        public virtual DbSet<HuContractAllowance> HuContractAllowances { get; set; }
        public virtual DbSet<HuContractWelface> HuContractWelfaces { get; set; }
        public virtual DbSet<HuDistrict> HuDistricts { get; set; }
        public virtual DbSet<HuEmployee> HuEmployees { get; set; }
        public virtual DbSet<HuEmployeeCv> HuEmployeeCvs { get; set; }
        public virtual DbSet<HuEmployeeEducation> HuEmployeeEducations { get; set; }
        public virtual DbSet<HuEmployeeFamily> HuFamilies { get; set; }
        public virtual DbSet<HuHospital> HuHospitals { get; set; }
        public virtual DbSet<HuNation> HuNations { get; set; }
        public virtual DbSet<HuOrgTitle> HuOrgTitles { get; set; }
        public virtual DbSet<HuOrganization> HuOrganizations { get; set; }
        public virtual DbSet<HuProvince> HuProvinces { get; set; }
        public virtual DbSet<HuSalaryRecord> HuSalaryRecords { get; set; }
        public virtual DbSet<HuSchool> HuShools { get; set; }
        public virtual DbSet<HuTitle> HuTitles { get; set; }
        public virtual DbSet<HuWard> HuWards { get; set; }
        public virtual DbSet<HuWelface> HuWelfaces { get; set; }
        public virtual DbSet<OtherList> OtherLists { get; set; }
        public virtual DbSet<OtherListType> OtherListTypes { get; set; }
        public virtual DbSet<SeUser> SeUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HJ37BIM;Initial Catalog=Employee_manager_VMO_lan2;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<HuAllowance>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            });

            modelBuilder.Entity<HuBank>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            });

            modelBuilder.Entity<HuContract>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            });

            modelBuilder.Entity<HuEmployee>(entity =>
            {
                entity.HasOne(d => d.OrgNavigation)
                    .WithMany(p => p.HuEmployees)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK_hu_employee_hu_organization");
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);

            });

            modelBuilder.Entity<HuEmployeeCv>(entity =>
            {
                entity.HasOne(d => d.BankBrank)
                    .WithMany(p => p.HuEmployeeCvs)
                    .HasForeignKey(d => d.BankBrankId)
                    .HasConstraintName("FK_hu_employee_cv_hu_bank_branch");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.HuEmployeeCvs)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_hu_employee_cv_hu_bank");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.HuEmployeeCvs)
                    .HasConstraintName("FK_hu_employee_cv_hu_employee");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.HuEmployeeCvs)
                    .HasForeignKey(d => d.HospitalId)
                    .HasConstraintName("FK_hu_employee_cv_hu_hospital");

                entity.HasOne(d => d.Nation)
                    .WithMany(p => p.HuEmployeeCvs)
                    .HasForeignKey(d => d.NationId)
                    .HasConstraintName("FK_hu_employee_cv_hu_nation");
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            });

            modelBuilder.Entity<HuHospital>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            });

            modelBuilder.Entity<HuNation>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            });

            modelBuilder.Entity<HuOrgTitle>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            });

            modelBuilder.Entity<HuSchool>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.HuShools)
                    .HasConstraintName("FK_hu_shools_hu_employee");
            });

            modelBuilder.Entity<HuTitle>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            });

            modelBuilder.Entity<OtherList>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);//ValueGeneratedNever();
            });
            modelBuilder.Entity<OtherListType>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
            });
            modelBuilder.Entity<SeUser>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn(seed: 1, increment: 1);
                entity.HasData(new SeUser
                {
                    Id = -1,
                    Code = "UE00-1",
                    Activeflg = "SuperActive",
                    CreatedTime = DateTime.UtcNow,
                    CreatedBy = "SuperAdmin",
                    LastUpdatedBy = "SuperAdmin",
                    LastUpdateTime = DateTime.UtcNow,
                    Password = EncodingUTF8("SuperAdmin@123"),
                    Username = "SuperAdmin",
                    Role = "SuperAdmin",
                }) ;
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
