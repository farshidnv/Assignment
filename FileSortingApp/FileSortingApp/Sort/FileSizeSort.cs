using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingApp
{
    class FileSizeSort : ISortableFiles
    {
        public List<FileAttribute> Sort(List<FileAttribute> list)
        {
            list.Sort((x, y) => x.Size.CompareTo(y.Size));
            return list;
        }
    }
}
