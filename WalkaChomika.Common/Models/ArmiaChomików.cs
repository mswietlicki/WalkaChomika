using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    /// <summary>
    /// Definicja nowego zawodnika - Armii Chomików
    /// </summary>
    public class ArmiaChomików : Zwierzę
    {
        /// <summary>
        /// Wewnętrzna kolekcja, lista, zawierająca poszczególne Chomiki
        /// </summary>
        private List<Chomik> chomiki;

        /// <summary>
        /// Ilość punktów życia w armii chomików jest znacząco zmodyfikowana - pobieranie HP sumuje HP
        /// wszystkich członków gromady, podczas gdy zmiana HP powoduje zaatakowanie konkretnego osobnika.
        /// </summary>
        public override int HP
        {
            get
            {
                var h = 0;
                foreach (var c in chomiki)
                {
                    h += c.HP;
                }

                return h;
            }

            set
            {
                if (chomiki != null)
                {
                    value = Math.Abs(value);

                    // wersja ataku przeciwnika zwykła - wybierany jest losowy cel
                    /*var r = new Random().Next(chomiki.Count);
                    chomiki[r].HP -= value;
                    if (chomiki[r].HP < 0)
                    {
                        chomiki.RemoveAt(r);
                    }*/

                    // wersja ataku przeciwnika z inteligencją armii - celem zawsze jest najsłabszy
                    var c = NajsłabszyChomik();
                    c.HP -= value;
                    if (c.HP < 0)
                        chomiki.Remove(c);
                    OnPropertyChanged("HP");
                }
            }
        }

        /// <summary>
        /// Funkcja wybierająca najsłabszego chomika
        /// </summary>
        /// <returns>Funkcja wybiera chomika o najmniejszym HP</returns>
        public Chomik NajsłabszyChomik()
        {
            return chomiki.OrderBy(x => x.HP).First();
        }

        public ArmiaChomików(int ilość, string imie)
            : base(imie)
        {
            chomiki = new List<Chomik>();

            var r = new Random();

            for (int i = 0; i < ilość; i++)
            {
                var c = new Chomik("Chomik " + i);
                c.HP = r.Next(10) + 1;
                chomiki.Add(c);
            }
        }

        /// <summary>
        /// Tworzenie nowej armii chomików
        /// </summary>
        /// <param name="ilość">Ilość chomików w armii</param>
        public ArmiaChomików(int ilość)
        {
            chomiki = new List<Chomik>();

            var r = new Random();

            for (int i = 0; i < ilość; i++)
            {
                var c = new Chomik("Chomik " + i);
                c.HP = r.Next(10) + 1;
                chomiki.Add(c);
            }

            this.Imię = "Armia";
        }

        /// <summary>
        /// Własna, dość specjalna, implementacja funkcji CzyŻyje
        /// </summary>
        /// <returns>Zwraca, czy istnieje przynajmniej jeden chomik w armii.</returns>
        public override bool CzyŻyje()
        {
            return (chomiki.Count > 0);
        }

        /// <summary>
        /// Własna implementacja dla ataku - atakują przeciwnika wszystkie chomiki
        /// </summary>
        /// <param name="z">Przeciwnik do zaatakowania</param>
        public override void Gryź(Zwierzę z)
        {
            Random r = new Random();

            foreach (var c in chomiki)
            {
                if (r.Next(5) >= z.Agility)
                {
                    var moc = r.Next(c.Damage);
                    z.HP = z.HP - moc;
                }
            }
        }

        /// <summary>
        /// Własna implementacja ToString dla armii chomików, prezentująca ilość pozostałych przy życiu i ich wspólne HP
        /// </summary>
        /// <returns>Tekstowy opis armii chomików</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}HP {2}", chomiki.Count, this.HP, CzyŻyje() ? "Żywe" : "RIP");
        }
    }
}