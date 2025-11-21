using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat
{
    public class Potwor
    {
        public virtual string? Nazwa { get; set; }
        public int HP;
        public int Sila;
        public int Otrzymaj(int obrażenia)
        {
            if (HP >= 0)
            {
                HP -= obrażenia;
                if (HP <= 0)
                {
                    HP = 0;
                    Console.WriteLine($"Potwór został pokonany");
                }
            }
            return HP;
        }

        public void Atakuj(Gracz cel, int Sila)
        {
            cel.Otrzymaj(Sila);
        }
    }

    public class Zombie : Potwor
    {
        public new string Nazwa = "Zombie";
        public new int HP = 50;
        public new int Sila = 7;
    }
}
