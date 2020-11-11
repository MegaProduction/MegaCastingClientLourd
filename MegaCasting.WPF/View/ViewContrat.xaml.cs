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
    /// Logique d'interaction pour ViewAddContrat.xaml
    /// </summary>
    public partial class ViewAddContrat : UserControl
    {
        /// <summary>
        /// Initialise la ViewAddContrat
        /// </summary>
        public ViewAddContrat()
        {
            InitializeComponent();
        }

        private void TextBoxNameContrat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameContrat.Text.Trim().Equals(string.Empty))
            {
                TextBoxNameContrat.Text = "Nom du type de contrat";
                TextBoxNameContrat.GotFocus += TextBoxNameContrat_GotFocus;
            }
        }

        private void TextBoxNameContrat_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNameContrat.Text = string.Empty;
            TextBoxNameContrat.GotFocus -= TextBoxNameContrat_GotFocus;
        }
        /// <summary>
        /// Ajoute le nom du contrat lorsque qu'on clique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddContrat_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelContrat)this.DataContext).AddContrat(TextBoxNameContrat.Text);
            
        }

        private void DeleteContrat_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelContrat)this.DataContext).DeleteContrat();
        }

        private void ButtonEditContrat_Click(object sender, RoutedEventArgs e)
        {
            ListBoxSuppressioncontrat.Items.Refresh();
            ((ViewModelContrat)this.DataContext).UpdateContrat();
        }
    }
}
