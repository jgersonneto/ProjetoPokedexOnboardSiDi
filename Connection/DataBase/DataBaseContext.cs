using Connection.Commons;
using Connection.Dispatcher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connection.DataBase
{
    public class DataBaseContext
    {
        private string _dataBasePath { get; set; }

        public DataBaseContext(string path)
        {
            _dataBasePath = path;
        }

        public async Task CreateDataBase()
        {
            GlobalParameters.DataBasePath = _dataBasePath;

            using (var db = new ClientDataBase())
            {
                await db.Database.EnsureCreatedAsync();
            }
        }

        public async Task AddPokemonToDB(Pokemon pokemon)
        {
            using (var db = new ClientDataBase())
            {
                db.Add(pokemon);

                await db.SaveChangesAsync();
            }
        }
    }
}
