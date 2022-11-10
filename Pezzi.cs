public class Pedone : Pezzo
{
    public bool primaMossa=true;
    public Pedone(Tavolo tavolo,Squadra squadra):base(tavolo,squadra){}
    public override List<Posizione> CercaMosse()
    {
        //Mossa standard pedone
        List<Posizione> pos=base.CercaMosse();
        short d=Convert.ToInt16(squadra.direzionePedoni);
        Posizione contr=posizione.SerchPos(0,d);
        if(contr!=null)
        {
            if(contr.pezzo==null)
                pos.Add(contr);
        }
        
        //Prima mossa lunga pedone
        
        if(primaMossa)
        {
            contr=posizione.SerchPos(0,Convert.ToInt16(d*2));
            if(contr!=null)
            {
                if(contr.pezzo==null)
                    pos.Add(contr);
            }
        }

        //Magio -
        contr=posizione.SerchPos(-1,d);
        if(contr!=null)
        {
            if((contr.pezzo!=null) ? contr.pezzo.squadra!=this.squadra : false)
                pos.Add(contr);
        }
        //Magio +
        contr=posizione.SerchPos(1,d);
        if(contr!=null)
        {
            if((contr.pezzo!=null) ? contr.pezzo.squadra!=this.squadra : false)
                pos.Add(contr);
        }
        return pos;
    }
} 
public class Torre : Pezzo
{
    public Torre(Tavolo tavolo,Squadra squadra):base(tavolo,squadra){}
    public override List<Posizione> CercaMosse()
    {
        List<Posizione> pos=base.CercaMosse();

        Posizione contr;
        short i=0;
        //Cerca x+
        while(true)
        {
            contr=posizione.SerchPos(++i,0);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        //Cerca x-
        i=0;
        while(true)
        {
            contr=posizione.SerchPos(--i,0);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        //Cerca y+
        i=0;
        while(true)
        {
            contr=posizione.SerchPos(0,++i);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        //Cerca y-
        i=0;
        while(true)
        {
            contr=posizione.SerchPos(0,--i);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }

        return pos;
    }
} 
public class Cavallo : Pezzo
{
    public Cavallo(Tavolo tavolo,Squadra squadra):base(tavolo,squadra){}
    public override List<Posizione> CercaMosse()
    {
        List<Posizione> pos=base.CercaMosse();

        Posizione contr;
        short x,y;

        //Cerca x+
        x=+2;
        //Cerca x+ y+
        y=+1;
        contr=posizione.SerchPos(x,y);
        if((contr!=null ? (contr.pezzo!=null ? contr.pezzo.squadra!=squadra : true) : false))
            pos.Add(contr);
        
        //Cerca x+ y-
        y=-1;
        contr=posizione.SerchPos(x,y);
        if((contr!=null ? (contr.pezzo!=null ? contr.pezzo.squadra!=squadra : true) : false))
            pos.Add(contr);

        
        //Cerca x-
        x=-2;
        //Cerca x- y+
        y=+1;
        contr=posizione.SerchPos(x,y);
        if((contr!=null ? (contr.pezzo!=null ? contr.pezzo.squadra!=squadra : true) : false))
            pos.Add(contr);

        //Cerca x+ y-
        y=-1;
        contr=posizione.SerchPos(x,y);
        if((contr!=null ? (contr.pezzo!=null ? contr.pezzo.squadra!=squadra : true) : false))
            pos.Add(contr);
        


        //Cerca y+
        y=+2;
        //Cerca y+ x+
        x=+1;
        contr=posizione.SerchPos(x,y);
        if((contr!=null ? (contr.pezzo!=null ? contr.pezzo.squadra!=squadra : true) : false))
            pos.Add(contr);
        
        //Cerca y+ x-
        x=-1;
        contr=posizione.SerchPos(x,y);
        if((contr!=null ? (contr.pezzo!=null ? contr.pezzo.squadra!=squadra : true) : false))
            pos.Add(contr);

        
        //Cerca y-
        y=-2;
        //Cerca y- x+
        x=+1;
        contr=posizione.SerchPos(x,y);
        if((contr!=null ? (contr.pezzo!=null ? contr.pezzo.squadra!=squadra : true) : false))
            pos.Add(contr);

        //Cerca y+ x-
        x=-1;
        contr=posizione.SerchPos(x,y);
        if((contr!=null ? (contr.pezzo!=null ? contr.pezzo.squadra!=squadra : true) : false))
            pos.Add(contr);
        
        return pos;
    }
} 
public class Alfiere : Pezzo
{
    public Alfiere(Tavolo tavolo,Squadra squadra):base(tavolo,squadra){}
    public override List<Posizione> CercaMosse()
    {
        List<Posizione> pos=base.CercaMosse();

        Posizione contr;
        short x,y;

        x=0;
        y=0;
        //Cerca x+ y+
        while(true)
        {
            contr=posizione.SerchPos(++x,++y);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        x=0;
        y=0;
        //Cerca x+ y-
        while(true)
        {
            contr=posizione.SerchPos(++x,--y);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        x=0;
        y=0;
        //Cerca x- y+
        while(true)
        {
            contr=posizione.SerchPos(--x,++y);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        x=0;
        y=0;
        //Cerca x- y-
        while(true)
        {
            contr=posizione.SerchPos(--x,--y);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }

        return pos;
    }
} 
public class Regina : Pezzo
{
    public Regina(Tavolo tavolo,Squadra squadra):base(tavolo,squadra){}
    public override List<Posizione> CercaMosse()
    {
        List<Posizione> pos=base.CercaMosse();

        Posizione contr;
        short x,y,i;

        /**TORRE**/

        //Cerca x+
        i=0;
        while(true)
        {
            contr=posizione.SerchPos(++i,0);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        //Cerca x-
        i=0;
        while(true)
        {
            contr=posizione.SerchPos(--i,0);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        //Cerca y+
        i=0;
        while(true)
        {
            contr=posizione.SerchPos(0,++i);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        //Cerca y-
        i=0;
        while(true)
        {
            contr=posizione.SerchPos(0,--i);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }


        x=0;
        y=0;

        /**ALFIERE**/
        //Cerca x+ y+
        while(true)
        {
            contr=posizione.SerchPos(++x,++y);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        x=0;
        y=0;
        //Cerca x+ y-
        while(true)
        {
            contr=posizione.SerchPos(++x,--y);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        x=0;
        y=0;
        //Cerca x- y+
        while(true)
        {
            contr=posizione.SerchPos(--x,++y);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }
        x=0;
        y=0;
        //Cerca x- y-
        while(true)
        {
            contr=posizione.SerchPos(--x,--y);
            if(contr==null)
                break;
            if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false)
                break;
            pos.Add(contr);
            if(contr.pezzo!=null)
                break;
        }

        return pos;
    }
} 
public class Re : Pezzo
{
    public Re(Tavolo tavolo,Squadra squadra):base(tavolo,squadra){}
    public override List<Posizione> CercaMosse()
    {
        List<Posizione> pos=base.CercaMosse();

        Posizione contr;
        short x,y,i;
        /**TORRE**/

        //Cerca x+
        i=0;
        contr=posizione.SerchPos(++i,0);
        if(contr==null) goto t2;
        if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false) goto t2;

        pos.Add(contr);

        t2:
        //Cerca x-
        i=0;

        contr=posizione.SerchPos(--i,0);
        if(contr==null) goto t3;
        if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false) goto t3;

        pos.Add(contr);
        
        t3:
        //Cerca y+
        i=0;
        contr=posizione.SerchPos(0,++i);
        if(contr==null) goto t4;
        if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false) goto t4;

        pos.Add(contr);


        t4:
        //Cerca y-
        i=0;
        
        contr=posizione.SerchPos(0,--i);
        if(contr==null) goto a5;
        if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false) goto a5;

        pos.Add(contr);


        a5:

        x=0;
        y=0;

        /**ALFIERE**/
        //Cerca x+ y+
        contr=posizione.SerchPos(++x,++y);
        if(contr==null) goto a6;
        if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false) goto a6;

        pos.Add(contr);


        a6:
        x=0;
        y=0;
        //Cerca x+ y-
        contr=posizione.SerchPos(++x,--y);
            
        if(contr==null) goto a7;
        if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false) goto a7;

        pos.Add(contr);

        a7:
        x=0;
        y=0;
        //Cerca x- y+

        contr=posizione.SerchPos(--x,++y);  
        if(contr==null) goto a8;
        if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false) goto a8;

        pos.Add(contr);

        a8:
        y=0;
        //Cerca x- y-
        contr=posizione.SerchPos(--x,--y);
              
        if(contr==null) goto fine;
        if((contr.pezzo!=null) ? contr.pezzo.squadra==this.squadra : false) goto fine;

        pos.Add(contr);

        fine:
        return pos;
    }
} 