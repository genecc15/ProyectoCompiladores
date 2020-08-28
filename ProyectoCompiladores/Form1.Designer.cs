namespace ProyectoCompiladores
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAnalisisLexico = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lblArchivo = new System.Windows.Forms.Label();
            this.lblCreado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 36);
            this.textBox1.TabIndex = 0;
            this.textBox1.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnAnalisisLexico
            // 
            this.btnAnalisisLexico.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAnalisisLexico.BackgroundImage")));
            this.btnAnalisisLexico.Location = new System.Drawing.Point(405, 345);
            this.btnAnalisisLexico.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnalisisLexico.Name = "btnAnalisisLexico";
            this.btnAnalisisLexico.Size = new System.Drawing.Size(163, 150);
            this.btnAnalisisLexico.TabIndex = 2;
            this.btnAnalisisLexico.UseVisualStyleBackColor = true;
            this.btnAnalisisLexico.Click += new System.EventHandler(this.btnAnalisisLexico_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(668, 145);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(580, 580);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(918, 37);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(0, 25);
            this.lblArchivo.TabIndex = 4;
            // 
            // lblCreado
            // 
            this.lblCreado.AutoSize = true;
            this.lblCreado.Location = new System.Drawing.Point(663, 67);
            this.lblCreado.Name = "lblCreado";
            this.lblCreado.Size = new System.Drawing.Size(66, 25);
            this.lblCreado.TabIndex = 5;
            this.lblCreado.Text = ".........";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoCompiladores.Properties.Resources.mc;
            this.ClientSize = new System.Drawing.Size(1393, 786);
            this.Controls.Add(this.lblCreado);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnAnalisisLexico);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniJ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnAnalisisLexico;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblArchivo;
        private System.Windows.Forms.Label lblCreado;
    }
}

