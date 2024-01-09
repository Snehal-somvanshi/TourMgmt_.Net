using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TourMgmtApp.Models;

public partial class TourdbContext : DbContext
{
    public TourdbContext()
    {
    }

    public TourdbContext(DbContextOptions<TourdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Orderrecord> Orderrecords { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Packageimage> Packageimages { get; set; }

    public virtual DbSet<Plannedtour> Plannedtours { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tourist> Tourists { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Traveller> Travellers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=12345;database=tourdb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.ToTable("address");

            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.Addressline)
                .HasMaxLength(200)
                .HasColumnName("addressline");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(45)
                .HasColumnName("country");
            entity.Property(e => e.District)
                .HasMaxLength(45)
                .HasColumnName("district");
            entity.Property(e => e.PostalCode).HasColumnName("postal_code");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .HasColumnName("state");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PRIMARY");

            entity.ToTable("admin");

            entity.HasIndex(e => e.ALoginid, "fk_loginid_idx");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.ALoginid).HasColumnName("a_loginid");

            entity.HasOne(d => d.ALogin).WithMany(p => p.Admins)
                .HasForeignKey(d => d.ALoginid)
                .HasConstraintName("fk_loginid");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.EAdharno, "e_adharno_UNIQUE").IsUnique();

            entity.HasIndex(e => e.EAddressid, "fk_e_addressid_idx");

            entity.HasIndex(e => e.ELoginid, "fk_e_loginid_idx");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EAddressid).HasColumnName("e_addressid");
            entity.Property(e => e.EAdharno)
                .HasMaxLength(45)
                .HasColumnName("e_adharno");
            entity.Property(e => e.EBdate)
                .HasMaxLength(45)
                .HasColumnName("e_bdate");
            entity.Property(e => e.EContact)
                .HasMaxLength(45)
                .HasColumnName("e_contact");
            entity.Property(e => e.EDesignation)
                .HasMaxLength(45)
                .HasColumnName("e_designation");
            entity.Property(e => e.EEmail)
                .HasMaxLength(255)
                .HasColumnName("e_email");
            entity.Property(e => e.EFname)
                .HasMaxLength(45)
                .HasColumnName("e_fname");
            entity.Property(e => e.EGender)
                .HasMaxLength(45)
                .HasColumnName("e_gender");
            entity.Property(e => e.EHiredate).HasColumnName("e_hiredate");
            entity.Property(e => e.ELname)
                .HasMaxLength(45)
                .HasColumnName("e_lname");
            entity.Property(e => e.ELoginid).HasColumnName("e_loginid");
            entity.Property(e => e.EMname)
                .HasMaxLength(45)
                .HasColumnName("e_mname");
            entity.Property(e => e.EPhoto).HasColumnName("e_photo");

            entity.HasOne(d => d.EAddress).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EAddressid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_e_addressid");

            entity.HasOne(d => d.ELogin).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ELoginid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_e_loginid");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("PRIMARY");

            entity.ToTable("login");

            entity.HasIndex(e => e.RoleId, "role_id_idx");

            entity.Property(e => e.LoginId).HasColumnName("login_id");
            entity.Property(e => e.Pwd)
                .HasMaxLength(45)
                .HasColumnName("pwd");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Uid)
                .HasMaxLength(45)
                .HasColumnName("uid");

            entity.HasOne(d => d.Role).WithMany(p => p.Logins)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("role_id");
        });

        modelBuilder.Entity<Orderrecord>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orderrecord");

            entity.HasIndex(e => e.Transactionid, "FKsxbqhvo2x2jc51lkmxf157dtp");

            entity.HasIndex(e => e.Tourid, "fk_o_packageid_idx");

            entity.HasIndex(e => e.Touristid, "fk_touristid_idx");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Tourid).HasColumnName("tourid");
            entity.Property(e => e.Touristid).HasColumnName("touristid");
            entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            entity.Property(e => e.Travellernumber).HasColumnName("travellernumber");

            entity.HasOne(d => d.Tour).WithMany(p => p.Orderrecords)
                .HasForeignKey(d => d.Tourid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_o_packageid");

            entity.HasOne(d => d.Tourist).WithMany(p => p.Orderrecords)
                .HasForeignKey(d => d.Touristid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_o_touristid");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Orderrecords)
                .HasForeignKey(d => d.Transactionid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FKsxbqhvo2x2jc51lkmxf157dtp");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PRIMARY");

            entity.ToTable("package");

            entity.HasIndex(e => e.Packagename, "packagename_UNIQUE").IsUnique();

            entity.Property(e => e.PackageId).HasColumnName("package_id");
            entity.Property(e => e.Boardinglocation)
                .HasMaxLength(255)
                .HasColumnName("boardinglocation");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration)
                .HasMaxLength(255)
                .HasColumnName("duration");
            entity.Property(e => e.Locations).HasColumnName("locations");
            entity.Property(e => e.Packagename)
                .HasMaxLength(100)
                .HasColumnName("packagename");
            entity.Property(e => e.TouristCapacity).HasColumnName("tourist_capacity");
        });

        modelBuilder.Entity<Packageimage>(entity =>
        {
            entity.HasKey(e => e.PackageimageId).HasName("PRIMARY");

            entity.ToTable("packageimage");

            entity.HasIndex(e => e.PackageId, "fk_packageid_idx");

            entity.Property(e => e.PackageimageId).HasColumnName("packageimage_id");
            entity.Property(e => e.PackageId).HasColumnName("package_id");
            entity.Property(e => e.Packimage).HasColumnName("packimage");

            entity.HasOne(d => d.Package).WithMany(p => p.Packageimages)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_packageid");
        });

        modelBuilder.Entity<Plannedtour>(entity =>
        {
            entity.HasKey(e => e.TourId).HasName("PRIMARY");

            entity.ToTable("plannedtour");

            entity.HasIndex(e => e.Employeeid, "fk_tour_employeeid_idx");

            entity.HasIndex(e => e.Packageid, "fk_tour_packageid_idx");

            entity.Property(e => e.TourId).HasColumnName("tour_id");
            entity.Property(e => e.Availseats).HasColumnName("availseats");
            entity.Property(e => e.Employeeid).HasColumnName("employeeid");
            entity.Property(e => e.Lastdate).HasColumnName("lastdate");
            entity.Property(e => e.LastdateApply).HasColumnName("lastdate_apply");
            entity.Property(e => e.Packageid).HasColumnName("packageid");
            entity.Property(e => e.Packageprice).HasColumnName("packageprice");
            entity.Property(e => e.Startdate).HasColumnName("startdate");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Employee).WithMany(p => p.Plannedtours)
                .HasForeignKey(d => d.Employeeid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tour_employeeid");

            entity.HasOne(d => d.Package).WithMany(p => p.Plannedtours)
                .HasForeignKey(d => d.Packageid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tour_packageid");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PRIMARY");

            entity.ToTable("reviews");

            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.FOrderid).HasColumnName("f_orderid");
            entity.Property(e => e.Feedback)
                .HasMaxLength(500)
                .HasColumnName("feedback");
            entity.Property(e => e.Rating).HasColumnName("rating");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(45)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Tourist>(entity =>
        {
            entity.HasKey(e => e.TouristId).HasName("PRIMARY");

            entity.ToTable("tourist");

            entity.HasIndex(e => e.TAddressid, "fk_t_addrid_idx");

            entity.HasIndex(e => e.TLoginid, "fk_t_loginid_idx");

            entity.Property(e => e.TouristId).HasColumnName("tourist_id");
            entity.Property(e => e.TAddressid).HasColumnName("t_addressid");
            entity.Property(e => e.TBdate).HasColumnName("t_bdate");
            entity.Property(e => e.TContact)
                .HasMaxLength(45)
                .HasColumnName("t_contact");
            entity.Property(e => e.TEmail)
                .HasMaxLength(45)
                .HasColumnName("t_email");
            entity.Property(e => e.TFname)
                .HasMaxLength(45)
                .HasColumnName("t_fname");
            entity.Property(e => e.TLname)
                .HasMaxLength(45)
                .HasColumnName("t_lname");
            entity.Property(e => e.TLoginid).HasColumnName("t_loginid");

            entity.HasOne(d => d.TAddress).WithMany(p => p.Tourists)
                .HasForeignKey(d => d.TAddressid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_t_addrid");

            entity.HasOne(d => d.TLogin).WithMany(p => p.Tourists)
                .HasForeignKey(d => d.TLoginid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_t_loginid");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.ToTable("transaction");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Amount)
                .HasPrecision(9, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Paymentdate)
                .HasColumnType("datetime")
                .HasColumnName("paymentdate");
            entity.Property(e => e.Paymenttype)
                .HasMaxLength(45)
                .HasColumnName("paymenttype");
        });

        modelBuilder.Entity<Traveller>(entity =>
        {
            entity.HasKey(e => e.Travellerid).HasName("PRIMARY");

            entity.ToTable("traveller");

            entity.HasIndex(e => e.Orderid, "fk_tr_orderid_idx");

            entity.HasIndex(e => e.Travellerid, "travellerid_UNIQUE").IsUnique();

            entity.Property(e => e.Travellerid).HasColumnName("travellerid");
            entity.Property(e => e.Bdate)
                .HasMaxLength(45)
                .HasColumnName("bdate");
            entity.Property(e => e.Fname)
                .HasMaxLength(45)
                .HasColumnName("fname");
            entity.Property(e => e.Gender)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("gender");
            entity.Property(e => e.Lname)
                .HasMaxLength(45)
                .HasColumnName("lname");
            entity.Property(e => e.Orderid).HasColumnName("orderid");

            entity.HasOne(d => d.Order).WithMany(p => p.Travellers)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_tr_orderid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
