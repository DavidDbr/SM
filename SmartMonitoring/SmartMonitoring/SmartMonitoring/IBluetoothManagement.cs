using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMonitoring
{
    public interface IBluetoothManagement
    {
        bool IsOn();

        Task<List<string>> scanDevices();

        Task<bool> openConnectionAsync(string MAC);

        string getDevice(string MAC);
    }
}
