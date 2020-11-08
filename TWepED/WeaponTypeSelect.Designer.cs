namespace TWepED
{
    partial class WeaponTypeSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeaponTypeSelect));
            this.bazookaTypeImage = new System.Windows.Forms.PictureBox();
            this.grenadeTypeImage = new System.Windows.Forms.PictureBox();
            this.airstrikeTypeImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bazookaTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grenadeTypeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.airstrikeTypeImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bazookaTypeImage
            // 
            this.bazookaTypeImage.Image = global::TWepED.Properties.Resources.bazooka;
            this.bazookaTypeImage.Location = new System.Drawing.Point(13, 61);
            this.bazookaTypeImage.Name = "bazookaTypeImage";
            this.bazookaTypeImage.Size = new System.Drawing.Size(128, 128);
            this.bazookaTypeImage.TabIndex = 0;
            this.bazookaTypeImage.TabStop = false;
            this.bazookaTypeImage.Click += new System.EventHandler(this.bazookaTypeImage_Click);
            // 
            // grenadeTypeImage
            // 
            this.grenadeTypeImage.Image = global::TWepED.Properties.Resources.grenade;
            this.grenadeTypeImage.Location = new System.Drawing.Point(154, 61);
            this.grenadeTypeImage.Name = "grenadeTypeImage";
            this.grenadeTypeImage.Size = new System.Drawing.Size(128, 128);
            this.grenadeTypeImage.TabIndex = 1;
            this.grenadeTypeImage.TabStop = false;
            this.grenadeTypeImage.Click += new System.EventHandler(this.grenadeTypeImage_Click);
            // 
            // airstrikeTypeImage
            // 
            this.airstrikeTypeImage.Image = global::TWepED.Properties.Resources.airstrike;
            this.airstrikeTypeImage.Location = new System.Drawing.Point(294, 61);
            this.airstrikeTypeImage.Name = "airstrikeTypeImage";
            this.airstrikeTypeImage.Size = new System.Drawing.Size(128, 128);
            this.airstrikeTypeImage.TabIndex = 2;
            this.airstrikeTypeImage.TabStop = false;
            this.airstrikeTypeImage.Click += new System.EventHandler(this.airstrikeTypeImage_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(95)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 47);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Weapon Type";
            // 
            // WeaponTypeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 208);
            this.Controls.Add(this.airstrikeTypeImage);
            this.Controls.Add(this.grenadeTypeImage);
            this.Controls.Add(this.bazookaTypeImage);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WeaponTypeSelect";
            this.Text = "Create a new Weapon";
            ((System.ComponentModel.ISupportInitialize)(this.bazookaTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grenadeTypeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.airstrikeTypeImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bazookaTypeImage;
        private System.Windows.Forms.PictureBox grenadeTypeImage;
        private System.Windows.Forms.PictureBox airstrikeTypeImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}