using LFR.Accessors;
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

            var factory = new ResourceAccessorFactory();
            var reader = factory.Create<IFileReader>();
            Result.Text = reader.Read(FilePath.Text, start);          
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
