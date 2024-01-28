using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sistema_de_Gestão_de_Colaboradores.Models;

namespace Sistema_de_Gestão_de_Colaboradores.Data.Map
{
    public class UnitMap : IEntityTypeConfiguration<UnitModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UnitModel> builder)
        {
            builder.HasKey(x => x.Id); // Chave primária

            builder.Property(x => x.UnitCode)
                   .IsRequired(); // Código da unidade é obrigatório

            builder.HasIndex(x => x.UnitCode).IsUnique();

            builder.Property(x => x.Name)
                   .IsRequired() // Nome é obrigatório
                   .HasMaxLength(30); // Comprimento máximo de 30 caracteres

            builder.Property(x => x.Status)
                   .IsRequired(); // Status é obrigatório

            builder.HasMany(u => u.Employees) // Assume que 'Employees' é a coleção em UnitModel
              .WithOne(e => e.Unit) // Assume que 'Unit' é a propriedade de navegação em EmployeeModel
              .HasForeignKey(e => e.UnitId); // Chave estrangeira em EmployeeModel
        
        }
    }
}
