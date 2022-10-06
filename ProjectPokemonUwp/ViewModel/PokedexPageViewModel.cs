using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectPokemonUwp.Model;
using ProjectPokemonUwp.Repository.Factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace ProjectPokemonUwp.ViewModel
{
    public class PokedexPageViewModel : ObservableObject
    {
        private DBManager _manegerConnection = new DBManager();

        //private ObservableCollection<Category> categories = new ObservableCollection<Category>();
        private ObservableCollection<Pokemon> _observerListPokemons = new ObservableCollection<Pokemon>();
        private List<Pokemon> _pokemonSearchResult = new List<Pokemon>();

        private Pokemon _pokemon = new Pokemon();

        private string _textAutoSuggestBox;
        private bool _isVisibleButton = true;

        private List<string> _cats = new List<string>()
        {
            "Abyssinian",
            "Aegean",
            "American Bobtail",
        };

        public Pokemon Pokemon
        {
            get => _pokemon;
            set => SetProperty(ref _pokemon, value);
        }

        public ObservableCollection<Pokemon> ObserverListPokemons
        {
            get => _observerListPokemons;
            set => SetProperty(ref _observerListPokemons, value);
        }

        public List<Pokemon> PokemonSearchResult
        {
            get => _pokemonSearchResult;
            set => _pokemonSearchResult = value;
        }

        public DBManager ManegerConnection
        {
            get => _manegerConnection;
            set => _manegerConnection = value;
        }

        public string TextAutoSuggestBox
        {
            get => _textAutoSuggestBox;
            set => SetProperty(ref _textAutoSuggestBox, value);
        }

        public bool IsVisibleButton
        {
            get => _isVisibleButton;
            set => SetProperty(ref _isVisibleButton, value);
        }

        public List<string> Cats
        {
            get => _cats;
            set => _cats = value;
        }

        private void InitializeDB()
        {
            ManegerConnection.InicializeConnection();
            ShowAllPokemonsDBSql();
        }

        public IRelayCommand SearchPokemons { get; }
        public async void SearchPokemon()
        {
            ObserverListPokemons.Clear();
            PokemonSearchResult.Clear();
            await Task.Run(() =>
            {
                var task = ManegerConnection.SearchPokemonsInApi(TextAutoSuggestBox);
                task.Wait();
            });

            var TaskPokemonSearchResult = ManegerConnection.GetPokemons(TextAutoSuggestBox);

            PokemonSearchResult = await TaskPokemonSearchResult;
            foreach (var pokemon in PokemonSearchResult)
            {
                ObserverListPokemons.Add(pokemon);
            };


            //searchForTenPages();
            //VisibleGo();
            TextAutoSuggestBox = "";
        }

        public ICommand ShowAllPokemonsDBSqlite { get; }
        private async void ShowAllPokemonsDBSql()
        {
            PokemonSearchResult = ManegerConnection.GetAllPokemonsFromSqlite();
            foreach (var pokemon in PokemonSearchResult)
            {
                ObserverListPokemons.Add(pokemon);
            }
        }

        public void SearchPokemon2(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suitableItems = new List<string>();
                var splitText = sender.Text.ToLower().Split(" ");
                foreach (var cat in Cats)
                {
                    var found = splitText.All((key) =>
                    {
                        return cat.ToLower().Contains(key);
                    });
                    if (found)
                    {
                        suitableItems.Add(cat);
                    }
                }
                if (suitableItems.Count == 0)
                {
                    suitableItems.Add("No results found");
                }
                sender.ItemsSource = suitableItems;
            }
        }

        public ICommand CatchSelectedPokemon
        {
            get;
            private set;
        }
        private async void SelectedPokemon(Pokemon p)
        {
            Pokemon = p;
        }


        public PokedexPageViewModel()
        {
            InitializeDB();

            //SearchPokemon = new RelayCommand(SearchByIdTypeName);
            ShowAllPokemonsDBSqlite = new RelayCommand(ShowAllPokemonsDBSql);
            SearchPokemons = new RelayCommand(SearchPokemon);
            CatchSelectedPokemon = new RelayCommand<Pokemon>(SelectedPokemon);


        }
    }
}
