using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using FirebirdSql.Data.Services;
using Cod3rsGrowth.Dominio.Interfaces;
using System;
using System.Windows.Forms;

namespace Cod3rsGrowth.Forms
{
    public partial class Form1 : Form
    {
        private Filtro filtro;
        private readonly ServicoClube _servicoClube;
        private readonly ServicoJogador _servicoJogador;

        public Form1(ServicoClube servicoClube, ServicoJogador servicoJogador)
        {
            _servicoClube = servicoClube;
            _servicoJogador = servicoJogador;
            InitializeComponent();
            filtro = new Filtro
            {
                Nome = "Flamengo"
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabelaClube.DataSource = _servicoClube.ObterTodos(null);
            tabelaJogadores.DataSource = _servicoJogador.ObterTodos(null);
        }

        private void tabelaClube_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Pesquisar_Click(object sender, EventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void BoxNomeClube_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabelaJogadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

