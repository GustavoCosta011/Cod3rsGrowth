using System.Data.SqlClient;
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
        private ClubeDto clubedto = new();
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
                    if (BotaoSimCriarClube.Checked == true)
                    {
                        clube.CoberturaAntiChuva = true;
                    }
                    else if (BotaoNaoCriarClube.Checked == true)
                    {
                        clube.CoberturaAntiChuva = false;
                    }
                    else
                    {
                        clube.CoberturaAntiChuva = null;
                    }

                    _servicoClube.CriarClube(clube);
                    Close();
                }
                catch (ValidationException ex)
                {
                    string? mensagem = null;
                    string? separador = "\n";
                    mensagem = string.Join(separador, ex.Errors.Select(erro => erro.ErrorMessage));
                    var StringDialogo = $"Erro encontrado: {mensagem}";
                    var NomeDaTela = "Erro";

                    MessageBox.Show(StringDialogo, NomeDaTela, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FormatException)
                {
                    var StringDialogo = $"Erro encontrado: Os campos devem ter seus formatos preenchidos corretamente de acodo com os dados solicitados!";
                    var NomeDaTela = "Erro";

                    MessageBox.Show(StringDialogo, NomeDaTela, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    _servicoClube.EditarClube(clube);
                    Close();
                }
                catch (ValidationException ex)
                {
                    string? mensagem = null;
                    string? separador = "\n";
                    mensagem = string.Join(separador, ex.Errors.Select(erro => erro.ErrorMessage));
                    var StringDialogo = $"Erro encontrado: {mensagem}";
                    var NomeDaTela = "Erro";

                    MessageBox.Show(StringDialogo, NomeDaTela, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SqlException) 
                {
                    var NomeJáPertencente = $"O nome {BoxNomeCriarClube.Text} já pertence a Clube existente!";
                    var NomeDaTela = "Erro";

                    MessageBox.Show(NomeJáPertencente, NomeDaTela, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                catch (FormatException)
                {
                    var StringDialogo = $"Erro encontrado: Os campos devem ter seus formatos preenchidos corretamente de acodo com os dados solicitados!";
                    var NomeDaTela = "Erro";

                    MessageBox.Show(StringDialogo, NomeDaTela, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                clubedto = _servicoClube.ObterPorId((int)_id);
                BoxNomeCriarClube.Text = clubedto.Nome;
                FundacaoCriarClube.Value = clubedto.Fundacao;
                BoxEstadioCriarClube.Text = clubedto.Estadio;
                EstadoCriarClube.SelectedIndex = (int)clubedto.EstadoInt;
                if(clubedto.CoberturaAntiChuva == true)
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
