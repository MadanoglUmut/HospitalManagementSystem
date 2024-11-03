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
    public partial class PoliklinkKayitDefteri : Form
    {

        NpgsqlConnection baglantiTwo = new NpgsqlConnection("server=localHost; port=5432; Database=hastaneDB; user ID=postgres; password=1234");

        public PoliklinkKayitDefteri()
        {
            InitializeComponent();

            string sorguOne = "select muaynetarih,ad,soyad,dogumyeri,dogumtarih,hastasikayet,tani,tedavi from hasta inner join muayne on hastaid=tc  order by muaynetarih";
            baglantiTwo.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorguOne, baglantiTwo);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantiTwo.Close();

        }
       


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 viewOne=new Form1();
            viewOne.Show();
            this.Hide();
        }
    }
}
