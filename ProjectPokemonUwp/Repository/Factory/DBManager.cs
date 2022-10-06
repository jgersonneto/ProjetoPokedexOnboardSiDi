using ProjectPokemonUwp.Model;
using ProjectPokemonUwp.Repository.Factory.Api;
using ProjectPokemonUwp.Repository.Factory.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonUwp.Repository.Factory
{
    public class DBManager
    {
        SqliteDBConnectionFatory sqliteDbConnection = new SqliteDBConnectionFatory();
        ApiDBConnectionFatory apiDbConnection = new ApiDBConnectionFatory();

        public DBManager()
        {

        }
        public async Task<List<Pokemon>> GetPokemons(string pokemonAttribute)
        {
            return sqliteDbConnection.GetPokemons(pokemonAttribute);
        }

        public void InicializeConnection()
        {
            sqliteDbConnection.InitializationDBWithFirstPokemons();
        }

        public List<Pokemon> GetAllPokemonsFromSqlite()
        {
            var pokemons = sqliteDbConnection.GetPokemons("");
            return pokemons;
        }

        public async Task SearchPokemonsInApi(string pokemonAttribute)
        {
            List<Pokemon> pokemonsAPI;
            await Task.Run(() =>
            {
                if (!sqliteDbConnection.ThisPokemonExist(pokemonAttribute))
                {
                    pokemonsAPI = apiDbConnection.GetPokemons(pokemonAttribute);
                    pokemonsAPI?.ForEach((pokemon) =>
                    {
                        var pokemonApi = apiDbConnection.GetPokemons(pokemon.Name)[0];
                        if (pokemonApi?.Id <= 251)
                            apiDbConnection.AddPokemonToDB(pokemonApi);
                    });
                }
            });
        }

        public bool ExistPokemonInSqlite(string pokemonAttribute)
        {
            return sqliteDbConnection.ThisPokemonExist(pokemonAttribute);
        }

        public void CreateNewPokemon(Pokemon pokemon)
        {
            sqliteDbConnection.AddPokemonToDB(pokemon);
        }

        //public List<Pokemon> SearchPokemonsInSqlite(string pokemonAttribute)
        //{
        //    return sqliteDbConnection.GetPokemons(pokemonAttribute);
        //}
    }
}
