
namespace Compilador___Projecto_Final
{
    partial class Compilador
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
            this.BTNANALIZADOR_LEXICO = new System.Windows.Forms.Button();
            this.BTNANALIZADORSEMANTICO = new System.Windows.Forms.Button();
            this.BTNANALIZADORSINTACTICO = new System.Windows.Forms.Button();
            this.dataGripTablaDeSimbolos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Output = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.BTNCLEAR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGripTablaDeSimbolos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTNANALIZADOR_LEXICO
            // 
            this.BTNANALIZADOR_LEXICO.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNANALIZADOR_LEXICO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNANALIZADOR_LEXICO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNANALIZADOR_LEXICO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTNANALIZADOR_LEXICO.Location = new System.Drawing.Point(110, 12);
            this.BTNANALIZADOR_LEXICO.Name = "BTNANALIZADOR_LEXICO";
            this.BTNANALIZADOR_LEXICO.Size = new System.Drawing.Size(159, 31);
            this.BTNANALIZADOR_LEXICO.TabIndex = 1;
            this.BTNANALIZADOR_LEXICO.Text = "Analizador Lexico";
            this.BTNANALIZADOR_LEXICO.UseVisualStyleBackColor = false;
            this.BTNANALIZADOR_LEXICO.Click += new System.EventHandler(this.BTNANALIZADOR_LEXICO_Click);
            // 
            // BTNANALIZADORSEMANTICO
            // 
            this.BTNANALIZADORSEMANTICO.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNANALIZADORSEMANTICO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNANALIZADORSEMANTICO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNANALIZADORSEMANTICO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTNANALIZADORSEMANTICO.Location = new System.Drawing.Point(308, 12);
            this.BTNANALIZADORSEMANTICO.Name = "BTNANALIZADORSEMANTICO";
            this.BTNANALIZADORSEMANTICO.Size = new System.Drawing.Size(171, 31);
            this.BTNANALIZADORSEMANTICO.TabIndex = 2;
            this.BTNANALIZADORSEMANTICO.Text = "Analizador Semantico";
            this.BTNANALIZADORSEMANTICO.UseVisualStyleBackColor = false;
            this.BTNANALIZADORSEMANTICO.Click += new System.EventHandler(this.BTNANALIZADORSEMANTICO_Click);
            // 
            // BTNANALIZADORSINTACTICO
            // 
            this.BTNANALIZADORSINTACTICO.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNANALIZADORSINTACTICO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNANALIZADORSINTACTICO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNANALIZADORSINTACTICO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTNANALIZADORSINTACTICO.Location = new System.Drawing.Point(519, 12);
            this.BTNANALIZADORSINTACTICO.Name = "BTNANALIZADORSINTACTICO";
            this.BTNANALIZADORSINTACTICO.Size = new System.Drawing.Size(165, 32);
            this.BTNANALIZADORSINTACTICO.TabIndex = 3;
            this.BTNANALIZADORSINTACTICO.Text = "Analizador Sintactico";
            this.BTNANALIZADORSINTACTICO.UseVisualStyleBackColor = false;
            this.BTNANALIZADORSINTACTICO.Click += new System.EventHandler(this.BTNANALIZADORSINTACTICO_Click);
            // 
            // dataGripTablaDeSimbolos
            // 
            this.dataGripTablaDeSimbolos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGripTablaDeSimbolos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Variable,
            this.Tipo,
            this.Valor});
            this.dataGripTablaDeSimbolos.Location = new System.Drawing.Point(6, 15);
            this.dataGripTablaDeSimbolos.Name = "dataGripTablaDeSimbolos";
            this.dataGripTablaDeSimbolos.Size = new System.Drawing.Size(680, 150);
            this.dataGripTablaDeSimbolos.TabIndex = 5;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Variable
            // 
            this.Variable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Variable.HeaderText = "Variable";
            this.Variable.Name = "Variable";
            this.Variable.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Output);
            this.groupBox1.Location = new System.Drawing.Point(420, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 333);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // textBox_Output
            // 
            this.textBox_Output.Location = new System.Drawing.Point(6, 12);
            this.textBox_Output.Multiline = true;
            this.textBox_Output.Name = "textBox_Output";
            this.textBox_Output.Size = new System.Drawing.Size(379, 315);
            this.textBox_Output.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGripTablaDeSimbolos);
            this.groupBox2.Location = new System.Drawing.Point(60, 399);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(692, 171);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tabla de Simbolos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_Input);
            this.groupBox3.Location = new System.Drawing.Point(12, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 333);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input";
            // 
            // textBox_Input
            // 
            this.textBox_Input.AcceptsReturn = true;
            this.textBox_Input.Location = new System.Drawing.Point(6, 12);
            this.textBox_Input.Multiline = true;
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(376, 315);
            this.textBox_Input.TabIndex = 5;
            // 
            // BTNCLEAR
            // 
            this.BTNCLEAR.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNCLEAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNCLEAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCLEAR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTNCLEAR.Location = new System.Drawing.Point(716, 11);
            this.BTNCLEAR.Name = "BTNCLEAR";
            this.BTNCLEAR.Size = new System.Drawing.Size(75, 32);
            this.BTNCLEAR.TabIndex = 9;
            this.BTNCLEAR.Text = "Limpiar";
            this.BTNCLEAR.UseVisualStyleBackColor = false;
            this.BTNCLEAR.Click += new System.EventHandler(this.BTNCLEAR_Click);
            // 
            // Compilador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 577);
            this.Controls.Add(this.BTNCLEAR);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BTNANALIZADORSINTACTICO);
            this.Controls.Add(this.BTNANALIZADORSEMANTICO);
            this.Controls.Add(this.BTNANALIZADOR_LEXICO);
            this.Name = "Compilador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compilador";
            ((System.ComponentModel.ISupportInitialize)(this.dataGripTablaDeSimbolos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BTNANALIZADOR_LEXICO;
        private System.Windows.Forms.Button BTNANALIZADORSEMANTICO;
        private System.Windows.Forms.Button BTNANALIZADORSINTACTICO;
        private System.Windows.Forms.DataGridView dataGripTablaDeSimbolos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BTNCLEAR;
        private System.Windows.Forms.TextBox textBox_Output;
        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
    }
}

