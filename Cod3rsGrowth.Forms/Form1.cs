using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using FirebirdSql.Data.Services;

namespace Cod3rsGrowth.Forms
{
    public partial class Form1 : Form
    {
        public static ServicoClube? ServicoClube { get; set; }
        public Form1(ServicoClube ServicoClube)
        {
            Form1.ServicoClube = ServicoClube;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
