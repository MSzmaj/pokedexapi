using System;

namespace PokedexApi.DataAccess.Interfaces {
    public interface IEntity {
        Guid Id { get; set; }
    }
}