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
    class ViewModelDelLocalization : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Collection de villes
        /// </summary>
        private ObservableCollection<Ville> _Villes;
        /// <summary>
        /// Ville sélectionnée
        /// </summary>
        private Ville _SelectedVille;
        /// <summary>
        /// Collection de pays
        /// </summary>
        private ObservableCollection<Pay> _Pays;
        /// <summary>
        /// Pays sélectionné
        /// </summary>
        private Pay _SelectedPays;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection de villes
        /// </summary>
        public ObservableCollection<Ville> Villes
        {
            get { return _Villes; }
            set { _Villes = value; }
        }
        /// <summary>
        /// Obtient ou définit la ville sélectionné
        /// </summary>
        public Ville SelectedVille
        {
            get { return _SelectedVille; }
            set { _SelectedVille = value; }
        }
        /// <summary>
        /// Obtient ou définit la collection de pays
        /// </summary>
        public ObservableCollection<Pay> Pays
        {
            get { return _Pays; }
            set { _Pays = value; }
        }
        /// <summary>
        /// Obtient ou définit le pays sélectionné
        /// </summary>
        public Pay SelectedPays
        {
            get { return _SelectedPays; }
            set { _SelectedPays = value; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructeur de la suppression des localisations
        /// </summary>
        /// <param name="entities"></param>
        public ViewModelDelLocalization(MegaCastingEntities entities)
            :base(entities)
        {
            this.Entities.Pays.ToList();
            this.Pays = this.Entities.Pays.Local;
            this.Entities.Villes.ToList();
            this.Villes = this.Entities.Villes.Local;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Sauvegarde les modifications 
        /// </summary>
        public void SaveChanges()
        {
            this.Entities.SaveChanges();
        }
        /// <summary>
        /// Supprime une ville
        /// </summary>
        public void DelCity()
        {
            this.Villes.Remove(SelectedVille);
            this.SaveChanges();
            MessageBox.Show("Ville supprimée");
        }
        /// <summary>
        /// Supprime un pays
        /// </summary>
        public void DelCountry()
        {
            if (SelectedPays is null)
            {
                MessageBox.Show("Aucun pays sélectionné");
            }
            else
            {
                if (!Villes.Any(pays => pays.IdentifiantPays == SelectedPays.Identifiant))
                {
                this.Pays.Remove(SelectedPays);
                this.SaveChanges();
                MessageBox.Show("Pays supprimé");
                }
                else
                {
                    MessageBox.Show("Impossible de supprimer ce pays : des villes y sont présentes");
                }
            }
        }
        #endregion
    }
}
