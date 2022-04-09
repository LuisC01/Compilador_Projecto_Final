
namespace Compilador___Projecto_Final
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
            this.BTNCOMPILAR = new System.Windows.Forms.Button();
            this.BTNANALIZADOR_LEXICO = new System.Windows.Forms.Button();
            this.BTNANALIZADORSEMANTICO = new System.Windows.Forms.Button();
            this.BTNANALIZADORSINTACTICO = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BTNCLEAR = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTNCOMPILAR
            // 
            this.BTNCOMPILAR.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNCOMPILAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNCOMPILAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCOMPILAR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTNCOMPILAR.Location = new System.Drawing.Point(29, 9);
            this.BTNCOMPILAR.Name = "BTNCOMPILAR";
            this.BTNCOMPILAR.Size = new System.Drawing.Size(96, 33);
            this.BTNCOMPILAR.TabIndex = 0;
            this.BTNCOMPILAR.Text = "Compilar";
            this.BTNCOMPILAR.UseVisualStyleBackColor = false;
            this.BTNCOMPILAR.Click += new System.EventHandler(this.BTNCOMPILAR_Click);
            // 
            // BTNANALIZADOR_LEXICO
            // 
            this.BTNANALIZADOR_LEXICO.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNANALIZADOR_LEXICO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNANALIZADOR_LEXICO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNANALIZADOR_LEXICO.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTNANALIZADOR_LEXICO.Location = new System.Drawing.Point(157, 10);
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
            this.BTNANALIZADORSEMANTICO.Location = new System.Drawing.Point(345, 10);
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
            this.BTNANALIZADORSINTACTICO.Location = new System.Drawing.Point(540, 10);
            this.BTNANALIZADORSINTACTICO.Name = "BTNANALIZADORSINTACTICO";
            this.BTNANALIZADORSINTACTICO.Size = new System.Drawing.Size(165, 32);
            this.BTNANALIZADORSINTACTICO.TabIndex = 3;
            this.BTNANALIZADORSINTACTICO.Text = "Analizador Sintactico";
            this.BTNANALIZADORSINTACTICO.UseVisualStyleBackColor = false;
            this.BTNANALIZADORSINTACTICO.Click += new System.EventHandler(this.BTNANALIZADORSINTACTICO_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 15);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(680, 150);
            this.dataGridView1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(420, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 333);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(6, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(379, 315);
            this.textBox2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(60, 399);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(692, 171);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tabla de Simbolos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(388, 333);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input";
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.Location = new System.Drawing.Point(6, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(376, 315);
            this.textBox1.TabIndex = 5;
            // 
            // BTNCLEAR
            // 
            this.BTNCLEAR.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BTNCLEAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTNCLEAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNCLEAR.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTNCLEAR.Location = new System.Drawing.Point(711, 9);
            this.BTNCLEAR.Name = "BTNCLEAR";
            this.BTNCLEAR.Size = new System.Drawing.Size(75, 32);
            this.BTNCLEAR.TabIndex = 9;
            this.BTNCLEAR.Text = "Limpiar";
            this.BTNCLEAR.UseVisualStyleBackColor = false;
            this.BTNCLEAR.Click += new System.EventHandler(this.BTNCLEAR_Click);
            // 
            // Form1
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
            this.Controls.Add(this.BTNCOMPILAR);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTNCOMPILAR;
        private System.Windows.Forms.Button BTNANALIZADOR_LEXICO;
        private System.Windows.Forms.Button BTNANALIZADORSEMANTICO;
        private System.Windows.Forms.Button BTNANALIZADORSINTACTICO;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BTNCLEAR;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

