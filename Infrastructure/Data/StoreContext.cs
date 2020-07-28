using System.Linq;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    //Como setar a biblioteca DbContext contida na classe API/Data/StoreContext.cs 
    //Video Seção 3: Setting up Entity Framework 4:04
    //Ctrl Shift P: Selecionar NugetPacketManager
    //Digitar: Microsoft.EntityFrameworkCore, selecionar da lista Microsoft.EntityFrameworkCore
    //Selecionar a versão 3.1.6 (versão do Host do dotnet usando o comando dotnet --info, 
    // no prompt do diretorio, como visto abaixo:
    //...
    //Host (useful for support):
    //Version: 3.1.6
    //Repetir o processo para baixar a biblioteca do SQLite...
    //Ctrl Shift P: Selecionar NugetPacketManager
    //Digitar: Microsoft.EntityFrameworkCore, selecionar da lista Microsoft.EntityFrameworkCore.SQLite
    //Selecionar a versão 3.1.6 (versão do Host do dotnet usando o comando dotnet --info, 
    //Clique na mensage de Restore e depois, no prompt do projeto, Restaure digitanto: dotnet restore
    // Ctrl + . (opçoes de correção)
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes()){
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType 
                    == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                        .HasConversion<double>();
                    }
                }
            }
        }
    }
}