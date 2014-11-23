namespace WalkaChomika
{
    public class ChomikSzaman : ZwierzęMagiczne
    {
        public ChomikSzaman(string imię, int mana)
        {
            Imię = imię;
            Mana = mana;
            HP = HP * 100;
        }
    }
}
