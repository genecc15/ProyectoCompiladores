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
using ProyectoCompiladores.Analisis_Lexico;
using System.Collections;

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

            //declarar la clase slr 
            Slr metodoSlr = new Slr();
            List<string> lista = new List<string>();

            foreach (var token in lexer.TokensFilteredInfo)
            {
                textB.Append(token + "\n");
                sw.WriteLine(token + "\n");
                lista.Add(token.ToString());
            }

            //convertir lista en pila para enviarla a clase analisis slr
            Stack pilaEntrada = new Stack();
            lista.Reverse();
            foreach(var s in lista)
            {
                pilaEntrada.Push(s);
            }
            metodoSlr.entrada = pilaEntrada;

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
    }
}
