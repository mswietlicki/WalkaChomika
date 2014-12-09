using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    /// <summary>
    /// Klasa ZwierzęMagiczne dziedziczy po klasie Zwierzę
    /// </summary>
    public class ZwierzęMagiczne : Zwierzę
    {
        /// <summary>
        /// Konstruktor, który ustawia wartości podstawowe
        /// </summary>
        public ZwierzęMagiczne()
            : base()
        {
        }

        /// <summary>
        /// Konstruktor, który ustawia wartości przekazane jako parametry
        /// </summary>
        /// <param name="imię">Imię stworzenia</param>
        /// <param name="mana">Ilość many stworzenia</param>
        public ZwierzęMagiczne(string imię, int mana)
            : base(imię)
        {
            this.Mana = mana;
        }

        /// <summary>
        /// Funkcja ataku magicznego, jest prawie analogiczna do funkcji
        /// Gryzienia, ale ma o wiele większą moc
        /// </summary>
        /// <param name="z"></param>
        public void AtakujMagicznie(Zwierzę z)
        {
            if (this.Mana > 0)
            {
                // tworzenie generatora liczb losowych
                Random r = new Random();
                // losuje liczbę z zakresu od 0 do maksymalnego ataku obecnego obiektu
                var moc = r.Next(this.Damage * 100);
                this.Mana = this.Mana - 1;

                // zwierzęciu przekazanemu jako parametr odejmuje od punktów HP tyle, ile wyniosła moc ataku
                z.HP = z.HP - moc;
            }
        }
    }
}