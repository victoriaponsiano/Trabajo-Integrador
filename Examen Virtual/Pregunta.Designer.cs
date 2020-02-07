namespace Examen_Virtual
{
    partial class Pregunta
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
            this.components = new System.ComponentModel.Container();
            this.preg = new System.Windows.Forms.Label();
            this.opcionA = new System.Windows.Forms.RadioButton();
            this.opcionB = new System.Windows.Forms.RadioButton();
            this.opcionC = new System.Windows.Forms.RadioButton();
            this.opcionD = new System.Windows.Forms.RadioButton();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // preg
            // 
            this.preg.AutoSize = true;
            this.preg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preg.Location = new System.Drawing.Point(39, 54);
            this.preg.Name = "preg";
            this.preg.Size = new System.Drawing.Size(16, 20);
            this.preg.TabIndex = 0;
            this.preg.Text = "*";
            // 
            // opcionA
            // 
            this.opcionA.AutoSize = true;
            this.opcionA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionA.Location = new System.Drawing.Point(41, 131);
            this.opcionA.Name = "opcionA";
            this.opcionA.Size = new System.Drawing.Size(14, 13);
            this.opcionA.TabIndex = 1;
            this.opcionA.TabStop = true;
            this.opcionA.UseVisualStyleBackColor = true;
            // 
            // opcionB
            // 
            this.opcionB.AutoSize = true;
            this.opcionB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionB.Location = new System.Drawing.Point(41, 191);
            this.opcionB.Name = "opcionB";
            this.opcionB.Size = new System.Drawing.Size(14, 13);
            this.opcionB.TabIndex = 2;
            this.opcionB.TabStop = true;
            this.opcionB.UseVisualStyleBackColor = true;
            // 
            // opcionC
            // 
            this.opcionC.AutoSize = true;
            this.opcionC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionC.Location = new System.Drawing.Point(41, 259);
            this.opcionC.Name = "opcionC";
            this.opcionC.Size = new System.Drawing.Size(14, 13);
            this.opcionC.TabIndex = 3;
            this.opcionC.TabStop = true;
            this.opcionC.UseVisualStyleBackColor = true;
            // 
            // opcionD
            // 
            this.opcionD.AutoSize = true;
            this.opcionD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opcionD.Location = new System.Drawing.Point(41, 324);
            this.opcionD.Name = "opcionD";
            this.opcionD.Size = new System.Drawing.Size(14, 13);
            this.opcionD.TabIndex = 4;
            this.opcionD.TabStop = true;
            this.opcionD.UseVisualStyleBackColor = true;
            
            // 
            // Pregunta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.opcionD);
            this.Controls.Add(this.opcionC);
            this.Controls.Add(this.opcionB);
            this.Controls.Add(this.opcionA);
            this.Controls.Add(this.preg);
            this.Name = "Pregunta";
            this.Text = "Pregunta";
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label preg;
        private System.Windows.Forms.RadioButton opcionA;
        private System.Windows.Forms.RadioButton opcionB;
        private System.Windows.Forms.RadioButton opcionC;
        private System.Windows.Forms.RadioButton opcionD;
        private System.Windows.Forms.Timer timer;
    }
}