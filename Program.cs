using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;
using SqlClient;

var connStr = "Data Source = localhost; Initial Catalog = db_videogame; Integrated Security = True";
var videogameManager = new VideogameManager(connStr);

Console.WriteLine("Ricerca gioco per ID");
var userId = Convert.ToInt64(Console.ReadLine());


var videogame =  videogameManager.GetVideogameById(userId);

foreach (var item in videogame) Console.WriteLine(item);


Console.WriteLine("Ricerca per nome");
var userName = Console.ReadLine();


var videogameName = videogameManager.GetVideoGameByNameLike(userName);


foreach (var item in videogameName) Console.WriteLine(item);

Console.WriteLine($"Count: {videogameName.Count}");


