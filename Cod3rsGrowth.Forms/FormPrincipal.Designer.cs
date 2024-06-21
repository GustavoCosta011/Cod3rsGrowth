namespace Cod3rsGrowth.Forms
{
    partial class FormPrincipal
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
            BoxNomeClube = new TextBox();
            Clubes = new TabControl();
            tabPage1 = new TabPage();
            PesquisarClube = new Button();
            RemoverClube = new Button();
            EditarClube = new Button();
            CriarClube = new Button();
            BoxBuscar = new GroupBox();
            LimparCamposClube = new Button();
            EnumEstado = new ComboBox();
            label8 = new Label();
            DataFinalClube = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            DataInicialClube = new DateTimePicker();
            tabPage2 = new TabPage();
            PesquisarJogador = new Button();
            RemoverJogador = new Button();
            EditarJogador = new Button();
            CriarJogador = new Button();
            tabelaJogadores = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Clube = new DataGridViewTextBoxColumn();
            idadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDeNascimentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            alturaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pesoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            jogadorBindingSource2 = new BindingSource(components);
            groupBox1 = new GroupBox();
            LimparCamposJogador = new Button();
            BoxIdClube = new TextBox();
            label7 = new Label();
            DataFinalJogador = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            DataInicialJogador = new DateTimePicker();
            BoxNomeJogador = new TextBox();
            jogadorBindingSource1 = new BindingSource(components);
            jogadorBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)tabelaClube).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource).BeginInit();
            Clubes.SuspendLayout();
            tabPage1.SuspendLayout();
            BoxBuscar.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabelaJogadores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogadorBindingSource2).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)jogadorBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)jogadorBindingSource).BeginInit();
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
            tabelaClube.RowHeadersVisible = false;
            tabelaClube.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            tabelaClube.Size = new Size(571, 261);
            tabelaClube.TabIndex = 0;
            tabelaClube.VirtualMode = true;
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
            BoxNomeClube.TextChanged += AoDigitarONomeDoClube;
            // 
            // Clubes
            // 
            Clubes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Clubes.Controls.Add(tabPage1);
            Clubes.Controls.Add(tabPage2);
            Clubes.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
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
            tabPage1.Controls.Add(PesquisarClube);
            tabPage1.Controls.Add(RemoverClube);
            tabPage1.Controls.Add(EditarClube);
            tabPage1.Controls.Add(CriarClube);
            tabPage1.Controls.Add(tabelaClube);
            tabPage1.Controls.Add(BoxBuscar);
            tabPage1.Location = new Point(4, 25);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(710, 346);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Clubes";
            // 
            // PesquisarClube
            // 
            PesquisarClube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PesquisarClube.BackColor = SystemColors.AppWorkspace;
            PesquisarClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PesquisarClube.ForeColor = Color.Black;
            PesquisarClube.Location = new Point(593, 15);
            PesquisarClube.Name = "PesquisarClube";
            PesquisarClube.Size = new Size(102, 53);
            PesquisarClube.TabIndex = 15;
            PesquisarClube.Text = "Pesquisar";
            PesquisarClube.UseVisualStyleBackColor = false;
            PesquisarClube.Click += AoClicarPesquisarNaAbaClubes;
            // 
            // RemoverClube
            // 
            RemoverClube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RemoverClube.BackColor = SystemColors.AppWorkspace;
            RemoverClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            RemoverClube.ForeColor = Color.Black;
            RemoverClube.Location = new Point(593, 192);
            RemoverClube.Name = "RemoverClube";
            RemoverClube.Size = new Size(102, 53);
            RemoverClube.TabIndex = 14;
            RemoverClube.Text = "Remover";
            RemoverClube.UseVisualStyleBackColor = false;
            // 
            // EditarClube
            // 
            EditarClube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EditarClube.BackColor = SystemColors.AppWorkspace;
            EditarClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            EditarClube.ForeColor = Color.Black;
            EditarClube.Location = new Point(593, 133);
            EditarClube.Name = "EditarClube";
            EditarClube.Size = new Size(102, 53);
            EditarClube.TabIndex = 13;
            EditarClube.Text = "Editar";
            EditarClube.UseVisualStyleBackColor = false;
            // 
            // CriarClube
            // 
            CriarClube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CriarClube.BackColor = SystemColors.AppWorkspace;
            CriarClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CriarClube.ForeColor = Color.Black;
            CriarClube.Location = new Point(593, 74);
            CriarClube.Name = "CriarClube";
            CriarClube.Size = new Size(102, 53);
            CriarClube.TabIndex = 9;
            CriarClube.Text = "Criar";
            CriarClube.UseVisualStyleBackColor = false;
            CriarClube.Click += AoClicarBotaocriarNaAbaclube;
            // 
            // BoxBuscar
            // 
            BoxBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BoxBuscar.BackColor = Color.LightGray;
            BoxBuscar.BackgroundImageLayout = ImageLayout.None;
            BoxBuscar.Controls.Add(LimparCamposClube);
            BoxBuscar.Controls.Add(EnumEstado);
            BoxBuscar.Controls.Add(label8);
            BoxBuscar.Controls.Add(DataFinalClube);
            BoxBuscar.Controls.Add(label2);
            BoxBuscar.Controls.Add(label1);
            BoxBuscar.Controls.Add(label3);
            BoxBuscar.Controls.Add(DataInicialClube);
            BoxBuscar.Controls.Add(BoxNomeClube);
            BoxBuscar.FlatStyle = FlatStyle.Popup;
            BoxBuscar.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BoxBuscar.Location = new Point(6, 6);
            BoxBuscar.Name = "BoxBuscar";
            BoxBuscar.Size = new Size(571, 67);
            BoxBuscar.TabIndex = 8;
            BoxBuscar.TabStop = false;
            // 
            // LimparCamposClube
            // 
            LimparCamposClube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LimparCamposClube.BackColor = SystemColors.AppWorkspace;
            LimparCamposClube.ForeColor = Color.Black;
            LimparCamposClube.Location = new Point(489, 10);
            LimparCamposClube.Name = "LimparCamposClube";
            LimparCamposClube.Size = new Size(65, 52);
            LimparCamposClube.TabIndex = 10;
            LimparCamposClube.Text = "Limpar Campos";
            LimparCamposClube.UseVisualStyleBackColor = false;
            LimparCamposClube.Click += AoClicarLimparCamposNaAbaClubes;
            // 
            // EnumEstado
            // 
            EnumEstado.DropDownHeight = 110;
            EnumEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            EnumEstado.FlatStyle = FlatStyle.Flat;
            EnumEstado.FormattingEnabled = true;
            EnumEstado.IntegralHeight = false;
            EnumEstado.Items.AddRange(new object[] { "        AC", "        AL", "        AP", "        AM", "        BA", "        CE", "        ES", "        GO", "        MA", "        MT", "        MS", "        MG", "        PA", "        PB", "        PR", "        PE", "        PI", "        RJ", "        RN", "        RS", "        RO", "        RR", "        SC", "        SP", "        SE", "        TO" });
            EnumEstado.Location = new Point(88, 39);
            EnumEstado.Name = "EnumEstado";
            EnumEstado.Size = new Size(57, 24);
            EnumEstado.TabIndex = 9;
            EnumEstado.Tag = "";
            EnumEstado.SelectedIndexChanged += AoSelecionarOEstadoDoClube;
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
            DataFinalClube.ValueChanged += AoSelecionarADataFinalNaAbaClubes;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(233, 36);
            label2.Name = "label2";
            label2.Size = new Size(57, 16);
            label2.TabIndex = 6;
            label2.Text = "Data Final:";
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
            DataInicialClube.Value = new DateTime(1800, 1, 1, 0, 0, 0, 0);
            DataInicialClube.ValueChanged += AoSelecionarADataInicialNaAbaClubes;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.DimGray;
            tabPage2.Controls.Add(PesquisarJogador);
            tabPage2.Controls.Add(RemoverJogador);
            tabPage2.Controls.Add(EditarJogador);
            tabPage2.Controls.Add(CriarJogador);
            tabPage2.Controls.Add(tabelaJogadores);
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 25);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(710, 346);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Jogadores";
            // 
            // PesquisarJogador
            // 
            PesquisarJogador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PesquisarJogador.BackColor = SystemColors.AppWorkspace;
            PesquisarJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            PesquisarJogador.ForeColor = Color.Black;
            PesquisarJogador.Location = new Point(593, 15);
            PesquisarJogador.Name = "PesquisarJogador";
            PesquisarJogador.Size = new Size(102, 53);
            PesquisarJogador.TabIndex = 14;
            PesquisarJogador.Text = "Pesquisar";
            PesquisarJogador.UseVisualStyleBackColor = false;
            PesquisarJogador.Click += AoClicarPesquisarNaAbaJogador;
            // 
            // RemoverJogador
            // 
            RemoverJogador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            RemoverJogador.BackColor = SystemColors.AppWorkspace;
            RemoverJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            RemoverJogador.ForeColor = Color.Black;
            RemoverJogador.Location = new Point(593, 192);
            RemoverJogador.Name = "RemoverJogador";
            RemoverJogador.Size = new Size(102, 53);
            RemoverJogador.TabIndex = 13;
            RemoverJogador.Text = "Remover";
            RemoverJogador.UseVisualStyleBackColor = false;
            // 
            // EditarJogador
            // 
            EditarJogador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EditarJogador.BackColor = SystemColors.AppWorkspace;
            EditarJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            EditarJogador.ForeColor = Color.Black;
            EditarJogador.Location = new Point(593, 133);
            EditarJogador.Name = "EditarJogador";
            EditarJogador.Size = new Size(102, 53);
            EditarJogador.TabIndex = 12;
            EditarJogador.Text = "Editar";
            EditarJogador.UseVisualStyleBackColor = false;
            // 
            // CriarJogador
            // 
            CriarJogador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CriarJogador.BackColor = SystemColors.AppWorkspace;
            CriarJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CriarJogador.ForeColor = Color.Black;
            CriarJogador.Location = new Point(593, 74);
            CriarJogador.Name = "CriarJogador";
            CriarJogador.Size = new Size(102, 53);
            CriarJogador.TabIndex = 11;
            CriarJogador.Text = "Criar";
            CriarJogador.UseVisualStyleBackColor = false;
            CriarJogador.Click += CriarJogador_Click;
            // 
            // tabelaJogadores
            // 
            tabelaJogadores.AllowUserToOrderColumns = true;
            tabelaJogadores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaJogadores.AutoGenerateColumns = false;
            tabelaJogadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabelaJogadores.BackgroundColor = Color.LightSlateGray;
            tabelaJogadores.BorderStyle = BorderStyle.Fixed3D;
            tabelaJogadores.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            tabelaJogadores.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            tabelaJogadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaJogadores.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeDataGridViewTextBoxColumn1, Clube, idadeDataGridViewTextBoxColumn, dataDeNascimentoDataGridViewTextBoxColumn, alturaDataGridViewTextBoxColumn, pesoDataGridViewTextBoxColumn });
            tabelaJogadores.DataSource = jogadorBindingSource2;
            tabelaJogadores.Location = new Point(6, 79);
            tabelaJogadores.Name = "tabelaJogadores";
            tabelaJogadores.RowHeadersVisible = false;
            tabelaJogadores.RowTemplate.Height = 25;
            tabelaJogadores.Size = new Size(568, 261);
            tabelaJogadores.TabIndex = 10;
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
            // Clube
            // 
            Clube.DataPropertyName = "Clube";
            Clube.HeaderText = "Clube";
            Clube.Name = "Clube";
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
            // jogadorBindingSource2
            // 
            jogadorBindingSource2.DataSource = typeof(Dominio.Modelos.Jogador);
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.LightGray;
            groupBox1.BackgroundImageLayout = ImageLayout.None;
            groupBox1.Controls.Add(LimparCamposJogador);
            groupBox1.Controls.Add(BoxIdClube);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(DataFinalJogador);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(DataInicialJogador);
            groupBox1.Controls.Add(BoxNomeJogador);
            groupBox1.FlatStyle = FlatStyle.Popup;
            groupBox1.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(568, 67);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // LimparCamposJogador
            // 
            LimparCamposJogador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LimparCamposJogador.BackColor = SystemColors.AppWorkspace;
            LimparCamposJogador.ForeColor = Color.Black;
            LimparCamposJogador.Location = new Point(489, 10);
            LimparCamposJogador.Name = "LimparCamposJogador";
            LimparCamposJogador.Size = new Size(65, 52);
            LimparCamposJogador.TabIndex = 11;
            LimparCamposJogador.Text = "Limpar Campos";
            LimparCamposJogador.UseVisualStyleBackColor = false;
            LimparCamposJogador.Click += AoClicarLimparCamposNaAbaJogador;
            // 
            // BoxIdClube
            // 
            BoxIdClube.Location = new Point(61, 39);
            BoxIdClube.Name = "BoxIdClube";
            BoxIdClube.Size = new Size(105, 22);
            BoxIdClube.TabIndex = 9;
            BoxIdClube.TextChanged += AoDigitarONomeDoClubeDoJogador;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 36);
            label7.Name = "label7";
            label7.Size = new Size(37, 16);
            label7.TabIndex = 8;
            label7.Text = "Clube:";
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
            DataFinalJogador.ValueChanged += AoSelecionarADataFinalNaAbaJogadores;
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
            DataInicialJogador.Value = new DateTime(1800, 1, 1, 0, 0, 0, 0);
            DataInicialJogador.ValueChanged += AoSelecionarADataInicialNaAbaJogadores;
            // 
            // BoxNomeJogador
            // 
            BoxNomeJogador.Location = new Point(61, 13);
            BoxNomeJogador.Name = "BoxNomeJogador";
            BoxNomeJogador.Size = new Size(105, 22);
            BoxNomeJogador.TabIndex = 1;
            BoxNomeJogador.TextChanged += AoDigitaroNomeDoJogador;
            // 
            // jogadorBindingSource1
            // 
            jogadorBindingSource1.DataSource = typeof(Dominio.Modelos.Jogador);
            // 
            // jogadorBindingSource
            // 
            jogadorBindingSource.DataSource = typeof(Dominio.Modelos.Jogador);
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = SystemColors.AppWorkspace;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(836, 450);
            Controls.Add(Clubes);
            DoubleBuffered = true;
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FormPrincipal";
            Text = "FormPrincipal";
            WindowState = FormWindowState.Minimized;
            Load += CarregarListasDoFormPrincipal;
            ((System.ComponentModel.ISupportInitialize)tabelaClube).EndInit();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource).EndInit();
            Clubes.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            BoxBuscar.ResumeLayout(false);
            BoxBuscar.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tabelaJogadores).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogadorBindingSource2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)jogadorBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)jogadorBindingSource).EndInit();
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
        private TextBox BoxNomeJogador;
        private TextBox BoxIdClube;
        private Label label7;
        private Button CriarClube;
        private Button EditarJogador;
        private Button CriarJogador;
        private Button RemoverJogador;
        private Button EditarClube;
        private Button RemoverClube;
        private BindingSource jogadorBindingSource;
        private DataGridViewTextBoxColumn idClubeDataGridViewTextBoxColumn;
        private Label label8;
        private ComboBox EnumEstado;
        private Button LimparCamposClube;
        private Button LimparCamposJogador;
        private Button PesquisarJogador;
        private Button PesquisarClube;
        private BindingSource jogadorBindingSource1;
        private BindingSource jogadorBindingSource2;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Clube;
        private DataGridViewTextBoxColumn idadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDeNascimentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn alturaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn pesoDataGridViewTextBoxColumn;
    }
}
