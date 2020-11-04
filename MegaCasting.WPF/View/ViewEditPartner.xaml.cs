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
    /// Logique d'interaction pour ViewEditPartner.xaml
    /// </summary>
    public partial class ViewEditPartner : UserControl
    {
        public ViewEditPartner()
        {
            InitializeComponent();
        }

        private void ButtonEditPartner_Click(object sender, RoutedEventArgs e)
        {
                ((ViewModelEditPartner)this.DataContext).EditPartner(TextBoxLibelle.Text);
        }
    }
}
