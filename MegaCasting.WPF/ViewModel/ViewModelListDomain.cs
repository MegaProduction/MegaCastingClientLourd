using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.DBlib;


namespace MegaCasting.WPF.ViewModel
{
    class ViewModelListDomaine : ViewModelBase
    {

        #region Attributes
        /// <summary>
        /// Collection de Domaine
        /// </summary>
        private ObservableCollection<Domaine> _Domaine;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection de Domaine
        /// </summary>
        public ObservableCollection<Domaine> Domaines
        {
            get { return _Domaine; }
            set { _Domaine = value; }
        }
        #endregion
        #region Construtor
        /// <summary>
        /// Constructeur de la liste de domaines
        /// </summary>
        /// <param name="entities"></param>
        public ViewModelListDomaine(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Domaines.ToList();
            this.Domaines = this.Entities.Domaines.Local;
        }
        #endregion
    }
}
