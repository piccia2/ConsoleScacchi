using System.Diagnostics;

Game game=new Game();


while(game.status==GameStatus.STARTED)
{
    printer.PrintTable(game);

    Console.Write("Pezzo da muovere:");
    String from=Console.ReadLine();
    Console.Write("Muovi in:");
    String to=Console.ReadLine();

    game.Move(from,to);
}