using Connection;
using Connection.Commons;
using Connection.DataBase;
using ProjectPokemonWpf.Model;
using ProjectPokemonWpf.Repository.Factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Foundation;

namespace ProjectPokemonWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private DBManager connection = new DBManager();

        public MainWindow()
        {
            InitializeComponent();
            Debug.WriteLine(GlobalParameters.DataBasePath + " Pagewpf");
            //Result();


        }

        //public async void Result()
        //{
        //    var task = connection.GetPokemons("bulbasaur");
        //    var pokemons = await task;            

        //    viewModels4.ObserverPokemon.Add(pokemons[0]);
        //}

        protected override void OnActivated(EventArgs e)
        {
            Debug.WriteLine(e.GetType().ToString() + " tttsstststs");
            base.OnActivated(e);
        }
        
    }
}
