using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;
using SqlClient;

var connStr = "Data Source = localhost; Initial Catalog = db_videogame; Integrated Security = True";
var videogameManager = new VideogameManager(connStr);

Console.WriteLine("Elimina un videogame dall'elenco");
Console.WriteLine("Inserisci l'id del gioco che vuoi eliminare");
var gameId = Convert.ToInt64(Console.ReadLine());

videogameManager.DeleteVideoGame(gameId);


Console.WriteLine("Ricerca gioco per ID");
var userId = Convert.ToInt64(Console.ReadLine());


var videogame =  videogameManager.GetVideogameById(userId);

foreach (var item in videogame) Console.WriteLine(item);

Console.WriteLine("Inserisci un videogioco");

Console.WriteLine("Aggiungi un nome");
var gameName = Console.ReadLine();

Console.WriteLine("Aggiungi una overview");
var gameOverview = Console.ReadLine();

Console.WriteLine("Aggiungi una data di rilascio");
var gameRelease = Convert.ToDateTime(Console.ReadLine());

Console.WriteLine("Aggiungi software house ID");
var gameSoftwareHouse = Convert.ToInt64(Console.ReadLine());



videogameManager.AddVideoGame(gameName , gameOverview, gameRelease, gameSoftwareHouse);


Console.WriteLine("Ricerca per nome");
var userName = Console.ReadLine();


var videogameName = videogameManager.GetVideoGameByNameLike(userName);


foreach (var item in videogameName) Console.WriteLine(item);

Console.WriteLine($"Count: {videogameName.Count}");


