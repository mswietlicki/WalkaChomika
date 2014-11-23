namespace WalkaChomika
{
    public class ChomikSzaman : ZwierzęMagiczne
    {
        public ChomikSzaman(string imię, int mana)
            : base(imię, mana)
        {
            HP = HP * 100;
        }
    }
}
