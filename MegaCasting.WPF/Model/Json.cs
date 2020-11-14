using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.WPF.Model
{
    class Json
    {
        #region Attributes
        private string _Name;
        private string _Color;
        #endregion
        #region Properties
        /// <summary>
        /// Obtient ou définit le nom de la sauvegarde
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        /// <summary>
        /// Obtient ou définit la coleur à sauvegarder
        /// </summary>
        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }
        #endregion
        #region Construteur
        /// <summary>
        /// Construteur Json pour enregistrer les données
        /// </summary>
        /// <param name="name">Nom de la clé json</param>
        /// <param name="color">code couleur enregistrée</param>
        public Json(string name, string color)
        {
            this.Name = name;
            this.Color = color;
        }
        #endregion
        #region Method
        /// <summary>
        /// Serialize l'objet et enregistre la serialization grâce à la méthode SaveFile définit dans la classe
        /// </summary>
        /// <param name="name">Nom de l'objet à serializé</param>
        public void JsonFile(Object name)
        {
            string json = JsonConvert.SerializeObject(name, Formatting.Indented);
            SaveFile(json);
        }
        /// <summary>
        /// Enregistre le fichier indiqué (par défaut le chemin ..\\..\\data\\config.json) en json
        /// </summary>
        /// <param name="json">string à enregistrer</param>
        /// <param name="fileName">string par défautcontenant le chemin du fichier à enregistrer</param>
        /// <returns></returns>
        private Boolean SaveFile(string json, string fileName = "..\\..\\data\\config.json")
        {
            File.WriteAllText(fileName, json);
            return true;
        }
        /// <summary>
        /// Ouvre le fichier indiqué et retour la valeur HEX custom
        /// </summary>
        /// <returns>Retourne une string</returns>
        public string OpenFile()
        {
            string fileName = "..\\..\\data\\config.json";
            //String de retour content la valeur en hex du background color Custom
            string content = "";
            //Ouvre dans le fichier config.json dans le dossier data de l'application
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                //Lit jusqu'à la fin du fichier
                string json = streamReader.ReadToEnd();
                //Création d'une liste d'objet Json pour deserializer son contenu serialize
                List<Json> jsons = JsonConvert.DeserializeObject<List<Json>>(json);
                //Convertir la liste d'objet Json en string en cherchant dans le fichier la ligne Custom pour récupérer le code couleur
                string result = string.Join("\n", jsons.Where(j => j.Name == "Custom").Select(j => j.Color));
                //Affectation de la string result à content
                content = result;
            }
            return content;
        }
        #endregion
    }
}
