using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestão_de_Colaboradores.Data.Map;
using Sistema_de_Gestão_de_Colaboradores.Models;

namespace Sistema_de_Gestão_de_Colaboradores.Data
{
    public class SystemDbContext : DbContext
    {
        public SystemDbContext(DbContextOptions<SystemDbContext> options) : base(options)
        {             
        }
        public DbSet<UserModel>? Users_tab { get; set; }
        public DbSet<EmployeeModel>? Employees_tab { get; set; }
        public DbSet<UnitModel>? Units_tab { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new UnitMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
