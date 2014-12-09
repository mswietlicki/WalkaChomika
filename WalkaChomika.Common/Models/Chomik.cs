using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Models
{
    /// <summary>
    /// Klasa Chomik, dziedzicząca po Zwierzę
    /// </summary>
    public class Chomik : Zwierzę
    {
        /// <summary>
        /// Ma własny konstruktor, który ustawia imię i nie ma bez -
        /// więc nie da się stworzyć go bez imienia
        /// </summary>
        /// <param name="imię">Imię chomika</param>
        public Chomik(string imię)
            : base(imię)
        {
        }
    }
}