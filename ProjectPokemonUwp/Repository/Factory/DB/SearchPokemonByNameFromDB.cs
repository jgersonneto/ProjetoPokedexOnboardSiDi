using ProjectPokemonUwp.Interface;
using ProjectPokemonUwp.Model;
using ProjectPokemonUwp.Repository.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonUwp.Repository.Factory.DB
{
    public class SearchPokemonByNameFromDB : ISearchPokemon
    {
        public List<Pokemon> SearchAndGetPokemon(string pokemonAttribute)
        {
            var pokemons = SqliteDBPokemonTable.SearchPokemonByNameForMainPage(pokemonAttribute);
            pokemons = SqliteDBTypesTable.SearchInTypesByNameForMainPage(pokemons);

            return pokemons;
        }

        public bool ThisPokemonExist(string pokemonAttribute)
        {
            bool result = false;
            var pokemons = SqliteDBPokemonTable.SearchOnePokemonByName(pokemonAttribute);
            if (pokemons.Count != 0)
            {
                result = true;
            }
            return result;
        }
    }
}
