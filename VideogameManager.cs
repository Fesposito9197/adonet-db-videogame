using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlClient
{
    public class VideogameManager
    {
        string connStr;

        public VideogameManager(string connStr)
        {
            this.connStr = connStr;
        }

        public List<Videogame> GetVideogameById(long likeId) 
        {
            using var conn = new SqlConnection(connStr);
            var videogames = new List<Videogame>();

            try
            {
                conn.Open();

                var query = "SELECT id, name , release_date"
                    + " FROM videogames"
                    + $" WHERE id =  @IdByUser";

                using var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@IdByUser", $"{likeId}");
                using SqlDataReader reader = command.ExecuteReader();
                while ( reader.Read())
                {
                    var idIdx = reader.GetOrdinal("id");
                    var id = reader.GetInt64(idIdx);

                    var nameIdx = reader.GetOrdinal("name");
                    var name = reader.GetString(nameIdx);

                    var releaseDateIdx = reader.GetOrdinal("release_date");
                    var releaseDate = reader.GetDateTime(releaseDateIdx);

                    var v = new Videogame(id, name, releaseDate);
                    videogames.Add(v);

                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return videogames;
        }
        public List<Videogame> GetVideoGameByNameLike(string likeString)
        {
            using var conn = new SqlConnection(connStr);
            var videogames = new List<Videogame>();
            try
            {
                conn.Open();

                var query = "SELECT id, name , release_date"
                    + " FROM videogames"
                    + $" WHERE [name] LIKE  @NameLike";

                using var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@NameLike", $"%{likeString}%");

                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("id");
                    var id = reader.GetInt64(idIdx);

                    var nameIdx = reader.GetOrdinal("name");
                    var name = reader.GetString(nameIdx);

                    var releaseDateIdx = reader.GetOrdinal("release_date");
                    var releaseDate = reader.GetDateTime(releaseDateIdx);

                    var v = new Videogame(id, name, releaseDate);
                    videogames.Add(v);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return videogames;
        }

        public void AddVideoGame(string name , string overview , DateTime releaseDate , long softwareHouseId)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                using var tran = conn.BeginTransaction();
                try
                {
                    var query = "INSERT INTO videogames (name , overview , release_date , software_house_id)"
                        + " VALUES (@Name, @Overview, @Releasedate, @Softwarehouseid)";

                    var cmd = new SqlCommand(query, conn , tran);
                    cmd.Parameters.AddWithValue ("@Name", name );
                    cmd.Parameters.AddWithValue("@Overview", overview );
                    cmd.Parameters.AddWithValue("@Releasedate", releaseDate);
                    cmd.Parameters.AddWithValue("@Softwarehouseid", softwareHouseId);

                    cmd.ExecuteNonQuery();



                    Console.WriteLine("Commit");
                    tran.Commit();

                }
                catch
                {
                    Console.WriteLine("RollBack");
                    tran.Rollback();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
