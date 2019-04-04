using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingApp
{
    public class StatusEventArgs : EventArgs
    {
        public string CurrentFileName { get; set; }
    }
}
