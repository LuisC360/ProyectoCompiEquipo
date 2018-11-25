using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Compiladores
{
    public partial class Form1 : Form
    {
        Algoritmos principal;
        String fileName = Directory.GetCurrentDirectory() + @"\ProyectoEquipoGramatica.txt";

        public Form1()
        {
            InitializeComponent();
            principal = new Algoritmos(richTextBox1);
            carga_gramatica();
        }

        private void carga_gramatica()
        {
            String line;

            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while ((line = file.ReadLine()) != null)
            {
                richTextBox1.Text += line + Environment.NewLine;
            }
            file.Close();

            if (principal.creglas() == true)
            {
                principal.lr1princ(treeView1, dataGridView1);
                if (principal.tlr1 == false)
                {
                    MessageBox.Show("Gramatica no valida" + principal.errorCelda);
                    dataGridView2.Rows.Clear();
                    Codigo.Enabled = false;
                }
                else
                {
                    Codigo.Enabled = true;
                }
            }
        }

        //Este funcion se activa cuando se quiere abrir un codigo
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.InitialDirectory = Environment.CurrentDirectory;
            abrir.RestoreDirectory = true;
            string line;

            if (abrir.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(abrir.FileName);
                richTextBox2.Clear();
                while ((line = file.ReadLine()) != null)
                {
                    richTextBox2.Text += line + Environment.NewLine;
                }
                file.Close();
            }
        }

        //Esta funcion guarda el texto de la parte de codigo al presionar el boton.
        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog guarda = new SaveFileDialog();
            guarda.InitialDirectory = Environment.CurrentDirectory;

            guarda.DefaultExt = "*.txt";
            guarda.Filter = "txt Files|*.txt";

            if (guarda.ShowDialog() == System.Windows.Forms.DialogResult.OK && guarda.FileName.Length > 0)
            {
                richTextBox2.SaveFile(guarda.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        //Esta funcion se activa cuando se va a calcular el LR1
        private void button3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Lines.Count() < 1)
            {
                MessageBox.Show("Tienes que escribir una gramatica");
            }
            else
            {
                if (principal.creglas() == true)
                {
                    principal.lr1princ(treeView1, dataGridView1);
                    if (principal.tlr1 == false)
                    {
                        MessageBox.Show("Gramatica no valida" + principal.errorCelda);
                        dataGridView2.Rows.Clear();
                        Codigo.Enabled = false;
                    }
                    else
                    {
                        Codigo.Enabled = true;
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (richTextBox2.Lines.Count() == 0)
            {
                MessageBox.Show("Tienes que escribir algo");
            }
            else
            {
                if (principal.evaluar(richTextBox2, dataGridView2, dataGridView1) == false)
                {
                    MessageBox.Show("No es valida dentro de la gramatica");
                }
            }
        }

        private void carnesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.carnesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.alimentosDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'alimentosDataSet.Verduras' Puede moverla o quitarla según sea necesario.
            this.verdurasTableAdapter.Fill(this.alimentosDataSet.Verduras);
            // TODO: esta línea de código carga datos en la tabla 'alimentosDataSet.Lacteos' Puede moverla o quitarla según sea necesario.
            this.lacteosTableAdapter.Fill(this.alimentosDataSet.Lacteos);
            // TODO: esta línea de código carga datos en la tabla 'alimentosDataSet.Cereales' Puede moverla o quitarla según sea necesario.
            this.cerealesTableAdapter.Fill(this.alimentosDataSet.Cereales);
            // TODO: esta línea de código carga datos en la tabla 'alimentosDataSet.Carnes' Puede moverla o quitarla según sea necesario.
            this.carnesTableAdapter.Fill(this.alimentosDataSet.Carnes);
            // TODO: esta línea de código carga datos en la tabla 'alimentosDataSet.Carnes' Puede moverla o quitarla según sea necesario.
            this.carnesTableAdapter.Fill(this.alimentosDataSet.Carnes);

        }

        private void carnesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.carnesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.alimentosDataSet);

        }
    }
}
