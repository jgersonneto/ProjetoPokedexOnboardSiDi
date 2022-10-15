using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using ProjectPokemonWpf.ViewModel;
using System.Diagnostics;
using Connection.DataBase;

namespace ProjectPokemonWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CreateDataBase();
        }

        private async Task CreateDataBase()
        {
            DataBaseContext dataBaseContext = new DataBaseContext(@"C:\Users\jg.neto\AppData\Local\Packages\53f0fc06-036b-4f4b-8261-5451720540d8_pzcytrm3zrahw\LocalState\PokeDexOnBoard.db");
            await dataBaseContext.CreateDataBase();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
           

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var parameters = e.Args;
            
            Debug.WriteLine(parameters + " OnStartup");
            base.OnStartup(e);
        }
        protected override void OnNavigated(NavigationEventArgs e)
        {
            
            //if (e.Uri != null)
            //{
            //    WwwFormUrlDecoder decoder = new WwwFormUrlDecoder(e.Uri.ToString());

            //    GlobalParameters.WpfMessage = decoder[0].Value;

            //}
            base.OnNavigated(e);


        }
        protected override void OnNavigationProgress(NavigationProgressEventArgs e)
        {
            base.OnNavigationProgress(e);

            Debug.WriteLine(e.Uri.ToString());
        }
    }
}
