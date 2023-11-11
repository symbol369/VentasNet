﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;

namespace VentasNet.Entity.Data.Configurations
{
    public partial class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.HasKey(e => e.IdProducto);

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.FechaAlta).HasColumnType("datetime");

            entity.Property(e => e.FechaBaja).HasColumnType("datetime");

            entity.Property(e => e.ImporteProducto)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.NombreProducto)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Producto> entity);
    }
}
