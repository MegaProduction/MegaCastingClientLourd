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
    class ViewModelDomaine : ViewModelBase
    {

        #region Attributes
        /// <summary>
        /// Collection de Domaine
        /// </summary>
        private ObservableCollection<Domaine> _Domaine;
        /// <summary>
        /// Domaine Sélectionné
        /// </summary>
        private Domaine _SelectedDomaine;
        /// <summary>
        /// Collection de Metier
        /// </summary>
        private ObservableCollection<Metier> _Metiers;
        /// <summary>
        /// Collection d'erreurs
        /// </summary>
        private ObservableCollection<Erreur> _Erreurs;

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
        /// <summary>
        /// Obtient ou définit le Domaine sélectionné
        /// </summary>
        public Domaine SelectedDomaine
        {
            get { return _SelectedDomaine; }
            set { _SelectedDomaine = value; }
        }
        /// <summary>
        /// Obtient ou définit la collection de Metier
        /// </summary>
        public ObservableCollection<Metier> Metiers
        {
            get { return _Metiers; }
            set { _Metiers = value; }
        }
        /// <summary>
        /// Obtient ou définit les erreurs
        /// </summary>
        public ObservableCollection<Erreur> Erreurs
        {
            get { return _Erreurs; }
            set { _Erreurs = value; }
        }
        #endregion
        #region Construteur
        /// <summary>
        /// Constructeur du domaine
        /// </summary>
        /// <param name="entities"></param>
        public ViewModelDomaine(MegaCastingEntities entities) : base(entities)
        {
            this.Entities.Domaines.ToList();
            this.Domaines = this.Entities.Domaines.Local;
            this.Entities.Metiers.ToList();
            this.Metiers = this.Entities.Metiers.Local;
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
        /// Ajoute un Domaine
        /// </summary>
        /// <param name="name">Nom du Domaine à ajouter</param>
        public void AddDomaine(string name)
        {
                Domaine Domaine = new Domaine();
                Domaine.Libelle = name;
                try
                {
                    Domaines.Add(Domaine);
                    this.SaveChanges();
                    MessageBox.Show("Domaine ajouté");

                }
                catch (DbUpdateException dbue)
                {
                    MessageBox.Show(dbue.InnerException.InnerException.Message.Replace(Environment.NewLine + "La transaction s'est terminée dans le déclencheur. Le traitement a été abandonné.", ""));
                    Domaines.Remove(Domaine);
                }
        }
        /// <summary>
        /// Supprime le Domaine sélectionné
        /// </summary>
        public void DeleteDomaine()
        {
            if (SelectedDomaine != null)
            {
                try
                {
                    //Vérification si on a le droit de supprimer
                    if (!Metiers.Any(Metier => Metier.IdentifiantDomaine == SelectedDomaine.Identifiant))
                    {
                        this.Domaines.Remove(SelectedDomaine);
                        this.SaveChanges();
                        MessageBox.Show("Domaine supprimé");
                    }
                    else
                    {
                        MessageBox.Show("Ce domaine est utilisé dans un métier");
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
                MessageBox.Show("Aucun domaine sélectionné");
            }
        }
        /// <summary>
        /// Fonction d'édition du domaine
        /// </summary>
        public void UpdateDomaine()
        {
            try
            {
                this.SaveChanges();
                MessageBox.Show("Nom du domaine édité");
            }
            catch (DbUpdateException)
            {
                //Permet de reload la liste des contracts
                Entities.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified).ToList().ForEach(e => e.Reload());
                MessageBox.Show("Impossible d'éditer le nom du domaine sélectionné");
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
