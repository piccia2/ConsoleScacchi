using System;
using System.Linq;
 public class Tavolo : List<Posizione>
 {
    public Squadra Bianco,Nero;
    public Squadra turno=null;
    public Tavolo()
    {
        Bianco  = new Squadra(this,Squadra.Colore.BIANCO);
        Nero    = new Squadra(this,Squadra.Colore.NERO);
        turno=Bianco;
        PulisciTavolo();
        PosizionaPezzi();
    }
    public void PulisciTavolo()
    {
        this.Clear();

        foreach(int y in Enumerable.Range(1,8))
        {
            foreach(char x in Enumerable.Range('a',8))
            {
                Add(new Posizione(this,y,x));
            }
        }
    }
    public Posizione GetPosition(String pos)
    {
        try
        {
        char x=pos.First();
        int y=Convert.ToInt32(pos.Last().ToString());
        return GetPosition(x,y);
        }
        catch
        {
            throw new FormatException();
        }
    }
    public Posizione GetPosition(char x,int y)
    {
        return this.FirstOrDefault(p=>p.x==x && p.y==y);
    }
    public void PosizionaPezzi()
    {
        GetPosition('a',1).pezzo=new Torre(this,Bianco);
        GetPosition('h',1).pezzo=new Torre(this,Bianco);
        GetPosition('b',1).pezzo=new Cavallo(this,Bianco);
        GetPosition('g',1).pezzo=new Cavallo(this,Bianco);
        GetPosition('c',1).pezzo=new Alfiere(this,Bianco);
        GetPosition('f',1).pezzo=new Alfiere(this,Bianco);
        GetPosition('d',1).pezzo=new Re(this,Bianco);
        GetPosition('e',1).pezzo=new Regina(this,Bianco);
        GetPosition('a',2).pezzo=new Pedone(this,Bianco);
        GetPosition('b',2).pezzo=new Pedone(this,Bianco);
        GetPosition('c',2).pezzo=new Pedone(this,Bianco);
        GetPosition('d',2).pezzo=new Pedone(this,Bianco);
        GetPosition('e',2).pezzo=new Pedone(this,Bianco);
        GetPosition('f',2).pezzo=new Pedone(this,Bianco);
        GetPosition('g',2).pezzo=new Pedone(this,Bianco);
        GetPosition('h',2).pezzo=new Pedone(this,Bianco);


        GetPosition('a',8).pezzo=new Torre(this,Nero);
        GetPosition('h',8).pezzo=new Torre(this,Nero);
        GetPosition('b',8).pezzo=new Cavallo(this,Nero);
        GetPosition('g',8).pezzo=new Cavallo(this,Nero);
        GetPosition('c',8).pezzo=new Alfiere(this,Nero);
        GetPosition('f',8).pezzo=new Alfiere(this,Nero);
        GetPosition('d',8).pezzo=new Re(this,Nero);
        GetPosition('e',8).pezzo=new Regina(this,Nero);
        GetPosition('a',7).pezzo=new Pedone(this,Nero);
        GetPosition('b',7).pezzo=new Pedone(this,Nero);
        GetPosition('c',7).pezzo=new Pedone(this,Nero);
        GetPosition('d',7).pezzo=new Pedone(this,Nero);
        GetPosition('e',7).pezzo=new Pedone(this,Nero);
        GetPosition('f',7).pezzo=new Pedone(this,Nero);
        GetPosition('g',7).pezzo=new Pedone(this,Nero);
        GetPosition('h',7).pezzo=new Pedone(this,Nero);
    }

    public bool MakeMove(String from, String To)
    {
        Posizione pFrom=GetPosition(from);
        Posizione pTo = GetPosition(To);

        if(pFrom==null || pTo==null)
            return false;
        
        Pezzo pz=pFrom.pezzo;

        if(pz==null)
            return false;
            
        if(pz.squadra!=turno)
            return false;
        if(pz.CercaMosse().Contains(pTo))
        {
            pz.posizione=pTo;
            return true;
        }
        return false;
    }
 }
 public class Posizione
 {
    int m_y=1;
    char m_x='a';
    public Pezzo m_pezzo=null;
    public Tavolo tavolo {get;set;}
    public int y{
        get=>m_y;
        set
        {
            m_y=value;
        }
    }
    public char x{
        get=>m_x;
        set
        {
            m_x=value;
        }
    }
    public Pezzo? pezzo {
        get=>m_pezzo;
        set
        {
            Posizione oldPosition=tavolo.FirstOrDefault(x=>x.pezzo==value);
            m_pezzo=value;
            if(oldPosition!=null)
                oldPosition.m_pezzo=null;
        }
    }
    public Posizione(Tavolo tavolo,int y,char x)
    {
        this.tavolo=tavolo;
        m_x=x;
        m_y=y;
    }
    public Posizione SerchPos(short x,short y){
        Posizione p=tavolo.GetPosition(Convert.ToChar(this.x+x),this.y+y);
        return p;
    }
 }
 public abstract class Pezzo
 {
    public Tavolo tavolo {get;private set;}
    public Squadra squadra {get;private set;}
    public Posizione posizione{
        get=>tavolo.FirstOrDefault(x=>x.pezzo==this);
        set{
            if(value!=null)
                value.pezzo=this; 
            else
                posizione.pezzo=null;
        }
    }
    public virtual List<Posizione> CercaMosse()
    {
        return new List<Posizione>();
    }
    public override String ToString()
    {
        return this.GetType().Name.PadLeft(10);
    }
    public Pezzo(Tavolo tavolo,Squadra squadra)
    {
        this.tavolo=tavolo;
        this.squadra=squadra;
    }
 }
 public class Squadra
 {
    public enum Colore
    {
        BIANCO,NERO
    }
    public Tavolo tavolo {get;private set;}
    public Colore colore {get;private set;}
    public int direzionePedoni{get=>colore==Colore.BIANCO ? 1 : -1; }
    public Squadra Avversario{get=>colore==Colore.BIANCO ? tavolo.Nero : tavolo.Bianco; } 
    public List<Posizione> MosseDisponibili{get=>pezzi
                                                    .SelectMany(x=>x.CercaMosse())
                                                    .ToList();}

    public IEnumerable<Pezzo?> pezzi{get=>tavolo
                                    .Where(x=>x!=null)
                                    .Select(x=>x.pezzo)
                                    .Where(x=>x!=null)
                                    .Where(x=>x.squadra==this);}
    public Re re{get=>(Re)pezzi.FirstOrDefault(x=>typeof(Re)==x.GetType());}
    public bool inScacco{get=>MosseDisponibili.Any(x=>Avversario.MosseDisponibili.Any(x=>x.pezzo==Avversario.re));}
    public Squadra(Tavolo tavolo,Colore col)
    {
        this.tavolo=tavolo;
        this.colore=col;
    }
 }