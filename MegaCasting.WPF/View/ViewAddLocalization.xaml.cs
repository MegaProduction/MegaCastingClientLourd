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
    /// Logique d'interaction pour ViewAddLocalization.xaml
    /// </summary>
    public partial class ViewAddLocalization : UserControl
    {
        public ViewAddLocalization()
        {
            InitializeComponent();
        }

        private void TextBoxPays_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPays.Text.Trim().Equals(string.Empty))
            {
                TextBoxPays.Text = "Pays";
                TextBoxPays.GotFocus += TextBoxPays_GotFocus;
            }
        }

        private void TextBoxPays_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxPays.Text = string.Empty;
            TextBoxPays.GotFocus -= TextBoxPays_GotFocus;
        }

        private void ButtonAddCountry_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelAddLocalization)this.DataContext).AddCountry(TextBoxPays.Text);
        }

        private void TextBoxCodePostal_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxCodePostal.Text = string.Empty;
            TextBoxCodePostal.GotFocus -= TextBoxCodePostal_GotFocus;
        }

        private void TextBoxCodePostal_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxCodePostal.Text.Trim().Equals(string.Empty))
            {
                TextBoxCodePostal.Text = "Code postal";
                TextBoxCodePostal.GotFocus += TextBoxCodePostal_GotFocus;
            }
        }

        private void TextBoxVille_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxVille.Text.Trim().Equals(string.Empty))
            {
                TextBoxVille.Text = "Ville";
                TextBoxVille.GotFocus += TextBoxVille_GotFocus;
            }
        }

        private void TextBoxVille_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxVille.Text = string.Empty;
            TextBoxVille.GotFocus -= TextBoxVille_GotFocus;
        }

        private void ButtonAddCity_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelAddLocalization)this.DataContext).AddCity(TextBoxVille.Text, TextBoxCodePostal.Text, comboBoxPaysVille.SelectedValuePath.ToString());
        }
    }
}
