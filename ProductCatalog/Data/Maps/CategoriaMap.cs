using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;

namespace ProductCatalog.Data.Maps{

    public class CategoriaMap : IEntityTypeConfiguration<Categoria> {

        public void Configure(EntityTypeBuilder<Categoria> builder){
            builder.ToTable("Categoria");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
        }
    }
}