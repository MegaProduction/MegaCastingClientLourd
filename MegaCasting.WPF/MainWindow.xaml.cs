using MegaCasting.DBlib;
using MegaCasting.WPF.View;
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

namespace MegaCasting.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
        /// <summary>
        /// Contexte de l'application
        /// </summary>
        private MegaCastingEntities _Entities;
        /// <summary>
        /// Vue modèle de la fenêtre main
        /// </summary>
        private ViewModelMainWindow _ViewModel;

        

        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou défini le contexte de l'application
        /// </summary>
        public MegaCastingEntities Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }
        /// <summary>
        /// Obtient ou défini le vue modèle de la fenêtre main
        /// </summary>
        public ViewModelMainWindow ViewModel
        {
            get { return _ViewModel; }
            set { _ViewModel = value; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Construteur
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.Entities = new MegaCastingEntities();

           
        }
        #endregion
        /// <summary>
        /// Défini le dockPanel comme affichant le type de contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonManageContractType_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewContratType());
        }

        private void ButtonManageChoseType_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewChose());
        }

        private void ButtonManageTrucType_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
