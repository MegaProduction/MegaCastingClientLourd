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
            //Identifiant de la ville
            int identifiantVille = comboBoxLocalisation.SelectedIndex;
            //identifiant du type de contrat pour l'offre
            int identifiantContat = comboBoxContrat.SelectedIndex;

            ((ViewModelAddOffer)this.DataContext).AddOffre(intitule, identifiantVille, identifiantContat);
        }
    }
}
