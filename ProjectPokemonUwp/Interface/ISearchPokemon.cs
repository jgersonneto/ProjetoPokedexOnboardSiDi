using ProjectPokemonUwp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonUwp.Interface
{
    public interface ISearchPokemon
    {
        List<Pokemon> SearchAndGetPokemon(string pokemonAttribute);
    }
}
