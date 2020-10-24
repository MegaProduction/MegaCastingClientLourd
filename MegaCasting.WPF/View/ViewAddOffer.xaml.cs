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
        /// <summary>
        /// Défini le comportement lors du clique sur le bouton d'ajout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddOffre_Click(object sender, RoutedEventArgs e)
        {
            //intitule de l'offre
            string intitule = textBoxIntitule.Text.ToString();
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
