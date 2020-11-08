namespace TWepED
{
    partial class WeaponItem
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.weaponTypePicture = new System.Windows.Forms.PictureBox();
            this.weaponNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.weaponTypePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // weaponTypePicture
            // 
            this.weaponTypePicture.Image = global::TWepED.Properties.Resources.bazooka;
            this.weaponTypePicture.Location = new System.Drawing.Point(5, 5);
            this.weaponTypePicture.Name = "weaponTypePicture";
            this.weaponTypePicture.Size = new System.Drawing.Size(64, 64);
            this.weaponTypePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.weaponTypePicture.TabIndex = 0;
            this.weaponTypePicture.TabStop = false;
            // 
            // weaponNameLabel
            // 
            this.weaponNameLabel.AutoSize = true;
            this.weaponNameLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.weaponNameLabel.Location = new System.Drawing.Point(73, 27);
            this.weaponNameLabel.Name = "weaponNameLabel";
            this.weaponNameLabel.Size = new System.Drawing.Size(96, 23);
            this.weaponNameLabel.TabIndex = 1;
            this.weaponNameLabel.Text = "Metheorite";
            // 
            // WeaponItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.Controls.Add(this.weaponNameLabel);
            this.Controls.Add(this.weaponTypePicture);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WeaponItem";
            this.Size = new System.Drawing.Size(800, 74);
            this.Load += new System.EventHandler(this.WeaponItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.weaponTypePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox weaponTypePicture;
        public System.Windows.Forms.Label weaponNameLabel;
    }
}
