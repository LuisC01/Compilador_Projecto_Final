using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Compilador___Projecto_Final
{
    public partial class Compilador : Form
    {
        private readonly AnalizadorLexico _analizadorLexico;
        private readonly AnalizadorSintactico _analizadorSintactico;
        private readonly AnalizadorSemantico _analizadorSemantico;
        private readonly TablaSimbolos _TablaDeSimbolos;

        public Compilador()
        {
            InitializeComponent();
            _analizadorLexico = new AnalizadorLexico();
            _analizadorSintactico = new AnalizadorSintactico();
            _analizadorSemantico = new AnalizadorSemantico();
            _TablaDeSimbolos = new TablaSimbolos();
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

        private void BTNANALIZADOR_LEXICO_Click(object sender, EventArgs e)
        {
            string codigo = textBox_Input.Text;
            codigo += "\r\n";
            string codigoSinSaltos = _analizadorLexico.RetirarSaltos(codigo);
            List<Lexema> lexemas = _analizadorLexico.ExtraerLexemas(codigoSinSaltos);
            string analisisLex = ArmarResultadoAnalisisLexico(lexemas);
            textBox_Output.Text = analisisLex;
        }

        private void BTNANALIZADORSEMANTICO_Click(object sender, EventArgs e)
        {
            string codigo = textBox_Input.Text;
            codigo += "\r\n";
            string codigoSinSaltos = _analizadorLexico.RetirarSaltos(codigo);
            List<Lexema> lexemas = _analizadorLexico.ExtraerLexemas(codigoSinSaltos);
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
                textBox_Output.Text = ArmarErroresSintax(errores);
            }
            else
            {
                textBox_Output.Text = "Análisis Semantico Completo";
            }
        }

        private void BTNANALIZADORSINTACTICO_Click(object sender, EventArgs e)
        {
            string codigo = textBox_Input.Text;
            codigo += "\r\n";
            string codigoSinSaltos = _analizadorLexico.RetirarSaltos(codigo);
            List<Lexema> lexemas = _analizadorLexico.ExtraerLexemas(codigoSinSaltos);
            int pos = 0;
            List<Bloque> bloques = _analizadorSintactico.RealizarAnalisisSintax(lexemas, ref pos, lexemas.Count);
            bloques.ForEach(y => y.HacersePadre());
            List<Bloque> bloquesFlat = bloques.SelectMany(y => y.BloquesPlanos()).ToList();
            List<string> errores = _analizadorSintactico.ExtraerErroresBloques(bloques);

            if (errores.Count > 0)
            {
                textBox_Output.Text = ArmarErroresSintax(errores);
            }
            else
            {
                _analizadorSemantico.ProcesarLexemas(lexemas, bloques);

                if (_analizadorSemantico.Errores.Count > 0)
                {
                    string erroresSemantic = ArmarErroresSintax(_analizadorSemantico.Errores);
                    textBox_Output.Text = erroresSemantic;
                }
                else
                {
                    textBox_Output.Text = "Análisis Sintactico Completo";
                }

                LimpiarTablaDeSimbolos();
                ImprimirTablaDeSimbolos(_analizadorSemantico.TablaSimbolos.RegistrosTabla);
            }
        }

        private void BTNCLEAR_Click(object sender, EventArgs e)
        {
            textBox_Input.Text = null;
            textBox_Output.Text = null;
            LimpiarTablaDeSimbolos();
        }
    }
}