using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador___Projecto_Final
{
    public partial class Form1 : Form
    {
        private readonly AnalizadorLexico _analizadorLexico;
        private readonly TablaSimbolos _TablaDeSimbolos;
        private readonly AnalizadorSintactico _analizadorSintactico;
        private readonly AnalizadorSemantico _analizadorSemantico;
        private readonly GeneradorCodigo _generadorCodigo;

        public Form1()
        {
            InitializeComponent();
            _analizadorLexico = new AnalizadorLexico();
            _TablaDeSimbolos = new TablaSimbolos();
            _analizadorSintactico = new AnalizadorSintactico();
            _analizadorSemantico = new AnalizadorSemantico();
            _generadorCodigo = new GeneradorCodigo();
            textBox_Output.ScrollBars = ScrollBars.Both;
            textBox_Output.WordWrap = false;
            textBox_Input.ScrollBars = ScrollBars.Both;
            textBox_Input.WordWrap = false;
        }

        private string ArmarResultadoAnalisisLexico(List<Lexema> lexemas)
        {
            string result = "";

            foreach (Lexema lexema in lexemas)
            {
                if (lexema.TipoElemento != Enums.TipoElemento.Error)
                {
                    result += "Lexema: [" + lexema.Texto + "] del tipo: " + lexema.TipoElemento + " \r\n";
                }
                else
                {
                    result += "Lexema: [" + lexema.Texto + "] Error: " + lexema.MensajeError + "  \r\n";
                }
            }

            return result;
        }

        private string ArmarErroresSintax(List<string> list)
        {
            string result = "Se detectaron los siguientes errores: \r\n";
            foreach (string error in list)
            {
                result = result + error + "\r\n";
            }

            return result;
        }

        public void LlenarArbol(ref TreeNode root, List<Bloque> bloquesTotales)
        {
            if (root == null)
            {
                root = new TreeNode();
                root.Text = "Programa";
                root.Tag = null;
                // Todos los nodos cuyo padre no es nulo
                var bloques = bloquesTotales.Where(t => t.BloquePadre == null);
                foreach (var bloque in bloques)
                {
                    var child = new TreeNode()
                    {
                        Text = string.Join(" ", bloque.Lexemas.Select(y => y.Texto)),
                        Tag = bloque.Incia
                    };
                    LlenarArbol(ref child, bloquesTotales);
                    root.Nodes.Add(child);
                }
            }
            else
            {
                var id = (int)root.Tag;
                var bloques = bloquesTotales.Where(t => t.BloquePadre != null && t.BloquePadre.Incia == id);
                foreach (var bloque in bloques)
                {
                    var child = new TreeNode()
                    {
                        Text = string.Join(" ", bloque.Lexemas.Select(y => y.Texto)),
                        Tag = bloque.Incia
                    };
                    LlenarArbol(ref child, bloquesTotales);
                    root.Nodes.Add(child);
                }
            }
        }

        private void ImprimirTablaDeSimbolos(List<RegistroTabla> registros)
        {
            foreach (RegistroTabla registroTabla in registros)
            {
                int rowId = dataGripTablaDeSimbolos.Rows.Add();

                DataGridViewRow row = dataGripTablaDeSimbolos.Rows[rowId];

                row.Cells["Codigo"].Value = registroTabla.Codigo;
                row.Cells["Variable"].Value = registroTabla.Nombre;
                row.Cells["Tipo"].Value = registroTabla.TipoVariable;
                row.Cells["Valor"].Value = registroTabla.Valor;
            }
        }

        private void LimpiarTablaDeSimbolos()
        {
            dataGripTablaDeSimbolos.Rows.Clear();
        }

        private static string GetPathLibrearia()
        {
            string parentOfStartupPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"../../"));
            parentOfStartupPath = Path.Combine(parentOfStartupPath, @"libreriaC");
            return parentOfStartupPath;
        }

        private static string GetPathGcc()
        {
            string path = Path.Combine(GetPathLibrearia(), @"bin");
            return path;
        }

        private void GenerarAsm()
        {
            string pathGcc = GetPathGcc(); // Example of location
            var process = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = pathGcc,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            process.StartInfo = startInfo;
            process.Start();
            process.StandardInput.WriteLine("gcc -S temp.c");
        }

        public void LeerAsm(string path)
        {
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string texto = r.ReadToEnd();
                    textBox_Output.Text = texto;
                }

                textBox_Output.Text = textBox_Output.Text.Replace("GCC: (MinGW.org GCC-6.3.0-1) 6.3.0",
                    "Universidad Don Bosco Compiladores Ciclo 2 2017");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo: " + ex.Message);
            }
        }

        private string FormatearCuadroTexto()
        {
            string texto = "int main() {" + textBox_Input.Text + " return 0; }";
            return texto;
        }

        private void cuadroTexto_TextChanged(object sender, EventArgs e) { }

        private void textBox_Output_TextChanged(object sender, EventArgs e) { }

        private void arbolSintax_AfterSelect(object sender, TreeViewEventArgs e) { }

        private void tablaSimbolos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void BTNANALIZADOR_LEXICO_Click(object sender, EventArgs e)
        {
            string codigo = textBox_Input.Text;
            codigo += "\r\n";
            string codigoSinComent = _analizadorLexico.RetirarComentarios(codigo);
            string codigoSinSaltos = _analizadorLexico.RetirarSaltos(codigoSinComent);
            List<Lexema> lexemas = _analizadorLexico.ExtraerLexemas(codigoSinSaltos);
            string analisisLex = ArmarResultadoAnalisisLexico(lexemas);
            textBox_Output.Text = analisisLex;
        }

        private void BTNANALIZADORSEMANTICO_Click(object sender, EventArgs e)
        {
            string codigo = textBox_Input.Text;
            codigo += "\r\n";
            string codigoSinComent = _analizadorLexico.RetirarComentarios(codigo);
            string codigoSinSaltos = _analizadorLexico.RetirarSaltos(codigoSinComent);
            List<Lexema> lexemas = _analizadorLexico.ExtraerLexemas(codigoSinSaltos);

            //Construir la tabla de simbolos
            _analizadorSintactico.ConstruirTablaSimbolos(lexemas);

            int pos = 0;

            List<Bloque> bloques = _analizadorSintactico.RealizarAnalisisSintax(lexemas, ref pos, lexemas.Count);
            bloques.ForEach(y => y.HacersePadre());
            List<Bloque> bloquesFlat = bloques.SelectMany(y => y.BloquesPlanos()).ToList();

            LimpiarTablaDeSimbolos();
            ImprimirTablaDeSimbolos(_analizadorSintactico.TablaSimbolos.RegistrosTabla);
            List<string> errores = _analizadorSintactico.ExtraerErroresBloques(bloques);
            if (errores.Count > 0)
            {
               // arbolSintax.Nodes.Clear();
                textBox_Output.Text = ArmarErroresSintax(errores);
            }
            else
            {
                textBox_Output.Text = "Análisis sintactico correcto!";
                TreeNode root = null;
                //arbolSintax.Nodes.Clear();
                LlenarArbol(ref root, bloquesFlat);
                //arbolSintax.Nodes.Add(root);
            }
        }

        private void BTNANALIZADORSINTACTICO_Click(object sender, EventArgs e)
        {
            string codigo = textBox_Input.Text;
            codigo += "\r\n";
            string codigoSinComent = _analizadorLexico.RetirarComentarios(codigo);
            string codigoSinSaltos = _analizadorLexico.RetirarSaltos(codigoSinComent);
            List<Lexema> lexemas = _analizadorLexico.ExtraerLexemas(codigoSinSaltos);

            int pos = 0;

            List<Bloque> bloques = _analizadorSintactico.RealizarAnalisisSintax(lexemas, ref pos, lexemas.Count);
            bloques.ForEach(y => y.HacersePadre());
            List<Bloque> bloquesFlat = bloques.SelectMany(y => y.BloquesPlanos()).ToList();

            List<string> errores = _analizadorSintactico.ExtraerErroresBloques(bloques);
            if (errores.Count > 0)
            {
                //arbolSintax.Nodes.Clear();
                textBox_Output.Text = ArmarErroresSintax(errores);
            }
            else
            {
                TreeNode root = null;
                //arbolSintax.Nodes.Clear();
                LlenarArbol(ref root, bloquesFlat);
                //arbolSintax.Nodes.Add(root);

                //Desde aca se hace el analisis semantico
                _analizadorSemantico.ProcesarLexemas(lexemas, bloques);

                if (_analizadorSemantico.Errores.Count > 0)
                {
                    string erroresSemantic = ArmarErroresSintax(_analizadorSemantico.Errores);
                    textBox_Output.Text = erroresSemantic;

                }
                else
                {
                    textBox_Output.Text = "Analisis semantico correcto";
                }

                LimpiarTablaDeSimbolos();
                ImprimirTablaDeSimbolos(_analizadorSemantico.TablaSimbolos.RegistrosTabla);
            }
        }

        private void BTNCLEAR_Click(object sender, EventArgs e)
        {
            textBox_Input.Text = null;
            textBox_Output.Text = null;
            dataGripTablaDeSimbolos.Rows.Clear();
        }
    }
}
