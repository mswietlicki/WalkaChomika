using System;

namespace WalkaChomika
{
    public class Zwierzę
    {
        public string Imię { get; set; }
        public int HP { get; set; }
        public int Mana { get; set; }
        public int Damage { get; protected set; }

        public Zwierzę()
        {
            HP = 10;
            Mana = 0;
            Damage = 5;
            Imię = "BRAK!";
        }

        public Zwierzę(string imię)
            : this()
        {
            Imię = imię;
        }

        public bool CzyŻyje()
        {
            return HP > 0;
        }

        public void Gryź(Zwierzę z)
        {
            var r = new Random();
            var moc = r.Next(Damage);

            z.HP = z.HP - moc;
        }
    }
}
