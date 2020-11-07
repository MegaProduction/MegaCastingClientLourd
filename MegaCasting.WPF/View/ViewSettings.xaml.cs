using MaterialDesignColors.ColorManipulation;
using MegaCasting.WPF.Model;
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
            Data json = new Data("Custom", color.ToString());
            Data jsonDefault = new Data("Default", "AAAAAA");
            MainWindow mw = (MainWindow)Application.Current.MainWindow;
            mw.Background = new SolidColorBrush(color);
            List<Data> jsons = new List<Data>();
            jsons.Add(json);
            jsons.Add(jsonDefault);
            json.JsonFile(jsons);
            textBlock.Text = json.OpenFile();
        }
    }
}
