
using MySqlConnector;
using System.Data;
using System.Windows.Forms;

namespace ControleDeCursos
{
    class Conexao
    {
        MySqlConnection conexao;

        public void Conectar()
        {
            string conn = "persist security info = false; server=localhost; database=cursos_bd; user=root; pwd=;";
            conexao = new MySqlConnection(conn);
            conexao.Open();
        }

        public void ExecutarComando(string sql)
        {
            Conectar();
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        public DataTable ExecutarConsulta(string sql)
        {
            Conectar();

            DataTable dt = new DataTable();
            MySqlDataAdapter dados = new MySqlDataAdapter(sql, conexao);

            dados.Fill(dt);
            conexao.Close();
            return dt;

        }
    }
}
