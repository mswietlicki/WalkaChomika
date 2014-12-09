namespace WalkaChomika.Models
{
    /// <summary>
    /// Jednorożec jest zarówno magiczny, jak i latający
    /// </summary>
    class Jednorożec : ZwierzęMagiczne, ILatający
    {
        /// <summary>
        /// Bazowy konstruktor
        /// </summary>
        public Jednorożec() : base()
        {

        }

        /// <summary>
        /// Tworzenie nowego jednorożca ustawiając imię i ilość many,
        /// ustawi również HP na 1000 punktów
        /// </summary>
        /// <param name="imię">Imię dla jednorożca</param>
        /// <param name="mana">Bazowa ilość many</param>
        public Jednorożec(string imię, int mana) : base(imię, mana)
        {
            this.HP = 1000;
        }

        /// <summary>
        /// Reprezentuje, czy jednorożec jest aktualnie w trakcie lotu
        /// </summary>
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
