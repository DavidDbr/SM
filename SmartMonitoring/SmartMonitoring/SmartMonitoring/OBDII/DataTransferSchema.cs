using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring.OBDII
{
    public class DataTransferSchema
    {
        string response;
        private Parameters.PID pid;
        private Parameters.ConsultMode mode;

        public string Response
        {
            get
            {
                return response;
            }

            set
            {
                response = value;
            }
        }

        public Parameters.PID Pid
        {
            get
            {
                return pid;
            }

            set
            {
                pid = value;
            }
        }

        internal Parameters.ConsultMode Mode
        {
            get
            {
                return mode;
            }

            set
            {
                mode = value;
            }
        }



        public DataTransferSchema(string response, Parameters.PID pid, Parameters.ConsultMode mode)
        {
            this.Response = response;
            this.Pid = pid;
            this.Mode = mode;
        }
        public DataTransferSchema(string response, Parameters.ConsultMode mode)
        {
            this.Response = response;
            this.Mode = mode;
        }
    }
}
