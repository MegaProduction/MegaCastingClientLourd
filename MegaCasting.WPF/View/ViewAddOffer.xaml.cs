using MegaCasting.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        /// <summary>
        /// Initialise la ViewAddOffer
        /// </summary>
        public ViewAddOffer()
        {
            InitializeComponent();
        }
        #region Affichage
        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxIntitule_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxIntitule.Text = string.Empty;
            TextBoxIntitule.GotFocus -= TextBoxIntitule_GotFocus;
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxIntitule_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxIntitule.Text.Trim().Equals(string.Empty))
            {
                TextBoxIntitule.Text = "Intitulé";
                TextBoxIntitule.GotFocus += TextBoxIntitule_GotFocus;
            }
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNbPostes_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNbPostes.Text = string.Empty;
            TextBoxNbPostes.GotFocus -= TextBoxNbPostes_GotFocus;
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNbPostes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNbPostes.Text.Trim().Equals(string.Empty))
            {
                TextBoxNbPostes.Text = "Nombre de postes";
                TextBoxNbPostes.GotFocus += TextBoxNbPostes_GotFocus;
            }
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescripPoste_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDescripPoste.Text = string.Empty;
            TextBoxDescripPoste.GotFocus -= TextBoxDescripPoste_GotFocus;
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescripPoste_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxDescripPoste.Text.Trim().Equals(string.Empty))
            {
                TextBoxDescripPoste.Text = "Description du poste";
                TextBoxDescripPoste.GotFocus += TextBoxDescripPoste_GotFocus;
            }
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescripProfil_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDescripProfil.Text = string.Empty;
            TextBoxDescripProfil.GotFocus -= TextBoxDescripProfil_GotFocus;
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDescripProfil_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxDescripProfil.Text.Trim().Equals(string.Empty))
            {
                TextBoxDescripProfil.Text = "Description du profil";
                TextBoxDescripProfil.GotFocus += TextBoxDescripProfil_GotFocus;
            }
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDureeDiff_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDureeDiff.Text = string.Empty;
            TextBoxDureeDiff.GotFocus -= TextBoxDureeDiff_GotFocus;
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDureeDiff_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxDureeDiff.Text.Trim().Equals(string.Empty))
            {
                TextBoxDureeDiff.Text = "Durée de diffusion";
                TextBoxDureeDiff.GotFocus += TextBoxDureeDiff_GotFocus;
            }
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxCoord_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxCoord.Text = string.Empty;
            TextBoxCoord.GotFocus -= TextBoxCoord_GotFocus;
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxCoord_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxCoord.Text.Trim().Equals(string.Empty))
            {
                TextBoxCoord.Text = "Coordonnées";
                TextBoxCoord.GotFocus += TextBoxCoord_GotFocus;
            }
        }
        /// <summary>
        /// Fonction pour n'autoriser que certains caractères dans le champ de date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePickerDateDebut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9/]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Fonction pour n'autoriser que certains caractères dans le champ de coordonnées
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxCoord_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("(0|\\+33)[1-9]([-. ]?[0-9]{2}){4}$");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Fonction pour n'autoriser que certains caractères dans le champ de nombre de postes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNbPostes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Fonction pour n'autoriser que certains caractères dans le champ de durée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxDureeDiff_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        #endregion

        /// <summary>
        /// Définit le comportement lors d'un clic sur le bouton d'ajout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddOffre_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelAddOffer)this.DataContext).AddOffre(
                TextBoxIntitule.Text,
                datePickerDateDebut.Text,
                TextBoxNbPostes.Text,
                TextBoxDescripProfil.Text,
                TextBoxDescripPoste.Text,
                TextBoxCoord.Text,
                TextBoxDureeDiff.Text);
        }
    }
}
