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

        private void Form1_Load(object sender, EventArgs e)
        {
            ObterListasAtualizadas();
        }

        private void ObterListasAtualizadas()
        {
            tabelaClube.DataSource = null;
            tabelaClube.DataSource = _servicoClube.ObterTodos(filtroClube);
            tabelaJogadores.DataSource = null;
            tabelaJogadores.DataSource = _servicoJogador.ObterTodos(filtroJogador);
        }

        private void tabelaClube_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabelaJogadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PesquisarClube_Click(object sender, EventArgs e)
        {
            ObterListasAtualizadas();
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void BoxNomeClube_TextChanged(object sender, EventArgs e)
        {
            filtroClube.Nome = BoxNomeClube.Text;
            ObterListasAtualizadas();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Clubes_Click(object sender, EventArgs e)
        {

        }

        private void BoxNomeJogador_TextChanged(object sender, EventArgs e)
        {
            filtroJogador.Nome = BoxNomeJogador.Text;
            ObterListasAtualizadas();
        }

        private void EnumEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EnumEstado.SelectedIndex != -1)
            {
                filtroClube.Estado = (EstadosEnum?)EnumEstado.SelectedIndex;
                ObterListasAtualizadas();
            }
            else
            {
                filtroClube.Estado = null;
                ObterListasAtualizadas();
            }

        }


        private void BoxIdClube_TextChanged(object sender, EventArgs e)
        {
            if(!BoxIdClube.Text.IsNullOrEmpty())
            {
                filtroJogador.IdClube = int.Parse(BoxIdClube.Text);
                ObterListasAtualizadas();
            }
            else
            {
                filtroJogador.IdClube = null;
                ObterListasAtualizadas();
            }

        }

        private void DataInicialJogador_ValueChanged(object sender, EventArgs e)
        {
            filtroJogador.DataPiso = DataInicialJogador.Value;
        }

        private void DataFinalJogador_ValueChanged(object sender, EventArgs e)
        {
            filtroJogador.DataTeto = DataFinalJogador.Value;
        }

        private void DataInicialClube_ValueChanged(object sender, EventArgs e)
        {
            filtroClube.DataPiso = DataInicialClube.Value;
        }

        private void DataFinalClube_ValueChanged(object sender, EventArgs e)
        {
            filtroClube.DataTeto = DataFinalClube.Value;
        }

        private void CriarClube_Click(object sender, EventArgs e)
        {

        }

        private void EditarClube_Click(object sender, EventArgs e)
        {

        }

        private void RemoverClube_Click(object sender, EventArgs e)
        {

        }

        private void CriarJogador_Click(object sender, EventArgs e)
        {

        }

        private void EditarJogador_Click(object sender, EventArgs e)
        {

        }

        private void RemoverJogador_Click(object sender, EventArgs e)
        {

        }

        private void PesquisarJogador_Click(object sender, EventArgs e)
        {
            ObterListasAtualizadas();
        }

        private void LimparCamposClube_Click(object sender, EventArgs e)
        {
            EnumEstado.SelectedIndex = -1;
            DataInicialClube.Value = DateTime.Parse("01/01/1800");
            DataFinalClube.Value = DateTime.Now;
            BoxNomeClube.Text = null;
            ObterListasAtualizadas();
        }

        private void PesquisarJogador_Click_1(object sender, EventArgs e)
        {
            ObterListasAtualizadas();
        }

        private void LimparCamposJogador_Click(object sender, EventArgs e)
        {
            BoxNomeJogador.Text = null;
            DataInicialJogador.Value = DateTime.Parse("01/01/1800");
            DataFinalJogador.Value = DateTime.Now;
            BoxIdClube.Text = "";
            ObterListasAtualizadas();
        }

        private void PesquisarClube_Click_1(object sender, EventArgs e)
        {
            ObterListasAtualizadas();
        }
    }
}

