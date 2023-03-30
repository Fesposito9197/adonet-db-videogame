using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;
using SqlClient;

var connStr = "Data Source = localhost; Initial Catalog = db_videogame; Integrated Security = True";
var videogameManager = new VideogameManager(connStr);

while (true)
{
    Console.WriteLine("Benvenuto! Che operazione desideri fare?");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("1 - Inserisci un nuovo videogioco.");
    Console.WriteLine("2 - Ricercare un videogioco per ID.");
    Console.WriteLine("3 - Ricercare un videogioco per nome.");
    Console.WriteLine("4 - Cancellare un videogioco.");
    Console.WriteLine("5 - Chiudi l'applicazione.");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Inserisci un'opzione:");
    string? userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            Console.WriteLine("Inserisci un videogioco");

            Console.WriteLine("Aggiungi un nome");
            var gameName = Console.ReadLine();

            while (gameName == "" || gameName == null)
            {
                Console.WriteLine("Il nome deve contenere almeno un carattere!");
                gameName = Console.ReadLine();
            }

            Console.WriteLine("Aggiungi una overview");
            var gameOverview = Console.ReadLine();

            while (gameOverview == "" || gameOverview == null)
            {
                Console.WriteLine("La overview deve contenere almeno un carattere!");
                gameOverview = Console.ReadLine();
            }

            Console.WriteLine("Aggiungi una data di rilascio");
            var gameRelease = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Aggiungi software house ID tra i seguenti: ");
            Console.WriteLine("1 - Nintendo");
            Console.WriteLine("2 - Rockstar Games");
            Console.WriteLine("3 - Valve Corporation");
            Console.WriteLine("4 - Electronic Arts");
            Console.WriteLine("5 - Ubisoft");
            Console.WriteLine("6 - Konami");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Inserisci un'opzione:");
            var gameSoftwareHouse = Convert.ToInt64(Console.ReadLine());

            videogameManager.AddVideoGame(gameName, gameOverview, gameRelease, gameSoftwareHouse);

            Console.WriteLine("Gioco aggiunto con successo!");
            Console.WriteLine("----------------------------------------");
            break;

        case "2":
            Console.WriteLine("Ricerca gioco per ID: ");
            var userId = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Risultato: ");
            var videogame = videogameManager.GetVideogameById(userId);

            foreach (var item in videogame) Console.WriteLine(item);
            Console.WriteLine("----------------------------------------");
            break;

        case "3":
            Console.WriteLine("Ricerca per nome: ");
            var userName = Console.ReadLine();

            Console.WriteLine("Risultato: ");
            var videogameName = videogameManager.GetVideoGameByNameLike(userName);


            foreach (var item in videogameName) Console.WriteLine(item);

            Console.WriteLine($"Count: {videogameName.Count}");
            Console.WriteLine("----------------------------------------");
            break;

        case "4":
            Console.WriteLine("Ricerca per nome il gioco da eliminare: ");
            userName = Console.ReadLine();

            Console.WriteLine("Risultato: ");
            videogameName = videogameManager.GetVideoGameByNameLike(userName);


            foreach (var item in videogameName) Console.WriteLine(item);

            Console.WriteLine($"Count: {videogameName.Count}");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Inserisci l'id del gioco che vuoi eliminare");
            var gameId = Convert.ToInt64(Console.ReadLine());

            videogameManager.DeleteVideoGame(gameId);
            Console.WriteLine("Gioco eliminato con successo!");
            Console.WriteLine("----------------------------------------");
            break;

        case "5":
            Environment.Exit(1);
            break;
    }
}


