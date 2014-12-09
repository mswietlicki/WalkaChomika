using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    delegate void ZwierzęMartwe(Zwierzę sender);

    /// <summary>
    /// Klasa Zwierzę, reprezentująca zwierzę bojowe
    /// </summary>
    class Zwierzę
    {
        /// <summary>
        /// To jest tzw. właściwość. Powinno używać się właściwości zamiast pól, ale dlaczego, to już
        /// kwestia nieco bardziej zaawansowana, więc chwilowo ją pominiemy. To konkretne pole reprezentuje
        /// imię zwierzęcia.
        /// </summary>
        public string Imię { get; set; }

        /// <summary>
        /// Prywatne pole odpowiadające właściwości HP - ręczna implementacja getterów i setterów
        /// </summary>
        private int _HP;

        /// <summary>
        /// Ta właściwość reprezentuje ilość punktów życia zwierzęcia
        /// </summary>
        public virtual int HP
        {
            get
            {
                return this._HP;
            }

            set
            {                
                this._HP = value;

                // jeśli HP jest mniejsze od 0 i ktokolwiek subskrybuje zdarzenie
                // to odpalamy zdarzenie Zmarł
                if (this._HP < 0 && Zmarł != null)
                    Zmarł.Invoke(this);
            }
        }

        /// <summary>
        /// To pole reprezentuje ilość many zwierzęcia
        /// </summary>
        public int Mana { get; set; }

        /// <summary>
        /// To pole reprezentuje maksymalne obrażenia zadawane przez atak
        /// </summary>
        public int Damage { get; protected set; }

        /// <summary>
        /// Zwinność zwierzęcia
        /// </summary>
        public int Agility { get; set; }

        /// <summary>
        /// Zdarzenie, które wywołuje się, kiedy zwierzę zmarło
        /// </summary>
        public event ZwierzęMartwe Zmarł;

        /// <summary>
        /// Podstawowy kontruktor ustawiający bazowe właściwości
        /// </summary>
        public Zwierzę()
        {
            this.HP = 10;
            this.Mana = 0;
            this.Damage = 5;
            this.Agility = 0;     
        }

        /// <summary>
        /// Konstruktor, który ustawia dodatkowo imię
        /// </summary>
        /// <param name="imię">Imię, które zostanie nadane zwierzęciu</param>
        public Zwierzę(string imię) : this()
        {
            this.Imię = imię;
        }

        /// <summary>
        /// Ta funkcja zwraca, czy zwierze jeszcze żyje, opierając się na danych z tego samego obiektu.
        /// Funkcje w klasach nazywa się metodami.
        /// </summary>
        /// <returns>Zwraca, czy zwierzę jeszcze żyje</returns>
        public virtual bool CzyŻyje()
        {
            if (HP > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Ta funkcja atakuje inne zwierzę - podawane jest jako parametr wykonania tej funkcji.
        /// </summary>
        /// <param name="z">Zwierzę do zaatakowania</param>
        public virtual void Gryź(Zwierzę z)
        {         
            Random r = new Random();
            if (r.Next(5) >= z.Agility)
            {
                var moc = r.Next(this.Damage);
                z.HP = z.HP - moc;
            }
        }

        /// <summary>
        /// Wywołanie ToString na zwierzęciu będzie uruchamiało własną funkcję, zamiast wbudowanej
        /// </summary>
        /// <returns>Zwierzę będzie po przekształceniu do stringa zwracało swój stan</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}HP {2}Mana {3}", Imię, HP, Mana, CzyŻyje() ? "Żywe" : "RIP");
        }
    }
}
