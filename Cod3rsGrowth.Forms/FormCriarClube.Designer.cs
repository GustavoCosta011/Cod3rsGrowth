
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCriarClube));
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
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // BoxNomeCriarClube
            // 
            resources.ApplyResources(BoxNomeCriarClube, "BoxNomeCriarClube");
            BoxNomeCriarClube.Name = "BoxNomeCriarClube";
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
            resources.ApplyResources(BoxCriar, "BoxCriar");
            BoxCriar.Name = "BoxCriar";
            BoxCriar.TabStop = false;
            // 
            // FundacaoCriarClube
            // 
            resources.ApplyResources(FundacaoCriarClube, "FundacaoCriarClube");
            FundacaoCriarClube.Format = DateTimePickerFormat.Short;
            FundacaoCriarClube.Name = "FundacaoCriarClube";
            // 
            // CancelarClube
            // 
            resources.ApplyResources(CancelarClube, "CancelarClube");
            CancelarClube.BackColor = SystemColors.AppWorkspace;
            CancelarClube.ForeColor = Color.Black;
            CancelarClube.Name = "CancelarClube";
            CancelarClube.UseVisualStyleBackColor = false;
            CancelarClube.Click += CancelarClube_Click;
            // 
            // SalvarClube
            // 
            resources.ApplyResources(SalvarClube, "SalvarClube");
            SalvarClube.BackColor = SystemColors.AppWorkspace;
            SalvarClube.ForeColor = Color.Black;
            SalvarClube.Name = "SalvarClube";
            SalvarClube.UseVisualStyleBackColor = false;
            SalvarClube.Click += AoClicarEmSalvarNaAbaCriarClube;
            // 
            // BotaoNaoCriarClube
            // 
            resources.ApplyResources(BotaoNaoCriarClube, "BotaoNaoCriarClube");
            BotaoNaoCriarClube.Name = "BotaoNaoCriarClube";
            BotaoNaoCriarClube.TabStop = true;
            BotaoNaoCriarClube.UseVisualStyleBackColor = true;
            // 
            // BotaoSimCriarClube
            // 
            resources.ApplyResources(BotaoSimCriarClube, "BotaoSimCriarClube");
            BotaoSimCriarClube.Name = "BotaoSimCriarClube";
            BotaoSimCriarClube.TabStop = true;
            BotaoSimCriarClube.UseVisualStyleBackColor = true;
            // 
            // EstadoCriarClube
            // 
            EstadoCriarClube.DropDownHeight = 110;
            EstadoCriarClube.DropDownStyle = ComboBoxStyle.DropDownList;
            resources.ApplyResources(EstadoCriarClube, "EstadoCriarClube");
            EstadoCriarClube.FormattingEnabled = true;
            EstadoCriarClube.Items.AddRange(new object[] { resources.GetString("EstadoCriarClube.Items"), resources.GetString("EstadoCriarClube.Items1"), resources.GetString("EstadoCriarClube.Items2"), resources.GetString("EstadoCriarClube.Items3"), resources.GetString("EstadoCriarClube.Items4"), resources.GetString("EstadoCriarClube.Items5"), resources.GetString("EstadoCriarClube.Items6"), resources.GetString("EstadoCriarClube.Items7"), resources.GetString("EstadoCriarClube.Items8"), resources.GetString("EstadoCriarClube.Items9"), resources.GetString("EstadoCriarClube.Items10"), resources.GetString("EstadoCriarClube.Items11"), resources.GetString("EstadoCriarClube.Items12"), resources.GetString("EstadoCriarClube.Items13"), resources.GetString("EstadoCriarClube.Items14"), resources.GetString("EstadoCriarClube.Items15"), resources.GetString("EstadoCriarClube.Items16"), resources.GetString("EstadoCriarClube.Items17"), resources.GetString("EstadoCriarClube.Items18"), resources.GetString("EstadoCriarClube.Items19"), resources.GetString("EstadoCriarClube.Items20"), resources.GetString("EstadoCriarClube.Items21"), resources.GetString("EstadoCriarClube.Items22"), resources.GetString("EstadoCriarClube.Items23"), resources.GetString("EstadoCriarClube.Items24"), resources.GetString("EstadoCriarClube.Items25") });
            EstadoCriarClube.Name = "EstadoCriarClube";
            EstadoCriarClube.Tag = "";
            // 
            // BoxEstadioCriarClube
            // 
            resources.ApplyResources(BoxEstadioCriarClube, "BoxEstadioCriarClube");
            BoxEstadioCriarClube.Name = "BoxEstadioCriarClube";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // FormCriarClube
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            Controls.Add(BoxCriar);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCriarClube";
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