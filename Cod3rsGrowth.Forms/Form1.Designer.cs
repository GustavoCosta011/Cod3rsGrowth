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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabelaClube = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fundacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadioDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            estadoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            coberturaAntiChuvaDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            clubeBindingSource = new BindingSource(components);
            BoxNomeClube = new TextBox();
            Clubes = new TabControl();
            tabPage1 = new TabPage();
            button6 = new Button();
            button5 = new Button();
            button2 = new Button();
            BoxBuscar = new GroupBox();
            BoxEstado = new TextBox();
            label8 = new Label();
            DataFinalClube = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            DataInicialClube = new DateTimePicker();
            Pesquisar = new Button();
            tabPage2 = new TabPage();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            tabelaJogadores = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            idClubeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            idadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDeNascimentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pesoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jogadorBindingSource = new BindingSource(components);
            groupBox1 = new GroupBox();
            BoxIdClube = new TextBox();
            label7 = new Label();
            DataFinalJogador = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            DataInicialJogador = new DateTimePicker();
            PesquisarJgador = new Button();
            BoxNomeJogador = new TextBox();
            ((System.ComponentModel.ISupportInitialize)tabelaClube).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource).BeginInit();
            Clubes.SuspendLayout();
            tabPage1.SuspendLayout();
            BoxBuscar.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabelaJogadores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogadorBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabelaClube
            // 
            tabelaClube.AllowUserToOrderColumns = true;
            tabelaClube.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaClube.AutoGenerateColumns = false;
            tabelaClube.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaClube.BackgroundColor = Color.SlateGray;
            tabelaClube.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.LightSteelBlue;
            dataGridViewCellStyle2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.InactiveCaptionText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            tabelaClube.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            tabelaClube.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaClube.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, fundacaoDataGridViewTextBoxColumn, estadioDataGridViewTextBoxColumn, estadoDataGridViewTextBoxColumn, coberturaAntiChuvaDataGridViewCheckBoxColumn });
            tabelaClube.DataSource = clubeBindingSource;
            tabelaClube.Location = new Point(6, 79);
            tabelaClube.Name = "tabelaClube";
            tabelaClube.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            tabelaClube.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            tabelaClube.Size = new Size(571, 262);
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
            // BoxNomeClube
            // 
            BoxNomeClube.Location = new Point(88, 15);
            BoxNomeClube.Name = "BoxNomeClube";
            BoxNomeClube.Size = new Size(108, 22);
            BoxNomeClube.TabIndex = 1;
            BoxNomeClube.TextChanged += textBox1_TextChanged;
            // 
            // Clubes
            // 
            Clubes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Clubes.Controls.Add(tabPage1);
            Clubes.Controls.Add(tabPage2);
            Clubes.Location = new Point(59, 30);
            Clubes.Name = "Clubes";
            Clubes.SelectedIndex = 0;
            Clubes.Size = new Size(718, 375);
            Clubes.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.DimGray;
            tabPage1.BackgroundImageLayout = ImageLayout.Stretch;
            tabPage1.Controls.Add(button6);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(tabelaClube);
            tabPage1.Controls.Add(BoxBuscar);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(710, 347);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Clubes";
            tabPage1.Click += tabPage1_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.BackColor = SystemColors.AppWorkspace;
            button6.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button6.ForeColor = Color.Black;
            button6.Location = new Point(593, 197);
            button6.Name = "button6";
            button6.Size = new Size(102, 53);
            button6.TabIndex = 14;
            button6.Text = "Remover";
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button5.BackColor = SystemColors.AppWorkspace;
            button5.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button5.ForeColor = Color.Black;
            button5.Location = new Point(593, 138);
            button5.Name = "button5";
            button5.Size = new Size(102, 53);
            button5.TabIndex = 13;
            button5.Text = "Editar";
            button5.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = SystemColors.AppWorkspace;
            button2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(593, 79);
            button2.Name = "button2";
            button2.Size = new Size(102, 53);
            button2.TabIndex = 9;
            button2.Text = "Criar";
            button2.UseVisualStyleBackColor = false;
            // 
            // BoxBuscar
            // 
            BoxBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BoxBuscar.BackColor = Color.LightGray;
            BoxBuscar.BackgroundImageLayout = ImageLayout.None;
            BoxBuscar.Controls.Add(BoxEstado);
            BoxBuscar.Controls.Add(label8);
            BoxBuscar.Controls.Add(DataFinalClube);
            BoxBuscar.Controls.Add(label2);
            BoxBuscar.Controls.Add(label1);
            BoxBuscar.Controls.Add(label3);
            BoxBuscar.Controls.Add(DataInicialClube);
            BoxBuscar.Controls.Add(Pesquisar);
            BoxBuscar.Controls.Add(BoxNomeClube);
            BoxBuscar.FlatStyle = FlatStyle.Popup;
            BoxBuscar.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BoxBuscar.Location = new Point(6, 6);
            BoxBuscar.Name = "BoxBuscar";
            BoxBuscar.Size = new Size(698, 67);
            BoxBuscar.TabIndex = 8;
            BoxBuscar.TabStop = false;
            BoxBuscar.Enter += groupBox1_Enter;
            // 
            // BoxEstado
            // 
            BoxEstado.Location = new Point(88, 39);
            BoxEstado.Name = "BoxEstado";
            BoxEstado.Size = new Size(108, 22);
            BoxEstado.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 36);
            label8.Name = "label8";
            label8.Size = new Size(64, 16);
            label8.TabIndex = 8;
            label8.Text = "Estado (UF):";
            // 
            // DataFinalClube
            // 
            DataFinalClube.CalendarFont = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DataFinalClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DataFinalClube.Format = DateTimePickerFormat.Short;
            DataFinalClube.Location = new Point(300, 39);
            DataFinalClube.Name = "DataFinalClube";
            DataFinalClube.Size = new Size(99, 22);
            DataFinalClube.TabIndex = 5;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(233, 15);
            label1.Name = "label1";
            label1.Size = new Size(64, 16);
            label1.TabIndex = 4;
            label1.Text = "Data Inicial:";
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
            // DataInicialClube
            // 
            DataInicialClube.CalendarFont = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DataInicialClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DataInicialClube.Format = DateTimePickerFormat.Short;
            DataInicialClube.Location = new Point(300, 13);
            DataInicialClube.Name = "DataInicialClube";
            DataInicialClube.Size = new Size(99, 22);
            DataInicialClube.TabIndex = 3;
            // 
            // Pesquisar
            // 
            Pesquisar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Pesquisar.BackColor = SystemColors.AppWorkspace;
            Pesquisar.ForeColor = Color.Black;
            Pesquisar.Location = new Point(587, 8);
            Pesquisar.Name = "Pesquisar";
            Pesquisar.Size = new Size(102, 53);
            Pesquisar.TabIndex = 2;
            Pesquisar.Text = "Pesquisar";
            Pesquisar.UseVisualStyleBackColor = false;
            Pesquisar.Click += Pesquisar_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.DimGray;
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(button3);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(tabelaJogadores);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(710, 347);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Jogadores";
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button4.BackColor = SystemColors.AppWorkspace;
            button4.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(591, 197);
            button4.Name = "button4";
            button4.Size = new Size(102, 53);
            button4.TabIndex = 13;
            button4.Text = "Remover";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = SystemColors.AppWorkspace;
            button3.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(591, 138);
            button3.Name = "button3";
            button3.Size = new Size(102, 53);
            button3.TabIndex = 12;
            button3.Text = "Editar";
            button3.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(591, 79);
            button1.Name = "button1";
            button1.Size = new Size(102, 53);
            button1.TabIndex = 11;
            button1.Text = "Criar";
            button1.UseVisualStyleBackColor = false;
            // 
            // tabelaJogadores
            // 
            tabelaJogadores.AllowUserToOrderColumns = true;
            tabelaJogadores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaJogadores.AutoGenerateColumns = false;
            tabelaJogadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaJogadores.BackgroundColor = Color.LightSlateGray;
            tabelaJogadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaJogadores.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeDataGridViewTextBoxColumn1, idClubeDataGridViewTextBoxColumn, idadeDataGridViewTextBoxColumn, dataDeNascimentoDataGridViewTextBoxColumn, alturaDataGridViewTextBoxColumn, pesoDataGridViewTextBoxColumn });
            tabelaJogadores.DataSource = jogadorBindingSource;
            tabelaJogadores.Location = new Point(6, 79);
            tabelaJogadores.Name = "tabelaJogadores";
            tabelaJogadores.RowTemplate.Height = 25;
            tabelaJogadores.Size = new Size(568, 262);
            tabelaJogadores.TabIndex = 10;
            tabelaJogadores.CellContentClick += tabelaJogadores_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.FillWeight = 60F;
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            // 
            // nomeDataGridViewTextBoxColumn1
            // 
            nomeDataGridViewTextBoxColumn1.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn1.FillWeight = 120F;
            nomeDataGridViewTextBoxColumn1.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn1.Name = "nomeDataGridViewTextBoxColumn1";
            // 
            // idClubeDataGridViewTextBoxColumn
            // 
            idClubeDataGridViewTextBoxColumn.DataPropertyName = "IdClube";
            idClubeDataGridViewTextBoxColumn.FillWeight = 65F;
            idClubeDataGridViewTextBoxColumn.HeaderText = "Clube";
            idClubeDataGridViewTextBoxColumn.Name = "idClubeDataGridViewTextBoxColumn";
            // 
            // idadeDataGridViewTextBoxColumn
            // 
            idadeDataGridViewTextBoxColumn.DataPropertyName = "Idade";
            idadeDataGridViewTextBoxColumn.FillWeight = 60F;
            idadeDataGridViewTextBoxColumn.HeaderText = "Idade";
            idadeDataGridViewTextBoxColumn.Name = "idadeDataGridViewTextBoxColumn";
            // 
            // dataDeNascimentoDataGridViewTextBoxColumn
            // 
            dataDeNascimentoDataGridViewTextBoxColumn.DataPropertyName = "DataDeNascimento";
            dataDeNascimentoDataGridViewTextBoxColumn.FillWeight = 130F;
            dataDeNascimentoDataGridViewTextBoxColumn.HeaderText = "Nascimento";
            dataDeNascimentoDataGridViewTextBoxColumn.Name = "dataDeNascimentoDataGridViewTextBoxColumn";
            // 
            // alturaDataGridViewTextBoxColumn
            // 
            alturaDataGridViewTextBoxColumn.DataPropertyName = "Altura";
            alturaDataGridViewTextBoxColumn.FillWeight = 70F;
            alturaDataGridViewTextBoxColumn.HeaderText = "Altura";
            alturaDataGridViewTextBoxColumn.Name = "alturaDataGridViewTextBoxColumn";
            // 
            // pesoDataGridViewTextBoxColumn
            // 
            pesoDataGridViewTextBoxColumn.DataPropertyName = "Peso";
            pesoDataGridViewTextBoxColumn.FillWeight = 70F;
            pesoDataGridViewTextBoxColumn.HeaderText = "Peso";
            pesoDataGridViewTextBoxColumn.Name = "pesoDataGridViewTextBoxColumn";
            // 
            // jogadorBindingSource
            // 
            jogadorBindingSource.DataSource = typeof(Dominio.Modelos.Jogador);
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.LightGray;
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(BoxIdClube);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(DataFinalJogador);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(DataInicialJogador);
            groupBox1.Controls.Add(PesquisarJgador);
            groupBox1.Controls.Add(BoxNomeJogador);
            groupBox1.FlatStyle = FlatStyle.Popup;
            groupBox1.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(698, 67);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // BoxIdClube
            // 
            BoxIdClube.Location = new Point(86, 39);
            BoxIdClube.Name = "BoxIdClube";
            BoxIdClube.Size = new Size(105, 22);
            BoxIdClube.TabIndex = 9;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 36);
            label7.Name = "label7";
            label7.Size = new Size(62, 16);
            label7.TabIndex = 8;
            label7.Text = "Id do Clube:";
            // 
            // DataFinalJogador
            // 
            DataFinalJogador.CalendarFont = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DataFinalJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DataFinalJogador.Format = DateTimePickerFormat.Short;
            DataFinalJogador.Location = new Point(300, 39);
            DataFinalJogador.Name = "DataFinalJogador";
            DataFinalJogador.Size = new Size(99, 22);
            DataFinalJogador.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(233, 36);
            label4.Name = "label4";
            label4.Size = new Size(57, 16);
            label4.TabIndex = 6;
            label4.Text = "Data Final:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(233, 15);
            label5.Name = "label5";
            label5.Size = new Size(64, 16);
            label5.TabIndex = 4;
            label5.Text = "Data Inicial:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 15);
            label6.Name = "label6";
            label6.Size = new Size(37, 16);
            label6.TabIndex = 7;
            label6.Text = "Nome:";
            // 
            // DataInicialJogador
            // 
            DataInicialJogador.CalendarFont = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DataInicialJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DataInicialJogador.Format = DateTimePickerFormat.Short;
            DataInicialJogador.Location = new Point(300, 13);
            DataInicialJogador.Name = "DataInicialJogador";
            DataInicialJogador.Size = new Size(99, 22);
            DataInicialJogador.TabIndex = 3;
            // 
            // PesquisarJgador
            // 
            PesquisarJgador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PesquisarJgador.BackColor = SystemColors.AppWorkspace;
            PesquisarJgador.ForeColor = Color.Black;
            PesquisarJgador.Location = new Point(585, 8);
            PesquisarJgador.Name = "PesquisarJgador";
            PesquisarJgador.Size = new Size(102, 53);
            PesquisarJgador.TabIndex = 2;
            PesquisarJgador.Text = "Pesquisar";
            PesquisarJgador.UseVisualStyleBackColor = false;
            // 
            // BoxNomeJogador
            // 
            BoxNomeJogador.Location = new Point(86, 13);
            BoxNomeJogador.Name = "BoxNomeJogador";
            BoxNomeJogador.Size = new Size(105, 22);
            BoxNomeJogador.TabIndex = 1;
            BoxNomeJogador.TextChanged += textBox2_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = SystemColors.AppWorkspace;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(836, 450);
            Controls.Add(Clubes);
            DoubleBuffered = true;
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
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
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tabelaJogadores).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogadorBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabelaClube;
        private BindingSource clubeBindingSource;
        private TextBox BoxNomeClube;
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
        private DateTimePicker DataInicialClube;
        private Label label2;
        private DateTimePicker DataFinalClube;
        private Label label1;
        private Label label3;
        private GroupBox BoxBuscar;
        private DataGridView tabelaJogadores;
        private GroupBox groupBox1;
        private DateTimePicker DataFinalJogador;
        private Label label4;
        private Label label5;
        private Label label6;
        private DateTimePicker DataInicialJogador;
        private Button PesquisarJgador;
        private TextBox BoxNomeJogador;
        private TextBox BoxIdClube;
        private Label label7;
        private Button button2;
        private Button button3;
        private Button button1;
        private Button button4;
        private Button button5;
        private Button button6;
        private BindingSource jogadorBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn idClubeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDeNascimentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alturaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
        private TextBox BoxEstado;
        private Label label8;
    }
}
