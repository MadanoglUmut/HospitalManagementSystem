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
    public partial class HastaOlustur : Form
    {
        public HastaOlustur()
        {
            InitializeComponent();
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
                    MessageBox.Show("TC KİMLİK OLMADAN HASTA EKLEME İŞLEMİ YAPILAMAZ");
                }
                else
                {
                    baglantiOne.Open();
                    NpgsqlCommand komutOne = new NpgsqlCommand("insert into hasta(tc,ad,soyad,dogumyeri,dogumtarih,medenidurum,adres,telefonno) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglantiOne);

                    komutOne.Parameters.AddWithValue("@p1", textBox1.Text);
                    komutOne.Parameters.AddWithValue("@p2", textBox2.Text);
                    komutOne.Parameters.AddWithValue("@p3", textBox3.Text);
                    komutOne.Parameters.AddWithValue("@p4", textBox7.Text);
                    komutOne.Parameters.AddWithValue("@p5", textBox5.Text);
                    komutOne.Parameters.AddWithValue("@p6", textBox6.Text);
                    komutOne.Parameters.AddWithValue("@p7", textBox4.Text);
                    komutOne.Parameters.AddWithValue("@p8", textBox8.Text);
                    komutOne.ExecuteNonQuery();
                    baglantiOne.Close();
                    MessageBox.Show("Hasta Ekleme İşlemi Başarılıyla Gerçekleşti");

                }
            }
            catch 
            {
                MessageBox.Show("GİRİLEN TC KİMLİK SİSTEME KAYITLI BİR HASTA");
            }

        }
    }
}
