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
//  Date : 30.06.2015
//  Maj : 02.07.2015
//
//  Classe permettant de gérer le vocabulaire(mots, traductions) dans le 
//  fichier XML.
//  --------------------------------------------------------------------------

// IMPROVEMENT !!!
// Modifier les noms d'identificateur
// Modifier le nom de la structure XML (mot --> motettrad ? // mot --> traduction)
// Méthode obtenirNombreMot pas correct ! dans le cas où il y a un "trou" dans les ids

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace VocaQuiz
{
    /// <summary>
    /// Classe permettant de gérer le vocabulaire du fichier XML
    /// </summary>
    class GestVocXml : GestionnaireVoc
    {
        private XmlDocument fichierXml = new XmlDocument();     // Fichier contenant le vocabulaire
        private string nomFichier = null;                       // Nom du fichier contenant le vocabulaire
        private string repertoire = null;                       // Répertoire de sauvegarde du fichier
        private bool open = false;                              // Etat du fichier
        
        /// <summary>
        /// Constructeur surchargé permettant d'ouvrir le fichier XML contenant le voc
        /// </summary>
        /// <param name="nomFichier">Nom du fichier contenant le voc</param>
        public GestVocXml(string nomFichier = "voc.xml", string repertoireXml = "./xml/")
        {
            // Initialise la liste de langues
            listeLangues.Add("Français");
            listeLangues.Add("English");

            // Indique le répertoire où est sauvegardé le document XML
            repertoire = repertoireXml;

            // Charge le fichier de vocabulaire
            AccederVoc(nomFichier);
        }

        /// <summary>
        /// Permet d'accéder au vocabulaire en chargeant le fichier XML
        /// </summary>
        /// <param name="nomFichier">Nom du fichier contenant le voc</param>
        public override void AccederVoc(string nomFichier)
        {
            // Charge le fichier
            fichierXml.Load("./xml/" + nomFichier);
            this.nomFichier = nomFichier;
            this.open = true;
        }

        /// <summary>
        /// Permet d'ajouter un nouveau mot dans n'importe quelle langue
        /// </summary>
        /// <param name="nouveauMot">Mot à ajouter</param>
        /// <returns>Id unique du mot</returns>
        public override int CreerMot(Mot nouveauMot)
        {
            XmlNode noeudRacine = null;     // Noeud sur la racine du fichier XML
            XmlNode noeudMot = null;        // Noeud du nouveau mot
            XmlNode noeudNom = null;        // Noeud du nom du mot
            XmlNode noeudDef = null;        // Noeud de la définition du mot
            XmlNode noeudLangue = null;     // Noeud sur la langue du mot
            XmlAttribute attributId = null; // Attribut de l'id
            string abrLangue = null;        // Abréviation de la langue du mot
            int idUnique = 0;               // Id unique généré

            // Vérifie que le mot reçu est valide
            if (nouveauMot == null || nouveauMot.Nom == "" || nouveauMot.Langue == "")
                throw new Exception("Impossible de créer le mot!");

            // Créé un nouveau noeud pour le mot
            noeudMot = fichierXml.CreateNode(XmlNodeType.Element, "mot", "");

            // Créé l'attribut de l'id du mot et l'attache au noeud mot
            attributId = fichierXml.CreateAttribute("id");
            idUnique = _GenererIdUnique();
            attributId.Value = idUnique.ToString();
            noeudMot.Attributes.SetNamedItem(attributId);

            // Créer un noeud pour chaque langue
            foreach (string langue in listeLangues)
            {
                // Obtient l'abréviation de la langue
                abrLangue = ObtenirAbreviationLangue(langue);

                // Crée le noeud de la langue
                noeudLangue = fichierXml.CreateNode(XmlNodeType.Element, abrLangue, "");

                // Crée les noeuds pour le nom et la définition du mot
                noeudNom = fichierXml.CreateNode(XmlNodeType.Element, "nom", "");
                noeudDef = fichierXml.CreateNode(XmlNodeType.Element, "definition", "");

                // Ajoute le mot lorsque c'est la bonne langue
                if (langue == nouveauMot.Langue)
                {
                    noeudNom.InnerText = nouveauMot.Nom;
                    noeudDef.InnerText = nouveauMot.Definition;
                }

                // Attache le nom et la définition à la langue
                noeudLangue.AppendChild(noeudNom);
                noeudLangue.AppendChild(noeudDef);

                // Attache la langue au mot
                noeudMot.AppendChild(noeudLangue);
            }

            // Attache le nouveau mot à la racine
            noeudRacine = fichierXml.SelectSingleNode("/vocaquiz");
            noeudRacine.AppendChild(noeudMot);

            // Retourne l'id
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
            XmlNode noeudMotAModifier = null;       // Noeud du mot à modifier
            XmlNode noeudNom = null;                // Noeud du nom du mot
            XmlNode noeudDef = null;                // Noeud de la définition du mot
            string abrAncienneLangue = null;        // Abréviation d'ancienne langue
            string abrNouvelleLangue = null;        // Abréviation de la nouvelle langue

            // Vérifie que le mot à modifier est valide
            if (motAModifier == null || motAModifier.Nom == "" || motAModifier.Langue == "")
                throw new Exception("Impossible de modifier le mot!");

            // Vérifie que le mot modifié est valide
            if (motModifie == null || motModifie.Nom == "" || motModifie.Langue == "")
                throw new Exception("Impossible de modifier le mot!");

            // Cherche le noeud du mot à modifier
            noeudMotAModifier = _ChercherNoeudMot(motAModifier);

            // Ajoute l'id
            motModifie.IdUnique = motAModifier.IdUnique;

            // Obtient les abrévations des langues
            abrAncienneLangue = ObtenirAbreviationLangue(motAModifier.Langue);
            abrNouvelleLangue = ObtenirAbreviationLangue(motModifie.Langue);

            // Efface le mot dans l'ancienne langue
            noeudNom = noeudMotAModifier.SelectSingleNode(abrAncienneLangue + "/nom");
            noeudDef = noeudMotAModifier.SelectSingleNode(abrAncienneLangue + "/definition");
            noeudNom.InnerText = "";
            noeudDef.InnerText = "";

            // Remet le mot dans la nouvelle langue
            noeudNom = noeudMotAModifier.SelectSingleNode(abrNouvelleLangue + "/nom");
            noeudDef = noeudMotAModifier.SelectSingleNode(abrNouvelleLangue + "/definition");
            noeudNom.InnerText = motModifie.Nom;
            noeudDef.InnerText = motModifie.Definition;

            // Sauvegarde le fichier
            //SauvegarderVoc();

            // Retourne le mot modifié
            return motModifie;
        }

        /// <summary>
        /// Permet de supprimer un mot (Toutes traductions comprises)
        /// </summary>
        /// <param name="motASupp">Mot à supprimer</param>
        public override void SupprimerMot(Mot motASupp)
        {
            XmlNode noeudRacine = null;     // Noeud de la racine
            XmlNode noeudMot = null;        // Noeud du mot à supprimer

            // Vérifie que le mot à supprimer est correct
            if (motASupp == null || motASupp.Nom == "" || motASupp.Langue == "")
                throw new Exception("Impossible de supprimer!");

            // Cherche le noeud du mot à supprimer
            noeudMot = _ChercherNoeudMot(motASupp);

            // Supprime le noeud dans le fichier XML
            noeudRacine = fichierXml.SelectSingleNode("/vocaquiz");
            noeudRacine.RemoveChild(noeudMot);
        }

        /// <summary>
        /// Permet d'ajouter une traduction à un mot dans une autre langue
        /// </summary>
        /// <param name="motATraduire">Mot qui doit être traduit</param>
        /// <param name="Traduction">Traduction du mot</param>
        public override void AjouterTraduction(Mot motATraduire, Mot traduction)
        {
            XmlNode noeudMot = null;        // Noeud du mot auquel il faut ajouter une traduction
            XmlNode noeudNom = null;        // Noeud du nom du mot
            XmlNode noeudDef = null;        // Noeud de la définition du mot
            string abrNouvLangue = null;    // Abréviation de la nouvelle langue
            int idUnique = 0;               // Id de du mot traduit

            // Vérifie que le mot à traduire est valide
            if (motATraduire == null || motATraduire.Nom == "" || motATraduire.Langue == "")
                throw new Exception("Impossible d'ajouter une traduction!");

            // Vérifie que la traduction est valide
            if (traduction == null || traduction.Nom == "" || traduction.Langue == "")
                throw new Exception("Impossible d'ajouter une traduction!");

            // Vérifie que soit bien une traduction
            if (traduction.Langue == motATraduire.Langue)
                throw new Exception("Cette traduction n'est pas valide!");

            // Cherche le noeud du mot à traduire
            noeudMot = _ChercherNoeudMot(motATraduire);

            // Obtient l'abréviation de la langue dans laquelle traduire
            abrNouvLangue = ObtenirAbreviationLangue(traduction.Langue);

            // Obtient les noeuds du nom et de la description pour la traduction
            idUnique = int.Parse(noeudMot.Attributes["id"].Value);
            noeudNom = noeudMot.SelectSingleNode(abrNouvLangue + "/nom");
            noeudDef = noeudMot.SelectSingleNode(abrNouvLangue + "/definition");

            // Insère les données de traduction
            noeudNom.InnerText = traduction.Nom;
            noeudDef.InnerText = traduction.Definition;

            /*
            // Créer un noeud pour la nouvelle traduction
            noeudNouvLangue = fichierXml.CreateNode(XmlNodeType.Element, abrNouvLangue, "");

            // Créer les noeuds du nom et de la définition
            noeudNom = fichierXml.CreateNode(XmlNodeType.Element, "nom", "");
            noeudDef = fichierXml.CreateNode(XmlNodeType.Element, "definition", "");

            // Attache le nom et la définition avec la langue
            noeudNouvLangue.AppendChild(noeudNom);
            noeudNouvLangue.AppendChild(noeudDef);

            // Attache la nouvelle traduction
            noeudMot.AppendChild(noeudNouvLangue);
             */
        }

        /// <summary>
        /// Permet de supprimer une traduction
        /// </summary>
        /// <param name="traductionASupp">Traduction à supprimer</param>
        public override void EffacerTraduction(Mot traductionASupp)
        {
            XmlNode noeudNom = null;        // Noeud du nom
            XmlNode noeudDef = null;        // Noeud de la définition
            XmlNode noeudMot = null;        // Noeud du mot à supprimer
            string abrLangueTrad = null;    // Abréviation de la langue de traduction

            // Vérifie que la traduction à supprimer est correct
            if (traductionASupp == null || traductionASupp.Nom == "" || traductionASupp.Langue == "")
                throw new Exception("Impossible de supprimer une traduction!");

            // Cherche le noeud du mot à supprimer
            noeudMot = _ChercherNoeudMot(traductionASupp);

            // Obtient l'abréviation de la langue de traduction
            abrLangueTrad = ObtenirAbreviationLangue(traductionASupp.Langue);

            // Efface le nom et la définition du mot
            noeudNom = noeudMot.SelectSingleNode(abrLangueTrad + "/nom");
            noeudDef = noeudMot.SelectSingleNode(abrLangueTrad + "/definition");
            noeudNom.InnerText = "";
            noeudDef.InnerText = "";
        }

        /// <summary>
        /// Permet d'obtenir la traduction d'un mot dans une langue
        /// </summary>
        /// <param name="motATraduire">Mot à traduire</param>
        /// <param name="langueTraduction">Langue dans laquelle traduire</param>
        /// <returns>Traduction du mot dans la langue souhaitée</returns>
        public override Mot ObtenirTraduction(Mot motATraduire, string langueTraduction)
        {
            XmlNodeList listeNoeudsTrad = null;     // Liste de traductions dans le fichier Xml
            XmlNode noeudMot = null;                // Noeud du mot à traduire
            string abrLangue = null;                // Contient l'abréviation de la langue
            string abrLangueTraduction = null;      // Contient l'abréviation de la langue dans laquelle traduire
            Mot traduction = new Mot();             // Mot traduit

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(motATraduire.Langue);

            // Obtient l'abréviation de la langue de traduction
            abrLangueTraduction = ObtenirAbreviationLangue(langueTraduction);

            // Obtient la liste des traductions à partir du fichier XML
            listeNoeudsTrad = fichierXml.SelectNodes("/vocaquiz/mot");

            // Cherche le noeud du mot
            noeudMot = _ChercherNoeudMot(motATraduire);

            // Obtient la traduction
            traduction.IdUnique = int.Parse(noeudMot.Attributes["id"].Value);
            traduction.Nom = noeudMot.SelectSingleNode(abrLangueTraduction + "/nom").InnerText;
            traduction.Definition = noeudMot.SelectSingleNode(abrLangueTraduction + "/definition").InnerText;
            traduction.Langue = langueTraduction;

            // Retourne la traduction du mot
            return traduction;
        }

        /// <summary>
        /// Permet d'obtenir toutes les traductions d'un mot d'une langue
        /// </summary>
        /// <param name="mot">Mot à traduire</param>
        /// <param name="langue">Langue du mot</param>
        /// <returns>Liste des traductions pour le mot</returns>
        public override List<Mot> ObtenirToutesTraductions(Mot motATraduire)
        {
            XmlNodeList listeNoeudsTrad = null;             // Liste de traduction dans le fichier Xml
            XmlNode noeudMot = null;                        // Noeud du mot à traduire dans toutes les langues possibles
            string abrLangue = null;                        // Contient l'abréviation de la langue
            string abrLangueTraduction = null;              // Contient l'abréviation de la langue dans laquelle traduire
            List<Mot> listeTraductions = new List<Mot>();   // Contient toutes les traductions du mot
            Mot traduction = null;                          // Mot traduit

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(motATraduire.Langue);

            // Obtient la liste des traductions à partir du fichier XML
            listeNoeudsTrad = fichierXml.SelectNodes("/vocaquiz/mot");

            // Cherche le noeud du mot
            noeudMot = _ChercherNoeudMot(motATraduire);

            // Obtient les traductions
            foreach (string langue in listeLangues)
            {
                if(langue != motATraduire.Langue)
                {
                    // Obtient l'abréviation de la langue de traduction
                    abrLangueTraduction = ObtenirAbreviationLangue(langue);

                    // Crée un nouveau mot contenant la traduction
                    traduction = new Mot();
                    traduction.IdUnique = int.Parse(noeudMot.Attributes["id"].Value);
                    traduction.Nom = noeudMot.SelectSingleNode(abrLangueTraduction + "/nom").InnerText;
                    traduction.Definition = noeudMot.SelectSingleNode(abrLangueTraduction + "/definition").InnerText;
                    traduction.Langue = langue;

                    // Ajoute la traduction dans la liste
                    listeTraductions.Add(traduction);
                }
            }

            // Retourne les traductions du mot
            return listeTraductions;
        }

        /// <summary>
        /// Permet d'obtenir tous les mots d'une langue
        /// </summary>
        /// <param name="langue">Langue des mots à obtenir</param>
        /// <returns>Liste de mots d'une langue</returns>
        public override List<Mot> ObtenirTousMotsDansUneLangue(string langue)
        {
            XmlNodeList listeNoeudsMot = null;          // Liste des noeuds de mots
            XmlNode noeudNom = null;                    // Noeud du nom d'un mot
            XmlNode noeudDef = null;                    // Noeud de la définition d'un mot
            List<Mot> listeMots = new List<Mot>();      // Liste de mots dans une seule langue
            Mot motAjoute = null;                       // Mot à ajouter dans la liste
            string abrLangue = null;                    // Abréviation de la langue
            int idUnique = 0;                           // Id unique du mot

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(langue);

            // Obtient la liste des noeuds "Mot"
            listeNoeudsMot = fichierXml.SelectNodes("/vocaquiz/mot");

            // Cherche les mots dans la langue voulue
            foreach (XmlNode noeudMot in listeNoeudsMot)
            {
                // Obtient l'id, le nom et la définition
                idUnique = int.Parse(noeudMot.Attributes["id"].Value);
                noeudNom = noeudMot.SelectSingleNode(abrLangue + "/nom");
                noeudDef = noeudMot.SelectSingleNode(abrLangue + "/definition");

                // Ajoute le mot dans la liste
                motAjoute = new Mot(idUnique, noeudNom.InnerText, noeudDef.InnerText, langue);
                listeMots.Add(motAjoute);
            }

            // Retourne la liste des mots d'une langue
            return listeMots;
        }

        /// <summary>
        /// Permet d'obtenir la liste de mots ayant des traductions
        /// </summary>
        /// <param name="langue">Langue d'origine</param>
        /// <param name="langueTrad">Langue de traduction</param>
        /// <returns>Liste de mots dans la langue d'origine ayant des traductions</returns>
        public override List<Mot> ObtenirMotsAvecTraductionsExistantes(string langue, string langueTraduction)
        {
            XmlNodeList listeNoeudsMots = null;     // Liste de mots dans le fichier Xml
            string nomMotLangue;                    // Nom du mot dans la langue d'origine
            string nomMotLangueTrad;                // Nom du mot dans la langue de traduction
            string abrLangue = null;                // Contient l'abréviation de la langue
            string abrLangueTraduction = null;      // Contient l'abréviation de la langue dans laquelle traduire
            List<Mot> listeMotsValides;             // Contient les mots qui ont une traduction pour les deux langues
            Mot motValide;                          // Mot ayant une traduction pour les deux langues

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(langue);

            // Obtient l'abréviation de la langue de traduction
            abrLangueTraduction = ObtenirAbreviationLangue(langueTraduction);

            // Obtient la liste des traductions à partir du fichier XML
            listeNoeudsMots = fichierXml.SelectNodes("/vocaquiz/mot");

            // Crée une liste de mots dans la langue d'origine ayant des traductions pour la langue de traduction choisie
            listeMotsValides = new List<Mot>();

            // Ajoute les mots valides dans la liste
            foreach (XmlNode noeudMot in listeNoeudsMots)
            {
                // Obtient le nom du mot dans la langue d'origine
                nomMotLangue = noeudMot.SelectSingleNode(abrLangue + "/nom").InnerText;

                // Obtient le nom du mot dans la langue de traduction
                nomMotLangueTrad = noeudMot.SelectSingleNode(abrLangueTraduction + "/nom").InnerText;

                // Vérifie que les mots sont valides
                if (nomMotLangue != "" && nomMotLangueTrad != "")
                {
                    // Ajoute les informations du mot dans un objet "Mot"
                    motValide = new Mot();
                    motValide.IdUnique = int.Parse(noeudMot.Attributes["id"].Value);
                    motValide.Nom = noeudMot.SelectSingleNode(abrLangue + "/nom").InnerText;
                    motValide.Definition = noeudMot.SelectSingleNode(abrLangue + "/definition").InnerText;
                    motValide.Langue = langue;

                    // Ajoute l'objet dans la liste
                    listeMotsValides.Add(motValide);
                }
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
            XmlNodeList listeNoeudsMot = null;     // Liste de noeuds de mots
            XmlNode dernierNoeudMot = null;        // Dernier noeud dans la liste de mots

            // Obtient la liste de noeuds des mots
            listeNoeudsMot = fichierXml.SelectNodes("/vocaquiz/mot");

            // Obtient le noeud du dernier mot
            dernierNoeudMot = listeNoeudsMot[listeNoeudsMot.Count-1];

            // Retourne le nombre de mots
            return int.Parse(dernierNoeudMot.Attributes["id"].Value);
        }

        /// <summary>
        /// Permet d'obtenir un mot par l'index
        /// </summary>
        /// <param name="index">Index d'une liste</param>
        /// <param name="langue">Langue du mot</param>
        /// <returns>Mot correspondant à l'index</returns>
        public override Mot ChercherMotParIndex(int index, string langue)
        {
            XmlNode noeudMot = null;    // Noeud du mot trouvé à l'aide de l'index
            Mot motTrouve = null;       // Mot trouvé
            string abrLangue = null;    // Abréviation de la langue

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(langue);

            // Obtient le noeud du mot à l'index mentionné
            noeudMot = fichierXml.SelectNodes("/vocaquiz/mot")[index];

            // Insère les informations du mot trouvé
            motTrouve = new Mot();
            motTrouve.IdUnique = int.Parse(noeudMot.Attributes["id"].Value);
            motTrouve.Nom = noeudMot.SelectSingleNode(abrLangue + "/nom").InnerText;
            motTrouve.Definition = noeudMot.SelectSingleNode(abrLangue + "/definition").InnerText;
            motTrouve.Langue = langue;

            // Retourne le mot trouvé
            return motTrouve;
        }        /// <summary>

        /// <summary>
        /// Permet de sauvegarder le fichier XML
        /// </summary>
        public override void SauvegarderVoc()
        {
            // Sauvegarde le fichier XML
            fichierXml.Save(repertoire + nomFichier);
        }

        /// <summary>
        /// Permet d'obtenir le noeud d'un mot de n'importe quelle langue
        /// </summary>
        /// <param name="motCherche">Mot recherché</param>
        /// <returns>Noeud du mot recherché</returns>
        private XmlNode _ChercherNoeudMot(Mot motCherche)
        {
            XmlNodeList listeNoeudsMot = null;      // Liste de noeuds mot contenu dans le fichier XML
            XmlNode noeudMotTrouve = null;          // Noeud du mot trouvé
            string abrLangue = null;                // Contient l'abréviation de la langue
            int idUniqueMot = 0;                    // Id unique d'un mot

            // Obtient l'abréviation de la langue
            abrLangue = ObtenirAbreviationLangue(motCherche.Langue);

            // Obtient la liste des mots à partir du fichier XML
            listeNoeudsMot = fichierXml.SelectNodes("/vocaquiz/mot");

            // Recherche le mot dans le fichier XML
            foreach (XmlNode noeudMot in listeNoeudsMot)
            {
                // Obtient l'id
                idUniqueMot = int.Parse(noeudMot.Attributes["id"].Value);

                // Vérifie l'id du mot
                if (idUniqueMot == motCherche.IdUnique)
                    // Sauvegarde le noeud
                    noeudMotTrouve = noeudMot;
            }

            // Retourne le noeud du mot
            return noeudMotTrouve;
        }

        /// <summary>
        /// Permet de générer un Id unique
        /// </summary>
        /// <returns>Id unique</returns>
        private int _GenererIdUnique()
        {
            XmlNodeList listeNoeudsMot = null;      // Liste de noeuds mot
            XmlNode noeudMot = null;                // Noeud du mot
            int nombreMots = 0;                     // Nombre de mots
            int dernierId = 0;                      // Dernier id
            int idGenere = 0;                       // Id généré

            // Obtient la liste de mots
            listeNoeudsMot = fichierXml.SelectNodes("/vocaquiz/mot");

            // Obtient le nombre de mots
            nombreMots = listeNoeudsMot.Count;

            // Calcule l'id
            if (nombreMots > 0)
            {
                // Obtient le dernier mot
                noeudMot = listeNoeudsMot[nombreMots - 1];

                // Obtient l'id
                dernierId = int.Parse(noeudMot.Attributes["id"].Value);

                // Calcule l'id
                idGenere = dernierId + 1;
            }
            else
                idGenere = 0;

            // Retourne l'Id unique
            return idGenere;
        }
    }
}
