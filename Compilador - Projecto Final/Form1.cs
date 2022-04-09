using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compilador___Projecto_Final
{
    public partial class Form1 : Form
    {
        private readonly AnalizadorLexico _analizadorLexico;
        private readonly TablaSimbolos _tablaSimbolos;
        private readonly AnalizadorSintactico _analizadorSintactico;
        private readonly AnalizadorSemantico _analizadorSemantico;
        private readonly GeneradorCodigo _generadorCodigo;
        OpenFileDialog openFile = new OpenFileDialog();
        SaveFileDialog saveFile = new SaveFileDialog();

        public Form1()
        {
            InitializeComponent();
            _analizadorLexico = new AnalizadorLexico();
            _tablaSimbolos = new TablaSimbolos();
            _analizadorSintactico = new AnalizadorSintactico();
            _analizadorSemantico = new AnalizadorSemantico();
            _generadorCodigo = new GeneradorCodigo();
            textBox_Output.ScrollBars = ScrollBars.Both;
            textBox_Output.WordWrap = false;
            textBox_Input.ScrollBars = ScrollBars.Both;
            textBox_Input.WordWrap = false;
        }

        private void BTNCOMPILAR_Click(object sender, EventArgs e)
        {

        }

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

            LimpiarTablaSimbolos();
            ImprimirTablaSimbolos(_analizadorSintactico.TablaSimbolos.RegistrosTabla);
            List<string> errores = _analizadorSintactico.ExtraerErroresBloques(bloques);
            if (errores.Count > 0)
            {
                arbolSintax.Nodes.Clear();
                textBox_Output.Text = ArmarErroresSintax(errores);
            }
            else
            {
                textBox_Output.Text = "Análisis sintactico correcto!";
                TreeNode root = null;
                arbolSintax.Nodes.Clear();
                LlenarArbol(ref root, bloquesFlat);
                arbolSintax.Nodes.Add(root);
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
                arbolSintax.Nodes.Clear();
                textBox_Output.Text = ArmarErroresSintax(errores);
            }
            else
            {
                TreeNode root = null;
                arbolSintax.Nodes.Clear();
                LlenarArbol(ref root, bloquesFlat);
                arbolSintax.Nodes.Add(root);

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

                LimpiarTablaSimbolos();
                ImprimirTablaSimbolos(_analizadorSemantico.TablaSimbolos.RegistrosTabla);
            }
        }

        private void BTNCLEAR_Click(object sender, EventArgs e)
        {
            textBox_Input.Text = null;
            textBox_Output.Text = null;
        }
    }
}
