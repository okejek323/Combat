using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    public class Gracz
    {
        public string? Nazwa { get; set; }
        public int HP = 100;
        public int Sila = 10;
        public int SilaLeczenia = 15;

        public int Otrzymaj(int obrażenia)
        {
            if (HP > 0)
            {
                HP -= obrażenia;
                if (HP <= 0)
                {
                    HP = 0;
                    Console.WriteLine("Porażka");
                }
            }
            return HP;
        }

        public void Atakuj(Potwor cel,int Sila)
        {
            cel.Otrzymaj(Sila);
        }

        public int Ulecz(int ile) 
        { 
            HP += ile;
            if (HP > 100)
            {
                HP = 100;
            }
            return HP;
        }
    }
}

