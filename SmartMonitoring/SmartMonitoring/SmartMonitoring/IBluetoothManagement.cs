using System.Collections.Generic;
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
