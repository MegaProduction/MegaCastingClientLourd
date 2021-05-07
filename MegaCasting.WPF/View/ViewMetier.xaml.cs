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
    /// Logique d'interaction pour ViewAddMetier.xaml
    /// </summary>
    public partial class ViewMetier : UserControl
    {
        /// <summary>
        /// Initialise la ViewAddMetier
        /// </summary>
        public ViewMetier()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNameMetier_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNameMetier.Text.Trim().Equals(string.Empty))
            {
                TextBoxNameMetier.Text = "Nom du métier";
                TextBoxNameMetier.GotFocus += TextBoxNameMetier_GotFocus;
            }
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxNameMetier_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxNameMetier.Text = string.Empty;
            TextBoxNameMetier.GotFocus -= TextBoxNameMetier_GotFocus;
        }
        /// <summary>
        /// Ajoute le nom du Metier lorsque qu'on clique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddMetier_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelMetier)this.DataContext).AddMetier(TextBoxNameMetier.Text, TextBoxFicheMetier.Text);
            TextBoxNameMetier.Clear();
            TextBoxFicheMetier.Clear();
            comboBoxDomaine.Text = "Domaine";
        }
        /// <summary>
        /// Appelle la fonction de suppression du métier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteMetier_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelMetier)this.DataContext).DeleteMetier();
        }
        /// <summary>
        /// Appelle la fonction d'édition du métier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEditMetier_Click(object sender, RoutedEventArgs e)
        {
            ListBoxSuppressionMetier.Items.Refresh();
            ((ViewModelMetier)this.DataContext).UpdateMetier();
            TextBoxEditMetier.Clear();
            TextBoxEditFicheMetier.Clear();
            ComboBoxEditDomain.Text = "Domaine";
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on quitte la TextBox sans y avoir rien mis
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxFicheMetier_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxFicheMetier.Text.Trim().Equals(string.Empty))
            {
                TextBoxFicheMetier.Text = "Fiche du métier";
                TextBoxNameMetier.GotFocus += TextBoxFicheMetier_GotFocus;
            }
        }
        /// <summary>
        /// Fonction qui indique quoi mettre si on clique sur la TextBox (pour modifier la valeur par défaut)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxFicheMetier_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxFicheMetier.Text = string.Empty;
            TextBoxFicheMetier.GotFocus -= TextBoxFicheMetier_GotFocus;
        }
    }
}
