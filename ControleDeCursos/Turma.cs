using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ControleDeCursos
{
    class Turma
    {
        public string tabela = "tbl_turma";
        public int codigo, idCurso, idProfessor;
        public string dataInicio, dataTermino, horaInicio, horaTermino;
        Conexao objConexao = new Conexao();

        public DataTable ListarTurma()
        {
            //passo 1
            string consulta = $@"select tbl_turma.codigo, tbl_curso.nomeCurso as Curso, dataInicio, dataTermino, horaInicio, horaTermino, tbl_professor.nome as Professor from {tabela} 
                                 JOIN tbl_curso ON idCurso = tbl_curso.codigo JOIN tbl_professor ON idProfessor = tbl_professor.codigo order by codigo";
            //passo 2 executar a consulta sql
            return objConexao.ExecutarConsulta(consulta);
        }

        public void InserirTurma()
        {
            string query = $"insert into {tabela} VALUES (null, '{idCurso}', '{dataInicio}', '{dataTermino}', '{horaInicio}', '{horaTermino}', '{idProfessor}');";
            objConexao.ExecutarComando(query);
        }

        public void AlterarTurma()
        {
            string query = $@"update {tabela} set idCurso = '{idCurso}', dataInicio = '{dataInicio}', dataTermino = '{dataTermino}', horaInicio = '{horaInicio}', horaTermino = '{horaTermino}', idProfessor = '{idProfessor}'
                            where tbl_turma.codigo = '{codigo}';";
            objConexao.ExecutarComando(query);
        }

        public void ExcluirTurma()
        {
            string query = $"DELETE FROM {tabela} WHERE codigo = '{codigo}';";
            objConexao.ExecutarComando(query);
        }
    }
}
