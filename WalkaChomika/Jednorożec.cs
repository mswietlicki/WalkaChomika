using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika
{
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
