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
using System.Windows.Data;

namespace MegaCasting.WPF.View
{
    /// <summary>
    /// Logique d'interaction pour ViewAddDomaine.xaml
    /// </summary>
    public partial class ViewAddDomaine : UserControl
    {
        /// <summary>
        /// Initialise la ViewAddDomaine
        /// </summary>
        public ViewAddDomaine()
        {
            InitializeComponent();
        }

        private void TextBoxNameDomaine_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameDomaine.Text.Trim().Equals(string.Empty))
            {
                TextBoxNameDomaine.Text = "Nom du type de Domaine";
                TextBoxNameDomaine.GotFocus += TextBoxNameDomaine_GotFocus;
            }
        }

        private void TextBoxNameDomaine_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNameDomaine.Text = string.Empty;
            TextBoxNameDomaine.GotFocus -= TextBoxNameDomaine_GotFocus;
        }
        /// <summary>
        /// Ajoute le nom du Domaine lorsque qu'on clique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddDomaine_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelDomaine)this.DataContext).AddDomaine(TextBoxNameDomaine.Text);

        }

        private void DeleteDomaine_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelDomaine)this.DataContext).DeleteDomaine();
        }

        private void ButtonEditDomaine_Click(object sender, RoutedEventArgs e)
        {
            ListBoxSuppressionDomaine.Items.Refresh();
            ((ViewModelDomaine)this.DataContext).UpdateDomaine();
            TextBoxEditDomaine.Clear();
        }
    }
}
