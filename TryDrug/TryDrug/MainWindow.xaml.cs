using System;
using System.IO;
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
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            var s = @"D:\Навчання\6 Семестр\Таня\3.docx";
            MessageBox.Show(s);
            Converters.ConvertFromWord.WordToXps(s);
            MessageBox.Show("File is converted");
            StartState();
        }


        private void lBoxDropFiles_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                image.Visibility = Visibility.Hidden;
                lBoxDropFiles.Items.Clear();


                string[] LOP = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                foreach (var lop in LOP)
                {
                    if (Checking.CheckFormat(lop))
                    {
                        ListBoxItem fileItem = new ListBoxItem();
                        fileItem.Content = lop;//System.IO.Path.GetFileNameWithoutExtension(lop);
                                               //fileItem.ToolTip = lop;
                        lBoxDropFiles.Items.Add(fileItem);
                    }
                }
            }

            btnDelete.IsEnabled = false;
            btnConvert.IsEnabled = true;
            btnDelete.Visibility = Visibility.Visible;

            if (lBoxDropFiles.Items.IsEmpty)
            {
                StartState();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var delItem = lBoxDropFiles.SelectedItem;
            lBoxDropFiles.Items.Remove(delItem);
            if (lBoxDropFiles.Items.IsEmpty)
            {
                lBoxDropFiles.Items.Clear();
                StartState();
            }

        }

        private void lBoxDropFiles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = (lBoxDropFiles.SelectedIndex != -1) ? true : false;
        }

        private void StartState()
        {
            image.Visibility = Visibility.Visible;
            lBoxDropFiles.Items.Clear();
            btnDelete.Visibility = Visibility.Hidden;
        }
    }
}
