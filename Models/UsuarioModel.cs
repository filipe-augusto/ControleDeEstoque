using System.Data.SqlClient;

namespace ControleDeEstoque.Models
{
    public class UsuarioModel
    {

        public static bool ValidarUsuario(string login, string senha)
        {

                var ret = false;
            using(var conexao = new SqlConnection())
            {
                conexao.ConnectionString = @"Data Source=FILIPE-HPRPE60\SQLEXPRESS;Initial Catalog=controle-estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
              //  conexao.ConnectionString = "Data Source=FILIPE-HPRPE60;initial Catalog=controle-estoque;";
                conexao.Open();
                using(var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format(
                        "select count(*) from usuario where login='{0}' and senha='{1}'", login, senha);
                   ret = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return ret;  
         
        }
    }
}