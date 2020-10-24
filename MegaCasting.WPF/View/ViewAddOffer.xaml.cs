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
            //Permet de savoir le parse en int est réussit
            bool result = Int32.TryParse(comboBoxLocalisation.SelectedValue.ToString(), out int idVille);
            //Ajouts l'offre que result est vrai sinon envoit un message
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
