using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cod3rsGrowth.Dominio.Enums;
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
                    jogador.IdClube = (int)ComboBoxClubeCriarJogador.SelectedValue;
                    jogador.Clube = ComboBoxClubeCriarJogador.Text;
                    jogador.Idade = !BoxIdadeCriarJogador.Text.IsNullOrEmpty() ? int.Parse(BoxIdadeCriarJogador.Text) : null;
                    jogador.DataDeNascimento = NascimentoCriarJogador.Value;
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
            }
            else
            {
                try
                {
                    jogador.Nome = BoxNomeCriarJogador.Text;
                    jogador.IdClube = (int)ComboBoxClubeCriarJogador.SelectedValue;
                    jogador.Clube = ComboBoxClubeCriarJogador.Text;
                    jogador.Idade = !BoxIdadeCriarJogador.Text.IsNullOrEmpty() ? int.Parse(BoxIdadeCriarJogador.Text) : null;
                    jogador.DataDeNascimento = NascimentoCriarJogador.Value;
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
            }
        }

        private void AoClicarCancelarNaAbaCriarJogador(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCriarJogador_Load(object sender, EventArgs e)
        {

            ComboBoxClubeCriarJogador.DataSource = _servicoClube.ObterTodos(null);
            if (_id != null)
            {
                this.Text = "Editar Jogador";
                jogador = _servicoJogador.ObterPorId((int)_id);
                BoxNomeCriarJogador.Text = jogador.Nome;
                ComboBoxClubeCriarJogador.SelectedValue = jogador.IdClube.ToString();
                ComboBoxClubeCriarJogador.Text = jogador.Clube;
                BoxIdadeCriarJogador.Text = jogador.Idade.ToString();
                NascimentoCriarJogador.Value = jogador.DataDeNascimento;
                BoxAlturaCriarJogador.Text = jogador.Altura.ToString();
                BoxPesoCriarJogador.Text = jogador.Peso.ToString();
            }
        }
    }
}
