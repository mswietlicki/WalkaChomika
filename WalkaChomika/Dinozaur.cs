namespace WalkaChomika
{
    public class Dinozaur : Zwierzę
    {
        public Dinozaur(string imię)
            : base(imię)
        {
            HP = 100000;
            Damage = 150;
        }
    }
}
