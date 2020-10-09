using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.DBlib;

namespace MegaCastingsV2.APV1
{
    class Program
    {
        /// <summary>
        /// Categorie
        /// </summary>
        private static List<Category> _Categories = null;
        /// <summary>
        /// Beer
        /// </summary>
        private static List<Beer> _Beers = null;

        static void Main(string[] args)
        {
            #region Présentation LinQ
            #region datas generation
            #region Categories
            _Categories = new List<Category>();

            _Categories.Add(new Category("Brune"));
            _Categories.Add(new Category("Blonde"));
            _Categories.Add(new Category("Ambree"));
            #endregion
            #region Beers
            _Beers = new List<Beer>();
            Category blondCategory = _Categories.First(category => category.Name == "Blonde");
            _Beers.Add(new Beer("Leffe", 5, blondCategory));
            _Beers.Add(new Beer("Despe", 4.7, blondCategory));
            _Beers.Add(new Beer("Corona", 5, blondCategory));
            _Beers.Add(new Beer("Chouffe", 8, blondCategory));
            _Beers.Add(new Beer("La levrette", 6.9, blondCategory));
            _Beers.Add(new Beer("La mort subite", 6, blondCategory));
            _Beers.Add(new Beer("la lancelot", 5.1, blondCategory));
            _Beers.Add(new Beer("La morgane", 5, blondCategory));
            #endregion
            #region Beers
            Category bitterCategory = _Categories.First(category => category.Name == "Brune");
            _Beers.Add(new Beer("Leffe rituelle", 12, bitterCategory));
            _Beers.Add(new Beer("Bavaria", 9, bitterCategory));
            _Beers.Add(new Beer("BrewDog IPA Punk", 5, bitterCategory));
            _Beers.Add(new Beer("Guinness", 5, bitterCategory));
            _Beers.Add(new Beer("Stephanus", 5, bitterCategory));

            #endregion
            #region Beers
            Category amberCategory = _Categories.First(category => category.Name == "Ambree");
            _Beers.Add(new Beer("Leffe ambrée", 12, amberCategory));
            _Beers.Add(new Beer("Kwak", 9, amberCategory));
            _Beers.Add(new Beer("Queue de charrue", 7.7, amberCategory));
            #endregion
            #endregion
            #region Exemple de rêquete linQ
            /*// Nombre de bière total
            Console.WriteLine("Nombre de bière total: " + _Beers.Count());

            // La somme des degrées des bières brunes
            Console.WriteLine("Somme des degres des bieres brunes :" + _Beers
                .Where(beer => beer.Category == bitterCategory)
                .Sum(beer => beer.Degrees)
                .ToString());

            // La liste des catégories en passant par les bières
            Console.WriteLine("La liste des catégories en passant par les bières");
            _Beers.Select(beer => beer.Category)
                .Distinct()
                .ToList()
                .ForEach(category => Console.WriteLine(category.Name));

            // La liste des bières blondes
            Console.WriteLine("La liste des bières blondes");
            _Beers.Where(beer => beer.Category.Name == "Blonde")
                .ToList()
                .ForEach(beer => Console.WriteLine(beer.Name));

            // La liste des bières à 6 degrés
            Console.WriteLine("La liste des bières à 6 degrés");
            _Beers.Where(beer => beer.Degrees == 6)
                .ToList()
                .ForEach(beer => Console.WriteLine(beer.Name));

            // La bière la plus fort
            Console.WriteLine("La ou les bière(s) la ou les plus forte(s) (" + _Beers.Max(beer => beer.Degrees) + "°)");
            List<Beer> beers = _Beers.Where(beer => beer.Degrees >= _Beers
                                                        .Select(beertemp => beertemp.Degrees).Max()).ToList();
            beers.ForEach(beer => Console.WriteLine(beer.Name));
            */
            #endregion
            #endregion
            #region Presentation EF
            MegaCastingEntities entities = new MegaCastingEntities();


            Console.WriteLine(entities.OffreClients
                                 .Where(offreClient => offreClient.IdentifiantPartenaire == 4)
                                 .Count()
                                 .ToString());
            Console.ReadKey();
            #endregion
        }
    }
}
