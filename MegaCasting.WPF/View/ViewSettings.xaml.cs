using MaterialDesignColors.ColorManipulation;
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
    /// Logique d'interaction pour ViewSettings.xaml
    /// </summary>
    public partial class ViewSettings : UserControl
    {
        public ViewSettings()
        {
            InitializeComponent();
        }

        private void colorPicker_MouseMove(object sender, MouseEventArgs e)
        {
            Color color = colorPicker.Color;
            textBlock.Background = new SolidColorBrush(color);
            MainWindow mw = (MainWindow)Application.Current.MainWindow;
            mw.Background = new SolidColorBrush(color);
        }
    }
}
