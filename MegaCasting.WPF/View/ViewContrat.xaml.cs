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
        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNameContrat_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameContrat.Text.Trim().Equals(string.Empty))
            {
                TextBoxNameContrat.Text = "Nom du type de contrat";
                TextBoxNameContrat.GotFocus += TextBoxNameContrat_GotFocus;
            }
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Appelle la fonction de suppression du contrat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteContrat_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelContrat)this.DataContext).DeleteContrat();
        }
        /// <summary>
        /// Appelle la fonction d'édition du contrat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditContrat_Click(object sender, RoutedEventArgs e)
        {
            ListBoxSuppressioncontrat.Items.Refresh();
            ((ViewModelContrat)this.DataContext).UpdateContrat();
            TextBoxEditContrat.Clear();
        }
    }
}
