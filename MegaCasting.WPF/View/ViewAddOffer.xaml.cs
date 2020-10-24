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
    /// Logique d'interaction pour ViewAddOffer.xaml
    /// </summary>
    public partial class ViewAddOffer : UserControl
    {
        public ViewAddOffer()
        {
            InitializeComponent();
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
        /// <summary>
        /// Défini le comportement lors du clique sur le bouton d'ajout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddOffre_Click(object sender, RoutedEventArgs e)
        {
            //intitule de l'offre
            string intitule = TextBoxIntitule.Text.ToString();
            bool ville = false;
            bool contrat = false;
            bool client = false;
            if (comboBoxLocalisation.SelectedIndex != -1 && comboBoxClient.SelectedIndex != -1 && comboBoxContrat.SelectedIndex != -1)
            {
                //Permet de savoir le parse en int est réussit
                ville = Int32.TryParse(comboBoxLocalisation.SelectedValue.ToString(), out int idVille);
                contrat = Int32.TryParse(comboBoxLocalisation.SelectedValue.ToString(), out int idContrat);
                client = Int32.TryParse(comboBoxLocalisation.SelectedValue.ToString(), out int idClient);
            }
            //Ajouts l'offre que result est vrai sinon envoit un message
            if (((ViewModelAddOffer)this.DataContext).VerifOffre(intitule, ville, contrat, client))
            {
                MessageBox.Show("L'offre a été ajouté");
            }
            else
            {
                MessageBox.Show("Impossible d'insérer l'offre des champs sont invalide");
            }
        }
    }
}
