
namespace Cod3rsGrowth.Forms
{
    partial class FormCriarClube
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
            label1 = new Label();
            BoxNomeCriarClube = new TextBox();
            BoxCriar = new GroupBox();
            FundacaoCriarClube = new DateTimePicker();
            CancelarClube = new Button();
            SalvarClube = new Button();
            BotaoNaoCriarClube = new RadioButton();
            BotaoSimCriarClube = new RadioButton();
            EstadoCriarClube = new ComboBox();
            BoxEstadioCriarClube = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            BoxCriar.SuspendLayout();
            SuspendLayout();
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
            // BoxNomeCriarClube
            // 
            BoxNomeCriarClube.Location = new Point(6, 29);
            BoxNomeCriarClube.Name = "BoxNomeCriarClube";
            BoxNomeCriarClube.Size = new Size(285, 23);
            BoxNomeCriarClube.TabIndex = 1;
            // 
            // BoxCriar
            // 
            BoxCriar.BackColor = Color.LightGray;
            BoxCriar.Controls.Add(FundacaoCriarClube);
            BoxCriar.Controls.Add(CancelarClube);
            BoxCriar.Controls.Add(SalvarClube);
            BoxCriar.Controls.Add(BotaoNaoCriarClube);
            BoxCriar.Controls.Add(BotaoSimCriarClube);
            BoxCriar.Controls.Add(EstadoCriarClube);
            BoxCriar.Controls.Add(BoxEstadioCriarClube);
            BoxCriar.Controls.Add(label5);
            BoxCriar.Controls.Add(label4);
            BoxCriar.Controls.Add(label3);
            BoxCriar.Controls.Add(label2);
            BoxCriar.Controls.Add(label1);
            BoxCriar.Controls.Add(BoxNomeCriarClube);
            BoxCriar.Location = new Point(12, 6);
            BoxCriar.Name = "BoxCriar";
            BoxCriar.Size = new Size(304, 361);
            BoxCriar.TabIndex = 2;
            BoxCriar.TabStop = false;
            // 
            // FundacaoCriarClube
            // 
            FundacaoCriarClube.CalendarFont = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FundacaoCriarClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FundacaoCriarClube.Format = DateTimePickerFormat.Short;
            FundacaoCriarClube.Location = new Point(7, 88);
            FundacaoCriarClube.Name = "FundacaoCriarClube";
            FundacaoCriarClube.Size = new Size(284, 22);
            FundacaoCriarClube.TabIndex = 18;
            // 
            // CancelarClube
            // 
            CancelarClube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CancelarClube.BackColor = SystemColors.AppWorkspace;
            CancelarClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            CancelarClube.ForeColor = Color.Black;
            CancelarClube.Location = new Point(172, 322);
            CancelarClube.Name = "CancelarClube";
            CancelarClube.Size = new Size(102, 27);
            CancelarClube.TabIndex = 17;
            CancelarClube.Text = " Cancelar";
            CancelarClube.UseVisualStyleBackColor = false;
            CancelarClube.Click += CancelarClube_Click;
            // 
            // SalvarClube
            // 
            SalvarClube.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SalvarClube.BackColor = SystemColors.AppWorkspace;
            SalvarClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            SalvarClube.ForeColor = Color.Black;
            SalvarClube.Location = new Point(19, 322);
            SalvarClube.Name = "SalvarClube";
            SalvarClube.Size = new Size(102, 27);
            SalvarClube.TabIndex = 16;
            SalvarClube.Text = "Salvar";
            SalvarClube.UseVisualStyleBackColor = false;
            SalvarClube.Click += AoClicarEmSalvarNaAbaCriarClube;
            // 
            // BotaoNaoCriarClube
            // 
            BotaoNaoCriarClube.AutoSize = true;
            BotaoNaoCriarClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BotaoNaoCriarClube.Location = new Point(21, 279);
            BotaoNaoCriarClube.Name = "BotaoNaoCriarClube";
            BotaoNaoCriarClube.Size = new Size(44, 20);
            BotaoNaoCriarClube.TabIndex = 12;
            BotaoNaoCriarClube.TabStop = true;
            BotaoNaoCriarClube.Text = "Não";
            BotaoNaoCriarClube.UseVisualStyleBackColor = true;
            // 
            // BotaoSimCriarClube
            // 
            BotaoSimCriarClube.AutoSize = true;
            BotaoSimCriarClube.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BotaoSimCriarClube.Location = new Point(21, 253);
            BotaoSimCriarClube.Name = "BotaoSimCriarClube";
            BotaoSimCriarClube.Size = new Size(43, 20);
            BotaoSimCriarClube.TabIndex = 11;
            BotaoSimCriarClube.TabStop = true;
            BotaoSimCriarClube.Text = "Sim";
            BotaoSimCriarClube.UseVisualStyleBackColor = true;
            // 
            // EstadoCriarClube
            // 
            EstadoCriarClube.DropDownHeight = 110;
            EstadoCriarClube.DropDownStyle = ComboBoxStyle.DropDownList;
            EstadoCriarClube.FlatStyle = FlatStyle.Flat;
            EstadoCriarClube.FormattingEnabled = true;
            EstadoCriarClube.IntegralHeight = false;
            EstadoCriarClube.Items.AddRange(new object[] { "        AC", "        AL", "        AP", "        AM", "        BA", "        CE", "        ES", "        GO", "        MA", "        MT", "        MS", "        MG", "        PA", "        PB", "        PR", "        PE", "        PI", "        RJ", "        RN", "        RS", "        RO", "        RR", "        SC", "        SP", "        SE", "        TO" });
            EstadoCriarClube.Location = new Point(7, 198);
            EstadoCriarClube.Name = "EstadoCriarClube";
            EstadoCriarClube.Size = new Size(95, 23);
            EstadoCriarClube.TabIndex = 10;
            EstadoCriarClube.Tag = "";
            // 
            // BoxEstadioCriarClube
            // 
            BoxEstadioCriarClube.Location = new Point(6, 143);
            BoxEstadioCriarClube.Name = "BoxEstadioCriarClube";
            BoxEstadioCriarClube.Size = new Size(285, 23);
            BoxEstadioCriarClube.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(6, 234);
            label5.Name = "label5";
            label5.Size = new Size(199, 16);
            label5.TabIndex = 5;
            label5.Text = "O estadio possui cobertura anti-chuva?";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(7, 179);
            label4.Name = "label4";
            label4.Size = new Size(42, 16);
            label4.TabIndex = 4;
            label4.Text = "Estado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(6, 124);
            label3.Name = "label3";
            label3.Size = new Size(45, 16);
            label3.TabIndex = 3;
            label3.Text = "Estadio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 69);
            label2.Name = "label2";
            label2.Size = new Size(56, 16);
            label2.TabIndex = 2;
            label2.Text = "Fundacao:";
            // 
            // FormCriarClube
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(328, 374);
            Controls.Add(BoxCriar);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCriarClube";
            Text = "Cadastro de Clube";
            Load += FormCriarClube_Load;
            BoxCriar.ResumeLayout(false);
            BoxCriar.PerformLayout();
            ResumeLayout(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Label label1;
        private TextBox BoxNomeCriarClube;
        private GroupBox BoxCriar;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private TextBox BoxEstadioCriarClube;
        private RadioButton BotaoNaoCriarClube;
        private RadioButton BotaoSimCriarClube;
        private ComboBox EstadoCriarClube;
        private Button CancelarClube;
        private Button SalvarClube;
        private DateTimePicker FundacaoCriarClube;
    }
}