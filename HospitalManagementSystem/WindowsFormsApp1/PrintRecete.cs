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
    public partial class PrintRecete : Form
    {

        NpgsqlConnection baglantiTwo = new NpgsqlConnection("server=localHost; port=5432; Database=hastaneDB; user ID=postgres; password=1234");
        public PrintRecete()
        {
            InitializeComponent();



            string sorguOne = "select recetemuayneid,recetetarih,receteno,ilacid,ilacadedi from recete inner join receteilac on receteid=receteno where receteno='A20'";
            baglantiTwo.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorguOne, baglantiTwo);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglantiTwo.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 viewOne= new Form1(); 
            viewOne.Show();
            this.Hide();
        }
    }
}
