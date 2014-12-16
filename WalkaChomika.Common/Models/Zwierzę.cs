using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    /// <summary>
    /// Klasa Zwierzę, reprezentująca zwierzę bojowe
    /// </summary>
    public class Zwierzę : INotifyPropertyChanged
    {
        /// <summary>
        /// To jest tzw. właściwość. Powinno używać się właściwości zamiast pól, ale dlaczego, to już
        /// kwestia nieco bardziej zaawansowana, więc chwilowo ją pominiemy. To konkretne pole reprezentuje
        /// imię zwierzęcia.
        /// </summary>
        private String imię;

        public String Imię
        {
            get { return imię; }
            set
            {
                if (this.imię != value)
                {
                    imię = value;
                    OnPropertyChanged("Imię");
                }
            }
        }

        /// <summary>
        /// To pole jest liczbą, która reprezentuje ile zwierzę ma punktów życia
        /// </summary>
        private int hp;

        public virtual int HP
        {
            get { return hp; }
            set
            {
                if (this.hp != value)
                {
                    hp = value;
                    OnPropertyChanged("HP");
                }
            }
        }

        /// <summary>
        /// To pole reprezentuje ilość many zwierzęcia
        /// </summary>
        private int mana;

        public virtual int Mana
        {
            get { return mana; }
            set
            {
                if (this.mana != value)
                {
                    mana = value;
                    OnPropertyChanged("Mana");
                }
            }
        }

        /// <summary>
        /// To pole reprezentuje maksymalne obrażenia zadawane przez atak
        /// </summary>
        public int Damage { get; protected set; }

        public int Agility { get; set; }

        public Zwierzę()
        {
            this.HP = 10;
            this.Mana = 0;
            this.Damage = 5;
            this.Agility = 0;
        }

        public Zwierzę(string imię)
            : this()
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}