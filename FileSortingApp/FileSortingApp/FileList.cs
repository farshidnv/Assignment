using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSortingApp
{
    public class FileList
    {
        public event EventHandler<StatusEventArgs> StatusUpdated;

        List<FileAttribute> files = new List<FileAttribute>();

        protected virtual void OnStatusUpdated(StatusEventArgs e)
        {
            StatusUpdated?.Invoke(this, e);
        }

        public virtual List<FileAttribute> GetFiles(string directory)
        {
            if (string.IsNullOrEmpty(directory))
                return files;

            GetAllFiles(directory);
            return files;

        }

        public virtual async Task<List<FileAttribute>> GetFilesAsync(string directory)
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
                foreach (string file in Directory.EnumerateFiles(directoryName, "*.*", SearchOption.AllDirectories))
                {
                    var fileAttribute = FileAttributeUtility.GetFileAttribute(file);
                    files.Add(fileAttribute);

                    OnStatusUpdated(new StatusEventArgs
                    {
                        CurrentFileName = fileAttribute.Name
                    });
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
          
        }

    }
}
