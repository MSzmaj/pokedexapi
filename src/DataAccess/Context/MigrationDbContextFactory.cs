using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PokedexApi.Common.Common;

namespace PokedexApi.DataAccess.Context {
    internal class MigrationDbContextFactory : IDesignTimeDbContextFactory<PokemonDbContext>
    {
        public PokemonDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
                
            var optionsBuilder = new DbContextOptionsBuilder<PokemonDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(Constants.DbContext)).UseLowerCaseNamingConvention();
            return new PokemonDbContext(optionsBuilder.Options);
        }
    }
}