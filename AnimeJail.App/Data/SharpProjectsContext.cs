using System;
using System.Collections.Generic;
using AnimeJail.App.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeJail.App.Data;

public partial class SharpProjectsContext : DbContext
{
    public SharpProjectsContext()
    {
    }

    public SharpProjectsContext(DbContextOptions<SharpProjectsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticlePrisoner> ArticlePrisoners { get; set; }

    public virtual DbSet<ArticleStatus> ArticleStatuses { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Jail> Jails { get; set; }

    public virtual DbSet<JailPrisoner> JailPrisoners { get; set; }

    public virtual DbSet<JailType> JailTypes { get; set; }

    public virtual DbSet<PassportDatum> PassportData { get; set; }

    public virtual DbSet<Prisoner> Prisoners { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkPostion> WorkPostions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=SharpProjects;Username=postgres;Password=#");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Address_pkey");

            entity.ToTable("Address", "AnimeJailDb");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ApartmentNumber).HasColumnName("apartmentNumber");
            entity.Property(e => e.BuildingNumber).HasColumnName("buildingNumber");
            entity.Property(e => e.CityId).HasColumnName("cityId");
            entity.Property(e => e.StreetName).HasColumnName("streetName");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Address_cityId_fkey");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Article_pkey");

            entity.ToTable("Article", "AnimeJailDb");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<ArticlePrisoner>(entity =>
        {
            entity.HasKey(e => new { e.PrisonerId, e.ArticleId }).HasName("ArticlePrisoner_pkey");

            entity.ToTable("ArticlePrisoner", "AnimeJailDb");

            entity.Property(e => e.PrisonerId).HasColumnName("prisonerId");
            entity.Property(e => e.ArticleId).HasColumnName("articleId");
            entity.Property(e => e.IsActual)
                .HasDefaultValue(false)
                .HasColumnName("isActual");

            entity.HasOne(d => d.Article).WithMany(p => p.ArticlePrisoners)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ArticlePrisoner_articleId_fkey");

            entity.HasOne(d => d.Prisoner).WithMany(p => p.ArticlePrisoners)
                .HasForeignKey(d => d.PrisonerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ArticlePrisoner_prisonerId_fkey");
        });

        modelBuilder.Entity<ArticleStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ArticleStatus_pkey");

            entity.ToTable("ArticleStatus", "AnimeJailDb");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("City_pkey");

            entity.ToTable("City", "AnimeJailDb");

            entity.HasIndex(e => e.Name, "City_name_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.RegionId).HasColumnName("regionId");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("City_countryId_fkey");

            entity.HasOne(d => d.Region).WithMany(p => p.Cities)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("City_regionId_fkey");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Country_pkey");

            entity.ToTable("Country", "AnimeJailDb");

            entity.HasIndex(e => e.Name, "Country_name_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Employee_pkey");

            entity.ToTable("Employee", "AnimeJailDb");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.Dismdate).HasColumnName("dismdate");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.Hiredate).HasColumnName("hiredate");
            entity.Property(e => e.MiddleName).HasColumnName("middleName");
            entity.Property(e => e.PassportId).HasColumnName("passportId");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.SecondName).HasColumnName("secondName");
            entity.Property(e => e.WorkPositionId).HasColumnName("workPositionId");

            entity.HasOne(d => d.Passport).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PassportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_passportId_fkey");

            entity.HasOne(d => d.WorkPosition).WithMany(p => p.Employees)
                .HasForeignKey(d => d.WorkPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Employee_workPositionId_fkey");
        });

        modelBuilder.Entity<Jail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Jail_pkey");

            entity.ToTable("Jail", "AnimeJailDb");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.TypeId).HasColumnName("typeId");

            entity.HasOne(d => d.Type).WithMany(p => p.Jails)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Jail_typeId_fkey");
        });

        modelBuilder.Entity<JailPrisoner>(entity =>
        {
            entity.HasKey(e => new { e.PrisonerId, e.JailId }).HasName("Jail_Prisoner_pkey");

            entity.ToTable("Jail_Prisoner", "AnimeJailDb");

            entity.Property(e => e.PrisonerId).HasColumnName("prisonerId");
            entity.Property(e => e.JailId).HasColumnName("jailId");
            entity.Property(e => e.BerthId).HasColumnName("berthId");

            entity.HasOne(d => d.Prisoner).WithMany(p => p.JailPrisoners)
                .HasForeignKey(d => d.PrisonerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Jail_Prisoner_prisonerId_fkey");
        });

        modelBuilder.Entity<JailType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("JailType_pkey");

            entity.ToTable("JailType", "AnimeJailDb");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<PassportDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PassportData_pkey");

            entity.ToTable("PassportData", "AnimeJailDb");

            entity.HasIndex(e => e.Serial, "PassportData_serial_number_key").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.DomiclleRegistrationAdressId).HasColumnName("domiclleRegistrationAdressId");
            entity.Property(e => e.IssueDate).HasColumnName("issueDate");
            entity.Property(e => e.IssuingCountryId).HasColumnName("issuingCountryId");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Serial).HasColumnName("serial");

            entity.HasOne(d => d.DomiclleRegistrationAdress).WithMany(p => p.PassportData)
                .HasForeignKey(d => d.DomiclleRegistrationAdressId)
                .HasConstraintName("PassportData_domiclleRegistrationAdressId_fkey");

            entity.HasOne(d => d.IssuingCountry).WithMany(p => p.PassportData)
                .HasForeignKey(d => d.IssuingCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PassportData_issuingCountryId_fkey");
        });

        modelBuilder.Entity<Prisoner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Prisoner_pkey");

            entity.ToTable("Prisoner", "AnimeJailDb");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.BirthDate).HasColumnName("birthDate");
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.FreedomDate).HasColumnName("freedomDate");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.ImprisonmentDate).HasColumnName("imprisonmentDate");
            entity.Property(e => e.MiddleName).HasColumnName("middleName");
            entity.Property(e => e.PassportId).HasColumnName("passportId");
            entity.Property(e => e.SecondName).HasColumnName("secondName");

            entity.HasOne(d => d.Address).WithMany(p => p.Prisoners)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prisoner_addressId_fkey");

            entity.HasOne(d => d.Passport).WithMany(p => p.Prisoners)
                .HasForeignKey(d => d.PassportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prisoner_passportId_fkey");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Region_pkey");

            entity.ToTable("Region", "AnimeJailDb");

            entity.HasIndex(e => e.Name, "Region_name_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Country).WithMany(p => p.Regions)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Region_countryId_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User", "AnimeJailDb");

            entity.HasIndex(e => e.Login, "User_login_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeId");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_employeeId_fkey");
        });

        modelBuilder.Entity<WorkPostion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("WorkPostion_pkey");

            entity.ToTable("WorkPostion", "AnimeJailDb");

            entity.HasIndex(e => e.Name, "WorkPostion_name_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
