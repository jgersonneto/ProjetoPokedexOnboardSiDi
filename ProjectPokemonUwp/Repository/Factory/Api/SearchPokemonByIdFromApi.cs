using ProjectPokemonUwp.Interface;
using ProjectPokemonUwp.Model;
using ProjectPokemonUwp.Repository.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonUwp.Repository.Factory.Api
{
    public class SearchPokemonByIdFromApi : ISearchPokemon
    {
        public List<Pokemon> SearchAndGetPokemon(string pokemonAttribute)
        {
            int id = short.Parse(pokemonAttribute);
            List<Pokemon> pokemons = new List<Pokemon>();
            pokemons.Add(Task.Run(async () => await ApiService.ApiPokeById(id)).Result);
            return pokemons;
        }
    }
}
