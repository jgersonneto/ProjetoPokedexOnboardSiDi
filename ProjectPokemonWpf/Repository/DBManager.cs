using ProjectPokemonWpf.Model;
using ProjectPokemonWpf.Repository.Factory.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonWpf.Repository.Factory
{
    public class DBManager
    {
        //SqliteDBConnectionFatory sqliteDbConnection = new SqliteDBConnectionFatory();

        //public DBManager()
        //{
        //    //InicializeConnection();
        //}
        //public async Task<List<Pokemon>> GetPokemons(string pokemonAttribute)
        //{
        //    return sqliteDbConnection.GetPokemons(pokemonAttribute);
        //}

        //public List<Pokemon> GetAllPokemonsFromSqlite()
        //{
        //    var pokemons = sqliteDbConnection.GetPokemons("");
        //    return pokemons;
        //}

        //public bool ExistPokemonInSqlite(string pokemonAttribute)
        //{
        //    return sqliteDbConnection.ThisPokemonExist(pokemonAttribute);
        //}
        //public void InicializeConnection()
        //{
        //    sqliteDbConnection.InitializationDBWithFirstPokemons();
        //}

        ////public Pokemon SearchPokemonsInApiNewDB(string pokemonAttribute)
        ////{
        ////    List<Pokemon> pokemonsAPI;
        ////    pokemonsAPI = apiDbConnection.GetPokemons(pokemonAttribute);
        ////    return pokemonsAPI[0];
        ////}

        ////public List<Pokemon> SearchPokemonsInSqlite(string pokemonAttribute)
        ////{
        ////    return sqliteDbConnection.GetPokemons(pokemonAttribute);
        ////}
    }
}
