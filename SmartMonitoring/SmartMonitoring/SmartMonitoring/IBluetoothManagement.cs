using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring
{
    public interface IBluetoothManagement
    {
        bool IsOn();

        Task<List<string>> scanDevices();

        bool openConnection(string MAC);

        string getDevice(string MAC);        
    }
}
