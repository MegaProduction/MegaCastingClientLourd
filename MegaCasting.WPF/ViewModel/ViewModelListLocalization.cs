using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelListLocalization : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Collection de villes
        /// </summary>
        private ObservableCollection<Ville> _Villes;
        /// <summary>
        /// Collection de pays
        /// </summary>
        private ObservableCollection<Pay> _Pays;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit les villes
        /// </summary>
        public ObservableCollection<Ville> Villes
        {
            get { return _Villes; }
            set { _Villes = value; }
        }
        /// <summary>
        /// Obtient ou définit les pays
        /// </summary>
        public ObservableCollection<Pay> Pays
        {
            get { return _Pays; }
            set { _Pays = value; }
        }
        #endregion
        #region Constructors
        public ViewModelListLocalization(MegaCastingEntities entities)
            :base(entities)
        {
            this.Entities.Villes.ToList();
            this.Villes = Entities.Villes.Local;
            this.Entities.Pays.ToList();
            this.Pays = Entities.Pays.Local;
        }
        #endregion
        #region Methods

        #endregion
    }
}
