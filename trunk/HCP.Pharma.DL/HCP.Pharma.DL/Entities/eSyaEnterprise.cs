﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HCP.Pharma.DL.Entities
{
    public partial class eSyaEnterprise : DbContext
    {
        public static string _connString = "";
        public eSyaEnterprise()
        {
        }

        public eSyaEnterprise(DbContextOptions<eSyaEnterprise> options)
            : base(options)
        {
        }

        public virtual DbSet<GtEastbl> GtEastbl { get; set; }
        public virtual DbSet<GtEavncd> GtEavncd { get; set; }
        public virtual DbSet<GtEavndr> GtEavndr { get; set; }
        public virtual DbSet<GtEcapcd> GtEcapcd { get; set; }
        public virtual DbSet<GtEcapct> GtEcapct { get; set; }
        public virtual DbSet<GtEcbsen> GtEcbsen { get; set; }
        public virtual DbSet<GtEcbsln> GtEcbsln { get; set; }
        public virtual DbSet<GtEcbssg> GtEcbssg { get; set; }
        public virtual DbSet<GtEccncd> GtEccncd { get; set; }
        public virtual DbSet<GtEccntc> GtEccntc { get; set; }
        public virtual DbSet<GtEcfmfd> GtEcfmfd { get; set; }
        public virtual DbSet<GtEcfmst> GtEcfmst { get; set; }
        public virtual DbSet<GtEciuom> GtEciuom { get; set; }
        public virtual DbSet<GtEcstrm> GtEcstrm { get; set; }
        public virtual DbSet<GtEpdrbi> GtEpdrbi { get; set; }
        public virtual DbSet<GtEpdrbl> GtEpdrbl { get; set; }
        public virtual DbSet<GtEpdrcd> GtEpdrcd { get; set; }
        public virtual DbSet<GtEpdrco> GtEpdrco { get; set; }
        public virtual DbSet<GtEpdrfr> GtEpdrfr { get; set; }
        public virtual DbSet<GtEpdrgc> GtEpdrgc { get; set; }
        public virtual DbSet<GtEpdrgn> GtEpdrgn { get; set; }
        public virtual DbSet<GtEpdrmf> GtEpdrmf { get; set; }
        public virtual DbSet<GtEpdrpa> GtEpdrpa { get; set; }
        public virtual DbSet<GtEpdrro> GtEpdrro { get; set; }
        public virtual DbSet<GtEpdrvl> GtEpdrvl { get; set; }
        public virtual DbSet<GtEpdtms> GtEpdtms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=103.227.97.123,1433;Database=eSyaEnterprise_Prod;user id=esya;password=Gt@pl#20;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<GtEastbl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.StoreCode, e.StoreClass });

                entity.ToTable("GT_EASTBL");

                entity.Property(e => e.StoreClass)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.BusinessKeyNavigation)
                    .WithMany(p => p.GtEastbl)
                    .HasPrincipalKey(p => p.BusinessKey)
                    .HasForeignKey(d => d.BusinessKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EASTBL_GT_ECBSLN");
            });

            modelBuilder.Entity<GtEavncd>(entity =>
            {
                entity.HasKey(e => e.VendorCode);

                entity.ToTable("GT_EAVNCD");

                entity.Property(e => e.VendorCode).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreditPeriod).HasColumnType("numeric(3, 0)");

                entity.Property(e => e.CreditType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.PreferredPaymentMode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonForBlacklist).HasMaxLength(100);

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GtEavndr>(entity =>
            {
                entity.HasKey(e => new { e.VendorCode, e.DrugCode });

                entity.ToTable("GT_EAVNDR");

                entity.Property(e => e.BusinessShare).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MinimumSupplyQty).HasColumnType("numeric(12, 3)");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Rate).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.RateType)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEcapcd>(entity =>
            {
                entity.HasKey(e => e.ApplicationCode)
                    .HasName("PK_GT_ECAPCD_1");

                entity.ToTable("GT_ECAPCD");

                entity.Property(e => e.ApplicationCode).ValueGeneratedNever();

                entity.Property(e => e.CodeDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ShortCode).HasMaxLength(15);

                entity.HasOne(d => d.CodeTypeNavigation)
                    .WithMany(p => p.GtEcapcd)
                    .HasForeignKey(d => d.CodeType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECAPCD_GT_ECAPCT");
            });

            modelBuilder.Entity<GtEcapct>(entity =>
            {
                entity.HasKey(e => e.CodeType);

                entity.ToTable("GT_ECAPCT");

                entity.Property(e => e.CodeType).ValueGeneratedNever();

                entity.Property(e => e.CodeTyepDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CodeTypeControl)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcbsen>(entity =>
            {
                entity.HasKey(e => e.BusinessId);

                entity.ToTable("GT_ECBSEN");

                entity.Property(e => e.BusinessId)
                    .HasColumnName("BusinessID")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusinessDesc)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.BusinessUnitType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEcbsln>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.SegmentId, e.LocationId });

                entity.ToTable("GT_ECBSLN");

                entity.HasIndex(e => e.BusinessKey)
                    .HasName("IX_GT_ECBSLN")
                    .IsUnique();

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.BusinessName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EActiveUsers)
                    .IsRequired()
                    .HasColumnName("eActiveUsers");

                entity.Property(e => e.EBusinessKey)
                    .IsRequired()
                    .HasColumnName("eBusinessKey");

                entity.Property(e => e.ENoOfBeds).HasColumnName("eNoOfBeds");

                entity.Property(e => e.ESyaLicenseType)
                    .IsRequired()
                    .HasColumnName("eSyaLicenseType")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.EUserLicenses)
                    .IsRequired()
                    .HasColumnName("eUserLicenses");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LocationCode)
                    .IsRequired()
                    .HasMaxLength(6);

                entity.Property(e => e.LocationDescription)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.TocurrConversion).HasColumnName("TOCurrConversion");

                entity.Property(e => e.TolocalCurrency)
                    .IsRequired()
                    .HasColumnName("TOLocalCurrency")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TorealCurrency).HasColumnName("TORealCurrency");

                entity.HasOne(d => d.GtEcbssg)
                    .WithMany(p => p.GtEcbsln)
                    .HasForeignKey(d => new { d.BusinessId, d.SegmentId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECBSLN_GT_ECBSSG");
            });

            modelBuilder.Entity<GtEcbssg>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId, e.SegmentId });

                entity.ToTable("GT_ECBSSG");

                entity.Property(e => e.BusinessId).HasColumnName("BusinessID");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OrgnDateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SegmentDesc)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.HasOne(d => d.Business)
                    .WithMany(p => p.GtEcbssg)
                    .HasForeignKey(d => d.BusinessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECBSSG_GT_ECBSEN");
            });

            modelBuilder.Entity<GtEccncd>(entity =>
            {
                entity.HasKey(e => e.Isdcode);

                entity.ToTable("GT_ECCNCD");

                entity.Property(e => e.Isdcode)
                    .HasColumnName("ISDCode")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.CountryFlag)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.DateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsPinapplicable).HasColumnName("IsPINApplicable");

                entity.Property(e => e.IsPoboxApplicable).HasColumnName("IsPOBoxApplicable");

                entity.Property(e => e.MobileNumberPattern)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.PincodePattern)
                    .HasColumnName("PINcodePattern")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PoboxPattern)
                    .HasColumnName("POBoxPattern")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDateFormat)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Uidlabel)
                    .HasColumnName("UIDLabel")
                    .HasMaxLength(50);

                entity.Property(e => e.Uidpattern)
                    .HasColumnName("UIDPattern")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<GtEccntc>(entity =>
            {
                entity.HasKey(e => new { e.Isdcode, e.TaxCode });

                entity.ToTable("GT_ECCNTC");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.SlabOrPerc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TaxDescription)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TaxShortCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.IsdcodeNavigation)
                    .WithMany(p => p.GtEccntc)
                    .HasForeignKey(d => d.Isdcode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_ECCNTC_GT_ECCNCD");
            });

            modelBuilder.Entity<GtEcfmfd>(entity =>
            {
                entity.HasKey(e => e.FormId);

                entity.ToTable("GT_ECFMFD");

                entity.Property(e => e.FormId)
                    .HasColumnName("FormID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ControllerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FormName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ToolTip).HasMaxLength(100);
            });

            modelBuilder.Entity<GtEcfmst>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.StoreCode });

                entity.ToTable("GT_ECFMST");

                entity.Property(e => e.FormId).HasColumnName("FormID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEciuom>(entity =>
            {
                entity.HasKey(e => e.UnitOfMeasure);

                entity.ToTable("GT_ECIUOM");

                entity.Property(e => e.UnitOfMeasure).ValueGeneratedNever();

                entity.Property(e => e.ConversionFactor).HasColumnType("numeric(12, 5)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.Uompdesc)
                    .IsRequired()
                    .HasColumnName("UOMPDesc")
                    .HasMaxLength(50);

                entity.Property(e => e.Uompurchase)
                    .IsRequired()
                    .HasColumnName("UOMPurchase")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Uomsdesc)
                    .IsRequired()
                    .HasColumnName("UOMSDesc")
                    .HasMaxLength(50);

                entity.Property(e => e.Uomstock)
                    .IsRequired()
                    .HasColumnName("UOMStock")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEcstrm>(entity =>
            {
                entity.HasKey(e => e.StoreCode)
                    .HasName("PK_GT_ECSTRM_1");

                entity.ToTable("GT_ECSTRM");

                entity.Property(e => e.StoreCode).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.StoreDesc)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StoreType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEpdrbi>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.DrugCode, e.StoreCode });

                entity.ToTable("GT_EPDRBI");

                entity.Property(e => e.BinInfo)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEpdrbl>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.DrugCode });

                entity.ToTable("GT_EPDRBL");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEpdrcd>(entity =>
            {
                entity.HasKey(e => e.DrugCode)
                    .HasName("PK_GT_EPDRCD_1");

                entity.ToTable("GT_EPDRCD");

                entity.Property(e => e.DrugCode).ValueGeneratedNever();

                entity.Property(e => e.BarcodeId)
                    .HasColumnName("BarcodeID")
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DrugBrand)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DrugFormulaId).HasColumnName("DrugFormulaID");

                entity.Property(e => e.DrugPrintDesc).HasMaxLength(150);

                entity.Property(e => e.DrugVolume).HasMaxLength(15);

                entity.Property(e => e.GenericId).HasColumnName("GenericID");

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ReferenceMrp)
                    .HasColumnName("ReferenceMRP")
                    .HasColumnType("numeric(18, 6)");
            });

            modelBuilder.Entity<GtEpdrco>(entity =>
            {
                entity.HasKey(e => e.CompositionId);

                entity.ToTable("GT_EPDRCO");

                entity.Property(e => e.CompositionId)
                    .HasColumnName("CompositionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompositionDesc)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEpdrfr>(entity =>
            {
                entity.HasKey(e => new { e.GenericId, e.DrugFormulaId });

                entity.ToTable("GT_EPDRFR");

                entity.Property(e => e.GenericId).HasColumnName("GenericID");

                entity.Property(e => e.DrugFormulaId).HasColumnName("DrugFormulaID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DrugFormulation)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.Generic)
                    .WithMany(p => p.GtEpdrfr)
                    .HasForeignKey(d => d.GenericId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EPDRFR_GT_EPDRGN");
            });

            modelBuilder.Entity<GtEpdrgc>(entity =>
            {
                entity.HasKey(e => new { e.GenericId, e.CompositionId });

                entity.ToTable("GT_EPDRGC");

                entity.Property(e => e.GenericId).HasColumnName("GenericID");

                entity.Property(e => e.CompositionId).HasColumnName("CompositionID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEpdrgn>(entity =>
            {
                entity.HasKey(e => e.GenericId);

                entity.ToTable("GT_EPDRGN");

                entity.Property(e => e.GenericId)
                    .HasColumnName("GenericID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GenericDesc)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });

            modelBuilder.Entity<GtEpdrmf>(entity =>
            {
                entity.HasKey(e => e.ManufacturerId);

                entity.ToTable("GT_EPDRMF");

                entity.Property(e => e.ManufacturerId)
                    .HasColumnName("ManufacturerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Isdcode).HasColumnName("ISDCode");

                entity.Property(e => e.ManfShortName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MarketedBy).HasMaxLength(100);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.OriginCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GtEpdrpa>(entity =>
            {
                entity.HasKey(e => new { e.DrugCode, e.ParameterId });

                entity.ToTable("GT_EPDRPA");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.HasOne(d => d.DrugCodeNavigation)
                    .WithMany(p => p.GtEpdrpa)
                    .HasForeignKey(d => d.DrugCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GT_EPDRPA_GT_EPDRCD");
            });

            modelBuilder.Entity<GtEpdrro>(entity =>
            {
                entity.HasKey(e => new { e.BusinessKey, e.DrugCode, e.StoreCode });

                entity.ToTable("GT_EPDRRO");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasColumnName("FormID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaximumStockLevel).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.MinimumStockLevel).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);

                entity.Property(e => e.ReorderLevel).HasColumnType("numeric(10, 3)");

                entity.Property(e => e.SafetyStockLevel).HasColumnType("numeric(10, 3)");
            });

            modelBuilder.Entity<GtEpdrvl>(entity =>
            {
                entity.HasKey(e => e.Packing);

                entity.ToTable("GT_EPDRVL");

                entity.Property(e => e.Packing).ValueGeneratedNever();
            });

            modelBuilder.Entity<GtEpdtms>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.Id });

                entity.ToTable("GT_EPDTMS");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedTerminal)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedTerminal).HasMaxLength(50);
            });
        }
    }
}
