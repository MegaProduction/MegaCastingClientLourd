using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.DBlib;


namespace MegaCasting.WPF.ViewModel
{
    class ViewModelListMetier : ViewModelBase
    {

        #region Attributes
        /// <summary>
        /// Collection de Metier
        /// </summary>
        private ObservableCollection<Metier> _Metier;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection de Metier
        /// </summary>
        public ObservableCollection<Metier> Metiers
        {
            get { return _Metier; }
            set { _Metier = value; }
        }
        #endregion
        #region Construtor
        public ViewModelListMetier(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Metiers.ToList();
            this.Metiers = this.Entities.Metiers.Local;
        }
        #endregion
        #region Method

        #endregion
    }
}
