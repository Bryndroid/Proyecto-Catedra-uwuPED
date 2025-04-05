using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;
using PictureBox = System.Windows.Forms.PictureBox;
using Timer = System.Windows.Forms.Timer;
using Proyecto_Catedra_PED.EMPLEADOS;

namespace Proyecto_Catedra_PED.Categorias
{
  
    public partial class Inicio : Form
    {
        private int indicerdb = 1;
    

     
        public Inicio()
        {
            InitializeComponent();
         
            
            timer1.Interval = 3000;
            timer1.Start();
            rdb1.Checked = true;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            //Codigo ocupado para el movimiento de las imagenes en el form
            if (rdb1.Checked==true)
            {
                pb1.Visible = true;
                pb2.Visible = false;
                pb3.Visible = false;
                pb4.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (indicerdb)
            {
                case 1:
                    rdb1.Checked = true;
                    break;
                case 2:
                    rdb2.Checked = true;
                    break;
                case 3:
                    rdb3.Checked = true;
                    break;
                case 4:
                    rdb4.Checked = true;
                    break;
            }

            indicerdb = indicerdb % 4 + 1;
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb2.Checked == true)
            {
                pb1.Visible = false;
                pb2.Visible = true;
                pb3.Visible = false;
                pb4.Visible = false;
            }
        }

        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb3.Checked == true)
            {
                pb1.Visible = false;
                pb2.Visible = false;
                pb3.Visible = true;
                pb4.Visible = false;
            }
        }

        private void rdb4_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb4.Checked == true)
            {
                pb1.Visible = false;
                pb2.Visible = false;
                pb3.Visible = false;
                pb4.Visible = true;
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      

        public void Dibujar()
        {
            int X = groupBox1.Width / 2;
            int Y = groupBox1.Height / 2;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form agua = new VistaVentas();

            agua.Show();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form agua = new Almacenamiento();
            agua.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form agua = new GERENTE();
            agua.Show();
        }

        private void Color_Tick(object sender, EventArgs e)
        {

        }
    }
}
