using System.DirectoryServices.ActiveDirectory;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarClube : Form
    {
        private readonly ServicoClube _servicoClube;
        private Clube clube = new();
        private int? _id = 0;
        public FormCriarClube(int? id, ServicoClube servicoClube)
        {
            _id = id;
            _servicoClube = servicoClube;
            InitializeComponent();
        }

        private void AoClicarEmSalvarNaAbaCriarClube(object sender, EventArgs e)
        {
            if(_id == null)
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
                    else if (BotaoNaoCriarClube.Checked)
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
            else
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
                    else if (BotaoNaoCriarClube.Checked)
                    {
                        clube.CoberturaAntiChuva = false;
                    }
                    _servicoClube.EditarClube((int)_id,clube);
                    Close();
                }
                catch (ValidationException ex)
                {
                    var StringDialogo = $"Erro encontrado: {ex.Message}";
                    var NomeDaTela = "Erro";

                    MessageBox.Show(StringDialogo, NomeDaTela, MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
        }

        private void CancelarClube_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCriarClube_Load(object sender, EventArgs e)
        {
            if (_id != null)
            {
                this.Text = "Editar Clube";
                clube = _servicoClube.ObterPorId((int)_id);
                BoxNomeCriarClube.Text = clube.Nome;
                FundacaoCriarClube.Value = clube.Fundacao;
                BoxEstadioCriarClube.Text = clube.Estadio;
                EstadoCriarClube.SelectedIndex = (int)clube.Estado;
                if(clube.CoberturaAntiChuva == true)
                {
                    BotaoSimCriarClube.Checked = true;
                }
                else
                {
                    BotaoNaoCriarClube.Checked = true;
                }
            }
        }
    }
}
