﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Server.Models
{
    public partial class Assignment02Context : DbContext
    {
        public Assignment02Context()
        {
        }

        public Assignment02Context(DbContextOptions<Assignment02Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblPhone> TblPhones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database =Assignment02;uid=duckm;pwd=123456;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblPhone>(entity =>
            {
                entity.ToTable("tblPhone");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateofManufacture).HasColumnType("datetime");

                entity.Property(e => e.StopManufacture).HasColumnName("stopManufacture");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}