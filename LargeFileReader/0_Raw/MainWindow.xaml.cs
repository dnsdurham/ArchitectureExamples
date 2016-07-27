using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace DemoArch_LargeFileReader
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

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            var start = int.Parse(Start.Text);
            var count = 10000;

            var buf = new byte[count];
            using (var stream = File.OpenRead(FilePath.Text))
            {
                stream.Seek(start, SeekOrigin.Begin);
                stream.Read(buf, 0, count);

                Result.Text = System.Text.Encoding.Default.GetString(buf);
            }
        }

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "txt";

            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                FilePath.Text = openFileDialog.FileName;
            }           
        }
    }
}
