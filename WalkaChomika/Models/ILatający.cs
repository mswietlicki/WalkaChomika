using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    /// <summary>
    /// Interfejs ILatający określa właściwości i metody, które będą posiadały
    /// wszystkie klasy go implementujące.
    /// </summary>
    interface ILatający
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
