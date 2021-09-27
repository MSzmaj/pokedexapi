using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokedexApi.DataAccess.EntityModels.Pokemon;

namespace PokedexApi.DataAccess.DataMaps {
    public class PokemonEntityMap : IEntityTypeConfiguration<PokemonEntity> {
        public void Configure(EntityTypeBuilder<PokemonEntity> builder)
        {
            builder.ToTable("pokemon");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Number);
            builder.Property(x => x.Name);
            builder.Property(x => x.Type1);
            builder.Property(x => x.Type2);
            builder.Property(x => x.Total);
            builder.Property(x => x.Hp);
            builder.Property(x => x.Attack);
            builder.Property(x => x.Defense);
            builder.Property(x => x.SpAttack);
            builder.Property(x => x.SpDefense);
            builder.Property(x => x.Speed);
            builder.Property(x => x.Generation);
            builder.Property(x => x.Legendary);
        }
    }
}