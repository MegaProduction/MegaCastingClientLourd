using MegaCasting.WPF.ViewModel;
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
    /// Logique d'interaction pour ViewEditLocalization.xaml
    /// </summary>
    public partial class ViewEditLocalization : UserControl
    {
        public ViewEditLocalization()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Édition de la ville
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditCity_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelEditLocalization)this.DataContext).EditCity();
        }
        /// <summary>
        /// Édition du pays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditCountry_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelEditLocalization)this.DataContext).EditCountry();
        }
    }
}
