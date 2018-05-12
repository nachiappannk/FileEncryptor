﻿using System;
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

namespace FileEncryptor
{
    /// <summary>
    /// Interaction logic for OperationsUserControl.xaml
    /// </summary>
    public partial class OperationsUserControl : UserControl
    {
        public OperationsUserControl()
        {
            InitializeComponent();
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0)
                {
                    if (!(DataContext is OperationsViewModel dataContext)) throw new Exception();
                    dataContext.Process(files[0]);
                }
            }
        }
    }
}
