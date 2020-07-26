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
        public StoreContext(DbContextOptions<StoreContext> options) : base
        (options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}