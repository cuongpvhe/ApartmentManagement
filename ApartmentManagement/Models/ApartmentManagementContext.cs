﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApartmentManagement.Models
{
    public partial class ApartmentManagementContext : DbContext
    {
        public ApartmentManagementContext()
        {
        }

        public ApartmentManagementContext(DbContextOptions<ApartmentManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; } = null!;
        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Floor> Floors { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Resident> Residents { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>(entity =>
            {
                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.BuildingName).HasMaxLength(100);

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Buildings__Manag__276EDEB3");
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.RentPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ResidentId)
                    .HasConstraintName("FK__Contracts__Resid__3C69FB99");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Contracts__RoomI__3B75D760");
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.Property(e => e.FloorId).HasColumnName("FloorID");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Floors)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK__Floors__Building__2A4B4B5E");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Cccd)
                    .HasMaxLength(20)
                    .HasColumnName("CCCD");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.PaymentType).HasMaxLength(50);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Payments__RoomID__403A8C7D");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Payments__Servic__3F466844");
            });

            modelBuilder.Entity<Resident>(entity =>
            {
                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Avatar)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Cccd)
                    .HasMaxLength(20)
                    .HasColumnName("CCCD");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(10);

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Residents)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Residents__RoomI__34C8D9D1");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.FloorId).HasColumnName("FloorID");

                entity.Property(e => e.RoomNumber).HasMaxLength(10);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Floor)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.FloorId)
                    .HasConstraintName("FK__Rooms__FloorID__300424B4");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Rooms__ServiceID__30F848ED");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.ServiceFee).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ServiceName).HasMaxLength(100);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Services__Manage__2D27B809");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.VehicleId).HasColumnName("VehicleID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.LicensePlate).HasMaxLength(20);

                entity.Property(e => e.ResidentId).HasColumnName("ResidentID");

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.Property(e => e.VehicleType).HasMaxLength(50);

                entity.HasOne(d => d.Resident)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ResidentId)
                    .HasConstraintName("FK__Vehicles__Reside__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
