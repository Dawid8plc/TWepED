namespace TWepED
{
    partial class Main
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.newWeaponButton = new System.Windows.Forms.Button();
            this.editWeaponButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.removeWeaponButton = new System.Windows.Forms.Button();
            this.weaponItemPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // newWeaponButton
            // 
            this.newWeaponButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newWeaponButton.Location = new System.Drawing.Point(312, 9);
            this.newWeaponButton.Name = "newWeaponButton";
            this.newWeaponButton.Size = new System.Drawing.Size(127, 23);
            this.newWeaponButton.TabIndex = 1;
            this.newWeaponButton.Text = "Create Weapon";
            this.newWeaponButton.UseVisualStyleBackColor = true;
            this.newWeaponButton.Click += new System.EventHandler(this.newWeaponButton_Click);
            // 
            // editWeaponButton
            // 
            this.editWeaponButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editWeaponButton.Location = new System.Drawing.Point(578, 9);
            this.editWeaponButton.Name = "editWeaponButton";
            this.editWeaponButton.Size = new System.Drawing.Size(127, 23);
            this.editWeaponButton.TabIndex = 2;
            this.editWeaponButton.Text = "Edit Weapon";
            this.editWeaponButton.UseVisualStyleBackColor = true;
            this.editWeaponButton.Click += new System.EventHandler(this.editWeaponButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(713, 9);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.bottomPanel.Controls.Add(this.removeWeaponButton);
            this.bottomPanel.Controls.Add(this.newWeaponButton);
            this.bottomPanel.Controls.Add(this.saveButton);
            this.bottomPanel.Controls.Add(this.editWeaponButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 407);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(800, 43);
            this.bottomPanel.TabIndex = 4;
            // 
            // removeWeaponButton
            // 
            this.removeWeaponButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeWeaponButton.Location = new System.Drawing.Point(445, 9);
            this.removeWeaponButton.Name = "removeWeaponButton";
            this.removeWeaponButton.Size = new System.Drawing.Size(127, 23);
            this.removeWeaponButton.TabIndex = 4;
            this.removeWeaponButton.Text = "Remove Weapon";
            this.removeWeaponButton.UseVisualStyleBackColor = true;
            this.removeWeaponButton.Click += new System.EventHandler(this.removeWeaponButton_Click);
            // 
            // weaponItemPanel
            // 
            this.weaponItemPanel.AutoScroll = true;
            this.weaponItemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weaponItemPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.weaponItemPanel.Location = new System.Drawing.Point(0, 0);
            this.weaponItemPanel.Margin = new System.Windows.Forms.Padding(0);
            this.weaponItemPanel.Name = "weaponItemPanel";
            this.weaponItemPanel.Size = new System.Drawing.Size(800, 407);
            this.weaponItemPanel.TabIndex = 5;
            this.weaponItemPanel.WrapContents = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.weaponItemPanel);
            this.Controls.Add(this.bottomPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "TWepED";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button newWeaponButton;
        private System.Windows.Forms.Button editWeaponButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.FlowLayoutPanel weaponItemPanel;
        private System.Windows.Forms.Button removeWeaponButton;
    }
}

