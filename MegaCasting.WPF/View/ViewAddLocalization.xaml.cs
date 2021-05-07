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
        /// <summary>
        /// Initialise la ViewAddLocalization
        /// </summary>
        public ViewAddLocalization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPays_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPays.Text.Trim().Equals(string.Empty))
            {
                TextBoxPays.Text = "Pays";
                TextBoxPays.GotFocus += TextBoxPays_GotFocus;
            }
        }

        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPays_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxPays.Text = string.Empty;
            TextBoxPays.GotFocus -= TextBoxPays_GotFocus;
        }

        /// <summary>
        /// Bouton qui appelle la fonction d'ajout des pays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddCountry_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelAddLocalization)this.DataContext).AddCountry(TextBoxPays.Text);
        }

        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxCodePostal_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxCodePostal.Text = string.Empty;
            TextBoxCodePostal.GotFocus -= TextBoxCodePostal_GotFocus;
        }

        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxCodePostal_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxCodePostal.Text.Trim().Equals(string.Empty))
            {
                TextBoxCodePostal.Text = "Code postal";
                TextBoxCodePostal.GotFocus += TextBoxCodePostal_GotFocus;
            }
        }

        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxVille_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxVille.Text.Trim().Equals(string.Empty))
            {
                TextBoxVille.Text = "Ville";
                TextBoxVille.GotFocus += TextBoxVille_GotFocus;
            }
        }

        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxVille_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxVille.Text = string.Empty;
            TextBoxVille.GotFocus -= TextBoxVille_GotFocus;
        }

        /// <summary>
        /// Bouton qui appelle la fonction d'ajout des villes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddCity_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelAddLocalization)this.DataContext).AddCity(TextBoxVille.Text, TextBoxCodePostal.Text);
        }
    }
}
