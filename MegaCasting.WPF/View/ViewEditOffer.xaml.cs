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
    /// Logique d'interaction pour ViewEditOffer.xaml
    /// </summary>
    public partial class ViewEditOffer : UserControl
    {
        public ViewEditOffer()
        {
            InitializeComponent();
        }

        private void ButtonEditOffer_Click(object sender, RoutedEventArgs e)
        {
            int idVille = 0;
            bool ville = Int32.TryParse(comboBoxVille.SelectedValue.ToString(), out idVille);
            MessageBox.Show(ville.ToString()+idVille.ToString());
            //((ViewModelEditOffer)this.DataContext).EditOffer();
        }
    }
}
