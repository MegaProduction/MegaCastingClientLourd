using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelEditOffer : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Collection d'offre 
        /// </summary>
        private ObservableCollection<Offre> _Offres;
        /// <summary>
        /// Collection des villes
        /// </summary>
        private ObservableCollection<Ville> _Villes;
        /// <summary>
        /// Offre sélectionnée
        /// </summary>
        private Offre _SelectedOffre;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection d'offre
        /// </summary>
        public ObservableCollection<Offre> Offres
        {
            get { return _Offres; }
            set { _Offres = value; }
        }
        /// <summary>
        /// Obtient ou définit la collection des villes
        /// </summary>
        public ObservableCollection<Ville> Villes
        {
            get { return _Villes; }
            set { _Villes = value; }
        }
        /// <summary>
        /// Obtient ou définit l'offre sélectionnée
        /// </summary>
        public Offre SelectedOffre
        {
            get { return _SelectedOffre; }
            set { _SelectedOffre = value; }
        }

        #endregion
        #region Construteur
        public ViewModelEditOffer(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Offres.ToList();
            this.Offres = this.Entities.Offres.Local;
            this.Entities.Villes.ToList();
            this.Villes = this.Entities.Villes.Local;
        }
        #endregion
        #region MyRegion
        public void EditOffer()
        {
            Offre offre = new Offre();
        }
        #endregion

    }
}
