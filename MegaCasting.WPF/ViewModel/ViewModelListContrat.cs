using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.DBlib;


namespace MegaCasting.WPF.ViewModel
{
    class ViewModelListContrat : ViewModelBase
    {
        
        #region Attributes
        /// <summary>
        /// Collection de contrat
        /// </summary>
        private ObservableCollection<Contrat> _Contrat;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection de contrat
        /// </summary>
        public ObservableCollection<Contrat> Contrats
        {
            get { return _Contrat; }
            set { _Contrat = value; }
        }
        #endregion
        #region Construtor
        /// <summary>
        /// Constructeur de la liste de contrats
        /// </summary>
        /// <param name="entities"></param>
        public ViewModelListContrat(MegaCastingEntities entities) : base(entities) 
        {
            this.Entities.Contrats.ToList();
            this.Contrats = this.Entities.Contrats.Local;
        }
        #endregion
    }
}
