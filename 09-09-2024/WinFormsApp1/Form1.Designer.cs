namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSalvar = new Button();
            lblValorDaBilheteria = new Label();
            lblQtdLugaresOcupados = new Label();
            lblValorBilheteria = new Label();
            lblQtdLugares = new Label();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(522, 730);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(339, 40);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "SALVAR";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // lblValorDaBilheteria
            // 
            lblValorDaBilheteria.AutoSize = true;
            lblValorDaBilheteria.Location = new Point(40, 749);
            lblValorDaBilheteria.Name = "lblValorDaBilheteria";
            lblValorDaBilheteria.Size = new Size(143, 21);
            lblValorDaBilheteria.TabIndex = 1;
            lblValorDaBilheteria.Text = "Valor da bilheteria: ";
            // 
            // lblQtdLugaresOcupados
            // 
            lblQtdLugaresOcupados.AutoSize = true;
            lblQtdLugaresOcupados.Location = new Point(40, 700);
            lblQtdLugaresOcupados.Name = "lblQtdLugaresOcupados";
            lblQtdLugaresOcupados.Size = new Size(194, 21);
            lblQtdLugaresOcupados.TabIndex = 2;
            lblQtdLugaresOcupados.Text = "Qtde de lugares ocupados:";
            // 
            // lblValorBilheteria
            // 
            lblValorBilheteria.AutoSize = true;
            lblValorBilheteria.Location = new Point(262, 749);
            lblValorBilheteria.Name = "lblValorBilheteria";
            lblValorBilheteria.Size = new Size(90, 21);
            lblValorBilheteria.TabIndex = 3;
            lblValorBilheteria.Text = "R$ 9999,99";
            // 
            // lblQtdLugares
            // 
            lblQtdLugares.AutoSize = true;
            lblQtdLugares.Location = new Point(293, 700);
            lblQtdLugares.Name = "lblQtdLugares";
            lblQtdLugares.Size = new Size(37, 21);
            lblQtdLugares.TabIndex = 4;
            lblQtdLugares.Text = "999";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.ForeColor = Color.White;
            button1.Location = new Point(50, 608);
            button1.Name = "button1";
            button1.Size = new Size(1294, 47);
            button1.TabIndex = 5;
            button1.Text = "TELA";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1028, 700);
            label1.Name = "label1";
            label1.Size = new Size(64, 21);
            label1.TabIndex = 6;
            label1.Text = "Valores:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1122, 700);
            label2.Name = "label2";
            label2.Size = new Size(108, 21);
            label2.TabIndex = 7;
            label2.Text = "A - E : 15 reais";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1122, 721);
            label3.Name = "label3";
            label3.Size = new Size(104, 21);
            label3.TabIndex = 8;
            label3.Text = "F - J : 30 reais";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1122, 742);
            label4.Name = "label4";
            label4.Size = new Size(111, 21);
            label4.TabIndex = 9;
            label4.Text = "K - O : 50 reais";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1377, 789);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(lblQtdLugares);
            Controls.Add(lblValorBilheteria);
            Controls.Add(lblQtdLugaresOcupados);
            Controls.Add(lblValorDaBilheteria);
            Controls.Add(btnSalvar);
            Name = "Form1";
            Text = "Bilheteria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvar;
        private Label lblValorDaBilheteria;
        private Label lblQtdLugaresOcupados;
        private Label lblValorBilheteria;
        private Label lblQtdLugares;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
