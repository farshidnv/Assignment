using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingApp
{
    public class FileAttributeUtility
    {
       public static FileAttribute GetFileAttribute(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return new FileAttribute
            {
                Name = fileInfo.Name,
                Date = fileInfo.CreationTime,
                Size = fileInfo.Length,
                Type = fileInfo.Extension
            };
        }
    }
}
