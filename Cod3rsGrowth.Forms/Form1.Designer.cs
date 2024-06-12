namespace Cod3rsGrowth.Forms
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
            components = new System.ComponentModel.Container();
            dataGridView1 = new DataGridView();
            clubeBindingSource = new BindingSource(components);
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fundacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            coberturaAntiChuvaDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, fundacaoDataGridViewTextBoxColumn, estadioDataGridViewTextBoxColumn, estadoDataGridViewTextBoxColumn, coberturaAntiChuvaDataGridViewCheckBoxColumn });
            dataGridView1.DataSource = clubeBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 450);
            dataGridView1.TabIndex = 0;
            // 
            // clubeBindingSource
            // 
            clubeBindingSource.DataSource = typeof(Dominio.Modelos.Clube);
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // fundacaoDataGridViewTextBoxColumn
            // 
            fundacaoDataGridViewTextBoxColumn.DataPropertyName = "Fundacao";
            fundacaoDataGridViewTextBoxColumn.HeaderText = "Fundacao";
            fundacaoDataGridViewTextBoxColumn.Name = "fundacaoDataGridViewTextBoxColumn";
            // 
            // estadioDataGridViewTextBoxColumn
            // 
            estadioDataGridViewTextBoxColumn.DataPropertyName = "Estadio";
            estadioDataGridViewTextBoxColumn.HeaderText = "Estadio";
            estadioDataGridViewTextBoxColumn.Name = "estadioDataGridViewTextBoxColumn";
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            // 
            // coberturaAntiChuvaDataGridViewCheckBoxColumn
            // 
            coberturaAntiChuvaDataGridViewCheckBoxColumn.DataPropertyName = "CoberturaAntiChuva";
            coberturaAntiChuvaDataGridViewCheckBoxColumn.HeaderText = "CoberturaAntiChuva";
            coberturaAntiChuvaDataGridViewCheckBoxColumn.Name = "coberturaAntiChuvaDataGridViewCheckBoxColumn";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fundacaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn coberturaAntiChuvaDataGridViewCheckBoxColumn;
        private BindingSource clubeBindingSource;
    }
}
