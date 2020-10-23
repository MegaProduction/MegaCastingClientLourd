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
            Object value = comboBoxLocalisation.SelectedValue;
            bool result = int.TryParse(value.ToString(), out int idVille);
            
            //identifiant du type de contrat pour l'offre
            if (result)
            {
                ((ViewModelAddOffer)this.DataContext).AddOffre(intitule, idVille, 1);
            }
            else
            {
                MessageBox.Show("Une errreur c\'est produite");
            }


        }
    }
}
