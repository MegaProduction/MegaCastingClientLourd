using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
    /// <summary>
    /// Class ViewModel de la mainWindow pour le contexte de l'application
    /// </summary>
    public class ViewModelMainWindow : ViewModelBase
    {
        #region Contructeur
        /// <summary>
        /// Constructeur du modèle-vue de la fenêtre main
        /// </summary>
        /// <param name="entities">Contexte de l'application</param>
        public ViewModelMainWindow(MegaCastingEntities entities)
            :base(entities)
        {
        }
        #endregion

    }
}
