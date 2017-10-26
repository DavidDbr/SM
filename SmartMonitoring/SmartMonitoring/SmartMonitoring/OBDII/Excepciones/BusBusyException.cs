using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.OBDII.Excepciones
{
    public class BusBusyException : Exception
    {
        public BusBusyException()
        {
        }

        public BusBusyException(string message) : base(message)
        {
        }

        public BusBusyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
