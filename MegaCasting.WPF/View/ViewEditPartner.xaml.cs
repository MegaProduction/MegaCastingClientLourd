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
    /// Logique d'interaction pour ViewEditPartner.xaml
    /// </summary>
    public partial class ViewEditPartner : UserControl
    {
        public ViewEditPartner()
        {
            InitializeComponent();
        }

        private void TextBoxNom_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNom.Text = string.Empty;
            TextBoxNom.GotFocus -= TextBoxNom_GotFocus;
        }

        private void TextBoxNom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNom.Text.Trim().Equals(string.Empty))
            {
                TextBoxNom.Text = "Nom";
                TextBoxNom.GotFocus += TextBoxNom_GotFocus;
            }
        }

        private void TextBoxPays_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxPays.Text = string.Empty;
            TextBoxPays.GotFocus -= TextBoxPays_GotFocus;
        }

        private void TextBoxPays_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPays.Text.Trim().Equals(string.Empty))
            {
                TextBoxPays.Text = "Pays";
                TextBoxPays.GotFocus += TextBoxPays_GotFocus;
            }
        }

        private void TextBoxVille_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxVille.Text = string.Empty;
            TextBoxVille.GotFocus -= TextBoxVille_GotFocus;
        }

        private void TextBoxVille_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxVille.Text.Trim().Equals(string.Empty))
            {
                TextBoxVille.Text = "Ville";
                TextBoxVille.GotFocus += TextBoxVille_GotFocus;
            }
        }

        private void TextBoxRue_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxRue.Text = string.Empty;
            TextBoxRue.GotFocus -= TextBoxRue_GotFocus;
        }

        private void TextBoxRue_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxRue.Text.Trim().Equals(string.Empty))
            {
                TextBoxRue.Text = "Rue";
                TextBoxRue.GotFocus += TextBoxRue_GotFocus;
            }
        }
    }
}
