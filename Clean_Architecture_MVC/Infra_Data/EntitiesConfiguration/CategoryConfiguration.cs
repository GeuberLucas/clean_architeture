using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra_Data.EntitiesConfiguration
{
    //Arquivo de Configuração da tabela Categories utilizando Entity
    class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.HasData(
                new Category(1,DateTime.Now,DateTime.Now,"Material Escolar"),
                new Category(2,DateTime.Now,DateTime.Now,"Eletrônicos"),
                new Category(3,DateTime.Now,DateTime.Now,"Acessórios")
                );
        }
    }
}
