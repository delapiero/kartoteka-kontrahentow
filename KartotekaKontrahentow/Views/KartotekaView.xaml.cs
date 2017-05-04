﻿using KartotekaKontrahentow.Models;
using KartotekaKontrahentow.ViewModels;
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

namespace KartotekaKontrahentow.Views
{
    /// <summary>
    /// Interaction logic for KartotekaView.xaml
    /// </summary>
    public partial class KartotekaView : UserControl
    {
        public KartotekaView()
        {
            InitializeComponent();

            this.DataContext = new KartotekaViewModel(new ZbiorKonrahentowCSV());
        }
    }
}
