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
    }
}
