using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Connection.DataBase;
using ProjectPokemonUwp.Model;
using ProjectPokemonUwp.Repository.Factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProjectPokemonUwp.ViewModel
{
    public class PokedexPageViewModel : ObservableObject
    {
        private DBManager _manegerConnection = new DBManager();
        private DataBaseContext dataBaseContext;

        //private ObservableCollection<Category> categories = new ObservableCollection<Category>();
        private ObservableCollection<Pokemon> _observerListPokemons = new ObservableCollection<Pokemon>();
        private List<Pokemon> _pokemonSearchResult = new List<Pokemon>();
        private ObservableCollection<Pokemon> _pokemonOther = new ObservableCollection<Pokemon>();

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

        public ObservableCollection<Pokemon> PokemonOther 
        { 
            get => _pokemonOther;
            set => SetProperty(ref _pokemonOther, value);
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

        public DBManager ManagerConnection
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

            newDBTest();
            ManagerConnection.InicializeConnection();
            ShowAllPokemonsDBSql();
        }

        public async void newDBTest()
        {
            dataBaseContext = new DataBaseContext(Path.Combine(ApplicationData.Current.LocalFolder.Path, "PokeDexOnBoard.db"));
            Pokemon pokemon;


            if (dataBaseContext != null)
            {
                pokemon = ManagerConnection.SearchPokemonsInApiNewDB("charizard");
                Connection.Dispatcher.Sprites sp = new Connection.Dispatcher.Sprites()
                {
                    Front_Default = pokemon.Sprites.Other.Home.Front_Default
                };
                Connection.Dispatcher.Pokemon pk = new Connection.Dispatcher.Pokemon()
                {
                    Id = pokemon.Id,
                    Name = pokemon.Name,
                    Base_Experience = pokemon.Base_Experience,
                    Height = pokemon.Height,
                    Weight = pokemon.Weight,
                    Sprites = sp,
                    Abilities = null,
                    Stats = null,
                    Types = null
                };


                await dataBaseContext.AddPokemonToDB(pk);
            }
        }

        public IRelayCommand SearchPokemons { get; }
        public async void SearchPokemon()
        {
            ObserverListPokemons.Clear();
            PokemonSearchResult.Clear();
            await Task.Run(() =>
            {
                var task = ManagerConnection.SearchPokemonsInApi(TextAutoSuggestBox);
                task.Wait();
            });

            var TaskPokemonSearchResult = ManagerConnection.GetPokemons(TextAutoSuggestBox);

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
            PokemonSearchResult = ManagerConnection.GetAllPokemonsFromSqlite();
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

        public ICommand NavegationPageDetails
        {
            get;
            private set;
        }
        private async void NavegationPDetails(Pokemon p)
        {
            PokemonOther.Clear();
            PokemonOther.Add(p);
            
            //Debug.WriteLine(p.Name + " PageUwP");
        }


        public PokedexPageViewModel()
        {
            InitializeDB();

            //SearchPokemon = new RelayCommand(SearchByIdTypeName);
            ShowAllPokemonsDBSqlite = new RelayCommand(ShowAllPokemonsDBSql);
            SearchPokemons = new RelayCommand(SearchPokemon);
            CatchSelectedPokemon = new RelayCommand<Pokemon>(SelectedPokemon);
            NavegationPageDetails = new RelayCommand<Pokemon>(NavegationPDetails);


        }
    }
}
