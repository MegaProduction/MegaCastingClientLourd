using MegaCasting.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour ViewEditOffer.xaml
    /// </summary>
    public partial class ViewEditOffer : UserControl
    {
        public ViewEditOffer()
        {
            InitializeComponent();
        }

        private void ButtonEditOffer_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModelEditOffer)this.DataContext).EditOffer();
        }
        private void TexBoxEditNombrePostes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Permet de définir le pattern autoriser dans la texBox ici des chiffres/nombres
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TexBoxEditDureeDiffusion_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Permet de définir le pattern autoriser dans la texBox ici des chiffres/nombres
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DatePickerEditDateDebut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9/]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TexBoxEditCoordonnees_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
             Regex regex = new Regex("(0|\\+33|06)[1-9][0-9]{8}");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
