namespace WalkaChomika.Models
{
    /// <summary>
    /// Interfejs ILatający określa właściwości i metody, które będą posiadały
    /// wszystkie klasy go implementujące.
    /// </summary>
    public interface ILatający
    {
        /// <summary>
        /// Definiuje, czy obiekt aktualnie już lata
        /// </summary>
        bool CzyLata { get; set; }

        /// <summary>
        /// Uruchamia lot - ale konkretny jego efekt będzie w klasach implementujących interfejs
        /// </summary>
        void Lataj();
    }
}