using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LojaCL
{
    class Class1
    {
        //conectar o sqlserver express com a string de conexao
        private static string str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\programas\\LojaChingLing-master\\DbLoja.mdf;Integrated Security=True;Connect Timeout=30";
        //representa a conexao com o banco
        private static SqlConnection con = null;
        //metodo que obtem a conexao com o banco
        public static SqlConnection obterConexao()
        {
            con = new SqlConnection(str);
            //verifica a conexao
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            try
            {
                con.Open();
            }
            catch (SqlException sqle)
            {
                con = null;
            }
            return con;
        }
            public static void fecharConexao() 
            {
                //Se  nao receber nula, ele fecha a conexa
                if (con != null)
                {
                    con.Close();
                }
            }                           
           
    }
}
