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
        Jogador jogador = new();
        
        public FormCriarJogador(ServicoJogador servicoJogador,ServicoClube servicoClube)
        {
            _servicoJogador = servicoJogador;
            _servicoClube = servicoClube;
            InitializeComponent();
        }

        private void AoClicarSalvarNaAbaCriarJogador(object sender, EventArgs e)
        {
            try
            {
                jogador.Nome = BoxNomeCriarJogador.Text;
                jogador.IdClube = (int)ComboBoxClubeCriarJogador.SelectedValue;
                jogador.Clube = ComboBoxClubeCriarJogador.Text;
                
                if (!BoxIdadeCriarJogador.Text.IsNullOrEmpty())
                {
                    jogador.Idade = int.Parse(BoxIdadeCriarJogador.Text);
                }
                else
                {
                    jogador.Idade = null;
                }

                jogador.DataDeNascimento = NascimentoCriarJogador.Value;

                if (BoxAlturaCriarJogador.Text != "")
                {
                    jogador.Altura = double.Parse(BoxAlturaCriarJogador.Text);
                }
                else
                {
                    jogador.Altura = null;
                }
                
                if(BoxPesoCriarJogador.Text != "")
                {
                    jogador.Peso = double.Parse(BoxPesoCriarJogador.Text);
                }
                else
                {
                    jogador.Peso = null;
                }
                
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

        private void FormCriarJogador_Load(object sender, EventArgs e)
        {
            ComboBoxClubeCriarJogador.DataSource = _servicoClube.ObterTodos(null);
        }
    }
}
