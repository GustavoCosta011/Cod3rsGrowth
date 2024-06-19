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
        Jogador jogador = new();
        public FormCriarJogador(ServicoJogador servicoJogador)
        {
            _servicoJogador = servicoJogador;
            InitializeComponent();
        }

        private void AoClicarSalvarNaAbaCriarJogador(object sender, EventArgs e)
        {
            try
            {
                jogador.Nome = BoxNomeCriarJogador.Text;
                jogador.Clube = BoxClubeCriarJogador.Text;
                if (!BoxIdadeCriarJogador.Text.IsNullOrEmpty())
                {
                    jogador.Idade = int.Parse(BoxIdadeCriarJogador.Text);
                }
                else
                {
                    jogador.Idade = null;
                }
                jogador.DataDeNascimento = NascimentoCriarJogador.Value;
                jogador.Altura = double.Parse(BoxAlturaCriarJogador.Text);
                jogador.Peso = double.Parse(BoxPesoCriarJogador.Text);
                _servicoJogador.CriarJogador(jogador);
                Close();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"Erro encontrado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AoClicarCancelarNaAbaCriarJogador(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
