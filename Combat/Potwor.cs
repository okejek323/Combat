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
        public virtual void SpecjalnyAtak(Gracz cel) { }

        public int Otrzymaj(int obrażenia)
        {
            if (HP > 0)
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
        public Zombie() 
        {
			Nazwa = "zombie";
			HP = 50;
			Sila = 7;
		}
    }

    public class Cyklop : Potwor
    {
        public Cyklop()
        {
            Nazwa = "cyklop";
            HP = 75;
            Sila = 10;
        }
    }

    public class Wampir : Potwor
    {
        public int SilaKrwi = 30;

		public Wampir()
        {
            Nazwa = "wapir";
            HP = 90;
            Sila = 10;
        }

        public override void SpecjalnyAtak(Gracz cel)
        {
            Console.WriteLine("Wampir używa umiejętności Wysysania Krwi");

            cel.Otrzymaj(SilaKrwi);
            Console.WriteLine($"Otrzymano {SilaKrwi} obrażeń");
            HP += SilaKrwi / 3;
            Console.WriteLine($"Wampir uzyskał {SilaKrwi/3} HP, teraz ma {HP} HP");
		}
    }
}
