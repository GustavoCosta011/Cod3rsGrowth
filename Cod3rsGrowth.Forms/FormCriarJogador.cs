using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarJogador : Form
    {
        private readonly ServicoJogador _servicoJogador;
        private readonly ServicoClube _servicoClube;
        private int? _id = 0;
        private Jogador jogador = new();
        
        public FormCriarJogador(int? id ,ServicoJogador servicoJogador,ServicoClube servicoClube)
        {
            _servicoJogador = servicoJogador;
            _servicoClube = servicoClube;
            _id = id;
            InitializeComponent();
        }

        private void AoClicarSalvarNaAbaCriarJogador(object sender, EventArgs e)
        {
            if (_id == null)
            {
                try
                {
                    jogador.Nome = BoxNomeCriarJogador.Text;
                    jogador.IdClube = (int?)ComboBoxClubeCriarJogador.SelectedValue;
                    jogador.Clube = jogador.IdClube != null ? ComboBoxClubeCriarJogador.Text : null;
                    jogador.DataDeNascimento = NascimentoCriarJogador.Value.Date;
                    jogador.Idade = DateTime.Now.Year - jogador.DataDeNascimento.Year;
                    jogador.Altura = !BoxAlturaCriarJogador.Text.IsNullOrEmpty() ? double.Parse(BoxAlturaCriarJogador.Text) : null;
                    jogador.Peso = !BoxPesoCriarJogador.Text.IsNullOrEmpty() ? double.Parse(BoxPesoCriarJogador.Text) : null;

                    _servicoJogador.CriarJogador(jogador);
                    Close();
                }
                catch (ValidationException ex)
                {
                    var StringDialogo = $"Erro encontrado: {ex.Message}";
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
                    jogador.Nome = BoxNomeCriarJogador.Text;
                    jogador.IdClube = (int?)ComboBoxClubeCriarJogador.SelectedValue;
                    jogador.Clube = ComboBoxClubeCriarJogador.Text;
                    jogador.DataDeNascimento = NascimentoCriarJogador.Value.Date;
                    jogador.Idade = DateTime.Now.Year - jogador.DataDeNascimento.Year;
                    jogador.Altura = !BoxAlturaCriarJogador.Text.IsNullOrEmpty() ? double.Parse(BoxAlturaCriarJogador.Text) : null;
                    jogador.Peso = !BoxPesoCriarJogador.Text.IsNullOrEmpty() ? double.Parse(BoxPesoCriarJogador.Text) : null;

                    _servicoJogador.EditarJogador((int)_id,jogador);
                    Close();
                }
                catch (ValidationException ex)
                {
                    var StringDialogo = $"Erro encontrado: {ex.Message}";
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
        }

        private void AoClicarCancelarNaAbaCriarJogador(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCriarJogador_Load(object sender, EventArgs e)
        {
            var EnumVazio = -1;
            ComboBoxClubeCriarJogador.DataSource = _servicoClube.ObterTodos(null);
            if (_id != null)
            {
                this.Text = "Editar Jogador";
                jogador = _servicoJogador.ObterPorId((int)_id);
                BoxNomeCriarJogador.Text = jogador.Nome;
                ComboBoxClubeCriarJogador.SelectedValue = jogador.IdClube != null ? jogador.IdClube : EnumVazio;
                NascimentoCriarJogador.Value = jogador.DataDeNascimento;
                BoxAlturaCriarJogador.Text = jogador.Altura.ToString();
                BoxPesoCriarJogador.Text = jogador.Peso.ToString();
            }
            else
            {
                ComboBoxClubeCriarJogador.SelectedValue = EnumVazio;
            }  
        }
    }
}
