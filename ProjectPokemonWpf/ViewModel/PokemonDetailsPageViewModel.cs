using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Connection;
using Connection.DataBase;
using ProjectPokemonWpf.Model;
using ProjectPokemonWpf.Repository.Factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPokemonWpf.ViewModel
{
    public class PokemonDetailsPageViewModel : ObservableObject
    {

        private ObservableCollection<Pokemon> _observerPokemon = new ObservableCollection<Pokemon>();
        private ObservableCollection<TypeElement> _observerTypePokemon = new ObservableCollection<TypeElement>();
        private Pokemon _pokemon = new Pokemon();

        DataBaseContext dataBaseContext;
        private DBManager _managerConnection = new DBManager();

        private string _imagePokemon;
        private string _id;
        private string _pokemonName;
        private string _imageTypePrimary;
        private string _imageTypeSecundary;
        private string _weight;
        private string _heigth;
        private string _baseExperience;
        private int _hp;
        private int _attack;
        private int _defense;
        private int _specialAttack;
        private int _specialDefense;
        private int _speed;

        public ObservableCollection<TypeElement> ObserverTypePokemon 
        { 
            get => _observerTypePokemon; 
            set => SetProperty(ref _observerTypePokemon, value); 
        }

        public ObservableCollection<Pokemon> ObserverPokemon
        {
            get => _observerPokemon;
            set => SetProperty(ref _observerPokemon, value);
        }

        public string ImagePokemon 
        { 
            get => _imagePokemon;
            set => SetProperty(ref _imagePokemon, value);
        }

        public string Id 
        { 
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string PokemonName 
        { 
            get => _pokemonName;
            set => SetProperty(ref _pokemonName, value); 
        }

        public string ImageTypePrimary 
        { 
            get => _imageTypePrimary;
            set => SetProperty(ref _imageTypePrimary, value); 
        }

        public string ImageTypeSecudary 
        {
            get => _imageTypeSecundary;
            set => SetProperty(ref _imageTypeSecundary, value);
        }

        public string Weight 
        { 
            get => _weight; 
            set => SetProperty(ref _weight, value); 
        }

        public string Height 
        { 
            get => _heigth; 
            set => SetProperty(ref _heigth, value); 
        }

        public string BaseExperience 
        { 
            get => _baseExperience; 
            set => SetProperty(ref _baseExperience, value); 
        }

        public int HP 
        { 
            get => _hp; 
            set => SetProperty(ref _hp, value); 
        }

        public int Attack 
        {
            get => _attack;
            set => SetProperty(ref _attack, value);
        }

        public int Defense 
        {
            get => _defense;
            set => SetProperty(ref _defense, value);
        }

        public int SpecialAttack 
        {
            get => _specialAttack;
            set => SetProperty(ref _specialAttack, value);
        }

        public int SpecialDefense 
        {
            get => _specialDefense;
            set => SetProperty(ref _specialDefense, value);
        }

        public int Speed 
        {
            get => _speed;
            set => SetProperty(ref _speed, value);
        }

        public void Initialization()
        {
            if (_observerPokemon.Count != 0)
            {
                foreach (var type in _observerPokemon[0].Types)
                {
                    ObserverTypePokemon.Add(type);
                }
                Id = _observerPokemon[0].Id + "";
                PokemonName = _observerPokemon[0].Name;
                ImagePokemon = _observerPokemon[0].Sprites.Front_Default;
                ImageTypePrimary = _observerPokemon[0].Types[0].Type.IconName;
                if (_observerPokemon[0].Types.Count == 2)
                    ImageTypeSecudary = _observerPokemon[0].Types[1].Type.IconName;
                Weight = _observerPokemon[0].Weight + "";
                Height = _observerPokemon[0].Height + "";
                BaseExperience = _observerPokemon[0].Base_Experience + "";
                HP = CalculatePercent(_observerPokemon[0].Stats[0].Base_Stat);
                Attack = CalculatePercent(_observerPokemon[0].Stats[1].Base_Stat);
                Defense = CalculatePercent(_observerPokemon[0].Stats[2].Base_Stat);
                SpecialAttack = CalculatePercent(_observerPokemon[0].Stats[3].Base_Stat);
                SpecialDefense = CalculatePercent(_observerPokemon[0].Stats[4].Base_Stat);
                Speed = CalculatePercent(_observerPokemon[0].Stats[5].Base_Stat);
            }            
            
        }

        public int CalculatePercent(int valeu)
        {
            int percent = (int)(valeu * 100) / 500;
            return percent;
        }

        //public async void mock()
        //{
        //    //DBManager connection = new DBManager();
        //    //var task = connection.GetPokemons("bulbasaur");
        //    //var pokemons = await task;            

        //    //ObserverPokemon.Add(pokemons[0]);
        //}

        private async void inicializeNewDb()
        {
            DataBaseContext dataBaseContext = new DataBaseContext(@"C:\Users\jg.neto\AppData\Local\Packages\53f0fc06-036b-4f4b-8261-5451720540d8_pzcytrm3zrahw\LocalState\PokeDexOnBoard.db");


            if (dataBaseContext != null)
            {
                Connection.Dispatcher.Pokemon pk = new Connection.Dispatcher.Pokemon()
                {
                    Id = 270,
                    Name = "neto",
                    Base_Experience = 21,
                    Height = 22,
                    Weight = 22,
                    Sprites = null,
                    Abilities = null,
                    Stats = null,
                    Types = null
                };


                await dataBaseContext.AddPokemonToDB(pk);
            }
        }
        public PokemonDetailsPageViewModel()
        {
            inicializeNewDb();
            Initialization();
            //mock();
        }


    }
}
