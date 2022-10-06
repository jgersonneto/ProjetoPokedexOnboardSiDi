﻿using ProjectPokemonUwp.Interface;
using ProjectPokemonUwp.Model;
using ProjectPokemonUwp.Repository.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonUwp.Repository.Factory.DB
{
    public class SearchPokemonByTypeFromDB : ISearchPokemon
    {
        public List<Pokemon> SearchAndGetPokemon(string pokemonAttribute)
        {
            var pokemons = SqliteDBPokemonTable.SearchPokemonByType(pokemonAttribute);
            pokemons = SqliteDBTypesTable.SearchInTypesByNameForMainPage(pokemons);
            return pokemons;
        }
        public bool ThisPokemonExist(string pokemonAttribute)
        {
            return false;
        }
    }
}
