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


        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox.GotFocus -= PasswordBox_GotFocus;
            TextBoxPassword.Text = string.Empty;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Trim().Equals(string.Empty))
            {
                TextBoxPassword.Text = "Mot de passe";
            }
        }

        private void PasswordBoxVerify_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox.GotFocus -= PasswordBox_GotFocus;
            TextBoxVerifyPassword.Text = string.Empty;
        }

        private void PasswordBoxVerify_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxVerify.Password.Trim().Equals(string.Empty))
            {
                TextBoxVerifyPassword.Text = "Confirmez le mot de passe";
            }
        }

        private void ButtonAddPartner_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
                ((ViewModelAddPartner)this.DataContext).AddPartner(TextBoxNom.Text, TextBoxPas.Text, TextBoxLibelle.Text);
                TextBoxNom_GotFocus(sender, e);
                TextBoxPas_GotFocus(sender, e);
                TextBoxLibelle_GotFocus(sender, e);
                TextBoxNom_LostFocus(sender, e);
                TextBoxPas_LostFocus(sender, e);
                TextBoxLibelle_LostFocus(sender, e);
                comboBoxVille.Text = "Ville";
=======
            if (PasswordBox.Password != PasswordBoxVerify.Password)
            {
                PasswordBoxVerify.Style = (Style)Application.Current.Resources["PasswordStyle"];
                MessageBox.Show("Les mots de passe ne sont pas identiques.");
            }
            if (string.IsNullOrWhiteSpace(PasswordBox.Password) || string.IsNullOrWhiteSpace(PasswordBoxVerify.Password))
            {
                MessageBox.Show("Il n'y a pas de mot de passe");
            }
            else
            {
                PasswordBoxVerify.Style = (Style)Application.Current.Resources["MaterialDesignPasswordBox"];
                if (PasswordBox.Password == PasswordBoxVerify.Password && !string.IsNullOrWhiteSpace(PasswordBox.Password) && 
                    !string.IsNullOrWhiteSpace(PasswordBoxVerify.Password) && ((ViewModelAddPartner)this.DataContext).AddPartner(TextBoxNom.Text, PasswordBox.Password, TextBoxLibelle.Text))
                {
                    TextBoxNom_GotFocus(sender, e);
                    TextBoxLibelle_GotFocus(sender, e);
                    TextBoxNom_LostFocus(sender, e);
                    TextBoxLibelle_LostFocus(sender, e);
                    PasswordBox_GotFocus(sender, e);
                    PasswordBox_LostFocus(sender, e);
                    comboBoxVille.Text = "Ville";
                    PasswordBox.Clear();
                    PasswordBoxVerify.Clear();
                    TextBoxVerifyPassword.Text = "Confirmez le mot de passe";
                    TextBoxPassword.Text = "Mot de passe";
                }
            }
>>>>>>> dev

        }

    }
}