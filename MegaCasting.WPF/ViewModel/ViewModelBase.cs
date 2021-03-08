using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    /// <summary>
    /// Class ViewModelBase viewModel de base pour le contexte de l'application
    /// </summary>
    public class ViewModelBase
    {
        #region Attributes

        /// <summary>
        /// Contexte de l'application
        /// </summary>
        private MegaCastingEntities _Entities;

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

        #endregion

        #region Contructeur
        /// <summary>
        /// Constructeur de base 
        /// </summary>
        /// <param name="entities">Contexte de l'application</param>
        public ViewModelBase(MegaCastingEntities entities)
        {
            this.Entities = entities;
        }
        #endregion

    }
}
