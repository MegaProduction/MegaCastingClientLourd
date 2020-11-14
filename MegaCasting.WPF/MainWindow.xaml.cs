using MegaCasting.DBlib;
using MegaCasting.WPF.Model;
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
            //chargement plus rapide pour cet élément
            //this.Entities.Villes.FirstOrDefault();

#if DEBUG
            this.Entities.Villes.FirstOrDefault();
#endif
#if RELEASE

#endif
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
            ViewModelEditOffer viewModelEditOffer = new ViewModelEditOffer(Entities);
            ViewEditOffer viewEditOffer = new ViewEditOffer();
            this.DataContext = viewModelEditOffer;
            this.DockPanelView.Children.Add(viewEditOffer);
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
            ViewModelAddPartner viewModelAddPartner = new ViewModelAddPartner(Entities);
            ViewAddPartner viewAddPartner = new ViewAddPartner();
            this.DataContext = viewModelAddPartner;
            this.DockPanelView.Children.Add(viewAddPartner);
        }

        private void EditPartner_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelEditPartner viewModelEditPartner = new ViewModelEditPartner(Entities);
            ViewEditPartner viewEditPartner = new ViewEditPartner();
            this.DataContext = viewModelEditPartner;
            this.DockPanelView.Children.Add(viewEditPartner);
        }

        private void DelPartner_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelDelPartner viewModelDelPartner = new ViewModelDelPartner(Entities);
            ViewDelPartner viewDelPartner = new ViewDelPartner();
            this.DataContext = viewModelDelPartner;
            this.DockPanelView.Children.Add(viewDelPartner);
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

        private void ContratList_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelListContrat viewModelListContrat = new ViewModelListContrat(Entities);
            ViewListContrat viewListContrat = new ViewListContrat();
            this.DataContext = viewModelListContrat;
            this.DockPanelView.Children.Add(viewListContrat);
        }

        private void Contrat_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelContrat viewModelContrat = new ViewModelContrat(Entities);
            ViewAddContrat viewAddContrat = new ViewAddContrat();
            this.DataContext = viewModelContrat;
            this.DockPanelView.Children.Add(viewAddContrat);
        }
        private void LocalizationList_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelListLocalization viewModelListLocalization = new ViewModelListLocalization(Entities);
            ViewListLocalization viewListLocalization = new ViewListLocalization();
            this.DataContext = viewModelListLocalization;
            this.DockPanelView.Children.Add(viewListLocalization);
        }

        private void LocalizationAdd_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelAddLocalization viewModelAddCountry = new ViewModelAddLocalization(Entities);
            ViewAddLocalization viewAddLocalization = new ViewAddLocalization();
            this.DataContext = viewModelAddCountry;
            this.DockPanelView.Children.Add(viewAddLocalization);
        }

        private void LocalizationEdit_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            this.DockPanelView.Children.Add(new ViewAddLocalization());
        }

        private void LocalizationDelete_Click(object sender, RoutedEventArgs e)
        {
            this.DockPanelView.Children.Clear();
            ViewModelDelLocalization viewModelDelLocalization = new ViewModelDelLocalization(Entities);
            ViewDelLocalization viewDelLocalization = new ViewDelLocalization();
            this.DataContext = viewModelDelLocalization;
            this.DockPanelView.Children.Add(viewDelLocalization);
        }
    }
}
