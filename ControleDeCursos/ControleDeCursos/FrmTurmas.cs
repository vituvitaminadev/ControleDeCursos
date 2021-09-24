using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeCursos
{
    public partial class FrmTurmas : Form
    {
        public FrmTurmas()
        {
            InitializeComponent();
            dtgTurma.DataSource = objTurma.ListarTurma();
            cbCurso.ValueMember = "codigo";
            cbCurso.DisplayMember = "nomeCurso";
            cbCurso.DataSource = objCurso.ListarNomeCurso();
            cbCurso.SelectedIndex = -1;
            cbProfessor.DisplayMember = "nome";
            cbProfessor.ValueMember = "codigo";
            cbProfessor.DataSource = objProf.ListarNomeProfessor();
            cbProfessor.SelectedIndex = -1;
        }

        Curso objCurso = new Curso();
        Professor objProf = new Professor();
        Turma objTurma = new Turma();

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            bool teste = verificaVazio();

            if (teste == true)
            {
                objTurma.idCurso = int.Parse(cbCurso.SelectedValue.ToString());
                objTurma.dataInicio = dtInicio.Value.Date.ToString("yyyy/MM/dd");
                objTurma.dataTermino = dtTermino.Value.Date.ToString("yyyy/MM/dd");
                objTurma.horaInicio = txtHoraInicio.Text;
                objTurma.horaTermino = txtHoraTermino.Text;
                objTurma.idProfessor = int.Parse(cbProfessor.SelectedValue.ToString());

                objTurma.InserirTurma();
                MessageBox.Show("Turma cadastrada com sucesso!");
                dtgTurma.DataSource = objTurma.ListarTurma();

                txtHoraInicio.Clear();
                txtHoraTermino.Clear();
                cbCurso.SelectedIndex = -1;
                cbProfessor.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private Boolean verificaVazio()
        {
            if ((cbCurso.SelectedIndex == -1 || cbCurso.SelectedItem.ToString() != "") && txtHoraInicio.MaskCompleted && txtHoraTermino.MaskCompleted && (cbProfessor.SelectedIndex == -1 || cbProfessor.SelectedItem.ToString() != ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dtgTurma.DataSource = objTurma.ListarTurma();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            bool teste = verificaVazio();

            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um registro para ser alterado!");
            }
            else
            {
                if (teste == true)
                {
                    objTurma.codigo = int.Parse(txtCodigo.Text);
                    objTurma.idCurso = int.Parse(cbCurso.SelectedValue.ToString());
                    objTurma.dataInicio = dtInicio.Value.Date.ToString("yyyy/MM/dd");
                    objTurma.dataTermino = dtTermino.Value.Date.ToString("yyyy/MM/dd");
                    objTurma.horaInicio = txtHoraInicio.Text;
                    objTurma.horaTermino = txtHoraTermino.Text;
                    objTurma.idProfessor = int.Parse(cbProfessor.SelectedValue.ToString());

                    objTurma.AlterarTurma();
                    MessageBox.Show("Turma alterada com sucesso!");
                    dtgTurma.DataSource = objTurma.ListarTurma();

                    txtCodigo.Clear();
                    txtHoraInicio.Clear();
                    txtHoraTermino.Clear();
                    cbCurso.SelectedIndex = -1;
                    cbProfessor.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
            }
            
        }

        private void dtgTurma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dtgTurma.Rows[e.RowIndex].Cells[0].Value.ToString();
            cbCurso.SelectedIndex = cbCurso.FindStringExact(dtgTurma.Rows[e.RowIndex].Cells[1].Value.ToString());
            dtInicio.Value = DateTime.Parse(dtgTurma.Rows[e.RowIndex].Cells[2].Value.ToString());
            dtTermino.Value = DateTime.Parse(dtgTurma.Rows[e.RowIndex].Cells[3].Value.ToString());
            txtHoraInicio.Text = dtgTurma.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtHoraTermino.Text = dtgTurma.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbProfessor.SelectedIndex = cbProfessor.FindStringExact(dtgTurma.Rows[e.RowIndex].Cells[6].Value.ToString());
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Selecione um registro para ser excluído!");
            }
            else
            {
                objTurma.codigo = int.Parse(txtCodigo.Text);
                objTurma.ExcluirTurma();
                MessageBox.Show("Turma excluída com sucesso!");
                dtgTurma.DataSource = objTurma.ListarTurma();

                txtCodigo.Clear();
                txtHoraInicio.Clear();
                txtHoraTermino.Clear();
                cbCurso.SelectedIndex = -1;
                cbProfessor.SelectedIndex = -1;
            }
        }
    }
}
