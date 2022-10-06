using ProjectPokemonUwp.Interface;
using ProjectPokemonUwp.Model;
using ProjectPokemonUwp.Repository.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonUwp.Repository.Factory.Api
{
    public class ApiDBConnectionFatory : IDBConnection
    {
        private Dictionary<int, string> types = new Dictionary<int, string>();

        public ApiDBConnectionFatory()
        {
            types.Add(0, "normal");
            types.Add(1, "fighting");
            types.Add(2, "flying");
            types.Add(3, "poison");
            types.Add(4, "ground");
            types.Add(5, "rock");
            types.Add(6, "bug");
            types.Add(7, "ghost");
            types.Add(8, "steel");
            types.Add(9, "fire");
            types.Add(10, "water");
            types.Add(11, "grass");
            types.Add(12, "electric");
            types.Add(13, "psychic");
            types.Add(14, "ice");
            types.Add(15, "dragon");
            types.Add(16, "dark");
            types.Add(17, "fairy");
            types.Add(18, "unknown");
            types.Add(19, "shadow");
        }

        public void AddPokemonToDB(Pokemon pokemon)
        {
            SqliteDBPokemonTable.AddPokemonToDB(pokemon);
            SqliteDBAbilitiesTable.AddAbilitiesToDB(pokemon);
            SqliteDBTypesTable.AddTypesToDB(pokemon);
        }

        public IDBConnection CreateConnection()
        {
            return new ApiDBConnectionFatory();
        }

        public List<Pokemon> GetPokemons(string pokemonAttribute)
        {
            if (string.IsNullOrEmpty(pokemonAttribute))
                return null;
            if (types.ContainsValue(pokemonAttribute))
                return new SearchPokemonByTypeFromApi().SearchAndGetPokemon(pokemonAttribute);
            if (pokemonAttribute.All(char.IsDigit))
                return new SearchPokemonByIdFromApi().SearchAndGetPokemon(pokemonAttribute);
            return new SearchPokemonByNameFromApi().SearchAndGetPokemon(pokemonAttribute);
        }
    }
}
