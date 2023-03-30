using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;

var connStr = "Data Source = localhost; Initial Catalog = db_videogame; Integrated Security = True";
using var conn = new SqlConnection(connStr);

try
{

    conn.Open();

}
catch
{

}

