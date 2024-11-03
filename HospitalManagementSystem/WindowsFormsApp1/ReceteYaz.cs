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
    public partial class ReceteYaz : Form
    {
        public ReceteYaz()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglantiOne = new NpgsqlConnection("server=localHost; port=5432; Database=hastaneDB; user ID=postgres; password=1234");

        private void button1_Click(object sender, EventArgs e)
        {
            string sorguOne = "select ilacid,ilacadedi from receteilac where receteid= '" + textBox1.Text + "'";
            baglantiOne.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorguOne, baglantiOne);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantiOne.Close();

            try
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("REÇETE NO GİRİLMEDEN REÇETE OLUŞTURULAMAZ");
                }
                else
                {
                    baglantiOne.Open();
                    NpgsqlCommand komutOne = new NpgsqlCommand("insert into recete(receteno,recetemuayneid,recetetarih) values(@p1,@p2,@p3)", baglantiOne);
                    komutOne.Parameters.AddWithValue("@p1", textBox1.Text);
                    komutOne.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));
                    komutOne.Parameters.AddWithValue("@p3", Convert.ToDateTime(textBox3.Text));
                    komutOne.ExecuteNonQuery();
                    baglantiOne.Close();
                    MessageBox.Show("Reçete No Ekleme İşlemi Başarılı");
                }
            }
            catch 
            {
                MessageBox.Show("");
            }

        }

        int i = 0;

        private void button3_Click(object sender, EventArgs e)
        {

            if (int.Parse(textBox5.Text) > 3)
            {
                MessageBox.Show("Bir İlaçtan 3 Kutu Yazılabilir");
            }
            else
            {
                if (i < 5)
                {
                    i++;

                    baglantiOne.Open();
                    NpgsqlCommand komutOne = new NpgsqlCommand("insert into receteilac(ilacid,receteid,ilacadedi) values(@p1,@p2,@p3)", baglantiOne);
                    komutOne.Parameters.AddWithValue("@p1", textBox4.Text);
                    komutOne.Parameters.AddWithValue("@p2", textBox1.Text);
                    komutOne.Parameters.AddWithValue("@p3", int.Parse(textBox5.Text));
                    komutOne.ExecuteNonQuery();
                    baglantiOne.Close();

                    textBox5.Clear();
                    textBox4.Clear();
                    MessageBox.Show("İlaç Ekleme Başarılı");

                    string sorguOne = "select ilacid,ilacadedi from receteilac where receteid= '" + textBox1.Text + "'";
                    baglantiOne.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorguOne, baglantiOne);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    baglantiOne.Close();


                }
                else
                {
                    MessageBox.Show("Maksimum 5 İlaç Eklenebilir");
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 viewOne = new Form1();
            viewOne.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintRecete viewTwo= new PrintRecete();
            viewTwo.Show(); 
            this.Hide();
        }
    }
}
