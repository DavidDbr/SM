using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.OBDII.Excepciones
{
    public class CanErrorException : Exception
    {
        public CanErrorException()
        {
        }

        public CanErrorException(string message) : base(message)
        {
        }

        public CanErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
