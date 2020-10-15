using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.ViewModel
{
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
