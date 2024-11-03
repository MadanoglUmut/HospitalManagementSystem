using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MuayneEt : Form
    {
        public MuayneEt()
        {
            InitializeComponent();
            button3.Visible= false;
        }

        NpgsqlConnection baglantiOne = new NpgsqlConnection("server=localHost; port=5432; Database=hastaneDB; user ID=postgres; password=1234");

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 viewOne= new Form1();
            viewOne.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("MUAYNE İD GİRİLMEDEN MUAYNE YAPILAMAZ");
                }
                else
                {
                    baglantiOne.Open();
                    NpgsqlCommand komutOne = new NpgsqlCommand("insert into muayne(id,hastaid,hastasikayet,tani,tedavi,muaynetarih) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglantiOne);
                    komutOne.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
                    komutOne.Parameters.AddWithValue("@p2", textBox2.Text);
                    komutOne.Parameters.AddWithValue("@p3", textBox3.Text);
                    komutOne.Parameters.AddWithValue("@p4", textBox4.Text);
                    komutOne.Parameters.AddWithValue("@p5", textBox5.Text); ;
                    komutOne.Parameters.AddWithValue("@p6", Convert.ToDateTime(textBox6.Text));
                    komutOne.ExecuteNonQuery();
                    baglantiOne.Close();
                    MessageBox.Show("Hasta Muayne İşlemi Başarılıyla Gerçekleşti");
                    button2.Visible = true;
                }
            }
            catch 
            {
                MessageBox.Show("Hasta Bir Günde Sadece Bir Defa Muayne Olabilir");
            }

            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReceteYaz viewTwo=new ReceteYaz();
            viewTwo.Show();
            this.Hide();
        }
    }
}
