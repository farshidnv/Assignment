using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingApp
{
    class FileNameSort : ISortableFiles
    {
        List<FileAttribute> ISortableFiles.Sort(List<FileAttribute> list)
        {
            list.Sort((x, y) => x.Name.CompareTo(y.Name));
            return list;
        }
    }
}
