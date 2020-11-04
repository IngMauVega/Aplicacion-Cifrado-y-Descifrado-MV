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
    public partial class Descifrar : Form
    {
        public Descifrar()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lim();
            if (comboBox1.SelectedItem == "César")
            {
                Decifrar();
            }
            if (comboBox1.SelectedItem == "Byte64")
            {
                Desencriptadobyte();
            }
            //if (comboBox1.SelectedItem == "pedro")
            //{
            //    if (txtclave.Text == "")
            //    {
            //        MessageBox.Show("Ingresa una clave para este tipo de cifrado");
            //    }
            //    if (txtclave.Text.Length != 1)
            //    {
            //        MessageBox.Show("El metodo ascii solo acepta un caracter como clave");
            //    }
            //    else
            //    {
            //       // desencriptarpedro();
            //    }
            //}
            if (comboBox1.SelectedItem == "Inversa")
            {
                inversa();
            }
            if (comboBox1.SelectedItem == "Llave")
            {
                if (txtclave.Text == "")
                {
                    MessageBox.Show("Ingresa una clave para este tipo de cifrado");
                }
                else
                {
                    llave();
                }

            }
            void Decifrar()
            {
                int letras, t;
                string juntar = "";
                string cadena = txtCadena.Text;
                letras = cadena.Length;
                char[] ch = new char[letras];
                for (int i = 0; i < letras; i = i + 1)
                {
                    t = (int)cadena[i];
                    ch[i] = (char)(t - 3);
                    juntar = juntar + ch[i];
                }
                txtdecifrado.Text = (juntar);
            }
            void lim()
            {
                txtdecifrado.Text = ("");
            }
            void Desencriptadobyte()
            {
                byte[] decryted = Convert.FromBase64String(txtCadena.Text);
                string result = System.Text.Encoding.Unicode.GetString(decryted);
                txtdecifrado.Text = (result);
            }
            void inversa()
            {
                int i = 0;
                string juntar = "";
                string mensaje = txtCadena.Text;
                string[] cifrado; cifrado = new string[mensaje.Length];
                foreach (char letra in mensaje)
                {
                    cifrado[i] = Convert.ToString(letra);
                    i = i + 1;
                }
                for (i = mensaje.Length - 1; i >= 0; i = i - 1)
                {
                    juntar = juntar + cifrado[i];
                }
                txtdecifrado.Text = (juntar);
            }
            //void desencriptarpedro()
            //{
            //    string original = txtCadena.Text, juntar = "";
            //    char clave = Convert.ToChar(txtclave.Text);
            //    int t;
            //    int pedro = (int)clave;
            //    char[] ch = new char[original.Length];
            //    for (int i = 0; i < original.Length; i = i + 1)
            //    {
            //        t = (int)original[i];
            //        ch[i] = (char)(t - pedro);
            //        juntar = juntar + ch[i];
            //    }
            //    txtdecifrado.Text = (juntar);
            //    // MessageBox.Show(Convert.ToString());
            //}
            void llave()
            {
                string original = txtCadena.Text, juntar = "";
                string clave = txtclave.Text;
                int Vnumericoclave = 0, t = 0, i = 0;
                char[] caracteroriginal = new char[original.Length];
                char[] caracterclave = new char[original.Length];
                int Lclave = txtclave.Text.Length;
                int pos = 0;
                for (i = 0; i < original.Length; i = i + 1)
                {
                    Vnumericoclave = (int)clave[pos];
                    pos = pos + 1;
                    if (pos >= Lclave)
                    { pos = 0; }
                    caracterclave[i] = (char)(Vnumericoclave);
                    t = (int)original[i];
                    caracteroriginal[i] = (char)(t - caracterclave[i]);
                    //MessageBox.Show("" + ch[i]);
                    juntar = juntar + caracteroriginal[i];
                }
               txtdecifrado.Text = (juntar);
            }
        }
    }
}
