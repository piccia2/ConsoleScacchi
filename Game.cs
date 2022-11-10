public class Game : Queue<Tuple<Posizione,Pezzo,Posizione,Pezzo>>
{
    public GameStatus status{get;private set;}=GameStatus.STARTED;
    public Tavolo tavolo{get;private set;} = new Tavolo();
    public Squadra turno{get;set;}=null;

    public Game(){
        turno=tavolo.Bianco;
    }

    public void Move(String from,String to)
    {
        Tuple<Posizione,Pezzo,Posizione,Pezzo> mv=null;
        if(tavolo.MakeMove(from ,to ,turno , out mv))
        {
            this.Enqueue(mv);
            if(turno.inScacco)
                Back();
            else
                turno=(tavolo.Bianco==turno ? tavolo.Nero : tavolo.Bianco);
        }
        if(turno.inScaccoMatto)
        {
            status=(tavolo.Nero==turno ? GameStatus.WIN_WHITE : GameStatus.WIN_BLACK);
        }
        else if(!turno.CanMove())
        {
            status=GameStatus.PATTA;
        }
    }
    public void Back()
    {
        Tuple<Posizione,Pezzo,Posizione,Pezzo> mv=this.Last();
        tavolo.BackMove(mv.Item3,mv.Item1,mv.Item4);
    }
}
public enum GameStatus
{
    STARTED, PATTA, WIN_BLACK, WIN_WHITE
}