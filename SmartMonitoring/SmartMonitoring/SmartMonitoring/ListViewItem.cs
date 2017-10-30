using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMonitoring
{
    public class ListViewItem
    {
        string showing;

        public string Showing { get => showing; set => showing = value; }

        public ListViewItem(String s)
        {
            Showing = s;
        }
    }

}
