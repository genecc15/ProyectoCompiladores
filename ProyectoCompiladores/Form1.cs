using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCompiladores.Tokens;
using ProyectoCompiladores.Analisis_Lexico;
using System.Threading;
using System.IO;
using ProyectoCompis.Analisis_Lexico;

namespace ProyectoCompiladores
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAnalisisLexico_Click(object sender, EventArgs e)
        {
            //agregué esto
            #region Variables y lectura
            string path = "";
            string path2 = "";
            string archivo = "";
            string nombreArchivo = "";
            string ext = "";
            OpenFileDialog ofd = new OpenFileDialog();
            StringBuilder textB = new StringBuilder();
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
            }
            ext = Path.GetExtension(path);
            nombreArchivo = Path.GetFileName(path).Replace(ext, "");
            StreamReader sr = new StreamReader(path);
            while (!sr.EndOfStream)
            {
                archivo += sr.ReadLine();
            }
            #endregion
            Lexer lexer = new Lexer(archivo);
            richTextBox1.Text = string.Empty;
            //y esto
            #region EscrituraArchivo            
            if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                path2 = fbd.SelectedPath;
            }
            StreamWriter sw = new StreamWriter(path2 + "/" + nombreArchivo + ".out");

            foreach (var token in lexer.TokensFilteredInfo)
            {
                textB.Append(token + "\n");
                sw.WriteLine(token + "\n");
            }
            sw.Close();
            richTextBox1.Text = textB.ToString();
            MessageBox.Show("Archivo de salida " + nombreArchivo + ".out, " + "creado con exito");
            #endregion
        }
    }
}
