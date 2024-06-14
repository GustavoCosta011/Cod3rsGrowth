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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabelaClube = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fundacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            coberturaAntiChuvaDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            clubeBindingSource = new BindingSource(components);
            textBox1 = new TextBox();
            Clubes = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            Pesquisar = new Button();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            BoxBuscar = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)tabelaClube).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource).BeginInit();
            Clubes.SuspendLayout();
            tabPage1.SuspendLayout();
            BoxBuscar.SuspendLayout();
            SuspendLayout();
            // 
            // tabelaClube
            // 
            tabelaClube.AllowUserToOrderColumns = true;
            tabelaClube.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabelaClube.AutoGenerateColumns = false;
            tabelaClube.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaClube.BackgroundColor = Color.SlateGray;
            tabelaClube.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.InactiveCaptionText;
            dataGridViewCellStyle1.NullValue = null;
            dataGridViewCellStyle1.SelectionBackColor = Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tabelaClube.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tabelaClube.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaClube.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, fundacaoDataGridViewTextBoxColumn, estadioDataGridViewTextBoxColumn, estadoDataGridViewTextBoxColumn, coberturaAntiChuvaDataGridViewCheckBoxColumn });
            tabelaClube.DataSource = clubeBindingSource;
            tabelaClube.Location = new Point(6, 79);
            tabelaClube.Name = "tabelaClube";
            tabelaClube.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabelaClube.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            tabelaClube.Size = new Size(566, 256);
            tabelaClube.TabIndex = 0;
            tabelaClube.VirtualMode = true;
            tabelaClube.CellContentClick += tabelaClube_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.FillWeight = 20F;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.FillWeight = 30F;
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fundacaoDataGridViewTextBoxColumn
            // 
            fundacaoDataGridViewTextBoxColumn.DataPropertyName = "Fundacao";
            fundacaoDataGridViewTextBoxColumn.FillWeight = 30F;
            fundacaoDataGridViewTextBoxColumn.HeaderText = "Fundacao";
            fundacaoDataGridViewTextBoxColumn.Name = "fundacaoDataGridViewTextBoxColumn";
            fundacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadioDataGridViewTextBoxColumn
            // 
            estadioDataGridViewTextBoxColumn.DataPropertyName = "Estadio";
            estadioDataGridViewTextBoxColumn.FillWeight = 30F;
            estadioDataGridViewTextBoxColumn.HeaderText = "Estadio";
            estadioDataGridViewTextBoxColumn.Name = "estadioDataGridViewTextBoxColumn";
            estadioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // estadoDataGridViewTextBoxColumn
            // 
            estadoDataGridViewTextBoxColumn.DataPropertyName = "Estado";
            estadoDataGridViewTextBoxColumn.FillWeight = 30F;
            estadoDataGridViewTextBoxColumn.HeaderText = "Estado";
            estadoDataGridViewTextBoxColumn.Name = "estadoDataGridViewTextBoxColumn";
            estadoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // coberturaAntiChuvaDataGridViewCheckBoxColumn
            // 
            coberturaAntiChuvaDataGridViewCheckBoxColumn.DataPropertyName = "CoberturaAntiChuva";
            coberturaAntiChuvaDataGridViewCheckBoxColumn.FillWeight = 50F;
            coberturaAntiChuvaDataGridViewCheckBoxColumn.HeaderText = "CoberturaTeto";
            coberturaAntiChuvaDataGridViewCheckBoxColumn.Name = "coberturaAntiChuvaDataGridViewCheckBoxColumn";
            coberturaAntiChuvaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // clubeBindingSource
            // 
            clubeBindingSource.DataSource = typeof(Dominio.Modelos.Clube);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(61, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(156, 22);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Clubes
            // 
            Clubes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Clubes.Controls.Add(tabPage1);
            Clubes.Controls.Add(tabPage2);
            Clubes.Location = new Point(124, 30);
            Clubes.Name = "Clubes";
            Clubes.SelectedIndex = 0;
            Clubes.Size = new Size(586, 369);
            Clubes.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.DimGray;
            tabPage1.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage1.Controls.Add(tabelaClube);
            tabPage1.Controls.Add(BoxBuscar);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(578, 341);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Clubes";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(578, 341);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Jogadores";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Pesquisar
            // 
            Pesquisar.BackColor = SystemColors.AppWorkspace;
            Pesquisar.ForeColor = Color.Black;
            Pesquisar.Location = new Point(437, 8);
            Pesquisar.Name = "Pesquisar";
            Pesquisar.Size = new Size(102, 50);
            Pesquisar.TabIndex = 2;
            Pesquisar.Text = "Pesquisar";
            Pesquisar.UseVisualStyleBackColor = false;
            Pesquisar.Click += Pesquisar_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(300, 13);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(99, 22);
            dateTimePicker1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(233, 15);
            label1.Name = "label1";
            label1.Size = new Size(64, 16);
            label1.TabIndex = 4;
            label1.Text = "Data Inicial:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarFont = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(300, 36);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(99, 22);
            dateTimePicker2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(233, 36);
            label2.Name = "label2";
            label2.Size = new Size(57, 16);
            label2.TabIndex = 6;
            label2.Text = "Data Final:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 15);
            label3.Name = "label3";
            label3.Size = new Size(37, 16);
            label3.TabIndex = 7;
            label3.Text = "Nome:";
            // 
            // BoxBuscar
            // 
            BoxBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BoxBuscar.BackColor = Color.LightGray;
            BoxBuscar.BackgroundImageLayout = ImageLayout.None;
            BoxBuscar.Controls.Add(dateTimePicker2);
            BoxBuscar.Controls.Add(label2);
            BoxBuscar.Controls.Add(label1);
            BoxBuscar.Controls.Add(label3);
            BoxBuscar.Controls.Add(dateTimePicker1);
            BoxBuscar.Controls.Add(Pesquisar);
            BoxBuscar.Controls.Add(textBox1);
            BoxBuscar.FlatStyle = FlatStyle.Popup;
            BoxBuscar.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BoxBuscar.Location = new Point(6, 6);
            BoxBuscar.Name = "BoxBuscar";
            BoxBuscar.Size = new Size(566, 67);
            BoxBuscar.TabIndex = 8;
            BoxBuscar.TabStop = false;
            BoxBuscar.Enter += groupBox1_Enter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.AppWorkspace;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(836, 450);
            Controls.Add(Clubes);
            DoubleBuffered = true;
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "Form1";
            WindowState = FormWindowState.Minimized;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)tabelaClube).EndInit();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource).EndInit();
            Clubes.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            BoxBuscar.ResumeLayout(false);
            BoxBuscar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaClube;
        private BindingSource clubeBindingSource;
        private TextBox textBox1;
        private TabControl Clubes;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fundacaoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadioDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn estadoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn coberturaAntiChuvaDataGridViewCheckBoxColumn;
        private Button Pesquisar;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Label label3;
        private GroupBox BoxBuscar;
    }
}
