using ProjectPokemonUwp.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonUwp.Repository.Api
{
    public interface IApiPoke
    {
        [Get("/pokemon/{id}")]
        Task<Pokemon> GetPokemonAsyncById(int id);

        [Get("/pokemon/{name}")]
        Task<Pokemon> GetPokemonAsyncByName(string name);

        [Get("/type/{name}")]
        Task<Types> GetTypesAsyncByType(string name);
    }
}
