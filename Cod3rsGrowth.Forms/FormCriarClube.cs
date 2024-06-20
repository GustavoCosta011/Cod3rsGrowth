using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarClube : Form
    {
        private readonly ServicoClube _servicoClube;
        Clube clube = new();
        public FormCriarClube(ServicoClube servicoClube)
        {
            _servicoClube = servicoClube;
            InitializeComponent();
        }

        private void AoClicarEmSalvarNaAbaCriarClube(object sender, EventArgs e)
        {
            try
            {
                clube.Nome = BoxNomeCriarClube.Text;
                clube.Fundacao = FundacaoCriarClube.Value;
                clube.Estadio = BoxEstadioCriarClube.Text;
                clube.Estado = (EstadosEnum)EstadoCriarClube.SelectedIndex;
                if (BotaoSimCriarClube.Checked)
                {
                    clube.CoberturaAntiChuva = true;
                }
                else if(BotaoNaoCriarClube.Checked)
                {
                    clube.CoberturaAntiChuva = false;
                }
                

                _servicoClube.CriarClube(clube);
                Close();
            }
            catch (ValidationException ex)
            {
                var StringDialogo = $"Erro encontrado: {ex.Message}";
                var NomeDaTela = "Erro";

                MessageBox.Show(StringDialogo, NomeDaTela, MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

        }

        private void CancelarClube_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCriarClube_Load(object sender, EventArgs e)
        {

        }
    }
}
