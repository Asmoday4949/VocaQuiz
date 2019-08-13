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
//  Maj : 20.08.2015
//
//  Classe permettant de gérer l'interface principale du programme
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VocaQuiz
{
    public partial class Frm_VocaQuiz : Form
    {
        private GestionnaireVoc gestVoc = null;     // Permet d'obtenir/gérer le vocabulaire dans le fichier XML
        private Quiz quiz = null;                   // Gère le quiz

        public Frm_VocaQuiz()
        {
            // Paramètre les composants de l'interface graphique
            InitializeComponent();

            try
            {
                // Créer un nouveau gestionnaire de vocFrm
                gestVoc = new GestVocXml();
                //gestVoc = new GestVocSql(@"MySql.Data.MySqlClient", @"server=localhost;user=asmoday;database=vocaquiz;port=3306;password=Delain4949;");

                // Créer un nouveau Quiz
                quiz = new Quiz(gestVoc);

                // Ajoute les langues pour les mots et les traductions
                foreach (string langue in gestVoc.ListeLangues)
                {
                    cb_langue_origine.Items.Add(langue);
                    cb_langue_testee.Items.Add(langue);
                }

                // Débloque la configuration du quiz
                pnl_config.Enabled = true;

                // Bloque le quiz
                pnl_quiz.Enabled = false;
            }
            catch (Exception exc)
            {
                // Affiche un message d'erreur
                MessageBox.Show(exc.Message, "Erreur!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Permet de lancer la fenêtre de configuration
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_gestion_voc_Click(object sender, EventArgs e)
        {
            // Créer la fenêtre de configuration et l'affiche
            Frm_GestionVoc frm_gestion_voc = new Frm_GestionVoc(gestVoc);
            frm_gestion_voc.ShowDialog();
        }

        /// <summary>
        /// Permet de lancer la nouvelle séquence
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_lancer_seq_Click(object sender, EventArgs e)
        {
            // Configure le quiz avec les paramètres de l'utilisateur
            quiz.NombreMots = Convert.ToInt32(tb_nombre_mots.Text);
            quiz.Temps = Convert.ToInt32(tb_min_chrono.Text) * 60 + Convert.ToInt32(tb_sec_chrono.Text);
            quiz.LangueOrigine = cb_langue_origine.Text;
            quiz.LangueTrad = cb_langue_testee.Text;

            // Vérifie que la séquence puisse être lancée
            if (cb_langue_origine.Text == "" || cb_langue_testee.Text == "")
            {
                // Impossible de lancer la séquence sans avoir définit les langues
                MessageBox.Show("Une ou plusieurs langues ne sont pas sélectionnées !", "Lancement de séquence impossible", MessageBoxButtons.OK);
            }
            else if (cb_langue_origine.Text == cb_langue_testee.Text)
            {
                // Impossible de lancer la séquence avec deux même langues
                MessageBox.Show("La langue testée est la même que celle d'origine !", "Lancement de séquence impossible", MessageBoxButtons.OK);
            }
            else if ((Convert.ToInt32(tb_min_chrono.Text) == 0 && Convert.ToInt32(tb_sec_chrono.Text) == 0) || Convert.ToInt32(tb_nombre_mots.Text) == 0)
            {
                // Impossible de lancer la séquence car le nombre de mots ou le temps du chrono est incorrect
                MessageBox.Show("Le nombre de mots testé ou le temps de chrono est invalide !", "Lancement de séquence impossible", MessageBoxButtons.OK);
            }
            else if (!quiz.VerifierValiditeVocs())
            {
                // Impossible de lancer la séquence car un des vocabulaires d'une langue semble vide
                MessageBox.Show("Le vocabulaire est certainement inexistant dans une de ces langues", "Lancement de séquence impossible", MessageBoxButtons.OK);
            }
            else
            {
                // Lance une nouvelle séquence
                LancerNouvelleSequence();
            }
        }

        /// <summary>
        /// Permet de lancer une nouvelle séquence
        /// </summary>
        private void LancerNouvelleSequence()
        {
            // Remet à zéro l'affichage du quiz
            InitialiserAffichageQuiz();

            // Bloque la configuration
            pnl_config.Enabled = false;

            // Débloque le quiz
            pnl_quiz.Enabled = true;

            // Initialise le quiz
            quiz.Initialiser();

            // Affiche le nombre de réponses justes ou fausses
            lbl_repCorrectes.Text = "Réponses correctes : " + quiz.NbreRepCorrectes;
            lbl_repFausses.Text = "Réponses fausses : " + quiz.NbreRepFausses;
            lbl_pourcentReussite.Text = "Pourcentage de réussite : -";

            // Choisit et affiche un mot à traduire
            ChoisirAfficherMot();

            // Configure les éléments différemment selon le mode
            if (quiz.Mode == QuizMode.NORMAL)
            {
                // Configure la barre de progression
                pb_chrono_rep.Maximum = quiz.NombreMots;
                pb_chrono_rep.Value = 0;
                lbl_chrono_rep.Text = quiz.CptReponses + "/" + quiz.NombreMots;

                // Bloque/Débloque les boutons
                btn_verifier.Visible = true;
                btn_suivant.Visible = false;
            }
            else if (quiz.Mode == QuizMode.CHRONO)
            {
                // Met à zéro le nombre de mot total
                quiz.NombreMots = 0;

                // Configure la barre de progression
                pb_chrono_rep.Maximum = quiz.Temps;
                pb_chrono_rep.Value = quiz.Temps;
                lbl_chrono_rep.Text = (quiz.Temps / 60) + ":" + (quiz.Temps % 60);

                // Rend invisible le bouton "Vérifier"
                btn_verifier.Visible = false;
                btn_suivant.Visible = true;

                // Lance le chrono
                ti_chrono.Enabled = true;
            }
        }

        /// <summary>
        /// Permet de stopper la séquence en cours
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_stopper_seq_Click(object sender, EventArgs e)
        {
            // Stoppe le chronomètre
            ti_chrono.Enabled = false;

            // Remet à zéro l'affichage du quiz
            InitialiserAffichageQuiz();

            // Débloque la configuration
            pnl_config.Enabled = true;

            // Bloque le quiz
            pnl_quiz.Enabled = false;
        }

        /// <summary>
        /// Permet d'initialiser l'affichage du quiz
        /// </summary>
        private void InitialiserAffichageQuiz()
        {
            // Modifie les boutons accessibles
            btn_verifier.Visible = true;
            btn_suivant.Visible = false;

            // Remet la couleur initiale à la boite de texte
            tb_traduction.BackColor = Color.White;

            // Efface le texte dans les champs
            tb_mot.Text = "";
            tb_mot_def.Text = "";
            tb_traduction.Text = "";
            tb_trad_def.Text = "";

            // Remet à zéro la barre de progression
            pb_chrono_rep.Value = 0;
            lbl_chrono_rep.Text = "";
        }

        /// <summary>
        /// Permet de vérifier la traduction entrée
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_verifier_Click(object sender, EventArgs e)
        {
            string tradUtil = tb_traduction.Text;   // Traduction de l'utilisateur
            Mot traduction = null;                  // Traduction correcte
            bool repCorrecte = false;               // Indique si la traduction est correcte
            
            // Vérifie la traduction de l'utilisateur
            repCorrecte = quiz.VerifierTraduction(tradUtil);
            traduction = quiz.Traduction;

            // Change la couleur de la boîte de texte selon la réponse
            if (repCorrecte)
                tb_traduction.BackColor = Color.Green;
            else
                tb_traduction.BackColor = Color.Red;

            // Affiche la réponse
            tb_traduction.Text = traduction.Nom;
            tb_trad_def.Text = traduction.Definition;

            // Affiche le nombre de réponses justes ou fausses
            lbl_repCorrectes.Text = "Réponses correctes : " + quiz.NbreRepCorrectes;
            lbl_repFausses.Text = "Réponses fausses : " + quiz.NbreRepFausses;

            // Met à jour la barre de progression
            pb_chrono_rep.Value = quiz.CptReponses;
            lbl_chrono_rep.Text = quiz.CptReponses + "/" + quiz.NombreMots;

            // Modifie les boutons accessibles
            btn_verifier.Visible = false;
            btn_suivant.Visible = true;
        }

        /// <summary>
        /// Permet de passer au mot suivant
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void btn_suivant_Click(object sender, EventArgs e)
        {
            string tradUtil = tb_traduction.Text;   // Traduction de l'utilisateur
            Mot motTeste = quiz.MotTeste;           // Mot testé

            // Efface le contenu dans les composants de réponse
            tb_traduction.Text = "";
            tb_trad_def.Text = "";

            // Selon le mode, modifie la barre de progression
            // et la condition de fin de la séquence
            if (quiz.Mode == QuizMode.NORMAL)
            {
                // Met à jour la barre de progression
                pb_chrono_rep.Value = quiz.CptReponses;

                // Modifie les boutons accessibles
                btn_verifier.Visible = true;
                btn_suivant.Visible = false;

                // Remet la couleur initiale à la boite de texte
                tb_traduction.BackColor = Color.White;

                // Choisit un nouveau mot à traduire et l'affiche
                if (quiz.CptReponses != quiz.NombreMots)
                    ChoisirAfficherMot();
                else
                {
                    // Affiche le pourcentage de réussite
                    lbl_pourcentReussite.Text = "Pourcentage de réussite :" + quiz.CalculerPourcentageRepJustes().ToString() + "%";

                    // Débloque la configuration
                    pnl_config.Enabled = true;

                    // Bloque le quiz
                    pnl_quiz.Enabled = false;
                }
            }
            else if (quiz.Mode == QuizMode.CHRONO)
            {
                // Vérifie la traduction de l'utilisateur
                quiz.VerifierTraduction(tradUtil);

                // Affiche le nombre de réponses justes ou fausses
                lbl_repCorrectes.Text = "Réponses correctes : " + quiz.NbreRepCorrectes;
                lbl_repFausses.Text = "Réponses fausses : " + quiz.NbreRepFausses;

                // Incrémente le nombre de mots pour le calcul du pourcentage de réussite
                quiz.NombreMots++;

                // Affiche un nouveau mot à traduire
                ChoisirAfficherMot();
            }
        }

        /// <summary>
        /// Permet de modifier le mode du quiz
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void rb_mode_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb_mode = sender as RadioButton;     // Permet d'obtenir la case à cocher qui a reçu l'événement
            
            // Mode normal coché
            if (rb_mode == rb_normal && rb_normal.Checked)
            {
                tb_nombre_mots.Enabled = true;
                tb_min_chrono.Enabled = false;
                tb_sec_chrono.Enabled = false;
                quiz.Mode = QuizMode.NORMAL;
            }

            // Mode chrono coché
            if (rb_mode == rb_chrono && rb_chrono.Checked)
            {
                tb_nombre_mots.Enabled = false;
                tb_min_chrono.Enabled = true;
                tb_sec_chrono.Enabled = true;
                quiz.Mode = QuizMode.CHRONO;
            }
        }

        /// <summary>
        /// Permet d'obtenir et d'afficher un mot avec sa définition
        /// </summary>
        /// <returns>Mot choisi aléatoirement</returns>
        private void ChoisirAfficherMot()
        {
            Mot motTeste = null;    // Mot testé

            // Choisit un mot de manière aléatoire
            quiz.ChoisirMotAleatoire();
            motTeste = quiz.MotTeste;

            // Affiche le mot et sa définition
            tb_mot.Text = motTeste.Nom;
            tb_mot_def.Text = motTeste.Definition;
        }

        /// <summary>
        /// Met à jour la barre de progression et vérifie que le temps ne soit pas dépassé
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void ti_chrono_Tick(object sender, EventArgs e)
        {
            int tempsRestant;           // Temps restant en secondes
            int pourcentageReussite;    // Pourcentage de réussite  de la séquence

            // Incrémente le temps
            quiz.TempsPasse++;
            
            // Calcule le temps restant et l'affiche
            tempsRestant = quiz.Temps - quiz.TempsPasse;
            lbl_chrono_rep.Text = (tempsRestant / 60) + ":" + (tempsRestant % 60);

            // Met à jour la barre de progression
            pb_chrono_rep.Value = tempsRestant;

            // Vérifie le temps
            if (quiz.TempsPasse >= quiz.Temps)
            {
                // Calcule le pourcentage de réussite (gère le cas de la division par 0)
                try
                {
                    pourcentageReussite = quiz.CalculerPourcentageRepJustes();
                }
                catch(DivideByZeroException zeroExc)
                {
                    pourcentageReussite = 0;
                }

                // Affiche le pourcentage de réussite
                lbl_pourcentReussite.Text = "Pourcentage de réussite :" + pourcentageReussite.ToString() + "%";

                // Débloque la configuration
                pnl_config.Enabled = true;

                // Bloque le quiz
                pnl_quiz.Enabled = false;

                // Stop le chrono
                ti_chrono.Enabled = false;
            }
        }

        /// <summary>
        /// Permet de vérifier la valeur des secondes
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void tb_sec_chrono_TextChanged(object sender, EventArgs e)
        {
            int secondes;       // Nombre de secondes entrée par l'utilisateur

            // Vérifie qu'une valeur est entrée
            if (tb_sec_chrono.Text == string.Empty)
                tb_sec_chrono.Text = Convert.ToString(0);

            // Convertit en nombre
            secondes = Convert.ToInt32(tb_sec_chrono.Text);

            // Vérifie que les secondes soit des valeurs correctes
            if (secondes < 0 || secondes >= 60)
                tb_sec_chrono.Text = Convert.ToString(0);
        }

        /// <summary>
        /// Permet de vérifier la valeur des minutes
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void tb_min_chrono_TextChanged(object sender, EventArgs e)
        {
            // Vérifie qu'une valeur est entrée
            if(tb_min_chrono.Text == string.Empty)
                tb_min_chrono.Text = Convert.ToString(0);
        }

        /// <summary>
        /// Permet de vérifier la valeur entrée pour le nombre de mot
        /// </summary>
        /// <param name="sender">Composant qui a envoyé l'événemenet</param>
        /// <param name="e">Information sur l'événement</param>
        private void tb_nombre_mots_TextChanged(object sender, EventArgs e)
        {
            // Vérifie le nombre de mot
            if (tb_nombre_mots.Text == string.Empty)
                tb_nombre_mots.Text = Convert.ToString(0);
        }
    }
}
