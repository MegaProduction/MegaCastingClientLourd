using MegaCasting.DBlib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MegaCasting.WPF.ViewModel
{
    class ViewModelEditLocalization : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Collection de pays
        /// </summary>
        private ObservableCollection<Pay> _Pays;
        /// <summary>
        /// Collection de villes
        /// </summary>
        private ObservableCollection<Ville> _Villes;
        /// <summary>
        /// Pays sélectionné
        /// </summary>
        private Pay _SelectedPays;
        /// <summary>
        /// Ville sélectionnée
        /// </summary>
        private Ville _SelectedVille;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit la collection de pays
        /// </summary>
        public ObservableCollection<Pay> Pays
        {
            get { return _Pays; }
            set { _Pays = value; }
        }
        /// <summary>
        /// Obtient ou définit la collection de villes
        /// </summary>
        public ObservableCollection<Ville> Villes
        {
            get { return _Villes; }
            set { _Villes = value; }
        }
        /// <summary>
        /// Obtient ou définit le pays sélectionné
        /// </summary>
        public Pay SelectedPays
        {
            get { return _SelectedPays; }
            set { _SelectedPays = value; }
        }
        /// <summary>
        /// Obtient ou définit la ville sélectionnée
        /// </summary>
        public Ville SelectedVille
        {
            get { return _SelectedVille; }
            set { _SelectedVille = value; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructeur de l'édition de la localisation
        /// </summary>
        /// <param name="entities"></param>
        public ViewModelEditLocalization(MegaCastingEntities entities)
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
        /// Fonction d'édition du la ville
        /// </summary>
        public void EditCity()
        {
            try
            {
                this.SaveChanges();
                MessageBox.Show("Ville éditée");
            }
            catch (DbUpdateException ex)
            {
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                MessageBox.Show(ex.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                foreach (DbEntityValidationResult error in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError item in error.ValidationErrors)
                    {
                        MessageBox.Show(item.PropertyName + " : " + item.ErrorMessage);
                    }
                }
            }
        }
        /// <summary>
        /// Fonction d'édition du pays
        /// </summary>
        public void EditCountry()
        {
            try
            {
                this.SaveChanges();
                MessageBox.Show("Pays édité");
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                MessageBox.Show(ex.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                foreach (DbEntityValidationResult error in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError item in error.ValidationErrors)
                    {
                        MessageBox.Show(item.PropertyName + " : " + item.ErrorMessage);
                    }
                }
            }
        }
        #endregion
    }
}
