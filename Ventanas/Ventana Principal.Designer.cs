namespace Trabajo_Integrador.Ventanas
{
    partial class Ventana_Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana_Principal));
            this.comenzarExamen = new System.Windows.Forms.Button();
            this.verRanking = new System.Windows.Forms.Button();
            this.admin = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comenzarExamen
            // 
            this.comenzarExamen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.comenzarExamen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comenzarExamen.Location = new System.Drawing.Point(324, 308);
            this.comenzarExamen.Name = "comenzarExamen";
            this.comenzarExamen.Size = new System.Drawing.Size(140, 47);
            this.comenzarExamen.TabIndex = 0;
            this.comenzarExamen.Text = "Comenzar Examen";
            this.comenzarExamen.UseVisualStyleBackColor = false;
            this.comenzarExamen.Click += new System.EventHandler(this.button1_Click);
            // 
            // verRanking
            // 
            this.verRanking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.verRanking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verRanking.Location = new System.Drawing.Point(69, 308);
            this.verRanking.Name = "verRanking";
            this.verRanking.Size = new System.Drawing.Size(140, 47);
            this.verRanking.TabIndex = 1;
            this.verRanking.Text = "Ver Ranking";
            this.verRanking.UseVisualStyleBackColor = false;
            this.verRanking.Click += new System.EventHandler(this.button2_Click);
            // 
            // admin
            // 
            this.admin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.admin.Location = new System.Drawing.Point(555, 308);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(140, 47);
            this.admin.TabIndex = 2;
            this.admin.Text = "Administrador";
            this.admin.UseVisualStyleBackColor = false;
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user.Image = ((System.Drawing.Image)(resources.GetObject("user.Image")));
            this.user.Location = new System.Drawing.Point(69, 32);
            this.user.Name = "user";
            this.user.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.user.Size = new System.Drawing.Size(0, 18);
            this.user.TabIndex = 3;
            // 
            // Ventana_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.user);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.verRanking);
            this.Controls.Add(this.comenzarExamen);
            this.Name = "Ventana_Principal";
            this.Text = "Examen Virtual";
            this.Load += new System.EventHandler(this.Ventana_Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button comenzarExamen;
        private System.Windows.Forms.Button verRanking;
        private System.Windows.Forms.Button admin;
        private System.Windows.Forms.Label user;
    }
}