namespace Cod3rsGrowth.Forms
{
    partial class FormCriarJogador
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
            components = new System.ComponentModel.Container();
            BoxCriar = new GroupBox();
            ComboBoxClubeCriarJogador = new ComboBox();
            clubeBindingSource1 = new BindingSource(components);
            NascimentoCriarJogador = new DateTimePicker();
            BoxPesoCriarJogador = new TextBox();
            label7 = new Label();
            BoxAlturaCriarJogador = new TextBox();
            label6 = new Label();
            label5 = new Label();
            CancelarJogador = new Button();
            SalvarJogador = new Button();
            BoxIdadeCriarJogador = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            BoxNomeCriarJogador = new TextBox();
            clubeBindingSource = new BindingSource(components);
            BoxCriar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // BoxCriar
            // 
            BoxCriar.BackColor = Color.LightGray;
            BoxCriar.Controls.Add(ComboBoxClubeCriarJogador);
            BoxCriar.Controls.Add(NascimentoCriarJogador);
            BoxCriar.Controls.Add(BoxPesoCriarJogador);
            BoxCriar.Controls.Add(label7);
            BoxCriar.Controls.Add(BoxAlturaCriarJogador);
            BoxCriar.Controls.Add(label6);
            BoxCriar.Controls.Add(label5);
            BoxCriar.Controls.Add(CancelarJogador);
            BoxCriar.Controls.Add(SalvarJogador);
            BoxCriar.Controls.Add(BoxIdadeCriarJogador);
            BoxCriar.Controls.Add(label4);
            BoxCriar.Controls.Add(label3);
            BoxCriar.Controls.Add(label2);
            BoxCriar.Controls.Add(label1);
            BoxCriar.Controls.Add(BoxNomeCriarJogador);
            BoxCriar.Location = new Point(12, 7);
            BoxCriar.Name = "BoxCriar";
            BoxCriar.Size = new Size(304, 383);
            BoxCriar.TabIndex = 3;
            BoxCriar.TabStop = false;
            // 
            // ComboBoxClubeCriarJogador
            // 
            ComboBoxClubeCriarJogador.DataSource = clubeBindingSource1;
            ComboBoxClubeCriarJogador.DisplayMember = "Nome";
            ComboBoxClubeCriarJogador.DropDownHeight = 80;
            ComboBoxClubeCriarJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            ComboBoxClubeCriarJogador.FormattingEnabled = true;
            ComboBoxClubeCriarJogador.IntegralHeight = false;
            ComboBoxClubeCriarJogador.Location = new Point(7, 88);
            ComboBoxClubeCriarJogador.Name = "ComboBoxClubeCriarJogador";
            ComboBoxClubeCriarJogador.Size = new Size(283, 24);
            ComboBoxClubeCriarJogador.TabIndex = 26;
            ComboBoxClubeCriarJogador.ValueMember = "Id";
            // 
            // clubeBindingSource1
            // 
            clubeBindingSource1.DataSource = typeof(Dominio.Modelos.Clube);
            // 
            // NascimentoCriarJogador
            // 
            NascimentoCriarJogador.CalendarFont = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NascimentoCriarJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            NascimentoCriarJogador.Format = DateTimePickerFormat.Short;
            NascimentoCriarJogador.Location = new Point(6, 199);
            NascimentoCriarJogador.Name = "NascimentoCriarJogador";
            NascimentoCriarJogador.Size = new Size(284, 22);
            NascimentoCriarJogador.TabIndex = 25;
            // 
            // BoxPesoCriarJogador
            // 
            BoxPesoCriarJogador.Location = new Point(7, 309);
            BoxPesoCriarJogador.Name = "BoxPesoCriarJogador";
            BoxPesoCriarJogador.Size = new Size(285, 23);
            BoxPesoCriarJogador.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(7, 290);
            label7.Name = "label7";
            label7.Size = new Size(33, 16);
            label7.TabIndex = 23;
            label7.Text = "Peso:";
            // 
            // BoxAlturaCriarJogador
            // 
            BoxAlturaCriarJogador.Location = new Point(7, 255);
            BoxAlturaCriarJogador.Name = "BoxAlturaCriarJogador";
            BoxAlturaCriarJogador.Size = new Size(285, 23);
            BoxAlturaCriarJogador.TabIndex = 22;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(7, 236);
            label6.Name = "label6";
            label6.Size = new Size(38, 16);
            label6.TabIndex = 21;
            label6.Text = "Altura:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(7, 180);
            label5.Name = "label5";
            label5.Size = new Size(107, 16);
            label5.TabIndex = 19;
            label5.Text = "Data de Nascimento:";
            // 
            // CancelarJogador
            // 
            CancelarJogador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CancelarJogador.BackColor = SystemColors.AppWorkspace;
            CancelarJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CancelarJogador.ForeColor = Color.Black;
            CancelarJogador.Location = new Point(172, 350);
            CancelarJogador.Name = "CancelarJogador";
            CancelarJogador.Size = new Size(102, 27);
            CancelarJogador.TabIndex = 17;
            CancelarJogador.Text = " Cancelar";
            CancelarJogador.UseVisualStyleBackColor = false;
            CancelarJogador.Click += AoClicarCancelarNaAbaCriarJogador;
            // 
            // SalvarJogador
            // 
            SalvarJogador.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SalvarJogador.BackColor = SystemColors.AppWorkspace;
            SalvarJogador.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SalvarJogador.ForeColor = Color.Black;
            SalvarJogador.Location = new Point(18, 350);
            SalvarJogador.Name = "SalvarJogador";
            SalvarJogador.Size = new Size(102, 27);
            SalvarJogador.TabIndex = 16;
            SalvarJogador.Text = "Salvar";
            SalvarJogador.UseVisualStyleBackColor = false;
            SalvarJogador.Click += AoClicarSalvarNaAbaCriarJogador;
            // 
            // BoxIdadeCriarJogador
            // 
            BoxIdadeCriarJogador.Location = new Point(6, 143);
            BoxIdadeCriarJogador.Name = "BoxIdadeCriarJogador";
            BoxIdadeCriarJogador.Size = new Size(285, 23);
            BoxIdadeCriarJogador.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 124);
            label4.Name = "label4";
            label4.Size = new Size(36, 16);
            label4.TabIndex = 4;
            label4.Text = "Idade:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 124);
            label3.Name = "label3";
            label3.Size = new Size(0, 16);
            label3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 69);
            label2.Name = "label2";
            label2.Size = new Size(37, 16);
            label2.TabIndex = 2;
            label2.Text = "Clube:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(6, 10);
            label1.Name = "label1";
            label1.Size = new Size(37, 16);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // BoxNomeCriarJogador
            // 
            BoxNomeCriarJogador.Location = new Point(6, 29);
            BoxNomeCriarJogador.Name = "BoxNomeCriarJogador";
            BoxNomeCriarJogador.Size = new Size(285, 23);
            BoxNomeCriarJogador.TabIndex = 1;
            // 
            // clubeBindingSource
            // 
            clubeBindingSource.DataSource = typeof(Dominio.Modelos.Clube);
            // 
            // FormCriarJogador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(328, 397);
            Controls.Add(BoxCriar);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCriarJogador";
            Text = "Cadastro de Jogador";
            Load += FormCriarJogador_Load;
            BoxCriar.ResumeLayout(false);
            BoxCriar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)clubeBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox BoxCriar;
        private Button CancelarJogador;
        private Button SalvarJogador;
        private TextBox BoxIdadeCriarJogador;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox BoxNomeCriarJogador;
        private Label label5;
        private TextBox BoxPesoCriarJogador;
        private Label label7;
        private TextBox BoxAlturaCriarJogador;
        private Label label6;
        private DateTimePicker NascimentoCriarJogador;
        private ComboBox ComboBoxClubeCriarJogador;
        private BindingSource clubeBindingSource;
        private BindingSource clubeBindingSource1;
    }
}