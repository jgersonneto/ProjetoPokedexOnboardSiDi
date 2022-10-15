using ProjectPokemonWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonWpf.Interface
{
    public interface IDBConnection
    {
        void AddPokemonToDB(Pokemon pokemon);
        List<Pokemon> GetPokemons(string pokemonAttribute);
        IDBConnection CreateConnection();
    }
}
