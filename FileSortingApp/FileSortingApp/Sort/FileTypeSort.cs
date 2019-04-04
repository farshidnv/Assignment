using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingApp
{
    class FileTypeSort : ISortableFiles
    {
        public List<FileAttribute> Sort(List<FileAttribute> list)
        {
            list.Sort((x, y) => x.Type.CompareTo(y.Type));
            return list;
        }
    }
}
