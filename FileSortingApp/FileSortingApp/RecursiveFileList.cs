using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingApp
{
    public class RecursiveFileList : FileList
    {
        List<FileAttribute> files = new List<FileAttribute>();

        public override List<FileAttribute> GetFiles(string directory)
        {
            if (string.IsNullOrEmpty(directory))
                return files;

            GetAllFiles(directory);
            return files;
        }

        public override async Task<List<FileAttribute>> GetFilesAsync(string directory)
        {
            if (string.IsNullOrEmpty(directory))
                return files;

            return await Task.Run(() =>
            {
                GetAllFiles(directory);
                return files;
            }
            );
        }

        private void GetAllFiles(string directoryName)
        {
            try
            {
                foreach (string directory in Directory.GetDirectories(directoryName))
                {
                    foreach (string file in Directory.GetFiles(directory))
                    {
                        var fileAttribute = FileAttributeUtility.GetFileAttribute(file);

                        files.Add(fileAttribute);
                        OnStatusUpdated(new StatusEventArgs
                        {
                            CurrentFileName = fileAttribute.Name
                        });
                    }
                    GetFiles(directory);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
            
        }
    }
}
