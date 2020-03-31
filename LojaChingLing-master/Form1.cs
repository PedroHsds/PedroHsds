using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace LojaCL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //Enviroment.Exit(0); esse n ta funcionando, ctz q n estou vendo o erro (que e bobo)
            this.Close();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            String str = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\programas\\LojaChingLing-master\\DbLoja.mdf;Integrated Security=True;Connect Timeout=30";
            string usu = "select login,senha from usuario where login=@login and senha=@senha ";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(usu, con);
            cmd.Parameters.AddWithValue("@login", SqlDbType.NVarChar).Value = textBox1.Text.Trim();
            cmd.Parameters.AddWithValue("@senha", SqlDbType.NVarChar).Value = textBox2.Text.Trim();
            con.Open();
            cmd.CommandType = CommandType.Text;
            SqlDataReader usuario = cmd.ExecuteReader();
            if (usuario.HasRows)
            {
                this.Hide();
                FrmPrincipal pri = new FrmPrincipal();
                pri.Show();
                con.Close();
            }else 
                {
                    MessageBox.Show("login ou senha incorretos! Tente novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    con.Close();
                }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
