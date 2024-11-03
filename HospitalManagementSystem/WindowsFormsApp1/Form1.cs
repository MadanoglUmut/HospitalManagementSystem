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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HastayaAitReceteler viewSix=new HastayaAitReceteler();
            viewSix.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HastaOlustur viewOne= new HastaOlustur();
            viewOne.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SistemeKayitliHastaBilgileri viewTwo=new SistemeKayitliHastaBilgileri();
            viewTwo.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MuayneEt viewThree=new MuayneEt();
            viewThree.Show();   
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PoliklinkKayitDefteri viewFour=new PoliklinkKayitDefteri();
            viewFour.Show();    
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SistemdeKayitliIlaclar viewFive=new SistemdeKayitliIlaclar();
            viewFive.Show();
            this.Hide();    
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ilacaAitReceteler viewSeven=new ilacaAitReceteler();
            viewSeven.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SistemdeKayitliTumReceteler viewEight=new  SistemdeKayitliTumReceteler();
            viewEight.Show(); 
            this.Hide();
        }
    }
}
