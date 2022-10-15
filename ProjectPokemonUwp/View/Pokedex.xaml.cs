using Connection;
using Connection.Commons;
using ProjectPokemonUwp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectPokemonUwp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pokedex : Page
    {
        
        public Pokedex()
        {
            this.InitializeComponent();
            
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            viewModels2.TextAutoSuggestBox = sender.Text;
        }

        // Handle user selecting an item, in our case just output the selected item.
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = args.SelectedItem.ToString();
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            viewModels2.SearchPokemon();
        }

        //private void ButaoCadastro_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Frame.Navigate(typeof(ViewCadastro), null, new DrillInNavigationTransitionInfo());
        //}

        private async void ButtonPageNavigation(object sender, RoutedEventArgs e)
        {    
            Button bt = (Button)sender;
            Pokemon pokemon = (Pokemon)bt.CommandParameter;
            Debug.WriteLine(pokemon.Name + " Teste Sender");
            GlobalParameters.DataBasePath = pokemon.Name;
            
            try
            {   
                await Launcher.LaunchUriAsync(new Uri("com.projectpokemonwpf://?wpfMessage={message}"));
            }
            catch (Exception ex)
            {
                //
            }

            //this.Frame.Navigate(typeof(MainWindow), viewModels.OtherListPokemons, new DrillInNavigationTransitionInfo());
            //if (ResultLaucher)
            //    Application.Current.Exit();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
