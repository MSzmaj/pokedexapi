using System.Collections.Generic;

namespace PokedexApi.Common.Common {
    public static class Constants {
        public static string DbContext = "PokemonDatabase";
        public const string LessThanEqual = "lte";
        public const string LessThan = "lt";
        public const string GreaterThanEqual = "gte";
        public const string GreaterThan = "gt";
        public const string EqualTo = "eq";
        public static List<string> Operators = new List<string> { LessThanEqual, LessThan, GreaterThanEqual, GreaterThan, EqualTo };
    }
}