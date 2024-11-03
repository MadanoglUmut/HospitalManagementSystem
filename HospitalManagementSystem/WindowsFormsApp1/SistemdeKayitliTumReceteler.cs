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
    public partial class SistemdeKayitliTumReceteler : Form
    {

        NpgsqlConnection baglantiTwo = new NpgsqlConnection("server=localHost; port=5432; Database=hastaneDB; user ID=postgres; password=1234");
        public SistemdeKayitliTumReceteler()
        {
            InitializeComponent();

            string sorguOne = "select recetetarih,tc,receteno,ad,soyad,ilacismi,ilacadedi from hasta " +
            "inner join muayne on hasta.tc=muayne.hastaid " +
            "inner join recete on recete.recetemuayneid=muayne.id " +
            "inner join receteilac on receteilac.receteid=recete.receteno " +
            "inner join ilac on receteilac.ilacid=ilac.ilacbarkod " +
            "order by recete.recetetarih";

            baglantiTwo.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorguOne, baglantiTwo);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantiTwo.Close();


        }

        private void SistemdeKayitliTumReceteler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 viewOne=new Form1();
            viewOne.Show();
            this.Hide();
        }
    }
}
