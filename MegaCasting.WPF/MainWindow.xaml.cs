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
        /// Vue modèle de la fenêtre principale
        /// </summary>
        private ViewModelMainWindow _ViewModel;


        #endregion


        #region Properties

        /// <summary>
        /// Obtient ou définit le contexte de l'application
        /// </summary>
        public MegaCastingEntities Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }


        /// <summary>
        /// Obtient ou définit la vue modèle de la fenêtre principale
        /// </summary>
        public ViewModelMainWindow ViewModel
        {
            get { return _ViewModel; }
            set { _ViewModel = value; }
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Constructeurs
        /// </summary>


        public MainWindow()
        {
            InitializeComponent();

            this.Entities = new MegaCastingEntities();
        }

        #endregion

        /// <summary>
        /// Définit le dockPanel comme affichant les différentes Views
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewMain());
        }

        private void AddOffer_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelAddOffer viewModelAddOffer = new ViewModelAddOffer(Entities);
            ViewAddOffer viewAddOffer = new ViewAddOffer();
            this.DataContext = viewModelAddOffer;
            this.DockPanelView.Children.Add(viewAddOffer);
        }

        private void EditOffer_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewEditOffer());
        }

        private void DelOffer_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelDelOffre viewModelDelOffre = new ViewModelDelOffre(Entities);
            ViewDelOffer viewDelOffer = new ViewDelOffer();
            this.DataContext = viewModelDelOffre;
            this.DockPanelView.Children.Add(viewDelOffer);
        }

        private void AddPartner_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewAddPartner());
        }

        private void EditPartner_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewEditPartner());
        }

        private void DelPartner_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewDelPartner());
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewSettings());
        }

        private void AccountCustomization_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewAccountCustomization());
        }

        private void AccountManagement_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewAccountManagement());
        }

        private void HistoriqueOffer_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelHistoriqueOffer viewModelHistoriqueOffer = new ViewModelHistoriqueOffer(Entities);
            ViewHistoriqueOffer viewHistoriqueOffer = new ViewHistoriqueOffer();
            this.DataContext = viewModelHistoriqueOffer;
            this.DockPanelView.Children.Add(viewHistoriqueOffer);
        }

        private void ClientsList_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelClientsList viewModelClientsList = new ViewModelClientsList(Entities);
            ViewPartnersList viewPartnersList = new ViewPartnersList();

            this.DataContext = viewModelClientsList;

            this.DockPanelView.Children.Add(viewPartnersList);
        }
    }
}
