using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_cifrado
{
    public partial class Portada : Form
    {
        public Portada()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\Img\candaditos.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Cifrar nuevo = new Cifrar();
           // nuevo.MdiParent = this;
            nuevo.Show();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Descifrar nuevo = new Descifrar();
            // nuevo.MdiParent = this;
            nuevo.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.CenterToScreen();
            Form4 nuevo = new Form4();
            // nuevo.MdiParent = this;
            nuevo.Show();
        }
    }
}
