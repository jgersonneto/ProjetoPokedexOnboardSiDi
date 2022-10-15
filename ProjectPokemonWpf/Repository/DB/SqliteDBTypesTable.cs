using ProjectPokemonWpf.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ProjectPokemonWpf.Repository.DB
{
    public class SqliteDBTypesTable
    {
        //public async static Task<bool> InitializeTableTypesDB()
        //{
        //    bool op = false;
        //    string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "pokeDex.db");

        //    using (SqliteConnection con = new SqliteConnection($"Filename={pathToDB}"))
        //    {
        //        con.Open();
        //        string createTableSQL = "CREATE TABLE IF NOT EXISTS " +
        //                                 "types( " +
        //                                     "type NVARCHAR(100), " +
        //                                     "id_pokemon INTEGER, " +
        //                                     "iconImage NVARCHAR(500), " +
        //                                     "PRIMARY KEY (type, id_pokemon), " +
        //                                     "FOREIGN KEY (id_pokemon) REFERENCES pokemon(id) " +
        //                                 ");";

        //        SqliteCommand commandCreateTable = new SqliteCommand(createTableSQL, con);
        //        commandCreateTable.ExecuteReader();
        //        con.Close();
        //        op = true;
        //    }
        //    return op;
        //}

        //public static void AddTypesToDB(Pokemon pokemon)
        //{
        //    if (pokemon != null && pokemon.Id != 0 && pokemon.Height != 0 && pokemon.Weight != 0 && !pokemon.Name.Equals(""))
        //    {
        //        string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "pokeDex.db");

        //        using (SqliteConnection con = new SqliteConnection($"Filename={pathToDB}"))
        //        {
        //            SqliteCommand commandInsert = new SqliteCommand
        //            {
        //                Connection = con
        //            };

        //            foreach (var value in pokemon.Types)
        //            {
        //                try
        //                {
        //                    commandInsert = new SqliteCommand
        //                    {
        //                        Connection = con
        //                    };

        //                    con.Open();

        //                    commandInsert.CommandText = "INSERT INTO types VALUES(@type, @id_pokemon, iconImage);";

        //                    commandInsert.Parameters.AddWithValue("@type", value.Type.Name);
        //                    commandInsert.Parameters.AddWithValue("@id_pokemon", pokemon.Id);

        //                    if(value.Type.Name.Equals("normal"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/aa/Pok%C3%A9mon_Normal_Type_Icon.svg/180px-Pok%C3%A9mon_Normal_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("fighting"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/be/Pok%C3%A9mon_Fighting_Type_Icon.svg/180px-Pok%C3%A9mon_Fighting_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("flying"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e0/Pok%C3%A9mon_Flying_Type_Icon.svg/180px-Pok%C3%A9mon_Flying_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("poison"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c4/Pok%C3%A9mon_Poison_Type_Icon.svg/180px-Pok%C3%A9mon_Poison_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("ground"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Pok%C3%A9mon_Ground_Type_Icon.svg/180px-Pok%C3%A9mon_Ground_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("rock"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bb/Pok%C3%A9mon_Rock_Type_Icon.svg/180px-Pok%C3%A9mon_Rock_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("bug"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3c/Pok%C3%A9mon_Bug_Type_Icon.svg/180px-Pok%C3%A9mon_Bug_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("ghost"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a0/Pok%C3%A9mon_Ghost_Type_Icon.svg/180px-Pok%C3%A9mon_Ghost_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("steel"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/38/Pok%C3%A9mon_Steel_Type_Icon.svg/180px-Pok%C3%A9mon_Steel_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("fire"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/56/Pok%C3%A9mon_Fire_Type_Icon.svg/180px-Pok%C3%A9mon_Fire_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("water"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/Pok%C3%A9mon_Water_Type_Icon.svg/180px-Pok%C3%A9mon_Water_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("grass"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f6/Pok%C3%A9mon_Grass_Type_Icon.svg/180px-Pok%C3%A9mon_Grass_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("electric"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a9/Pok%C3%A9mon_Electric_Type_Icon.svg/180px-Pok%C3%A9mon_Electric_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("psychic"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ab/Pok%C3%A9mon_Psychic_Type_Icon.svg/180px-Pok%C3%A9mon_Psychic_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("ice"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/88/Pok%C3%A9mon_Ice_Type_Icon.svg/180px-Pok%C3%A9mon_Ice_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("dragon"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Pok%C3%A9mon_Dragon_Type_Icon.svg/180px-Pok%C3%A9mon_Dragon_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("dark"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/09/Pok%C3%A9mon_Dark_Type_Icon.svg/180px-Pok%C3%A9mon_Dark_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("fairy"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/Pok%C3%A9mon_Fairy_Type_Icon.svg/180px-Pok%C3%A9mon_Fairy_Type_Icon.svg.png");
        //                    if (value.Type.Name.Equals("unknown"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://cdn-icons-png.flaticon.com/512/5259/5259989.png");
        //                    if (value.Type.Name.Equals("shadow"))
        //                        commandInsert.Parameters.AddWithValue("@iconImage", "https://cdn-icons-png.flaticon.com/512/5259/5259989.png");

        //                    commandInsert.ExecuteReader();
        //                    con.Close();
        //                }
        //                catch (SqliteException e)
        //                {
        //                    Console.WriteLine("erro na inserção no DB " + e.Message);
        //                }
        //            }
        //        }
        //    }
        //}
        //public static List<Pokemon> GetAllAttributesForMainPage(List<Pokemon> pokemons)
        //{
        //    List<Pokemon> pokeList = new List<Pokemon>();

        //    string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "pokeDex.db");

        //    using (SqliteConnection con = new SqliteConnection($"Filename={pathToDB}"))
        //    {
        //        con.Open();

        //        foreach (Pokemon p in pokemons)
        //        {
        //            string selectTypeSQL = "SELECT type, id_pokemon, iconImage FROM types";
        //            SqliteCommand CommandSelectType = new SqliteCommand(selectTypeSQL, con);

        //            SqliteDataReader reader2 = CommandSelectType.ExecuteReader();

        //            List<TypeElement> typeList = new List<TypeElement>();
        //            while (reader2.Read())
        //            {
        //                int idPokemon = reader2.GetInt32(1);
        //                if (idPokemon == p.Id)
        //                {
        //                    TypeClass nameType = new TypeClass
        //                    {
        //                        Name = reader2.GetString(0),
        //                        IconName = reader2.GetString(2),
        //                    };
        //                    TypeElement type = new TypeElement
        //                    {
        //                        Type = nameType
        //                    };
        //                    typeList.Add(type);
        //                    p.Types = typeList;
        //                }
        //            }
        //            pokeList.Add(p);
        //        }
        //        con.Close();
        //    }
        //    return pokeList;
        //}
        //public static List<Pokemon> SearchInTypesByIdForMainPage(List<Pokemon> pokemons)
        //{
        //    List<Pokemon> pokeList = new List<Pokemon>();


        //    string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "pokeDex.db");

        //    using (SqliteConnection con = new SqliteConnection($"Filename={pathToDB}"))
        //    {
        //        con.Open();

        //        foreach (Pokemon p in pokemons)
        //        {
        //            string selectTypeSQL = "SELECT type, id_pokemon FROM types";
        //            SqliteCommand CommandSelectType = new SqliteCommand(selectTypeSQL, con);

        //            SqliteDataReader reader2 = CommandSelectType.ExecuteReader();

        //            List<TypeElement> typeList = new List<TypeElement>();
        //            while (reader2.Read())
        //            {
        //                int idPokemon = reader2.GetInt32(1);
        //                if (idPokemon == p.Id)
        //                {
        //                    TypeClass nameType = new TypeClass
        //                    {
        //                        Name = reader2.GetString(0),
        //                        IconName = reader2.GetString(2),
        //                    };
        //                    TypeElement type = new TypeElement
        //                    {
        //                        Type = nameType
        //                    };
        //                    typeList.Add(type);
        //                    p.Types = typeList;
        //                }
        //            }
        //            pokeList.Add(p);
        //        }
        //        con.Close();
        //    }
        //    return pokeList;
        //}

        //public static List<Pokemon> SearchInTypesByNameForMainPage(List<Pokemon> pokemons)
        //{
        //    List<Pokemon> pokeList = new List<Pokemon>();


        //    string pathToDB = Path.Combine(ApplicationData.Current.LocalFolder.Path, "pokeDex.db");

        //    using (SqliteConnection con = new SqliteConnection($"Filename={pathToDB}"))
        //    {
        //        con.Open();

        //        foreach (Pokemon p in pokemons)
        //        {
        //            string selectTypeSQL = "SELECT type, id_pokemon FROM types";
        //            SqliteCommand CommandSelectType = new SqliteCommand(selectTypeSQL, con);

        //            SqliteDataReader reader2 = CommandSelectType.ExecuteReader();

        //            List<TypeElement> typeList = new List<TypeElement>();
        //            while (reader2.Read())
        //            {
        //                int idPokemon = reader2.GetInt32(1);
        //                if (idPokemon == p.Id)
        //                {
        //                    TypeClass nameType = new TypeClass
        //                    {
        //                        Name = reader2.GetString(0),
        //                        IconName = reader2.GetString(2),
        //                    };
        //                    TypeElement type = new TypeElement
        //                    {
        //                        Type = nameType
        //                    };
        //                    typeList.Add(type);
        //                    p.Types = typeList;
        //                }
        //            }
        //            pokeList.Add(p);
        //        }
        //        con.Close();
        //    }
        //    return pokeList;
        //}
    }
}
