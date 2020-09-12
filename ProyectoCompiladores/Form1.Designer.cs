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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 30);
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
            this.btnAnalisisLexico.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnAnalisisLexico.Location = new System.Drawing.Point(311, 116);
            this.btnAnalisisLexico.Name = "btnAnalisisLexico";
            this.btnAnalisisLexico.Size = new System.Drawing.Size(122, 120);
            this.btnAnalisisLexico.TabIndex = 2;
            this.btnAnalisisLexico.Text = "Analisis Lexico";
            this.btnAnalisisLexico.UseVisualStyleBackColor = false;
            this.btnAnalisisLexico.Click += new System.EventHandler(this.btnAnalisisLexico_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(501, 116);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(436, 465);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // lblArchivo
            // 
            this.lblArchivo.AutoSize = true;
            this.lblArchivo.Location = new System.Drawing.Point(688, 30);
            this.lblArchivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblArchivo.Name = "lblArchivo";
            this.lblArchivo.Size = new System.Drawing.Size(0, 20);
            this.lblArchivo.TabIndex = 4;
            // 
            // lblCreado
            // 
            this.lblCreado.AutoSize = true;
            this.lblCreado.Location = new System.Drawing.Point(497, 54);
            this.lblCreado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCreado.Name = "lblCreado";
            this.lblCreado.Size = new System.Drawing.Size(45, 20);
            this.lblCreado.TabIndex = 5;
            this.lblCreado.Text = ".........";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(311, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 112);
            this.button1.TabIndex = 6;
            this.button1.Text = "Analisis Sintactico";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoCompiladores.Properties.Resources.mc;
            this.ClientSize = new System.Drawing.Size(1045, 629);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCreado);
            this.Controls.Add(this.lblArchivo);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnAnalisisLexico);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Button button1;
    }
}

