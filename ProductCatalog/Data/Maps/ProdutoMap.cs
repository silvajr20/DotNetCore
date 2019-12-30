using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalog.Models;

namespace ProductCatalog.Data.Maps{

    public class ProdutoMap : IEntityTypeConfiguration<Produto>{
        public void Configure(EntityTypeBuilder<Produto> builder){
            builder.ToTable("Produto");
            builder.HasKey(x => x.id);
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(x => x.Image).IsRequired().HasMaxLength(1024).HasColumnType("varchar(1024)");
            builder.Property(x => x.LastUpdateDate).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("money");
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
            builder.HasOne(x => x.Categoria).WithMany(x => x.Produtos);
        }


    }

}