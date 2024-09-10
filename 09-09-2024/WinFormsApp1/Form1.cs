using System;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private CheckBox[,] poltronas;
        private string fileName = "poltronas_reservadas.txt";
        private string filePath;
        private int qtdLugaresOcupados = 0;
        private double valorTotalDaBilheteria = 0;
        private int[] valoresDasPoltronas = { 15, 15, 15, 15, 15, 30, 30, 30, 30, 30, 50, 50, 50, 50, 50 };

        public Form1()
        {
            InitializeComponent();
            InitializeMyComponents();
            this.FormBorderStyle = FormBorderStyle.FixedDialog; 
            this.MaximizeBox = false; 
        }

        private void InitializeMyComponents()
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
            poltronas = new CheckBox[15, 40];

            int checkBoxSize = 30;
            int padding = 2;
            int labelOffset = 30; 

            string[] lines = File.Exists(filePath) ? File.ReadAllLines(filePath) : null;
            int qtdLines = 0;

   
            for (int j = 0; j < 40; j++)
            {
                Label lblColuna = new Label();
                lblColuna.Text = (j + 1).ToString();
                lblColuna.Size = new System.Drawing.Size(checkBoxSize, checkBoxSize);
                lblColuna.Location = new System.Drawing.Point(labelOffset + (j + 1) * (checkBoxSize + padding), labelOffset - (checkBoxSize + padding)); 
                this.Controls.Add(lblColuna);
            }

      
            for (int i = 0; i < 15; i++)
            {
                Label lblFileira = new Label();
                lblFileira.Text = ((char)('A' + i)).ToString();
                lblFileira.Size = new System.Drawing.Size(checkBoxSize, checkBoxSize);
                lblFileira.Location = new System.Drawing.Point(labelOffset - (checkBoxSize + padding) + 20, labelOffset + (i + 1) * (checkBoxSize + padding)); 
                this.Controls.Add(lblFileira);
            }

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    bool isReserved = lines != null && lines.Length > qtdLines && lines[qtdLines] == "#";
                    InicializarPoltrona(i, j, checkBoxSize, padding, labelOffset, isReserved);

                    qtdLines++;
                }
            }

            if (lines == null)
            {
                Console.WriteLine($"Arquivo '{fileName}' criado com sucesso.");
                File.WriteAllText(filePath, "");
            }

            lblValorBilheteria.Text = "R$ " + valorTotalDaBilheteria.ToString() + " reais";
            lblQtdLugares.Text = qtdLugaresOcupados.ToString();
        }


        private void InicializarPoltrona(int i, int j, int checkBoxSize, int padding, int labelOffset, bool isReserved)
        {
            poltronas[i, j] = new CheckBox();
            poltronas[i, j].Tag = new Tuple<int, int>(i, j);
            poltronas[i, j].Size = new System.Drawing.Size(checkBoxSize, checkBoxSize);
            poltronas[i, j].Location = new System.Drawing.Point(labelOffset + (j + 1) * (checkBoxSize + padding), labelOffset + (i + 1) * (checkBoxSize + padding)); 
            poltronas[i, j].Click += new EventHandler(checkBoxPoltrona_Click);
            poltronas[i, j].Checked = isReserved;

            if (isReserved)
            {
                qtdLugaresOcupados++;
                valorTotalDaBilheteria += valoresDasPoltronas[i];
            }

            this.Controls.Add(poltronas[i, j]);
        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < 15; i++)
                {
                    for (int j = 0; j < 40; j++)
                    {
                        writer.Write(poltronas[i, j].Checked ? "#" : ".");
                        writer.WriteLine();
                    }
                }
            }

            setLabels();
            MessageBox.Show("Estado das poltronas salvo com sucesso!");
        }

        private void checkBoxPoltrona_Click(object sender, EventArgs e)
        {
            CheckBox clickedCheckBox = sender as CheckBox;
            var posicao = clickedCheckBox?.Tag as Tuple<int, int>;

            if (clickedCheckBox != null && posicao != null)
            {
                if (clickedCheckBox.Checked)
                {
                    qtdLugaresOcupados++;
                    valorTotalDaBilheteria += valoresDasPoltronas[posicao.Item1];
                    setLabels();
                }
                else
                {
                    qtdLugaresOcupados--;
                    valorTotalDaBilheteria -= valoresDasPoltronas[posicao.Item1];
                    setLabels();
                }
            }
            else
                MessageBox.Show("Erro ao selecionar checkbox!!");

        }

        private void setLabels()
        {
            lblValorBilheteria.Text = "R$ " + valorTotalDaBilheteria.ToString() + " reais";
            lblQtdLugares.Text = qtdLugaresOcupados.ToString();
        }
    }
}
