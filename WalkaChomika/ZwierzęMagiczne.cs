using System;

namespace WalkaChomika
{
    public class ZwierzęMagiczne : Zwierzę
    {
        public ZwierzęMagiczne(string imię, int mana)
            : base(imię)
        {
            Mana = mana;
        }

        public void AtakujMagicznie(Zwierzę z)
        {
            if (Mana <= 0)
                return;

            var r = new Random();
            var moc = r.Next(Damage * 100);
            Mana = Mana - 1;
            z.HP = z.HP - moc;
        }
    }
}
