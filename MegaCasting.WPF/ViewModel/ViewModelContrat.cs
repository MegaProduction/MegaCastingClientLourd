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
        private ObservableCollection<Offre> _Offres;

        public ObservableCollection<Offre> Offres
        {
            get { return _Offres; }
            set { _Offres = value; }
        }

        #region Attributes
        /// <summary>
        /// Collection de contrat
        /// </summary>
        private ObservableCollection<Contrat> _Contrat;
        /// <summary>
        /// COntrat Sélectionné
        /// </summary>
        private Contrat _SelectedContrat;
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
        /// <summary>
        /// Obtient ou définit le contrat sélectionné
        /// </summary>
        public Contrat SelectedContrat
        {
            get { return _SelectedContrat; }
            set { _SelectedContrat = value; }
        }
        #endregion
        #region Construteur
        public ViewModelContrat(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Contrats.ToList();
            this.Contrats = this.Entities.Contrats.Local;
            this.Entities.Offres.ToList();
            this.Offres = this.Entities.Offres.Local;
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
        /// Permet de rollback 
        /// </summary>
        private void RollBack()
        {
            this.Entities.Database.BeginTransaction().Rollback();
        }
        private void Commit()
        {
            this.Entities.Database.BeginTransaction().Commit();
        }
        /// <summary>
        /// Ajoute un contrat
        /// </summary>
        /// <param name="name">Nom du contrat à ajouter</param>
        public void AddContrat(string name)
        {
            if (!this.Entities.Contrats.Any(contrat => contrat.Libelle == name))
            {
                Contrat contrat = new Contrat();
                contrat.Libelle = name;
                try
                {
                    Contrats.Add(contrat);
                    this.SaveChanges();
                    MessageBox.Show("Contrat ajouté");
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException)
                {
                    Contrats.Remove(contrat);
                    MessageBox.Show("Une erreur c\'est produite lors de la saisie");
                }
            }
            else
            {
                MessageBox.Show("Ce contrat existe déjà");
            }
        }
        /// <summary>
        /// Supprime le contrat sélectionné
        /// </summary>
        public void DeleteContrat()
        {
            //Vérification si on a le droit de supprimer
            if (!Offres.Any(offre => offre.IdentifiantContrat == SelectedContrat.Identifiant))
            {
                this.Contrats.Remove(SelectedContrat);
                this.SaveChanges();
                MessageBox.Show("Contrat supprimée");
            }
            else
            { 
                MessageBox.Show("Ce contrat est utilisé dans une offre");
            }       
        }
        public void UpdateContrat()
        {
            try
            {
                this.SaveChanges();
                this.Commit();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                this.RollBack();
            }
        }
        #endregion
    }
}
