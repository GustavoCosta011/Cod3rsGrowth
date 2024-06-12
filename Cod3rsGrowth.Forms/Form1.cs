using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using FirebirdSql.Data.Services;

namespace Cod3rsGrowth.Forms
{
    public partial class Form1 : Form
    {
        private readonly ServicoClube _servicoClube;
        public Form1(ServicoClube servicoClube)
        {
            _servicoClube = servicoClube;
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
