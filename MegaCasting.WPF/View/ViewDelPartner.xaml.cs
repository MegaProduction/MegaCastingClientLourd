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
    /// Logique d'interaction pour ViewDelPartner.xaml
    /// </summary>
    public partial class ViewDelPartner : UserControl
    {
        /// <summary>
        /// Initialise la ViewDelPartner
        /// </summary>
        public ViewDelPartner()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Appelle la fonction de suppression du client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelPartner_Click(object sender, RoutedEventArgs e)
        {
                ((ViewModelDelPartner)this.DataContext).DelPartner();
        }
    }
}
