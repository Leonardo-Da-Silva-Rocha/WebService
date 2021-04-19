using Service.Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Service
{
    public partial class Form1 : Form
    {
        private Endereco endereco = new Endereco();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                this.endereco.Cep = this.txtCep.Text;
                this.endereco.PesquisarCep();
                this.txtEstado.Text = this.endereco.Estado;
                this.txtCidade.Text = this.endereco.Cidade;
                this.txtRua.Text = this.endereco.Rua;
                this.txtBairro.Text = this.endereco.Bairro;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            this.txtBairro.Text = string.Empty;
            this.txtCep.Text = string.Empty;
            this.txtCidade.Text = string.Empty;
            this.txtEstado.Text = string.Empty;
            this.txtRua.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}