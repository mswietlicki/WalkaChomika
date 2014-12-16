namespace WalkaChomika.Models
{
    /// <summary>
    /// Dinozaur, klasa dziedzicząca po Zwierzę
    /// </summary>
    public class Dinozaur : Zwierzę
    {
        /// <summary>
        /// Konstruktor, nadaje bazowe, bardzo duże,
        /// wartości HP i obrazeń
        /// </summary>
        /// <param name="imię">Imię stworzenia</param>
        public Dinozaur(string imię)
            : base(imię)
        {
            this.HP = 100000;
            this.Damage = 150;
        }
    }
}
