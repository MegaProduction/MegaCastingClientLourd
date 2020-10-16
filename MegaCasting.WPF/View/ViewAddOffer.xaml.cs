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
    /// Logique d'interaction pour ViewAddOffer.xaml
    /// </summary>
    public partial class ViewAddOffer : UserControl
    {
        public ViewAddOffer()
        {
            InitializeComponent();
        }

        private void TextBoxDatDeb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDatDeb.Text = string.Empty;
            TextBoxDatDeb.GotFocus -= TextBoxDatDeb_GotFocus;
        }

        private void TextBoxDatDeb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxDatDeb.Text.Trim().Equals(string.Empty))
            {
                TextBoxDatDeb.Text = "Date de début";
                TextBoxDatDeb.GotFocus += TextBoxDatDeb_GotFocus;
            }
        }
    }
}
