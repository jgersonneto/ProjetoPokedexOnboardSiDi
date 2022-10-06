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
    public class SearchPokemonByTypeFromApi : ISearchPokemon
    {
        public List<Pokemon> SearchAndGetPokemon(string pokemonAttribute)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            Types typePoke = Task.Run(async () => await ApiService.ApiPokeByTypes(pokemonAttribute)).Result;
            foreach (var pokemonType in typePoke.Pokemon)
            {
                Pokemon pokemon = new Pokemon()
                {
                    Name = pokemonType.Pokemon.Name
                };
                pokemons.Add(pokemon);
            }
            return pokemons;
        }
    }
}
