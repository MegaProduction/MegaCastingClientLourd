﻿using MegaCasting.WPF.ViewModel;
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

namespace MegaCasting.WPF.View
{
    /// <summary>
    /// Logique d'interaction pour ViewDelOffer.xaml
    /// </summary>
    public partial class ViewDelOffer : UserControl
    {
        /// <summary>
        /// Initialise la ViewDelOffer
        /// </summary>
        public ViewDelOffer()
        {
            InitializeComponent();
        }
        private void DeleteOffreButton_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelDelOffre)this.DataContext).DeleteOffre();
        }
    }
}
