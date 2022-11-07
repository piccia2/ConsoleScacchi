public class printer
{
    public static void PrintTable(Tavolo t)
    {
        Console.Clear();
        Console.Write("Turno del:");
        Console.BackgroundColor=(t.turno==t.Bianco ? ConsoleColor.White : ConsoleColor.Black );
        Console.ForegroundColor=(t.turno==t.Bianco ? ConsoleColor.Black : ConsoleColor.White );
        Console.WriteLine(Enum.GetName(typeof(Squadra.Colore), t.turno.colore));

        Console.ResetColor();
        Console.WriteLine($"0|"+
            String.Join(
                " | ",
                Enumerable.Range('a',8).Select(x=>Convert.ToChar(x).ToString().PadRight(10,' '))
            )+" |"
        );
        Console.WriteLine("_".PadRight((10+3)*8,'_'));
        foreach(int y in t.Select(x=>x.y).Distinct())
        {
            Console.Write($"{y}|");
            foreach(int x in t.Select(x=>x.x).Distinct() )
            {
                var res=t.First(p=>p.y==y && p.x==x);
                if(res.pezzo!=null)
                {
                    Console.BackgroundColor=(res.pezzo.squadra==t.Bianco ? ConsoleColor.White : ConsoleColor.Black );
                    Console.ForegroundColor=(res.pezzo.squadra==t.Bianco ? ConsoleColor.Black : ConsoleColor.White );
                    Console.Write(res.pezzo.ToString());
                }
                else
                Console.Write("          ");
                Console.Write(" | ");
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.WriteLine("_".PadRight((10+3)*8,'_'));
        }
    }
}