using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkaChomika.Common.Models
{
    public class HorseCannotIntoSkyException : Exception
    {
        public HorseCannotIntoSkyException()
        {
        }

        public HorseCannotIntoSkyException(string message) : base(message)
        {
        }

        public HorseCannotIntoSkyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
