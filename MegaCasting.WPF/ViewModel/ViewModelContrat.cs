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
    class ViewModelContrat : ViewModelBase
    {
        #region Attributes
        /// <summary>
        /// Collection de contrat
        /// </summary>
        private ObservableCollection<Contrat> _Contrat;
        /// <summary>
        /// COntrat Sélectionné
        /// </summary>
        private Contrat _SelectedContrat;
        /// <summary>
        /// Collection d'offre
        /// </summary>
        private ObservableCollection<Offre> _Offres;
        /// <summary>
        /// Collection d'erreurs
        /// </summary>
        private ObservableCollection<Erreur> _Erreurs;

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
        /// <summary>
        /// Obtient ou définit la collection d'offre
        /// </summary>
        public ObservableCollection<Offre> Offres
        {
            get { return _Offres; }
            set { _Offres = value; }
        }
        /// <summary>
        /// Obtient ou définit la collection d'erreurs
        /// </summary>
        public ObservableCollection<Erreur> Erreurs
        {
            get { return _Erreurs; }
            set { _Erreurs = value; }
        }
        #endregion
        #region Construteur
        /// <summary>
        /// Constructeur des contrats
        /// </summary>
        /// <param name="entities"></param>
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
                   
                }
                catch (DbUpdateException)
                {
                    Contrats.Remove(contrat);
                    MessageBox.Show("Une erreur s\'est produite lors de la saisie");
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
            if (SelectedContrat != null)
            {
            try
            {
                //Vérification si on a le droit de supprimer
                if (!Offres.Any(offre => offre.IdentifiantContrat == SelectedContrat.Identifiant))
                {
                    this.Contrats.Remove(SelectedContrat);
                    this.SaveChanges();
                    MessageBox.Show("Contrat supprimé");
                }
                else
                { 
                    MessageBox.Show("Ce contrat est utilisé dans une offre");
                }       
            }
            catch (DbUpdateException due)
            {
                MessageBox.Show(due.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
            }
            catch (DbEntityValidationException deve)
            {
                foreach (DbEntityValidationResult error in deve.EntityValidationErrors)
                {
                    foreach (DbValidationError item in error.ValidationErrors)
                    {
                        MessageBox.Show(item.PropertyName + " : " + item.ErrorMessage);
                    }
                }
            }
            }
            else
            {
                MessageBox.Show("Aucun contrat sélectionné");
            }
        }
        /// <summary>
        /// Fonction d'édition des contrats
        /// </summary>
        public void UpdateContrat()
        {
            try
            {
                this.SaveChanges();
                MessageBox.Show("Nom du contrat édité");
            }
            catch (DbUpdateException)
            {
                //Permet de reload la liste des contracts
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                MessageBox.Show("Impossible d'éditer le nom du contrat sélectionné");
            }
            catch (DbEntityValidationException deve)
            {
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                foreach (DbEntityValidationResult error in deve.EntityValidationErrors)
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
