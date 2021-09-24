using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeCursos
{
    public partial class FrmProfessores : Form
    {
        Professor objProf = new Professor();
        public FrmProfessores()
        {
            InitializeComponent();
        }

        private Boolean verificaVazio()
        {
            if (txtNome.Text != "" && txtValorHA.Text != "" && txtTelefone.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool teste = verificaVazio();

            if (teste == true)
            {
                objProf.nomeProfessor = txtNome.Text;
                objProf.valorHA = double.Parse(txtValorHA.Text);
                objProf.telefone = txtTelefone.Text;
                objProf.CadastrarProfessor();
                MessageBox.Show("Professor cadastrado com sucesso!");

                txtNome.Clear();
                txtValorHA.Clear();
                txtTelefone.Clear();

                dtgProfessores.DataSource = objProf.ListarProfessor();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void FrmProfessores_Load(object sender, EventArgs e)
        {
            txtCodigo.Enabled = false;
            //exibir os professores cadastrados no Grid
            dtgProfessores.DataSource = objProf.ListarProfessor();
        }

        private void dtgProfessores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtgProfessores.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNome.Text = dtgProfessores.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtValorHA.Text = dtgProfessores.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTelefone.Text = dtgProfessores.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um cadastro para ser alterado!");
            }
            else
            {
                bool teste = verificaVazio();

                if (teste == true)
                {
                    objProf.codigo = int.Parse(txtCodigo.Text);
                    objProf.nomeProfessor = txtNome.Text;
                    objProf.valorHA = double.Parse(txtValorHA.Text);
                    objProf.telefone = txtTelefone.Text;

                    objProf.AlterarProfessor();
                    MessageBox.Show("Dados alterados com sucesso!");
                    txtCodigo.Clear();
                    txtNome.Clear();
                    txtValorHA.Clear();
                    txtTelefone.Clear();
                    dtgProfessores.DataSource = objProf.ListarProfessor();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um cadastro para ser excluído!");
            }
            else
            {
                objProf.codigo = int.Parse(txtCodigo.Text);
                objProf.ExcluirProfessor();
                MessageBox.Show("Professor excluído com sucesso.");
                txtCodigo.Clear();
                txtNome.Clear();
                txtValorHA.Clear();
                txtTelefone.Clear();
                dtgProfessores.DataSource = objProf.ListarProfessor();
            }
        }

    }
}
