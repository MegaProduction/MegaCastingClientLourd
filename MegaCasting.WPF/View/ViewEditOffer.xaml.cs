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

        private void TextBoxIntitule_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxIntitule.Text = string.Empty;
            TextBoxIntitule.GotFocus -= TextBoxIntitule_GotFocus;
        }

        private void TextBoxIntitule_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxIntitule.Text.Trim().Equals(string.Empty))
            {
                TextBoxIntitule.Text = "Intitulé";
                TextBoxIntitule.GotFocus += TextBoxIntitule_GotFocus;
            }
        }

        private void TextBoxNbPostes_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNbPostes.Text = string.Empty;
            TextBoxNbPostes.GotFocus -= TextBoxNbPostes_GotFocus;
        }

        private void TextBoxNbPostes_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNbPostes.Text.Trim().Equals(string.Empty))
            {
                TextBoxNbPostes.Text = "Nombre de postes";
                TextBoxNbPostes.GotFocus += TextBoxNbPostes_GotFocus;
            }
        }

        private void TextBoxDescripPoste_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDescripPoste.Text = string.Empty;
            TextBoxDescripPoste.GotFocus -= TextBoxDescripPoste_GotFocus;
        }

        private void TextBoxDescripPoste_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxDescripPoste.Text.Trim().Equals(string.Empty))
            {
                TextBoxDescripPoste.Text = "Description du poste";
                TextBoxDescripPoste.GotFocus += TextBoxDescripPoste_GotFocus;
            }
        }

        private void TextBoxDescripProfil_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDescripProfil.Text = string.Empty;
            TextBoxDescripProfil.GotFocus -= TextBoxDescripProfil_GotFocus;
        }

        private void TextBoxDescripProfil_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxDescripProfil.Text.Trim().Equals(string.Empty))
            {
                TextBoxDescripProfil.Text = "Description du profil";
                TextBoxDescripProfil.GotFocus += TextBoxDescripProfil_GotFocus;
            }
        }

        private void TextBoxDureeDiff_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxDureeDiff.Text = string.Empty;
            TextBoxDureeDiff.GotFocus -= TextBoxDureeDiff_GotFocus;
        }

        private void TextBoxDureeDiff_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxDureeDiff.Text.Trim().Equals(string.Empty))
            {
                TextBoxDureeDiff.Text = "Durée de diffusion";
                TextBoxDureeDiff.GotFocus += TextBoxDureeDiff_GotFocus;
            }
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

        private void TextBoxCoord_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxCoord.Text = string.Empty;
            TextBoxCoord.GotFocus -= TextBoxCoord_GotFocus;
        }

        private void TextBoxCoord_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxCoord.Text.Trim().Equals(string.Empty))
            {
                TextBoxCoord.Text = "Coordonnées";
                TextBoxCoord.GotFocus += TextBoxCoord_GotFocus;
            }
        }

        private void TextBoxLoc_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxLoc.Text = string.Empty;
            TextBoxLoc.GotFocus -= TextBoxLoc_GotFocus;
        }

        private void TextBoxLoc_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLoc.Text.Trim().Equals(string.Empty))
            {
                TextBoxLoc.Text = "Localisation";
                TextBoxLoc.GotFocus += TextBoxLoc_GotFocus;
            }
        }
    }
}
