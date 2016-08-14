using System;
using System.Collections.Generic;
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

namespace TryDrug
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnConvert.IsEnabled = false;
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            image.Visibility = Visibility.Visible;
            lBoxDropFiles.Items.Clear();
            btnDelete.Visibility = Visibility.Hidden;
        }


        private void lBoxDropFiles_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                image.Visibility = Visibility.Hidden;
                lBoxDropFiles.Items.Clear();

                string[] droppedFilePaths =
                e.Data.GetData(DataFormats.FileDrop, true) as string[];

                foreach (string droppedFilePath in droppedFilePaths)
                {
                    ListBoxItem fileItem = new ListBoxItem();

                    fileItem.Content = System.IO.Path.GetFileNameWithoutExtension(droppedFilePath);
                    fileItem.ToolTip = droppedFilePath;

                    lBoxDropFiles.Items.Add(fileItem);
                }
            }

            btnConvert.IsEnabled = true;
            btnDelete.Visibility = Visibility.Visible;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lBoxDropFiles.Items.Remove(lBoxDropFiles.SelectedItem);
            if (lBoxDropFiles.Items.IsEmpty)
            {
                btnConvert.IsEnabled = false;
                image.Visibility = Visibility.Visible;
                lBoxDropFiles.Items.Clear();
                btnDelete.Visibility = Visibility.Hidden;
            }
        }

        private void lBoxDropFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = (lBoxDropFiles.SelectedIndex != -1) ? true : false;
        }
    }
}
