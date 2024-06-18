using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using FirebirdSql.Data.Services;
using Cod3rsGrowth.Dominio.Interfaces;
using System;
using System.Windows.Forms;
using Cod3rsGrowth.Dominio.Enums;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.Forms
{
    public partial class Form1 : Form
    {
        private readonly ServicoClube _servicoClube;
        private readonly ServicoJogador _servicoJogador;
        Filtro filtroClube = new();
        Filtro filtroJogador = new();

        public Form1(ServicoClube servicoClube, ServicoJogador servicoJogador)
        {
            _servicoClube = servicoClube;
            _servicoJogador = servicoJogador;
            InitializeComponent();
        }

        private void CarregarListasDoForm1(object sender, EventArgs e)
        {
            CarregarListaAtualizadas();
        }

        private void CarregarListaAtualizadas()
        {
            tabelaClube.DataSource = null;
            tabelaClube.DataSource = _servicoClube.ObterTodos(filtroClube);
            tabelaJogadores.DataSource = null;
            tabelaJogadores.DataSource = _servicoJogador.ObterTodos(filtroJogador);
        }

        private void AoClicarPesquisarNaAbaClubes(object sender, EventArgs e)
        {
            CarregarListaAtualizadas();
        }

        private void AoClicarPesquisarNaAbaJogador(object sender, EventArgs e)
        {
            CarregarListaAtualizadas();
        }


        private void AoDigitarONomeDoClube(object sender, EventArgs e)
        {
            filtroClube.Nome = BoxNomeClube.Text;
            CarregarListaAtualizadas();
        }

        private void AoDigitaroNomeDoJogador(object sender, EventArgs e)
        {
            filtroJogador.Nome = BoxNomeJogador.Text;
            CarregarListaAtualizadas();
        }

        private void AoSelecionarOEstadoDoClube(object sender, EventArgs e)
        {
            var EnumVazio = -1;
            if (EnumEstado.SelectedIndex != EnumVazio)
            {
                filtroClube.Estado = (EstadosEnum?)EnumEstado.SelectedIndex;
                CarregarListaAtualizadas();
            }
            else
            {
                filtroClube.Estado = null;
                CarregarListaAtualizadas();
            }

        }


        private void AoDigitarOIdDoClubeDoJogador(object sender, EventArgs e)
        {
            if (!BoxIdClube.Text.IsNullOrEmpty())
            {
                filtroJogador.IdClube = int.Parse(BoxIdClube.Text);
                CarregarListaAtualizadas();
            }
            else
            {
                filtroJogador.IdClube = null;
                CarregarListaAtualizadas();
            }
        }

        private void AoSelecionarADataInicialNaAbaJogadores(object sender, EventArgs e)
        {
            filtroJogador.DataPiso = DataInicialJogador.Value;
        }

        private void AoSelecionarADataFinalNaAbaJogadores(object sender, EventArgs e)
        {
            filtroJogador.DataTeto = DataFinalJogador.Value;
        }

        private void AoSelecionarADataInicialNaAbaClubes(object sender, EventArgs e)
        {
            filtroClube.DataPiso = DataInicialClube.Value;
        }

        private void AoSelecionarADataFinalNaAbaClubes(object sender, EventArgs e)
        {
            filtroClube.DataTeto = DataFinalClube.Value;
        }

        private void AoClicarLimparCamposNaAbaClubes(object sender, EventArgs e)
        {
            var DataInicial = "01/01/1800";
            var EnumVazio = -1;
            EnumEstado.SelectedIndex = EnumVazio;
            DataInicialClube.Value = DateTime.Parse(DataInicial);
            DataFinalClube.Value = DateTime.Now;
            BoxNomeClube.Text = null;
            CarregarListaAtualizadas();
        }

        private void AoClicarLimparCamposNaAbaJogador(object sender, EventArgs e)
        {
            var DataInicial = "01/01/1800";
            BoxNomeJogador.Text = null;
            DataInicialJogador.Value = DateTime.Parse(DataInicial);
            DataFinalJogador.Value = DateTime.Now;
            BoxIdClube.Text = "";
            CarregarListaAtualizadas();
        }
    }
}

