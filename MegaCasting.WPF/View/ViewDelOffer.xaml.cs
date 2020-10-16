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
        public ViewDelOffer()
        {
            InitializeComponent();
        }

        private void TextBoxNomDel_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNomDel.Text = string.Empty;
            TextBoxNomDel.GotFocus -= TextBoxNomDel_GotFocus;
        }

        private void TextBoxNomDel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNomDel.Text.Trim().Equals(string.Empty))
            {
                TextBoxNomDel.Text = "Nom";
                TextBoxNomDel.GotFocus += TextBoxNomDel_GotFocus;
            }
        }
    }
}
