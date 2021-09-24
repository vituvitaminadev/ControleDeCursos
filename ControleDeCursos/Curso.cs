using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ControleDeCursos
{
    class Curso
    {
        public int codigo;
        public string nomeCurso, conteudo;
        public double valorMensalidade;
        public int cargaHoraria;

        Conexao objBD = new Conexao();
        string tabela = "tbl_curso";

        public void InserirCurso()
        {
            string inserir = $"INSERT INTO {tabela} VALUES (null, '{nomeCurso}', '{conteudo}', '{valorMensalidade}', '{cargaHoraria}');";
            objBD.ExecutarComando(inserir);
       }

        public void AlterarCurso()
        {
            string alterar = $@"UPDATE {tabela} SET     nomeCurso        = '{nomeCurso}', 
                                                        conteudo         = '{conteudo}', 
                                                        valorMensalidade = '{valorMensalidade}', 
                                                        cargaHoraria     = '{cargaHoraria}' 
                                                WHERE   codigo           = '{codigo}';";
            objBD.ExecutarComando(alterar);
        }

        public void ExcluirCurso()
        {
            string excluir = $"DELETE FROM {tabela} WHERE codigo = '{codigo}';";
            objBD.ExecutarComando(excluir);
        }

        public DataTable ListarCurso()
        {
            string query = $"SELECT * FROM {tabela} ORDER BY codigo;";
            return objBD.ExecutarConsulta(query);
        }

        public DataTable ListarNomeCurso()
        {
            string query = $"SELECT codigo, nomeCurso FROM {tabela} ORDER BY codigo;";
            return objBD.ExecutarConsulta(query);
               
        }
    }
}
