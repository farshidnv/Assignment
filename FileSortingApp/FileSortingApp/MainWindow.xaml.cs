using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileSortingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileList fileList = null;
        List<FileAttribute> files = null;


        public MainWindow()
        {
            InitializeComponent();
            fileList = new RecursiveFileList();
            fileList.StatusUpdated += FileList_StatusUpdated;
            files = new List<FileAttribute>();   
        }

        private async void SelectDirectory_Click(object sender, RoutedEventArgs e)
        {
            string directory = "";
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result != System.Windows.Forms.DialogResult.OK)
                    return;

               _selectedDirectory.Text = directory = dialog.SelectedPath;
            }

            files.Clear();
            _sortPanel.IsEnabled = false;
            _dataGridFiles.IsEnabled = false;

            files = await fileList.GetFilesAsync(directory);
            UpdateDataContext(files);
            _sortPanel.IsEnabled = true;
            _dataGridFiles.IsEnabled = true;

        }

        private void UpdateDataContext(List<FileAttribute> fileAttributes)
        {
            DataContext = null;
            DataContext = fileAttributes;
        }

        private void FileList_StatusUpdated(object sender, StatusEventArgs e)
        {
            try
            {
                _status.Dispatcher.Invoke(new Action(() => { _status.Text = e.CurrentFileName; })
                    );
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }

        }

        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            ISortableFiles sortable = new FileNameSort();
            UpdateDataContext(sortable.Sort(files));
        }

        private void SortByType_Click(object sender, RoutedEventArgs e)
        {
            ISortableFiles sortable = new FileTypeSort();
            UpdateDataContext(sortable.Sort(files));
        }

        private void SortBySize_Click(object sender, RoutedEventArgs e)
        {
            ISortableFiles sortable = new FileSizeSort();
            UpdateDataContext(sortable.Sort(files));
        }

        private void SortByDate_Click(object sender, RoutedEventArgs e)
        {
            ISortableFiles sortable = new FileDateSort();
            UpdateDataContext(sortable.Sort(files));
        }
    }
}
