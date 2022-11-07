using System.Diagnostics;


var u=Enumerable.Range('a',8);
Tavolo t=new Tavolo();

bool gameover=false;
while(!gameover)
{
    printer.PrintTable(t);
    t.turno=t.Bianco;
    bool mossafatta=false;
    while(!mossafatta)
    {
        Console.Write("Pezzo da muovere:");
        String from=Console.ReadLine();
        Console.Write("Muovi in:");
        String to=Console.ReadLine();
        if(!String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
            {
                mossafatta=t.MakeMove(from,to);
            }
        if(!mossafatta)
            Console.WriteLine("ripeti mossa");
    }
    
    printer.PrintTable(t);
    t.turno=t.Nero;
    mossafatta=false;
    while(!mossafatta)
    {
        Console.Write("Pezzo da muovere:");
        String from=Console.ReadLine();
        Console.Write("Muovi in:");
        String to=Console.ReadLine();
        if(!String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
            {
                mossafatta=t.MakeMove(from,to);
            }
        if(!mossafatta)
            Console.WriteLine("ripeti mossa");
    }
}