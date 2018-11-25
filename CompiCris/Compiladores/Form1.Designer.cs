namespace Compiladores
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Pila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cadena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Acciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccionTraduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textoDieta = new System.Windows.Forms.RichTextBox();
            this.alimentosDataSet = new Compiladores.AlimentosDataSet();
            this.carnesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carnesTableAdapter = new Compiladores.AlimentosDataSetTableAdapters.CarnesTableAdapter();
            this.tableAdapterManager = new Compiladores.AlimentosDataSetTableAdapters.TableAdapterManager();
            this.cerealesTableAdapter = new Compiladores.AlimentosDataSetTableAdapters.CerealesTableAdapter();
            this.lacteosTableAdapter = new Compiladores.AlimentosDataSetTableAdapters.LacteosTableAdapter();
            this.verdurasTableAdapter = new Compiladores.AlimentosDataSetTableAdapters.VerdurasTableAdapter();
            this.cerealesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lacteosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.verdurasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Codigo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alimentosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carnesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerealesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lacteosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verdurasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(90, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(38, 46);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gramatica";
            this.groupBox1.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(298, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "Calcula LR1";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 338);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Abrir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 26);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(848, 306);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Location = new System.Drawing.Point(142, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(45, 15);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Arbol";
            this.groupBox2.Visible = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(8, 26);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(336, 342);
            this.treeView1.TabIndex = 0;
            this.treeView1.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(134, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(38, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tabla de Analisis";
            this.groupBox3.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(849, 289);
            this.dataGridView1.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.Controls.Add(this.button6);
            this.Codigo.Controls.Add(this.button5);
            this.Codigo.Controls.Add(this.button4);
            this.Codigo.Controls.Add(this.richTextBox2);
            this.Codigo.Location = new System.Drawing.Point(12, 45);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(710, 471);
            this.Codigo.TabIndex = 3;
            this.Codigo.TabStop = false;
            this.Codigo.Text = "Perfil del paciente";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(186, 426);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(184, 39);
            this.button6.TabIndex = 3;
            this.button6.Text = "Comprobar";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(98, 426);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 39);
            this.button5.TabIndex = 2;
            this.button5.Text = "Guardar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 426);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 39);
            this.button4.TabIndex = 1;
            this.button4.Text = "Abrir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 26);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(684, 394);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(843, 189);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(45, 45);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tabla de Acciones";
            this.groupBox4.Visible = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pila,
            this.Cadena,
            this.Acciones,
            this.AccionTraduccion});
            this.dataGridView2.Location = new System.Drawing.Point(8, 26);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(684, 285);
            this.dataGridView2.TabIndex = 0;
            // 
            // Pila
            // 
            this.Pila.HeaderText = "Pila A.S.";
            this.Pila.Name = "Pila";
            // 
            // Cadena
            // 
            this.Cadena.HeaderText = "Cadena de Entrada";
            this.Cadena.Name = "Cadena";
            // 
            // Acciones
            // 
            this.Acciones.HeaderText = "Accion";
            this.Acciones.Name = "Acciones";
            // 
            // AccionTraduccion
            // 
            this.AccionTraduccion.HeaderText = "Accion Traduccion";
            this.AccionTraduccion.Name = "AccionTraduccion";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textoDieta);
            this.groupBox5.Location = new System.Drawing.Point(728, 45);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(669, 471);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Dieta recomendada:";
            // 
            // textoDieta
            // 
            this.textoDieta.Location = new System.Drawing.Point(8, 26);
            this.textoDieta.Name = "textoDieta";
            this.textoDieta.Size = new System.Drawing.Size(656, 434);
            this.textoDieta.TabIndex = 0;
            this.textoDieta.Text = "";
            // 
            // alimentosDataSet
            // 
            this.alimentosDataSet.DataSetName = "AlimentosDataSet";
            this.alimentosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // carnesBindingSource
            // 
            this.carnesBindingSource.DataMember = "Carnes";
            this.carnesBindingSource.DataSource = this.alimentosDataSet;
            // 
            // carnesTableAdapter
            // 
            this.carnesTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CarnesTableAdapter = this.carnesTableAdapter;
            this.tableAdapterManager.CerealesTableAdapter = this.cerealesTableAdapter;
            this.tableAdapterManager.LacteosTableAdapter = this.lacteosTableAdapter;
            this.tableAdapterManager.UpdateOrder = Compiladores.AlimentosDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VerdurasTableAdapter = this.verdurasTableAdapter;
            // 
            // cerealesTableAdapter
            // 
            this.cerealesTableAdapter.ClearBeforeFill = true;
            // 
            // lacteosTableAdapter
            // 
            this.lacteosTableAdapter.ClearBeforeFill = true;
            // 
            // verdurasTableAdapter
            // 
            this.verdurasTableAdapter.ClearBeforeFill = true;
            // 
            // cerealesBindingSource
            // 
            this.cerealesBindingSource.DataMember = "Cereales";
            this.cerealesBindingSource.DataSource = this.alimentosDataSet;
            // 
            // lacteosBindingSource
            // 
            this.lacteosBindingSource.DataMember = "Lacteos";
            this.lacteosBindingSource.DataSource = this.alimentosDataSet;
            // 
            // verdurasBindingSource
            // 
            this.verdurasBindingSource.DataMember = "Verduras";
            this.verdurasBindingSource.DataSource = this.alimentosDataSet;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1426, 532);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Codigo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Codigo.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alimentosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carnesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cerealesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lacteosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verdurasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox Codigo;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pila;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cadena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Acciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccionTraduccion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox textoDieta;
        private AlimentosDataSet alimentosDataSet;
        private System.Windows.Forms.BindingSource carnesBindingSource;
        private AlimentosDataSetTableAdapters.CarnesTableAdapter carnesTableAdapter;
        private AlimentosDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private AlimentosDataSetTableAdapters.CerealesTableAdapter cerealesTableAdapter;
        private System.Windows.Forms.BindingSource cerealesBindingSource;
        private AlimentosDataSetTableAdapters.LacteosTableAdapter lacteosTableAdapter;
        private System.Windows.Forms.BindingSource lacteosBindingSource;
        private AlimentosDataSetTableAdapters.VerdurasTableAdapter verdurasTableAdapter;
        private System.Windows.Forms.BindingSource verdurasBindingSource;
    }
}

