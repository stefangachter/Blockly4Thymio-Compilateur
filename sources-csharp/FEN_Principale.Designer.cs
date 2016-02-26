
namespace Blockly4Thymio {
	partial class FEN_Principale {
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent() {
			this.PICTURE_Titre = new System.Windows.Forms.PictureBox();
			this.TEXT_Messages = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.PICTURE_Titre)).BeginInit();
			this.SuspendLayout();
			// 
			// PICTURE_Titre
			// 
			this.PICTURE_Titre.Image = global::Blockly4Thymio.Properties.Resources.logo;
			this.PICTURE_Titre.InitialImage = null;
			this.PICTURE_Titre.Location = new System.Drawing.Point(12, 12);
			this.PICTURE_Titre.Name = "PICTURE_Titre";
			this.PICTURE_Titre.Size = new System.Drawing.Size(756, 105);
			this.PICTURE_Titre.TabIndex = 1;
			this.PICTURE_Titre.TabStop = false;
			// 
			// TEXT_Messages
			// 
			this.TEXT_Messages.AcceptsReturn = true;
			this.TEXT_Messages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(175)))), ((int)(((byte)(218)))));
			this.TEXT_Messages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.TEXT_Messages.CausesValidation = false;
			this.TEXT_Messages.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TEXT_Messages.ForeColor = System.Drawing.Color.White;
			this.TEXT_Messages.Location = new System.Drawing.Point(12, 123);
			this.TEXT_Messages.Multiline = true;
			this.TEXT_Messages.Name = "TEXT_Messages";
			this.TEXT_Messages.ReadOnly = true;
			this.TEXT_Messages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TEXT_Messages.ShortcutsEnabled = false;
			this.TEXT_Messages.Size = new System.Drawing.Size(756, 227);
			this.TEXT_Messages.TabIndex = 2;
			this.TEXT_Messages.TabStop = false;
			// 
			// FEN_Principale
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(175)))), ((int)(((byte)(218)))));
			this.ClientSize = new System.Drawing.Size(780, 358);
			this.Controls.Add(this.TEXT_Messages);
			this.Controls.Add(this.PICTURE_Titre);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FEN_Principale";
			this.ShowIcon = false;
			this.Text = "Blockly4Thymio - Compilateur v<VERSION>";
			this.Load += new System.EventHandler(this.FEN_Principale_Load);
			((System.ComponentModel.ISupportInitialize)(this.PICTURE_Titre)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox PICTURE_Titre;
		private System.Windows.Forms.TextBox TEXT_Messages;
	}
}

