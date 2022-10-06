using ProjectPokemonUwp.Interface;
using ProjectPokemonUwp.Model;
using ProjectPokemonUwp.Repository.DB;
using ProjectPokemonUwp.Repository.Factory.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonUwp.Repository.Factory.DB
{
    public class SqliteDBConnectionFatory : IDBConnection
    {
        private Dictionary<int, string> types = new Dictionary<int, string>();

        public SqliteDBConnectionFatory()
        {
            types.Add(0, "normal");
            types.Add(1, "fighting");
            types.Add(2, "flying");
            types.Add(3, "poison");
            types.Add(4, "ground");
            types.Add(5, "rock");
            types.Add(6, "bug");
            types.Add(7, "ghost");
            types.Add(8, "steel");
            types.Add(9, "fire");
            types.Add(10, "water");
            types.Add(11, "grass");
            types.Add(12, "electric");
            types.Add(13, "psychic");
            types.Add(14, "ice");
            types.Add(15, "dragon");
            types.Add(16, "dark");
            types.Add(17, "fairy");
            types.Add(18, "unknown");
            types.Add(19, "shadow");
        }

        public void InitializationDBWithFirstPokemons()
        {
            var result1 = Task.Run(async () => await SqliteDBPokemonTable.InitializeTablePokemonDB()).Result;
            var result2 = Task.Run(async () => await SqliteDBAbilitiesTable.InitializeTableAbilitiesDB()).Result;
            var result3 = Task.Run(async () => await SqliteDBTypesTable.InitializeTableTypesDB()).Result;


            string pikachu = "25", bulbasaur = "1", charmander = "4", squirtle = "7";
            List<string> pokemons = new List<string>
            {
                pikachu,
                bulbasaur,
                squirtle,
                charmander
            };

            pokemons.ForEach((value) =>
            {
                var listPokemon = new SearchPokemonByIdFromApi().SearchAndGetPokemon(value);
                foreach (var pokemon in listPokemon)
                {
                    AddPokemonToDB(pokemon);
                }
            });
        }

        public void AddPokemonToDB(Pokemon pokemon)
        {
            SqliteDBPokemonTable.AddPokemonToDB(pokemon);
            SqliteDBAbilitiesTable.AddAbilitiesToDB(pokemon);
            SqliteDBTypesTable.AddTypesToDB(pokemon);
        }

        public IDBConnection CreateConnection()
        {
            return new SqliteDBConnectionFatory();
        }

        public List<Pokemon> GetPokemons(string pokemonAttribute)
        {
            if (string.IsNullOrEmpty(pokemonAttribute))
                return new SearchPokemonByIdFromDB().SearchAndGetPokemon(pokemonAttribute);
            if (types.ContainsValue(pokemonAttribute))
                return new SearchPokemonByTypeFromDB().SearchAndGetPokemon(pokemonAttribute);
            if (pokemonAttribute.All(char.IsDigit))
                return new SearchPokemonByIdFromDB().SearchAndGetPokemon(pokemonAttribute);
            return new SearchPokemonByNameFromDB().SearchAndGetPokemon(pokemonAttribute);
        }

        public bool ThisPokemonExist(string pokemonAttribute)
        {
            if (string.IsNullOrEmpty(pokemonAttribute))
                return new SearchPokemonByTypeFromDB().ThisPokemonExist(pokemonAttribute);
            if (pokemonAttribute.All(char.IsDigit))
                return new SearchPokemonByIdFromDB().ThisPokemonExist(pokemonAttribute);
            if (types.ContainsValue(pokemonAttribute))
                return new SearchPokemonByTypeFromDB().ThisPokemonExist(pokemonAttribute);
            return new SearchPokemonByNameFromDB().ThisPokemonExist(pokemonAttribute);
        }
    }
}
