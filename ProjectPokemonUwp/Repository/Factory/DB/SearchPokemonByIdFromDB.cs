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
    public class SearchPokemonByIdFromDB : ISearchPokemon
    {
        public List<Pokemon> SearchAndGetPokemon(string pokemonAttribute)
        {

            dynamic pokemons;
            if (string.IsNullOrEmpty(pokemonAttribute))
            {
                pokemons = SqliteDBPokemonTable.GetAllAttributesForMainPage();
                pokemons = SqliteDBTypesTable.GetAllAttributesForMainPage(pokemons);
                return pokemons;
            }
            var Attribute = short.Parse(pokemonAttribute);
            pokemons = SqliteDBPokemonTable.SearchPokemonByIdForMainPage(Attribute);
            pokemons = SqliteDBTypesTable.SearchInTypesByIdForMainPage(pokemons);

            return pokemons;
        }

        public bool ThisPokemonExist(string pokemonAttribute)
        {
            var Attribute = short.Parse(pokemonAttribute);
            bool result = false;
            var pokemons = SqliteDBPokemonTable.SearchOnePokemonById(Attribute);
            if (pokemons.Count != 0)
            {
                result = true;
            }
            return result;
        }
    }
}
