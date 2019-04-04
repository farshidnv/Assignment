using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingApp
{
    class FileDateSort : ISortableFiles
    {
        public List<FileAttribute> Sort(List<FileAttribute> list)
        {
            list.Sort((x, y) => x.Date.CompareTo(y.Date));
            return list;
        }
    }
}
