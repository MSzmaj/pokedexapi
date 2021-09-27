using PokedexApi.DataAccess.EntityModels.Pokemon;
using PokedexApi.DataAccess.DataMaps;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using System.Linq;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;

namespace PokedexApi.DataAccess.Context {
    public class PokemonDbContext : DbContext {
        public PokemonDbContext (DbContextOptions options) : base (options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);   
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PokemonEntityMap());
        }

        public virtual DbSet<PokemonEntity> Pokemon { get; set; }

        private static void Seed (ModelBuilder modelBuilder) {
            var pokemonList = new List<PokemonEntity>();
            using (var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/../../../../../Data/pokemon.csv")) //TODO: Write better path.
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
                csv.Context.RegisterClassMap<CsvPokemonMap>();
                pokemonList = csv.GetRecords<PokemonEntity>().ToList();
            }

            foreach (var pokemon in pokemonList) {
                pokemon.Id = Guid.NewGuid();

                modelBuilder.Entity<PokemonEntity>().HasData(pokemon);
            }
        }
    }
}