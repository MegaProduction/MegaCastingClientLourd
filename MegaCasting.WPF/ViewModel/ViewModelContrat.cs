using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelContrat : ViewModelBase
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
        #region Construteur
        public ViewModelContrat(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Contrats.ToList();
            this.Contrats = this.Entities.Contrats.Local;
        }
        #endregion
        #region Method
        /// <summary>
        /// Sauvegarde les changements
        /// </summary>
        public void SaveChanges()
        {
            this.Entities.SaveChanges();
        }
        /// <summary>
        /// Ajoute un contrat
        /// </summary>
        /// <param name="name">Nom du contrat à ajouter</param>
        public void AddContrat(string name)
        {
            if (!this.Entities.Contrats.Any(contrat => contrat.Libelle == name))
            {
                if (VerifyContrat(name))
                {
                    Contrat contrat = new Contrat();
                    contrat.Libelle = name;
                    Contrats.Add(contrat);
                    this.SaveChanges();
                    MessageBox.Show("Contrat ajouté");
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue lors de la saisie");
                }
            }
            else
            {
                MessageBox.Show("Ce contrat existe déjà");
            }
        }
        public bool VerifyContrat(string name)
        {
            bool result = false;
            if (string.IsNullOrWhiteSpace(name))
            {
                result = true;
            }
            return result;
        }
        #endregion
    }
}
