using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using FirebirdSql.Data.Services;
using Cod3rsGrowth.Dominio.Interfaces;
using System;
using System.Windows.Forms;
using Cod3rsGrowth.Dominio.Enums;
using Microsoft.IdentityModel.Tokens;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Forms
{
    public partial class FormPrincipal : Form
    {
        private readonly ServicoClube _servicoClube;
        private readonly ServicoJogador _servicoJogador;
        Filtro filtroClube = new();
        Filtro filtroJogador = new();

        public FormPrincipal(ServicoClube servicoClube, ServicoJogador servicoJogador)
        {
            _servicoClube = servicoClube;
            _servicoJogador = servicoJogador;
            InitializeComponent();

        }

        private void CarregarListasDoFormPrincipal(object sender, EventArgs e)
        {
            CarregarListaAtualizadas();
            LimparSelecaoNaGrid(tabelaJogadores);
            LimparSelecaoNaGrid(tabelaClube);
        }

        private void CarregarListaAtualizadas()
        {
            tabelaClube.DataSource = null;
            tabelaClube.DataSource = _servicoClube.ObterTodos(filtroClube);
            tabelaJogadores.DataSource = null;
            tabelaJogadores.DataSource = _servicoJogador.ObterTodos(filtroJogador);       
        }

        private void LimparSelecaoNaGrid(DataGridView tabela)
        {
            tabela.ClearSelection();
            tabela.CurrentCell = null;
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
            filtroClube.Estado = EnumEstado.SelectedIndex != EnumVazio ? (EstadosEnum?)EnumEstado.SelectedIndex : null;
            CarregarListaAtualizadas();
        }


        private void AoDigitarONomeDoClubeDoJogador(object sender, EventArgs e)
        {
            filtroJogador.Clube = !BoxIdClube.Text.IsNullOrEmpty() ? BoxIdClube.Text : null;
            CarregarListaAtualizadas();
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

        private void AoClicarBotaoCriarNaAbaclube(object sender, EventArgs e)
        {
            int? IdClube = null;
            new FormCriarClube(IdClube, _servicoClube).ShowDialog();
            CarregarListaAtualizadas();
        }

        private void AoClicarCriarNaAbaJogador(object sender, EventArgs e)
        {
            int? id = null;
            new FormCriarJogador(id,_servicoJogador, _servicoClube).ShowDialog();
            CarregarListaAtualizadas();
        }

        private readonly string Aviso = "Aviso!!";
        private void AoClicarRemoverNaAbaClubes(object sender, EventArgs e)
        {
            string MsgNenhumClubeNãoSelecionado = "Nenhum Clube foi selecionado!!";
            try
            {
                if (tabelaClube.CurrentCell == null) throw new Exception();
                string? clubeSelecionado = tabelaClube.Rows[tabelaClube.CurrentRow.Index].Cells[idClube.Index].Value.ToString();

                if (clubeSelecionado != null)
                {
                    int idClubeSelecionado = int.Parse(clubeSelecionado);
                    string MsgConfirmacaoRemoverClube = $"Deseja excluir o Clube {tabelaClube.Rows[tabelaClube.CurrentRow.Index].Cells[NomeClube.Index].Value}?";

                    DialogResult ConfirmacaoRemoverClube = MessageBox.Show(MsgConfirmacaoRemoverClube, Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ConfirmacaoRemoverClube == DialogResult.Yes)
                    {
                        _servicoClube.RemoverClube(idClubeSelecionado);
                    }
                    else
                    {
                        LimparSelecaoNaGrid(tabelaClube);
                    }
                    CarregarListaAtualizadas();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MsgNenhumClubeNãoSelecionado, Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AoCliclarRemoverNaAbaJogadores(object sender, EventArgs e)
        {
            string MsgNenhumJogadorSelecionado = "Nenhuma Jogador foi selecionado!!";

            try
            {
                if (tabelaJogadores.CurrentCell == null) throw new Exception();
                string? jogadorSelecionado = tabelaJogadores.Rows[tabelaJogadores.CurrentRow.Index].Cells[IdJogador.Index].Value.ToString();

                if (jogadorSelecionado != null)
                {
                    int idJogadorSelecionado = int.Parse(jogadorSelecionado);
                    string MsgConfirmacaoRemoverJogador = $"Deseja excluir o Jogador {tabelaJogadores.Rows[tabelaJogadores.CurrentRow.Index].Cells[NomeJogador.Index].Value}?";

                    DialogResult ConfirmacaoRemoverClube = MessageBox.Show(MsgConfirmacaoRemoverJogador, Aviso, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (ConfirmacaoRemoverClube == DialogResult.Yes)
                    {
                        _servicoJogador.RemoverJogador(idJogadorSelecionado);
                        CarregarListaAtualizadas();
                    }
                    else
                    {
                        LimparSelecaoNaGrid(tabelaJogadores);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MsgNenhumJogadorSelecionado, Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AoclicarEditarNaAbaClube(object sender, EventArgs e)
        {
            string MsgNenhumClubeSelecionado = "Nenhuma Clube foi selecionado!!";
            try
            {
                if (tabelaClube.CurrentCell == null) throw new Exception();
                string? clubeSelecionado = tabelaClube.Rows[tabelaClube.CurrentRow.Index].Cells[idClube.Index].Value.ToString();
                int idClubeSelecionado = int.Parse(clubeSelecionado);
                new FormCriarClube(idClubeSelecionado, _servicoClube).ShowDialog();
                CarregarListaAtualizadas();
                LimparSelecaoNaGrid(tabelaClube);
            }
            catch (Exception)
            {
                MessageBox.Show(MsgNenhumClubeSelecionado, Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AoClicarEditarNaAbaJogador(object sender, EventArgs e)
        {
            string MsgNenhumJogadorSelecionado = "Nenhuma Jogador foi selecionado!!";
            try
            {
                if (tabelaJogadores.CurrentCell == null) throw new Exception();
                string? jogadorSelecionado = tabelaJogadores.Rows[tabelaJogadores.CurrentRow.Index].Cells[IdJogador.Index].Value.ToString();
                int idJogadorSelecionado = int.Parse(jogadorSelecionado);
                new FormCriarJogador(idJogadorSelecionado, _servicoJogador, _servicoClube).ShowDialog();
                CarregarListaAtualizadas();
                LimparSelecaoNaGrid(tabelaJogadores);
            }
            catch (Exception)
            {
                MessageBox.Show(MsgNenhumJogadorSelecionado, Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

