﻿using LFR;
using LFR.Accessors;
using LFR.Managers;
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

        private void SelectFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "txt";

            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                FilePath.Text = openFileDialog.FileName;
            }

            var factory = new ManagerFactory();
            var manager = factory.Create<IDataFileManager>();
            FilePosition.Maximum = manager.NumberOfParts(FilePath.Text);
            FilePosition.Value = 0;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var factory = new ManagerFactory();
            var manager = factory.Create<IDataFileManager>();
            Result.Text = manager.Read(FilePath.Text, (int)FilePosition.Value, MakeLower.IsChecked.Value);
        }
    }
}
