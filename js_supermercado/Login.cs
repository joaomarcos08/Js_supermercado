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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection c = new SqlConnection(@"Data Source=SNBBLLAB02-12\JOAO;Initial Catalog=jsSupermercado;Integrated Security=True");

        private void entrarBtn_Click(object sender, EventArgs e)
        {
            c.Open();
            SqlCommand cmd = new SqlCommand("select * from usuarios where id = "+ idText.Text+" and senha= "+senhaText.Text+"",c);
            SqlDataReader login = cmd.ExecuteReader();

            if (login.Read()){
                MessageBox.Show("Login realizado");
                ListaProduto listaProduto = new ListaProduto(login[2].ToString());
                listaProduto.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("ERRO: Senha incorreta");
                senhaText.Text = "";
                idText.Text = "";
            }
            c.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            entrarBtn.Enabled = false;

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
        }

        private void senhaText_TextChanged(object sender, EventArgs e)
        {
            if (senhaText.Text.Length >= 6)
            {
                entrarBtn.Enabled = true;

            }
            else
            {
                entrarBtn.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '1';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '2';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '3';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '4';
        }

        private void button5_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '5';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '6';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '7';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '8';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '9';
        }

        private void button11_Click(object sender, EventArgs e)
        {
            senhaText.Text = senhaText.Text + '0';
        }

        private void button10_Click(object sender, EventArgs e)
        {
            senhaText.Text = "";
            idText.Text = "";
        }

        private void idText_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button11.Visible = false;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
            button19.Visible = true;
            button20.Visible = true;
            button21.Visible = true;
        }

        private void idText_MouseClick(object sender, MouseEventArgs e)
        {
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
            button19.Visible = true;
            button20.Visible = true;
            button21.Visible = true;
        }

        private void senhaText_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button11.Visible = true;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '1';
        }

        private void button20_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '2';
        }

        private void button19_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '3';
        }

        private void button18_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '4';
        }

        private void button17_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '5';
        }

        private void button16_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '6';
        }

        private void button15_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '7';
        }

        private void button14_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '8';
        }

        private void button13_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '9';
        }

        private void button12_Click(object sender, EventArgs e)
        {
            idText.Text = idText.Text + '0';
        }


    }    
}
