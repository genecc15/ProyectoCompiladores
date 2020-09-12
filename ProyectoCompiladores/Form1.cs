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
using ProyectoCompiladores.Analisis_Sintactico;

namespace ProyectoCompiladores
{
    public partial class Form1 : Form
    {
        
        loading load;
        public Form1()
        {
            InitializeComponent();
            lblCreado.Visible = false;
        }
        #region boton Lexico
        private async void btnAnalisisLexico_Click(object sender, EventArgs e)
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
                archivo += sr.ReadLine() + "\n";
            }

            #endregion
            Lexer lexer = new Lexer(archivo);
            richTextBox1.Text = string.Empty;
            Show();
            Task oTask = new Task(Loadd);
            oTask.Start();
            await oTask;
            Hide();

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
            lblCreado.Visible = true;
            lblCreado.ForeColor = Color.Green;
            lblCreado.Text = "Archivo de salida " + nombreArchivo + ".out, " + "creado con exito";
            #endregion
        }
        public void Loadd()
        {
            Thread.Sleep(2000);
        }
        public void Show()
        {
            load = new loading();
            load.Show();
        }
        public void Hide()
        {
            if (load != null)
            {
                load.Close();
            }
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;

            richTextBox1.Text = string.Empty;
            try
            {
                Lexer lexer = new Lexer(text);
                Parser p = new Parser(lexer);
                p.parseProgram();
                richTextBox1.Text = "Programa analizado correctamente";
            }catch(Exception ex)
            {
                richTextBox1.Text = ex.Message;
            }

            //Ignora esta parte ya no me dio tiempo hacer que funcionara la lectura de archivos
            #region Variables y lectura 
            //string path = "";
            //string archivo2 = "";
            //string nombreArchivo = "";
            //string ext = "";
            //OpenFileDialog ofd = new OpenFileDialog();
            //StringBuilder textB = new StringBuilder();
            //FolderBrowserDialog fbd = new FolderBrowserDialog();

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    path = ofd.FileName;
            //}


            //ext = Path.GetExtension(path);
            //nombreArchivo = Path.GetFileName(path).Replace(ext, "");
            //StreamReader sr = new StreamReader(path);
            //while (!sr.EndOfStream)
            //{
            //    archivo2 += sr.ReadLine() + "\n";
            //}

            //#endregion
            //Lexer lexer2 = new Lexer(archivo2);
            //#region EscrituraArchivo   
            //richTextBox1.Text = string.Empty;
            //try
            //{
            //    Parser p = new Parser(lexer2);
            //    p.parseProgram();
            //    richTextBox1.Text = "Programa analizado correctamente";
            //}
            //catch (Exception ex)
            //{
            //    richTextBox1.Text = ex.Message;
            //}

            //richTextBox1.Text = textB.ToString();
            //lblCreado.Visible = true;
            //lblCreado.ForeColor = Color.Green;
            //lblCreado.Text = "Archivo analizado";
            #endregion
        }
    }
}
