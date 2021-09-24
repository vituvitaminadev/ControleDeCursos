using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeCursos
{
    class Professor
    {
        public int codigo;
        public string nomeProfessor, telefone;
        public double valorHA;
        string tabela = "tbl_professor";
        Conexao objConexao = new Conexao();

        public void CadastrarProfessor()
        {
            //passo 1: comando sql
            string inserir = $@"insert into {tabela} values(null,
                            '{nomeProfessor}','{valorHA}','{telefone}');";
            //passo 2: executar o sql
            objConexao.ExecutarComando(inserir);
        }

        public void AlterarProfessor()
        {
            string alterar = $@"UPDATE {tabela} SET     nome        = '{nomeProfessor}', 
                                                        valorHoraAula = '{valorHA}', 
                                                        telefone     = '{telefone}' 
                                                WHERE   codigo           = '{codigo}';";
            objConexao.ExecutarComando(alterar);
        }

        public void ExcluirProfessor()
        {
            string excluir = $"DELETE FROM {tabela} WHERE codigo = '{codigo}';";
            objConexao.ExecutarComando(excluir);
        }

        public DataTable ListarProfessor()
        {
            //passo 1
            string consulta = $"select * from {tabela} order by codigo";
            //passo 2 executar a consulta sql
            return objConexao.ExecutarConsulta(consulta);
        }

        public DataTable ListarNomeProfessor()
        {
            //passo 1
            string consulta = $"select codigo, nome from {tabela} order by codigo";
            //passo 2 executar a consulta sql
            return objConexao.ExecutarConsulta(consulta);
        }

    }
}
