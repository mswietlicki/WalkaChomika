using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    /// <summary>
    /// Jednorożec jest zarówno magiczny, jak i latający
    /// </summary>
    class Jednorożec : ZwierzęMagiczne, ILatający
    {
        public Jednorożec() : base()
        {

        }

        public Jednorożec(string imię, int mana) : base (imię, mana)
        {
            this.HP = 1000;           
        }

        public bool CzyLata { get; set; }

        /// <summary>
        /// Implementacja latania - jeżeli aktualnie nie lata, to spada mu mana, ale
        /// zwiększa się zwinność oraz zadawane obrażenia
        /// </summary>
        public void Lataj()
        {
            if (!this.CzyLata)
            {
                this.Mana = this.Mana - 10;
                this.Agility += 1;
                this.Damage += 10;
            }
        }
    }
}
