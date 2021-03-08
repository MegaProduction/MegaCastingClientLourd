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
    /// Logique d'interaction pour ViewAddPartner.xaml
    /// </summary>
    public partial class ViewAddPartner : UserControl
    {
        /// <summary>
        /// Initialise la viewAddPartner
        /// </summary>
        public ViewAddPartner()
        {
            InitializeComponent();
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
                TextBoxNom.Text = "Login";
                TextBoxNom.GotFocus += TextBoxNom_GotFocus;
            }
        }

        //private void TextBoxPas_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    PasswordBox.Password = string.Empty;
        //    PasswordBox.GotFocus -= TextBoxPas_GotFocus;
        //}

        //private void TextBoxPas_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    if (PasswordBox.Password.Trim().Equals(string.Empty))
        //    {
        //        PasswordBox.Password = "Mot de passe";
        //        PasswordBox.GotFocus += TextBoxPas_GotFocus;
        //    }
        //}

        private void PasswordBoxVerify_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password != PasswordBoxVerify.Password)
            {
                PasswordBoxVerify.Style = (Style)Application.Current.Resources["PasswordStyle"];
            }
            else
            {
                PasswordBoxVerify.Style = (Style)Application.Current.Resources["MaterialDesignPasswordBox"];
            }
        }

        private void TextBoxLibelle_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxLibelle.Text = string.Empty;
            TextBoxLibelle.GotFocus -= TextBoxLibelle_GotFocus;
        }

        private void TextBoxLibelle_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLibelle.Text.Trim().Equals(string.Empty))
            {
                TextBoxLibelle.Text = "Libellé";
                TextBoxLibelle.GotFocus += TextBoxLibelle_GotFocus;
            }
        }

        private void ButtonAddPartner_Click(object sender, RoutedEventArgs e)
        {
                ((ViewModelAddPartner)this.DataContext).AddPartner(TextBoxNom.Text, /*TextBoxPas.Text*/PasswordBox.Password, TextBoxLibelle.Text);
                TextBoxNom_GotFocus(sender, e);
                //TextBoxPas_GotFocus(sender, e);
                TextBoxLibelle_GotFocus(sender, e);
                TextBoxNom_LostFocus(sender, e);
                //TextBoxPas_LostFocus(sender, e);
                TextBoxLibelle_LostFocus(sender, e);
                comboBoxVille.Text = "Ville";

        }
    }
}