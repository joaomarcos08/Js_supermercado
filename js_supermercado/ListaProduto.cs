using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace js_supermercado
{
    public partial class ListaProduto : Form
    {
        public ListaProduto(string p)
        {
            string perfil;
            InitializeComponent();
            perfil = p;

            if (int.Parse(perfil) == 3)
            {
                labelNovoProduto.Visible = true;
                dataGridView1.Columns["Column5"].Visible = true;
            }
            else
            {
                labelNovoProduto.Visible = false;
                dataGridView1.Columns["Column5"].Visible = false;
            }
        }
        SqlConnection c = new SqlConnection(@"Data Source=SNBBLLAB02-12\JOAO;Initial Catalog=jsSupermercado;Integrated Security=True");

        private void data()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            int i = 0;

            c.Open();
            SqlCommand cmd = new SqlCommand("select imagem, produto, descricao from produto ", c);
            SqlDataReader fill = cmd.ExecuteReader();
            while (fill.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = Image.FromFile("C:/Users/SN00091501/Desktop/JS_Supermercado/Imagens_Produtos/" + fill[0].ToString() + "");
                dataGridView1.Rows[i].Cells[1].Value = fill[1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = fill[2].ToString();
                i++;
            }
            c.Close();
        }

        private void data2()
        {
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            int i = 0;
            string nomePerfil;

            c.Open();
            SqlCommand cmd = new SqlCommand("select comentario, idPerfil, daata, descricao from comentarios A inner join produto B on A.idProduto = B.id ", c);
            SqlDataReader fill = cmd.ExecuteReader();
            while (fill.Read())
            {
                dataGridView2.Rows.Add();
                if (int.Parse(fill[1].ToString()) == 1)
                {
                    dataGridView2.Rows[i].Cells[1].Value = "Vendedor";
                } else if (int.Parse(fill[1].ToString()) == 2)
                {
                    dataGridView2.Rows[i].Cells[1].Value = "Supervisor";
                }
                else if (int.Parse(fill[1].ToString()) == 3)
                {
                    dataGridView2.Rows[i].Cells[1].Value = "Gerente";
                }

                dataGridView2.Rows[i].Cells[0].Value = fill[0].ToString();
                dataGridView2.Rows[i].Cells[2].Value = fill[2].ToString();
                dataGridView2.Rows[i].Cells[3].Value = fill[3].ToString();
                i++;
            }
            c.Close();
        }

        private void ListaProduto_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            panel2.Visible = false;
            data();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string produto = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(4))
            {
                if (
                MessageBox.Show
                ("Atenção! Tem certeza quedeseja excluir o produto ? " +
                "Essa ação não poderá ser desfeita.",
                "Exclusão de produto", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    c.Open();
                    SqlCommand delete = new SqlCommand("delete from produto where produto = '" + produto + "'", c);
                    int resultado = delete.ExecuteNonQuery();

                    if (resultado == 1)
                    {
                        MessageBox.Show("produto deletado");

                        c.Close();
                        data();
                        c.Open();
                    }
                    else
                    {
                        MessageBox.Show("Erro de Exclusão");
                    }
                    c.Close();
                }
            }
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(3))
            {
                dataGridView1.Visible = false;
                dataGridView2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                data2();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            panel2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            panel2.Visible = false;
        }
    }
}
