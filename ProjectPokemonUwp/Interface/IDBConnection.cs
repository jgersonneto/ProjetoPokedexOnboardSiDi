using ProjectPokemonUwp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonUwp.Interface
{
    public interface IDBConnection
    {
        void AddPokemonToDB(Pokemon pokemon);
        List<Pokemon> GetPokemons(string pokemonAttribute);
        IDBConnection CreateConnection();
    }
}
