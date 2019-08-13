/*
____   ____                               .__        
\   \ /   /___   ____ _____    ________ __|__|_______
 \   Y   /  _ \_/ ___\\__  \  / ____/  |  \  \___   /
  \     (  <_> )  \___ / __ \< <_|  |  |  /  |/    / 
   \___/ \____/ \___  >____  /\__   |____/|__/_____ \
                    \/     \/    |__|              \/
*/
//  --------------------------------------------------------------------------
//  Auteur : Fleury Malik
//  Date : 03.08.2015
//  Maj : 21.08.2015
//
//  Classe permettant de gérer le vocabulaire(mots, traductions) dans une base 
//  de données relationnelle
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace VocaQuiz
{
    /// <summary>
    /// Classe permettant de gérer le vocabulaire dans une base de données relationnelle
    /// </summary>
    class GestVocSql : GestionnaireVoc
    {
        private DbProviderFactory dbpf = null;     // Fabrique de connexion BD
        private DbConnection bdConnexion = null;   // Connexion à la base de donnée
        private DbDataAdapter bdAdaptateur = null; // Adaptateur BD
        private DataSet dbVocaquiz = null;         // Ensemble de tables de la base de données
        private DataTable voc = null;              // Table de vocabulaire
        string nomTable = null;                    // Nom de la table

        /// <summary>
        /// Constructeur surchargé permettant d'accéder au vocabulaire
        /// </summary>
        /// <param name="nomFichier">Nom du fichier contenant le voc</param>
        public GestVocSql(string bdType, string chaineConnexion, string nomTable = "vocabulaire")
        {
            // Initialise la liste de langues
            listeLangues.Add("Français");
            listeLangues.Add("English");
            listeLangues.Add("Deutsch");
            listeLangues.Add("Italiano");
            listeLangues.Add("Español");

            // Créer une connexion à la base de données
            dbpf = DbProviderFactories.GetFactory(bdType);
            bdConnexion = dbpf.CreateConnection();
            bdConnexion.ConnectionString = chaineConnexion;

            // Créer un adaptateur et une structure pour stocker les données
            bdAdaptateur = dbpf.CreateDataAdapter();
            dbVocaquiz = new DataSet();

            // Sauvegarde le nom de la table
            this.nomTable = nomTable;

            // Charge les données
            AccederVoc(nomTable);
        }

        /// <summary>
        /// Permet d'accéder au vocabulaire en chargeant les données à partir de la base
        /// de données
        /// </summary>
        /// <param name="table">Nom de la table contenant le voc</param>
        public override void AccederVoc(string table)
        {
            DataRow ligneIdPlusGrand = null;       // Ligne contenant l'id le plus grand

            // Obtient le vocabulaire à partir de la base de données
            bdAdaptateur.SelectCommand = bdConnexion.CreateCommand();
            bdAdaptateur.SelectCommand.CommandText = "SELECT * FROM " + table;
            bdAdaptateur.Fill(dbVocaquiz, table);
            voc = dbVocaquiz.Tables[0];

            // Indique à la colonne id que c'est un auto-incrément
            voc.Columns["VO_id"].AutoIncrement = true;
            voc.Columns["VO_id"].AutoIncrementStep = 1;

            // Recherche l'id le plus grand
            try
            {
                ligneIdPlusGrand = voc.Select("VO_id = MAX(VO_id)")[0];
            }
            catch (IndexOutOfRangeException indexExc)
            {
                ligneIdPlusGrand = null;
            }

            // Définit le début de l'auto-incrément
            if (ligneIdPlusGrand == null)
                voc.Columns["VO_id"].AutoIncrementSeed = 1;
            else
                voc.Columns["VO_id"].AutoIncrementSeed = (int)ligneIdPlusGrand["VO_id"] + 1;

        }

        /// <summary>
        /// Permet d'ajouter un nouveau mot dans une langue
        /// </summary>
        /// <param name="nouveauMot">Mot à ajouter</param>
        /// <returns>Id unique du mot</returns>
        public override int CreerMot(Mot nouveauMot)
        {
            DataRow ligneMotAjoute = null;  // Ligne de données contenant le mot et ses traductions à ajouter
            string abrLangue = null;        // Abréviation de la langue du mot
            string colonne_nom = null;      // Nom de la colonne contenant le mot
            string colonne_desc = null;     // Nom de la colonne contenant la desciption
            int idUnique = 0;               // Id unique généré

            // Vérifie que le mot reçu est valide
            if (nouveauMot == null || nouveauMot.Nom == "" || nouveauMot.Langue == "")
                throw new Exception("Impossible de créer le mot!");

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(nouveauMot.Langue);

            // Définit les noms des colonnes
            colonne_nom = "VO_" + abrLangue + "_nom";
            colonne_desc = "VO_" + abrLangue + "_desc";

            // Ajoute un nouveau mot dans la base de données locale (en mémoire)
            ligneMotAjoute = voc.NewRow();
            ligneMotAjoute[colonne_nom] = nouveauMot.Nom;
            ligneMotAjoute[colonne_desc] = nouveauMot.Definition;
            voc.Rows.Add(ligneMotAjoute);

            // Obtient l'id
            idUnique = (int)ligneMotAjoute["VO_id"];

            // Met en forme la commande d'ajout
            /*commandeAjout  = "INSERT INTO " + nomTable + " (" + colonne_nom + ", " + colonne_desc + ") ";
            commandeAjout += "VALUES ('" + nouveauMot.Nom + "', '" + nouveauMot.Definition + "')";

            // Créer une nouvelle commande pour l'insertion
            bdAdaptateur.InsertCommand = bdConnexion.CreateCommand();
            bdAdaptateur.InsertCommand.CommandText = commandeAjout;*/

            // Retourne l'id du nouveau mot
            return idUnique;
        }

        /// <summary>
        /// Permet de modifier les caractéristiques d'un mot ou d'une traduction
        /// </summary>
        /// <param name="motAModifier">Mot à modifier</param>
        /// <param name="motModifie">Mot avec les caractéristiques modifiées</param>
        /// <returns>Mot modifié</returns>
        public override Mot ModifierMot(Mot motAModifier, Mot motModifie)
        {
            DataRow ligneMotModifie = null;        // Ligne de données contenant le mot et ses traductions à modifier
            string colonne_nom = null;             // Nom de la colonne contenant le mot
            string colonne_desc = null;            // Nom de la colonne contenant la desciption
            string abrAncienneLangue = null;       // Abréviation d'ancienne langue
            string abrNouvelleLangue = null;       // Abréviation de la nouvelle langue

            // Vérifie que le mot à modifier est valide
            if (motAModifier == null || motAModifier.Nom == "" || motAModifier.Langue == "")
                throw new Exception("Impossible de modifier le mot!");

            // Vérifie que le mot modifié est valide
            if (motModifie == null || motModifie.Nom == "" || motModifie.Langue == "")
                throw new Exception("Impossible de modifier le mot!");

            // Ajoute l'id au mot modifié
            motModifie.IdUnique = motAModifier.IdUnique;

            // Obtient les abrévations des langues
            abrAncienneLangue = ObtenirAbreviationLangue(motAModifier.Langue);
            abrNouvelleLangue = ObtenirAbreviationLangue(motModifie.Langue);

            // Recherche le mot à modifier à l'aide de l'id
            ligneMotModifie = voc.Select("VO_id =" + motAModifier.IdUnique)[0];

            // Définit les noms des colonnes pour l'ancienne langue
            colonne_nom = "VO_" + abrAncienneLangue + "_nom";
            colonne_desc = "VO_" + abrAncienneLangue + "_desc";

            // Efface le mot dans l'ancienne langue
            ligneMotModifie[colonne_nom] = null;
            ligneMotModifie[colonne_desc] = null;

            // Définit les noms des colonnes pour la nouvelle langue
            colonne_nom = "VO_" + abrNouvelleLangue + "_nom";
            colonne_desc = "VO_" + abrNouvelleLangue + "_desc";

            // Remet le mot dans la nouvelle langue
            ligneMotModifie[colonne_nom] = motModifie.Nom;
            ligneMotModifie[colonne_desc] = motModifie.Definition;

            // Retourne le mot modifié
            return motModifie;
        }

        /// <summary>
        /// Permet de supprimer un mot (Toutes traductions comprises)
        /// </summary>
        /// <param name="motASupp">Mot à supprimer</param>
        public override void SupprimerMot(Mot motASupp)
        {
            DataRow ligneMotSupprime = null;     // Ligne de données contenant le mot et ses traductions devant être supprimés

            // Vérifie que le mot à supprimer est correct
            if (motASupp == null || motASupp.Nom == "" || motASupp.Langue == "")
                throw new Exception("Impossible de supprimer!");

            // Recherche la ligne à supprimer
            ligneMotSupprime = voc.Select("VO_id = " + motASupp.IdUnique)[0];

            // Supprime la ligne
            ligneMotSupprime.Delete();
            
            // FONCTIONNE PAS AVEC REMOVE !
            // Supprime la ligne de la base de données
            //voc.Rows.Remove(ligneMotSupprime);
        }

        /// <summary>
        /// Permet d'ajouter une traduction à un mot dans une autre langue
        /// </summary>
        /// <param name="motATraduire">Mot qui doit être traduit</param>
        /// <param name="Traduction">Traduction du mot</param>
        public override void AjouterTraduction(Mot motATraduire, Mot traduction)
        {
            DataRow ligneMotNouvelleTrad = null;       // Ligne de données d'un mot recevant la nouvelle traduction
            string abrLangueTraduction = null;         // Abréviation de la langue de traduction
            string colonne_nom = null;                 // Nom de la colonne contenant le mot
            string colonne_desc = null;                // Nom de la colonne contenant la desciption

            // Vérifie que le mot à traduire est valide
            if (motATraduire == null || motATraduire.Nom == "" || motATraduire.Langue == "")
                throw new Exception("Impossible d'ajouter une traduction!");

            // Vérifie que la traduction est valide
            if (traduction == null || traduction.Nom == "" || traduction.Langue == "")
                throw new Exception("Impossible d'ajouter une traduction!");

            // Vérifie que soit bien une traduction
            if (traduction.Langue == motATraduire.Langue)
                throw new Exception("Cette traduction n'est pas valide!");

            // Vérifie que la traduction n'existe pas déjà
            /*if (ChercherNoeudMot(traduction) != null)
                throw new Exception("Cette traduction existe déjà!");*/

            // Obtient l'abréviation de la langue
            abrLangueTraduction = ObtenirAbreviationLangue(traduction.Langue);

            // Définit les noms des colonnes
            colonne_nom = "VO_" + abrLangueTraduction + "_nom";
            colonne_desc = "VO_" + abrLangueTraduction + "_desc";

            // Recherche la ligne contenant le mot devant être traduit
            ligneMotNouvelleTrad = voc.Select("VO_id = " + motATraduire.IdUnique)[0];

            // Insère les informations de traductions
            ligneMotNouvelleTrad[colonne_nom] = traduction.Nom;
            ligneMotNouvelleTrad[colonne_desc] = traduction.Definition;
        }

        /// <summary>
        /// Permet de supprimer une traduction
        /// </summary>
        /// <param name="traductionASupp">Traduction à supprimer</param>
        public override void EffacerTraduction(Mot traductionASupp)
        {
            DataRow ligneMotTradEffacee = null;        // Ligne de données d'un mot contenant la traduction à effacer
            string abrLangueTraduction = null;         // Abréviation de la langue de traduction
            string colonne_nom = null;                 // Nom de la colonne contenant le mot
            string colonne_desc = null;                // Nom de la colonne contenant la desciption

            // Vérifie que la traduction à supprimer est correct
            if (traductionASupp == null || traductionASupp.Nom == "" || traductionASupp.Langue == "")
                throw new Exception("Impossible de supprimer une traduction!");

            // Obtient l'abréviation de la langue
            abrLangueTraduction = ObtenirAbreviationLangue(traductionASupp.Langue);

            // Définit les noms des colonnes
            colonne_nom = "VO_" + abrLangueTraduction + "_nom";
            colonne_desc = "VO_" + abrLangueTraduction + "_desc";

            // Recherche la traduction à effacer
            ligneMotTradEffacee = voc.Select("VO_id = " + traductionASupp.IdUnique)[0];

            // Efface la traduction
            ligneMotTradEffacee[colonne_nom] = null;
            ligneMotTradEffacee[colonne_desc] = null;
        }

        /// <summary>
        /// Permet d'obtenir la traduction d'un mot dans une langue
        /// </summary>
        /// <param name="motATraduire">Mot à traduire</param>
        /// <param name="langueTraduction">Langue dans laquelle traduire</param>
        /// <returns>Traduction du mot dans la langue souhaitée</returns>
        public override Mot ObtenirTraduction(Mot motATraduire, string langueTraduction)
        {
            DataRow ligneMotTraductions = null; // Ligne de données d'un mot contenant toutes ses traductions
            Mot traduction = null;              // Mot contenant la traduction
            string abrLangue = null;            // Abréviation de la langue d'origine
            string abrLangueTrad = null;        // Abréviation de la langue de traduction
            string commande = null;             // Commande SQL à exécuter

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(motATraduire.Langue);

            // Obtient l'abréviation de la langue de traduction
            abrLangueTrad = ObtenirAbreviationLangue(langueTraduction);

            // Met en forme la commande SQL
            commande = "VO_id = " + motATraduire.IdUnique;

            // Obtient toutes les traductions du mots
            ligneMotTraductions = voc.Select(commande)[0];

            // Crée un nouveau mot et insère la traduction si elle existe
            if (!(ligneMotTraductions["VO_" + abrLangueTrad + "_nom"] is DBNull) && (ligneMotTraductions != null))
            {
                // Créer un nouveau mot contenant la traduction
                traduction          = new Mot();
                traduction.IdUnique = (int)motATraduire.IdUnique;
                traduction.Nom = (string)ligneMotTraductions["VO_" + abrLangueTrad + "_nom"];
                traduction.Langue   = langueTraduction;
                traduction.Definition = (string)ligneMotTraductions["VO_" + abrLangueTrad + "_desc"];
            }

            // Retourne la traduction trouvée
            return traduction;
        }

        /// <summary>
        /// Permet d'obtenir toutes les traductions d'un mot dans une langue
        /// </summary>
        /// <param name="mot">Mot à traduire</param>
        /// <param name="langue">Langue du mot</param>
        /// <returns>Liste des traductions pour le mot</returns>
        public override List<Mot> ObtenirToutesTraductions(Mot motATraduire)
        {
            List<Mot> listeTraductions = null;     // Liste de traductions pour le mot
            DataRow ligneMotTraductions = null;    // Ligne de données d'un mot contenant toute les traductions
            Mot traduction = null;                 // Mot contenant une des traductions
            string abrLangue = null;               // Abréviation de la langue
            string abrLangueTrad = null;           // Abréviation de la langue de traduction
            string commande = null;                // Commande SQL à exécuter

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(motATraduire.Langue);

            // Met en forme la commande SQL
            commande = "VO_id = " + motATraduire.IdUnique;

            // Obtient toutes les traductions du mot
            ligneMotTraductions = voc.Select(commande)[0];

            // Crée la liste de traductions
            listeTraductions = new List<Mot>();

            // Obtient chaque traduction et l'ajoute dans la liste
            foreach (string langue in listeLangues)
            {
                // Obtient l'abréviation de la langue de traduction
                abrLangueTrad = ObtenirAbreviationLangue(langue);

                // Vérifie que la traduction existe et qu'elle soit différente de la langue à traduire
                if (!(ligneMotTraductions["VO_" + abrLangueTrad + "_nom"] is DBNull) && (langue != motATraduire.Langue))
                {
                    // Crée un nouveau mot contenant la traduction
                    traduction          = new Mot();
                    traduction.IdUnique = (int)motATraduire.IdUnique;
                    traduction.Nom = (string)ligneMotTraductions["VO_" + abrLangueTrad + "_nom"];
                    traduction.Langue   = langue;
                    traduction.Definition = (string)ligneMotTraductions["VO_" + abrLangueTrad + "_desc"];

                    // Ajoute la traduction dans la liste
                    listeTraductions.Add(traduction);
                }
            }

            // Retourne la liste des traductions
            return listeTraductions;
        }

        /// <summary>
        /// Permet d'obtenir tous les mots d'une langue
        /// </summary>
        /// <param name="langue">Langue des mots à obtenir</param>
        /// <returns>Liste de mots dans une langue</returns>
        public override List<Mot> ObtenirTousMotsDansUneLangue(string langue)
        {
            List<Mot> listeMotsUneLangue = null;   // Liste de mots dans une langue
            DataRow[] lignesMot = null;            // Lignes de données contenant des mots dans la langue voulue
            Mot motTrouve = null;                  // Mot trouvé dans la langue voulue
            string abrLangue = null;               // Abréviation de la langue
            string commande = null;                // Commande SQL à exécuter

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(langue);

            // Met en forme la commande SQL
            commande = "VO_" + abrLangue + "_nom IS NOT NULL";

            // Obtient les lignes correspondant à la requête
            lignesMot = voc.Select(commande);

            // Crée la liste de mots
            listeMotsUneLangue = new List<Mot>();

            // Insère les données dans des objets "Mots"
            foreach (DataRow ligneMot in lignesMot)
            {
                // Créer un nouveau mot et insère les données
                motTrouve = new Mot();
                motTrouve.IdUnique = (int)ligneMot["VO_id"];
                motTrouve.Nom = (string)ligneMot["VO_" + abrLangue + "_nom"];
                motTrouve.Langue = langue;
                motTrouve.Definition = (string)ligneMot["VO_" + abrLangue + "_desc"];

                // Ajoute dans la liste le mot
                listeMotsUneLangue.Add(motTrouve);
            }

            // Retourne la liste de mots d'une langue
            return listeMotsUneLangue;
        }

        /// <summary>
        /// Permet d'obtenir la liste de mots ayant des traductions
        /// </summary>
        /// <param name="langue">Langue d'origine</param>
        /// <param name="langueTrad">Langue de traduction</param>
        /// <returns>Liste de mots ayant des traductions pour la langue de traduction</returns>
        public override List<Mot> ObtenirMotsAvecTraductionsExistantes(string langue, string langueTraduction)
        {
            DataRow[] lignesMotsTraductions = null;        // Lignes de données contenant les mots et traductions valides
            string abrLangue = null;                       // Contient l'abréviation de la langue
            string abrLangueTraduction = null;             // Contient l'abréviation de la langue dans laquelle traduire
            string commande = null;                        // Commande SQL à exécuter
            List<Mot> listeMotsValides = null;             // Contient les mots qui ont une traduction pour la langue choisie
            Mot motValide = null;                          // Mot ayant une traduction pour la langue choisie

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(langue);

            // Obtient l'abréviation de la langue de traduction
            abrLangueTraduction = ObtenirAbreviationLangue(langueTraduction);

            // Obtient la table des mots et traductions valides
            commande = "VO_" + abrLangue + "_nom IS NOT NULL AND VO_" + abrLangueTraduction + "_nom IS NOT NULL";
            lignesMotsTraductions = voc.Select(commande);

            // Crée une liste de mots dans la langue d'origine ayant des traductions pour la langue de traduction choisie
            listeMotsValides = new List<Mot>();

            // Insère les informations dans des objets "Mot"
            foreach (DataRow ligneMotTrad in lignesMotsTraductions)
            {
                // Créé un nouvel objet "Mot" et insére les informations
                motValide = new Mot();
                motValide.IdUnique = (int)ligneMotTrad["VO_id"];
                motValide.Nom = (string)ligneMotTrad["VO_" + abrLangue + "_nom"];
                motValide.Definition = (string)ligneMotTrad["VO_" + abrLangue + "_desc"];
                motValide.Langue = langue;

                // Ajoute le mot dans la liste
                listeMotsValides.Add(motValide);
            }

            // Retourne la liste de mots dans la langue d'origine ayant des traductions pour la langue de traduction
            return listeMotsValides;
        }

        /// <summary>
        /// Permet d'obtenir le nombre de mots dans le fichier XML
        /// </summary>
        /// <returns>Nombre de mots</returns>
        public override int ObtenirNombreMots()
        {
            // Retourne l'id le plus grand
            return (int)voc.Select("VO_id = MAX(VO_id)")[0]["VO_id"];
        }

        /// <summary>
        /// Permet d'obtenir un mot par l'index
        /// </summary>
        /// <param name="index">Index d'une liste</param>
        /// <param name="langue">Langue du mot</param>
        /// <returns>Mot correspondant à l'index</returns>
        public override Mot ChercherMotParIndex(int index, string langue)
        {
            DataRow ligneTraductions = null;   // Ligne de données contenant toutes les traductions
            Mot motTrouve = null;              // Mot trouvé avec l'index donné
            string abrLangue = null;           // Abréviation de la langue
            string commande = null;            // Commande à exécuter

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(langue);

            // Met en forme la commande
            commande = "VO_id = " + index;

            // Obtient toutes les traductions
            ligneTraductions = voc.Select(commande)[0];

            // Créer un nouveau mot et insère la traduction si elle existe
            if (!(ligneTraductions["VO_" + abrLangue + "_nom"] is DBNull))
            {
                // Créer un nouveau mot contenant la traduction
                motTrouve           = new Mot();
                motTrouve.IdUnique  = index;
                motTrouve.Nom       = (string)ligneTraductions["VO_" + abrLangue + "_nom"];
                motTrouve.Langue    = langue;

                // Ajoute la définition si elle existe
                if (ligneTraductions["VO_" + abrLangue + "_desc"] is DBNull)
                    motTrouve.Definition = "";
                else
                    motTrouve.Definition = (string)ligneTraductions["VO_" + abrLangue + "_desc"];
            }

            // Retourne le mot trouvé
            return motTrouve;
        }

        /// <summary>
        /// Permet de sauvegarder les informations dans la base de données
        /// </summary>
        public override void SauvegarderVoc()
        {
            // Créer la requête d'insertion
            _CreerRequeteInsertionBdd();

            // Créer la requête de mise à jour
            _CreerRequeteMajBdd();

            // Créer la requête de suppression
            _CreerRequeteSuppressionBdd();

            // Met à jour la base de données
            bdAdaptateur.Update(dbVocaquiz.Tables[nomTable]);
        }

        /// <summary>
        /// Permet de créer la requête SQL pour l'insertion de nouvelle données
        /// </summary>
        private void _CreerRequeteInsertionBdd()
        {
            DbParameter paramId = null;        // Paramètre Id
            DbParameter paramNom = null;       // Paramètre du nom du mot pour chaque langue
            DbParameter paramDesc = null;      // Paramètre de la définition du mot pour chaque langue
            string abrLangue = null;           // Abréviation de la langue

            // Crée la commande permettant d'ajouter des données dans la base de données
            bdAdaptateur.InsertCommand = bdConnexion.CreateCommand();

            // Crée le paramètre id
            paramId = bdAdaptateur.InsertCommand.CreateParameter();
            paramId.SourceColumn = "VO_id";
            paramId.ParameterName = "VO_id";
            bdAdaptateur.InsertCommand.Parameters.Add(paramId);

            // Ajoute le nom et la définition du mot pour chaque langue
            foreach (string langue in listeLangues)
            {
                // Obtient l'abréviation de la langue
                abrLangue = ObtenirAbreviationLangue(langue);

                // Crée le paramètre nom
                paramNom = bdAdaptateur.InsertCommand.CreateParameter();
                paramNom.SourceColumn = "VO_" + abrLangue + "_nom";
                paramNom.ParameterName = "VO_" + abrLangue + "_nom";
                bdAdaptateur.InsertCommand.Parameters.Add(paramNom);

                // Crée le paramètre définition
                paramDesc = bdAdaptateur.InsertCommand.CreateParameter();
                paramDesc.SourceColumn = "VO_" + abrLangue + "_desc";
                paramDesc.ParameterName = "VO_" + abrLangue + "_desc";
                bdAdaptateur.InsertCommand.Parameters.Add(paramDesc);
            }

            // Définit la requête d'insertion
            bdAdaptateur.InsertCommand.CommandText = "INSERT INTO " + nomTable + " (VO_fr_nom, VO_fr_desc, VO_de_nom, VO_de_desc, VO_en_nom, VO_en_desc, VO_it_nom, VO_it_desc, VO_es_nom, VO_es_desc) VALUES (@VO_fr_nom, @VO_fr_desc, @VO_de_nom, @VO_de_desc, @VO_en_nom, @VO_en_desc, @VO_it_nom, @VO_it_desc, @VO_es_nom, @VO_es_desc)";
        }

        /// <summary>
        /// Permet de créer la requête SQL pour la mise à jour de données
        /// </summary>
        private void _CreerRequeteMajBdd()
        {
            DbParameter paramId;        // Paramètre Id
            DbParameter paramNom;       // Paramètre du nom du mot pour chaque langue
            DbParameter paramDesc;      // Paramètre de la définition du mot pour chaque langue
            string abrLangue;           // Abréviation de la langue

            // Crée la commande permettant de mettre à jour la base de données
            bdAdaptateur.UpdateCommand = bdConnexion.CreateCommand();

            // Crée le paramètre id
            paramId = bdAdaptateur.UpdateCommand.CreateParameter();
            paramId.SourceColumn = "VO_id";
            paramId.ParameterName = "VO_id";
            bdAdaptateur.UpdateCommand.Parameters.Add(paramId);

            // Ajoute le nom et la définition du mot pour chaque langue
            foreach (string langue in listeLangues)
            {
                // Obtient l'abréviation de la langue
                abrLangue = ObtenirAbreviationLangue(langue);

                // Crée le paramètre nom
                paramNom = bdAdaptateur.UpdateCommand.CreateParameter();
                paramNom.SourceColumn = "VO_" + abrLangue + "_nom";
                paramNom.ParameterName = "VO_" + abrLangue + "_nom";
                bdAdaptateur.UpdateCommand.Parameters.Add(paramNom);

                // Crée le paramètre définition
                paramDesc = bdAdaptateur.UpdateCommand.CreateParameter();
                paramDesc.SourceColumn = "VO_" + abrLangue + "_desc";
                paramDesc.ParameterName = "VO_" + abrLangue + "_desc";
                bdAdaptateur.UpdateCommand.Parameters.Add(paramDesc);
            }

            // Définit la requête d'insertion
            bdAdaptateur.UpdateCommand.CommandText = "UPDATE " + nomTable + " SET VO_fr_nom = @VO_fr_nom, VO_fr_desc = @VO_fr_desc, VO_de_nom = @VO_de_nom, VO_de_desc = @VO_de_desc, VO_en_nom = @VO_en_nom, VO_en_desc = @VO_en_desc, VO_it_nom = @VO_it_nom, VO_it_desc = @VO_it_desc, VO_es_nom = @VO_es_nom, VO_es_desc = @VO_es_desc WHERE VO_id = @VO_id";
        }

        /// <summary>
        /// Permet de créer la requête pour la suppression de données
        /// </summary>
        private void _CreerRequeteSuppressionBdd()
        {
            DbParameter paramId;        // Paramètre Id

            // Créé la commande permettant de supprimer des données dans la base de données
            bdAdaptateur.DeleteCommand = bdConnexion.CreateCommand();

            // Crée le paramètre id
            paramId = bdAdaptateur.DeleteCommand.CreateParameter();
            paramId.SourceColumn = "VO_id";
            paramId.ParameterName = "VO_id";
            bdAdaptateur.DeleteCommand.Parameters.Add(paramId);

            // Définit la requête de suppression
            bdAdaptateur.DeleteCommand.CommandText = "DELETE FROM " + nomTable + " WHERE VO_id = @VO_id";
        }
    }
}
