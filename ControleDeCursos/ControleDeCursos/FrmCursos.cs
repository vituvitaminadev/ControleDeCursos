using System;
using System.Windows.Forms;

namespace ControleDeCursos
{
    public partial class FrmCursos : Form
    {
        public FrmCursos()
        {
            InitializeComponent();
        }

        private void FrmCursos_Load(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private Boolean verificaVazio()
        {
            if (txtNome.Text != "" && txtConteudo.Text != "" && txtValor.Text != "" && txtCH.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        Curso objCurso = new Curso();
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool teste = verificaVazio();

            if (teste == true)
            {
                objCurso.nomeCurso = txtNome.Text;
                objCurso.conteudo = txtConteudo.Text;
                objCurso.valorMensalidade = int.Parse(txtValor.Text);
                objCurso.cargaHoraria = int.Parse(txtCH.Text);

                objCurso.InserirCurso();

                MessageBox.Show("Dados enviados com sucesso.");

                txtNome.Clear();
                txtConteudo.Clear();
                txtValor.Clear();
                txtCH.Clear();

                dtgCursos.DataSource = objCurso.ListarCurso();
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dtgCursos.DataSource = objCurso.ListarCurso();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um curso para ser alterado!");
            }
            else
            {
                bool teste = verificaVazio();

                if (teste == true)
                {
                    objCurso.codigo = int.Parse(txtCodigo.Text);
                    objCurso.nomeCurso = txtNome.Text;
                    objCurso.conteudo = txtConteudo.Text;
                    objCurso.valorMensalidade = int.Parse(txtValor.Text);
                    objCurso.cargaHoraria = int.Parse(txtCH.Text);

                    objCurso.AlterarCurso();
                    MessageBox.Show("Dados alterados com sucesso.");
                    txtCodigo.Clear();
                    txtNome.Clear();
                    txtConteudo.Clear();
                    txtValor.Clear();
                    txtCH.Clear();
                    ExibirDados();
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
                MessageBox.Show("Selecione um curso para ser excluído!");
            }
            else
            {
                objCurso.codigo = int.Parse(txtCodigo.Text);
                objCurso.ExcluirCurso();
                MessageBox.Show("Curso excluído com sucesso.");
                txtCodigo.Clear();
                txtNome.Clear();
                txtConteudo.Clear();
                txtValor.Clear();
                txtCH.Clear();
                ExibirDados();
            }
        }

        private void ExibirDados()
        {
            dtgCursos.DataSource = objCurso.ListarCurso();
        }

        private void dtgCursos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text      = dtgCursos.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtNome.Text        = dtgCursos.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtConteudo.Text    = dtgCursos.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtValor.Text       = dtgCursos.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCH.Text          = dtgCursos.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
