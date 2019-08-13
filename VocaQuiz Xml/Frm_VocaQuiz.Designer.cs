namespace VocaQuiz
{
    partial class Frm_VocaQuiz
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_VocaQuiz));
            this.pnl_quiz = new System.Windows.Forms.Panel();
            this.pb_quiz = new System.Windows.Forms.PictureBox();
            this.lbl_quiz = new System.Windows.Forms.Label();
            this.btn_verifier = new System.Windows.Forms.Button();
            this.tb_trad_def = new System.Windows.Forms.TextBox();
            this.btn_suivant = new System.Windows.Forms.Button();
            this.lbl_reponse = new System.Windows.Forms.Label();
            this.lbl_mot_teste = new System.Windows.Forms.Label();
            this.tb_traduction = new System.Windows.Forms.TextBox();
            this.tb_mot_def = new System.Windows.Forms.TextBox();
            this.tb_mot = new System.Windows.Forms.TextBox();
            this.lbl_chrono_rep = new System.Windows.Forms.Label();
            this.pb_chrono_rep = new System.Windows.Forms.ProgressBar();
            this.rb_normal = new System.Windows.Forms.RadioButton();
            this.tb_min_chrono = new System.Windows.Forms.TextBox();
            this.lbl_temps_chrono = new System.Windows.Forms.Label();
            this.tb_nombre_mots = new System.Windows.Forms.TextBox();
            this.lbl_nombre_mots = new System.Windows.Forms.Label();
            this.rb_chrono = new System.Windows.Forms.RadioButton();
            this.btn_gestion_voc = new System.Windows.Forms.Button();
            this.lbl_langue_testee = new System.Windows.Forms.Label();
            this.cb_langue_testee = new System.Windows.Forms.ComboBox();
            this.lbl_langue_origine = new System.Windows.Forms.Label();
            this.cb_langue_origine = new System.Windows.Forms.ComboBox();
            this.btn_lancer_seq = new System.Windows.Forms.Button();
            this.btn_stopper_seq = new System.Windows.Forms.Button();
            this.ti_chrono = new System.Windows.Forms.Timer(this.components);
            this.lbl_pourcentReussite = new System.Windows.Forms.Label();
            this.lbl_repFausses = new System.Windows.Forms.Label();
            this.lbl_repCorrectes = new System.Windows.Forms.Label();
            this.pnl_config = new System.Windows.Forms.Panel();
            this.lbl_config = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_langues = new System.Windows.Forms.Label();
            this.pnl_mode = new System.Windows.Forms.Panel();
            this.lbl_sec_chrono = new System.Windows.Forms.Label();
            this.lbl_min_chrono = new System.Windows.Forms.Label();
            this.tb_sec_chrono = new System.Windows.Forms.TextBox();
            this.lbl_mode = new System.Windows.Forms.Label();
            this.pnl_statistiques = new System.Windows.Forms.Panel();
            this.lbl_statistiques = new System.Windows.Forms.Label();
            this.pnl_controles = new System.Windows.Forms.Panel();
            this.lbl_controles = new System.Windows.Forms.Label();
            this.pnl_quiz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_quiz)).BeginInit();
            this.pnl_config.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_mode.SuspendLayout();
            this.pnl_statistiques.SuspendLayout();
            this.pnl_controles.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_quiz
            // 
            this.pnl_quiz.BackColor = System.Drawing.Color.White;
            this.pnl_quiz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_quiz.Controls.Add(this.pb_quiz);
            this.pnl_quiz.Controls.Add(this.lbl_quiz);
            this.pnl_quiz.Controls.Add(this.btn_verifier);
            this.pnl_quiz.Controls.Add(this.tb_trad_def);
            this.pnl_quiz.Controls.Add(this.btn_suivant);
            this.pnl_quiz.Controls.Add(this.lbl_reponse);
            this.pnl_quiz.Controls.Add(this.lbl_mot_teste);
            this.pnl_quiz.Controls.Add(this.tb_traduction);
            this.pnl_quiz.Controls.Add(this.tb_mot_def);
            this.pnl_quiz.Controls.Add(this.tb_mot);
            this.pnl_quiz.Controls.Add(this.lbl_chrono_rep);
            this.pnl_quiz.Controls.Add(this.pb_chrono_rep);
            this.pnl_quiz.Location = new System.Drawing.Point(5, 5);
            this.pnl_quiz.Margin = new System.Windows.Forms.Padding(0);
            this.pnl_quiz.Name = "pnl_quiz";
            this.pnl_quiz.Size = new System.Drawing.Size(637, 188);
            this.pnl_quiz.TabIndex = 2;
            // 
            // pb_quiz
            // 
            this.pb_quiz.Image = global::VocaQuiz.Properties.Resources.quiz;
            this.pb_quiz.Location = new System.Drawing.Point(300, 53);
            this.pb_quiz.Name = "pb_quiz";
            this.pb_quiz.Size = new System.Drawing.Size(33, 31);
            this.pb_quiz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_quiz.TabIndex = 16;
            this.pb_quiz.TabStop = false;
            // 
            // lbl_quiz
            // 
            this.lbl_quiz.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_quiz.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_quiz.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_quiz.Location = new System.Drawing.Point(0, -1);
            this.lbl_quiz.Name = "lbl_quiz";
            this.lbl_quiz.Size = new System.Drawing.Size(637, 29);
            this.lbl_quiz.TabIndex = 15;
            this.lbl_quiz.Text = "Quiz";
            this.lbl_quiz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_verifier
            // 
            this.btn_verifier.Location = new System.Drawing.Point(278, 129);
            this.btn_verifier.Name = "btn_verifier";
            this.btn_verifier.Size = new System.Drawing.Size(75, 23);
            this.btn_verifier.TabIndex = 14;
            this.btn_verifier.Text = "Vérifier";
            this.btn_verifier.UseVisualStyleBackColor = true;
            this.btn_verifier.Click += new System.EventHandler(this.btn_verifier_Click);
            // 
            // tb_trad_def
            // 
            this.tb_trad_def.Location = new System.Drawing.Point(432, 103);
            this.tb_trad_def.Multiline = true;
            this.tb_trad_def.Name = "tb_trad_def";
            this.tb_trad_def.ReadOnly = true;
            this.tb_trad_def.Size = new System.Drawing.Size(199, 80);
            this.tb_trad_def.TabIndex = 13;
            // 
            // btn_suivant
            // 
            this.btn_suivant.Location = new System.Drawing.Point(278, 130);
            this.btn_suivant.Name = "btn_suivant";
            this.btn_suivant.Size = new System.Drawing.Size(75, 23);
            this.btn_suivant.TabIndex = 12;
            this.btn_suivant.Text = "Suivant";
            this.btn_suivant.UseVisualStyleBackColor = true;
            this.btn_suivant.Click += new System.EventHandler(this.btn_suivant_Click);
            // 
            // lbl_reponse
            // 
            this.lbl_reponse.AutoSize = true;
            this.lbl_reponse.Location = new System.Drawing.Point(323, 87);
            this.lbl_reponse.Name = "lbl_reponse";
            this.lbl_reponse.Size = new System.Drawing.Size(73, 13);
            this.lbl_reponse.TabIndex = 9;
            this.lbl_reponse.Text = "Votre réponse";
            // 
            // lbl_mot_teste
            // 
            this.lbl_mot_teste.AutoSize = true;
            this.lbl_mot_teste.Location = new System.Drawing.Point(206, 87);
            this.lbl_mot_teste.Name = "lbl_mot_teste";
            this.lbl_mot_teste.Size = new System.Drawing.Size(57, 13);
            this.lbl_mot_teste.TabIndex = 8;
            this.lbl_mot_teste.Text = "Mot testé :";
            // 
            // tb_traduction
            // 
            this.tb_traduction.Location = new System.Drawing.Point(326, 103);
            this.tb_traduction.Name = "tb_traduction";
            this.tb_traduction.Size = new System.Drawing.Size(100, 20);
            this.tb_traduction.TabIndex = 6;
            // 
            // tb_mot_def
            // 
            this.tb_mot_def.Location = new System.Drawing.Point(6, 103);
            this.tb_mot_def.Multiline = true;
            this.tb_mot_def.Name = "tb_mot_def";
            this.tb_mot_def.ReadOnly = true;
            this.tb_mot_def.Size = new System.Drawing.Size(199, 80);
            this.tb_mot_def.TabIndex = 5;
            // 
            // tb_mot
            // 
            this.tb_mot.Location = new System.Drawing.Point(209, 103);
            this.tb_mot.Name = "tb_mot";
            this.tb_mot.Size = new System.Drawing.Size(100, 20);
            this.tb_mot.TabIndex = 4;
            // 
            // lbl_chrono_rep
            // 
            this.lbl_chrono_rep.AutoSize = true;
            this.lbl_chrono_rep.BackColor = System.Drawing.Color.Transparent;
            this.lbl_chrono_rep.Location = new System.Drawing.Point(2, 54);
            this.lbl_chrono_rep.Name = "lbl_chrono_rep";
            this.lbl_chrono_rep.Size = new System.Drawing.Size(13, 13);
            this.lbl_chrono_rep.TabIndex = 3;
            this.lbl_chrono_rep.Text = "--";
            // 
            // pb_chrono_rep
            // 
            this.pb_chrono_rep.BackColor = System.Drawing.SystemColors.Control;
            this.pb_chrono_rep.Location = new System.Drawing.Point(-1, 28);
            this.pb_chrono_rep.Name = "pb_chrono_rep";
            this.pb_chrono_rep.Size = new System.Drawing.Size(637, 23);
            this.pb_chrono_rep.TabIndex = 0;
            // 
            // rb_normal
            // 
            this.rb_normal.AutoSize = true;
            this.rb_normal.Checked = true;
            this.rb_normal.Location = new System.Drawing.Point(24, 34);
            this.rb_normal.Name = "rb_normal";
            this.rb_normal.Size = new System.Drawing.Size(58, 17);
            this.rb_normal.TabIndex = 0;
            this.rb_normal.TabStop = true;
            this.rb_normal.Text = "Normal";
            this.rb_normal.UseVisualStyleBackColor = true;
            this.rb_normal.CheckedChanged += new System.EventHandler(this.rb_mode_CheckedChanged);
            // 
            // tb_min_chrono
            // 
            this.tb_min_chrono.Enabled = false;
            this.tb_min_chrono.Location = new System.Drawing.Point(57, 130);
            this.tb_min_chrono.MaxLength = 2;
            this.tb_min_chrono.Name = "tb_min_chrono";
            this.tb_min_chrono.Size = new System.Drawing.Size(27, 20);
            this.tb_min_chrono.TabIndex = 5;
            this.tb_min_chrono.Text = "2";
            this.tb_min_chrono.TextChanged += new System.EventHandler(this.tb_min_chrono_TextChanged);
            // 
            // lbl_temps_chrono
            // 
            this.lbl_temps_chrono.AutoSize = true;
            this.lbl_temps_chrono.Location = new System.Drawing.Point(54, 116);
            this.lbl_temps_chrono.Name = "lbl_temps_chrono";
            this.lbl_temps_chrono.Size = new System.Drawing.Size(96, 13);
            this.lbl_temps_chrono.TabIndex = 4;
            this.lbl_temps_chrono.Text = "Temps du chrono :";
            // 
            // tb_nombre_mots
            // 
            this.tb_nombre_mots.Location = new System.Drawing.Point(57, 70);
            this.tb_nombre_mots.Name = "tb_nombre_mots";
            this.tb_nombre_mots.Size = new System.Drawing.Size(100, 20);
            this.tb_nombre_mots.TabIndex = 3;
            this.tb_nombre_mots.Text = "10";
            this.tb_nombre_mots.TextChanged += new System.EventHandler(this.tb_nombre_mots_TextChanged);
            // 
            // lbl_nombre_mots
            // 
            this.lbl_nombre_mots.AutoSize = true;
            this.lbl_nombre_mots.Location = new System.Drawing.Point(54, 54);
            this.lbl_nombre_mots.Name = "lbl_nombre_mots";
            this.lbl_nombre_mots.Size = new System.Drawing.Size(121, 13);
            this.lbl_nombre_mots.TabIndex = 2;
            this.lbl_nombre_mots.Text = "Nombre de mots testés :";
            // 
            // rb_chrono
            // 
            this.rb_chrono.AutoSize = true;
            this.rb_chrono.Location = new System.Drawing.Point(24, 96);
            this.rb_chrono.Name = "rb_chrono";
            this.rb_chrono.Size = new System.Drawing.Size(85, 17);
            this.rb_chrono.TabIndex = 1;
            this.rb_chrono.Text = "Chronomètre";
            this.rb_chrono.UseVisualStyleBackColor = true;
            this.rb_chrono.CheckedChanged += new System.EventHandler(this.rb_mode_CheckedChanged);
            // 
            // btn_gestion_voc
            // 
            this.btn_gestion_voc.Location = new System.Drawing.Point(0, 292);
            this.btn_gestion_voc.Name = "btn_gestion_voc";
            this.btn_gestion_voc.Size = new System.Drawing.Size(198, 29);
            this.btn_gestion_voc.TabIndex = 5;
            this.btn_gestion_voc.Text = "Gestion du vocabulaire";
            this.btn_gestion_voc.UseVisualStyleBackColor = true;
            this.btn_gestion_voc.Click += new System.EventHandler(this.btn_gestion_voc_Click);
            // 
            // lbl_langue_testee
            // 
            this.lbl_langue_testee.AutoSize = true;
            this.lbl_langue_testee.Location = new System.Drawing.Point(21, 77);
            this.lbl_langue_testee.Name = "lbl_langue_testee";
            this.lbl_langue_testee.Size = new System.Drawing.Size(75, 13);
            this.lbl_langue_testee.TabIndex = 8;
            this.lbl_langue_testee.Text = "Langue testée";
            // 
            // cb_langue_testee
            // 
            this.cb_langue_testee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_langue_testee.FormattingEnabled = true;
            this.cb_langue_testee.Location = new System.Drawing.Point(21, 93);
            this.cb_langue_testee.Name = "cb_langue_testee";
            this.cb_langue_testee.Size = new System.Drawing.Size(151, 21);
            this.cb_langue_testee.TabIndex = 7;
            // 
            // lbl_langue_origine
            // 
            this.lbl_langue_origine.AutoSize = true;
            this.lbl_langue_origine.Location = new System.Drawing.Point(21, 37);
            this.lbl_langue_origine.Name = "lbl_langue_origine";
            this.lbl_langue_origine.Size = new System.Drawing.Size(85, 13);
            this.lbl_langue_origine.TabIndex = 6;
            this.lbl_langue_origine.Text = "Langue d\'origine";
            // 
            // cb_langue_origine
            // 
            this.cb_langue_origine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_langue_origine.FormattingEnabled = true;
            this.cb_langue_origine.Location = new System.Drawing.Point(21, 53);
            this.cb_langue_origine.Name = "cb_langue_origine";
            this.cb_langue_origine.Size = new System.Drawing.Size(151, 21);
            this.cb_langue_origine.TabIndex = 0;
            // 
            // btn_lancer_seq
            // 
            this.btn_lancer_seq.Location = new System.Drawing.Point(3, 42);
            this.btn_lancer_seq.Name = "btn_lancer_seq";
            this.btn_lancer_seq.Size = new System.Drawing.Size(158, 27);
            this.btn_lancer_seq.TabIndex = 10;
            this.btn_lancer_seq.Text = "Lancer la séquence";
            this.btn_lancer_seq.UseVisualStyleBackColor = true;
            this.btn_lancer_seq.Click += new System.EventHandler(this.btn_lancer_seq_Click);
            // 
            // btn_stopper_seq
            // 
            this.btn_stopper_seq.Location = new System.Drawing.Point(3, 75);
            this.btn_stopper_seq.Name = "btn_stopper_seq";
            this.btn_stopper_seq.Size = new System.Drawing.Size(158, 27);
            this.btn_stopper_seq.TabIndex = 9;
            this.btn_stopper_seq.Text = "Arrêter la séquence";
            this.btn_stopper_seq.UseVisualStyleBackColor = true;
            this.btn_stopper_seq.Click += new System.EventHandler(this.btn_stopper_seq_Click);
            // 
            // ti_chrono
            // 
            this.ti_chrono.Interval = 1000;
            this.ti_chrono.Tick += new System.EventHandler(this.ti_chrono_Tick);
            // 
            // lbl_pourcentReussite
            // 
            this.lbl_pourcentReussite.AutoSize = true;
            this.lbl_pourcentReussite.Location = new System.Drawing.Point(4, 97);
            this.lbl_pourcentReussite.Name = "lbl_pourcentReussite";
            this.lbl_pourcentReussite.Size = new System.Drawing.Size(134, 13);
            this.lbl_pourcentReussite.TabIndex = 19;
            this.lbl_pourcentReussite.Text = "Pourcentage de réussite : -";
            // 
            // lbl_repFausses
            // 
            this.lbl_repFausses.AutoSize = true;
            this.lbl_repFausses.Location = new System.Drawing.Point(4, 61);
            this.lbl_repFausses.Name = "lbl_repFausses";
            this.lbl_repFausses.Size = new System.Drawing.Size(109, 13);
            this.lbl_repFausses.TabIndex = 18;
            this.lbl_repFausses.Text = "Réponses fausses : 0";
            // 
            // lbl_repCorrectes
            // 
            this.lbl_repCorrectes.AutoSize = true;
            this.lbl_repCorrectes.Location = new System.Drawing.Point(4, 42);
            this.lbl_repCorrectes.Name = "lbl_repCorrectes";
            this.lbl_repCorrectes.Size = new System.Drawing.Size(117, 13);
            this.lbl_repCorrectes.TabIndex = 17;
            this.lbl_repCorrectes.Text = "Réponses correctes : 0";
            // 
            // pnl_config
            // 
            this.pnl_config.Controls.Add(this.lbl_config);
            this.pnl_config.Controls.Add(this.btn_gestion_voc);
            this.pnl_config.Controls.Add(this.panel1);
            this.pnl_config.Controls.Add(this.pnl_mode);
            this.pnl_config.Location = new System.Drawing.Point(645, 1);
            this.pnl_config.Name = "pnl_config";
            this.pnl_config.Size = new System.Drawing.Size(228, 322);
            this.pnl_config.TabIndex = 20;
            // 
            // lbl_config
            // 
            this.lbl_config.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_config.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_config.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_config.Image = global::VocaQuiz.Properties.Resources.Config;
            this.lbl_config.Location = new System.Drawing.Point(196, 3);
            this.lbl_config.Name = "lbl_config";
            this.lbl_config.Size = new System.Drawing.Size(29, 316);
            this.lbl_config.TabIndex = 23;
            this.lbl_config.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lbl_langue_testee);
            this.panel1.Controls.Add(this.lbl_langues);
            this.panel1.Controls.Add(this.cb_langue_testee);
            this.panel1.Controls.Add(this.lbl_langue_origine);
            this.panel1.Controls.Add(this.cb_langue_origine);
            this.panel1.Location = new System.Drawing.Point(3, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 133);
            this.panel1.TabIndex = 22;
            // 
            // lbl_langues
            // 
            this.lbl_langues.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_langues.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_langues.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_langues.Location = new System.Drawing.Point(0, 0);
            this.lbl_langues.Name = "lbl_langues";
            this.lbl_langues.Size = new System.Drawing.Size(194, 28);
            this.lbl_langues.TabIndex = 0;
            this.lbl_langues.Text = "Langues";
            this.lbl_langues.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_mode
            // 
            this.pnl_mode.BackColor = System.Drawing.Color.White;
            this.pnl_mode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_mode.Controls.Add(this.lbl_sec_chrono);
            this.pnl_mode.Controls.Add(this.lbl_min_chrono);
            this.pnl_mode.Controls.Add(this.tb_sec_chrono);
            this.pnl_mode.Controls.Add(this.tb_min_chrono);
            this.pnl_mode.Controls.Add(this.lbl_mode);
            this.pnl_mode.Controls.Add(this.lbl_temps_chrono);
            this.pnl_mode.Controls.Add(this.rb_normal);
            this.pnl_mode.Controls.Add(this.tb_nombre_mots);
            this.pnl_mode.Controls.Add(this.rb_chrono);
            this.pnl_mode.Controls.Add(this.lbl_nombre_mots);
            this.pnl_mode.Location = new System.Drawing.Point(3, 3);
            this.pnl_mode.Name = "pnl_mode";
            this.pnl_mode.Size = new System.Drawing.Size(194, 161);
            this.pnl_mode.TabIndex = 21;
            // 
            // lbl_sec_chrono
            // 
            this.lbl_sec_chrono.AutoSize = true;
            this.lbl_sec_chrono.Location = new System.Drawing.Point(141, 134);
            this.lbl_sec_chrono.Name = "lbl_sec_chrono";
            this.lbl_sec_chrono.Size = new System.Drawing.Size(26, 13);
            this.lbl_sec_chrono.TabIndex = 8;
            this.lbl_sec_chrono.Text = "Sec";
            // 
            // lbl_min_chrono
            // 
            this.lbl_min_chrono.AutoSize = true;
            this.lbl_min_chrono.Location = new System.Drawing.Point(85, 134);
            this.lbl_min_chrono.Name = "lbl_min_chrono";
            this.lbl_min_chrono.Size = new System.Drawing.Size(24, 13);
            this.lbl_min_chrono.TabIndex = 7;
            this.lbl_min_chrono.Text = "Min";
            // 
            // tb_sec_chrono
            // 
            this.tb_sec_chrono.Enabled = false;
            this.tb_sec_chrono.Location = new System.Drawing.Point(115, 131);
            this.tb_sec_chrono.MaxLength = 2;
            this.tb_sec_chrono.Name = "tb_sec_chrono";
            this.tb_sec_chrono.Size = new System.Drawing.Size(27, 20);
            this.tb_sec_chrono.TabIndex = 6;
            this.tb_sec_chrono.Text = "0";
            this.tb_sec_chrono.TextChanged += new System.EventHandler(this.tb_sec_chrono_TextChanged);
            // 
            // lbl_mode
            // 
            this.lbl_mode.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_mode.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_mode.Location = new System.Drawing.Point(0, 0);
            this.lbl_mode.Name = "lbl_mode";
            this.lbl_mode.Size = new System.Drawing.Size(194, 29);
            this.lbl_mode.TabIndex = 0;
            this.lbl_mode.Text = "Mode";
            this.lbl_mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_statistiques
            // 
            this.pnl_statistiques.BackColor = System.Drawing.Color.White;
            this.pnl_statistiques.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_statistiques.Controls.Add(this.lbl_statistiques);
            this.pnl_statistiques.Controls.Add(this.lbl_repFausses);
            this.pnl_statistiques.Controls.Add(this.lbl_pourcentReussite);
            this.pnl_statistiques.Controls.Add(this.lbl_repCorrectes);
            this.pnl_statistiques.Location = new System.Drawing.Point(5, 196);
            this.pnl_statistiques.Name = "pnl_statistiques";
            this.pnl_statistiques.Size = new System.Drawing.Size(469, 124);
            this.pnl_statistiques.TabIndex = 23;
            // 
            // lbl_statistiques
            // 
            this.lbl_statistiques.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_statistiques.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_statistiques.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_statistiques.Location = new System.Drawing.Point(0, 0);
            this.lbl_statistiques.Name = "lbl_statistiques";
            this.lbl_statistiques.Size = new System.Drawing.Size(468, 28);
            this.lbl_statistiques.TabIndex = 0;
            this.lbl_statistiques.Text = "Statistiques";
            this.lbl_statistiques.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_controles
            // 
            this.pnl_controles.BackColor = System.Drawing.Color.White;
            this.pnl_controles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_controles.Controls.Add(this.lbl_controles);
            this.pnl_controles.Controls.Add(this.btn_lancer_seq);
            this.pnl_controles.Controls.Add(this.btn_stopper_seq);
            this.pnl_controles.Location = new System.Drawing.Point(476, 196);
            this.pnl_controles.Name = "pnl_controles";
            this.pnl_controles.Size = new System.Drawing.Size(166, 124);
            this.pnl_controles.TabIndex = 24;
            // 
            // lbl_controles
            // 
            this.lbl_controles.BackColor = System.Drawing.Color.SteelBlue;
            this.lbl_controles.Font = new System.Drawing.Font("Comic Sans MS", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_controles.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_controles.Location = new System.Drawing.Point(0, 0);
            this.lbl_controles.Name = "lbl_controles";
            this.lbl_controles.Size = new System.Drawing.Size(165, 28);
            this.lbl_controles.TabIndex = 0;
            this.lbl_controles.Text = "Contrôles";
            this.lbl_controles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_VocaQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 327);
            this.Controls.Add(this.pnl_controles);
            this.Controls.Add(this.pnl_statistiques);
            this.Controls.Add(this.pnl_config);
            this.Controls.Add(this.pnl_quiz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_VocaQuiz";
            this.Text = "VocaQuiz Xml";
            this.pnl_quiz.ResumeLayout(false);
            this.pnl_quiz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_quiz)).EndInit();
            this.pnl_config.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_mode.ResumeLayout(false);
            this.pnl_mode.PerformLayout();
            this.pnl_statistiques.ResumeLayout(false);
            this.pnl_statistiques.PerformLayout();
            this.pnl_controles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_quiz;
        private System.Windows.Forms.RadioButton rb_normal;
        private System.Windows.Forms.RadioButton rb_chrono;
        private System.Windows.Forms.Button btn_gestion_voc;
        private System.Windows.Forms.Label lbl_reponse;
        private System.Windows.Forms.Label lbl_mot_teste;
        private System.Windows.Forms.TextBox tb_traduction;
        private System.Windows.Forms.TextBox tb_mot_def;
        private System.Windows.Forms.TextBox tb_mot;
        private System.Windows.Forms.Label lbl_chrono_rep;
        private System.Windows.Forms.ProgressBar pb_chrono_rep;
        private System.Windows.Forms.TextBox tb_min_chrono;
        private System.Windows.Forms.Label lbl_temps_chrono;
        private System.Windows.Forms.TextBox tb_nombre_mots;
        private System.Windows.Forms.Label lbl_nombre_mots;
        private System.Windows.Forms.Label lbl_langue_testee;
        private System.Windows.Forms.ComboBox cb_langue_testee;
        private System.Windows.Forms.Label lbl_langue_origine;
        private System.Windows.Forms.ComboBox cb_langue_origine;
        private System.Windows.Forms.Button btn_suivant;
        private System.Windows.Forms.TextBox tb_trad_def;
        private System.Windows.Forms.Button btn_lancer_seq;
        private System.Windows.Forms.Button btn_stopper_seq;
        private System.Windows.Forms.Timer ti_chrono;
        private System.Windows.Forms.Label lbl_pourcentReussite;
        private System.Windows.Forms.Label lbl_repFausses;
        private System.Windows.Forms.Label lbl_repCorrectes;
        private System.Windows.Forms.Button btn_verifier;
        private System.Windows.Forms.Panel pnl_config;
        private System.Windows.Forms.Panel pnl_mode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_langues;
        private System.Windows.Forms.Label lbl_mode;
        private System.Windows.Forms.Label lbl_config;
        private System.Windows.Forms.Label lbl_quiz;
        private System.Windows.Forms.Panel pnl_statistiques;
        private System.Windows.Forms.Label lbl_statistiques;
        private System.Windows.Forms.Panel pnl_controles;
        private System.Windows.Forms.Label lbl_controles;
        private System.Windows.Forms.PictureBox pb_quiz;
        private System.Windows.Forms.TextBox tb_sec_chrono;
        private System.Windows.Forms.Label lbl_sec_chrono;
        private System.Windows.Forms.Label lbl_min_chrono;
    }
}

