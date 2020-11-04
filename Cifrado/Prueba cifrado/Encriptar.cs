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
    public partial class Cifrar : Form
    {
        
        public Cifrar()
        {            
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\Img\Encriptar.jpg");
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lim();
            if (comboBox1.SelectedItem == "César")
            {
                cifrar();
            }
            if (comboBox1.SelectedItem == "Byte64")
            {
                encriptadobyte();
            }
            if (comboBox1.SelectedItem == "Inversa")
            {
                inversa();
            }
            
            if (comboBox1.SelectedItem == "Llave")
            {
                if (TXTclave.Text == "")
                {
                    MessageBox.Show("Ingresa una clave para este tipo de cifrado");
                }                
                else
                {
                    llave();
                }
            }
            if (comboBox1.SelectedItem == "Columnar")
            {
                if (TXTclave.Text == "")
                {
                    MessageBox.Show("Ingresa una clave para este tipo de cifrado");
                }
                if (TXTclave.Text.Length!=5)
                {
                    MessageBox.Show("El metodo columnar requiere una clave de 5 caracteres");
                }
                else
                {
                    columnar();
                    label2.Visible = true;                   
                }
            }
        }
        void cifrar()//metodo fer cesar
        {
            int letras, posicion;
            string juntar = "";
            string cadena = txtoriginal.Text;
            letras = cadena.Length;
            char[] ch = new char[letras];
            for (int i = 0; i < letras; i = i + 1)
            {
                posicion = (int)cadena[i];
                ch[i] = (char)(posicion + 3);
                juntar = juntar + ch[i];
            }            
            txtcifrado.Text = (juntar);
        }
        void lim()
        {
            txtcifrado.Text = ("");            
        }
        void encriptadobyte()
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(txtoriginal.Text);
            string result = Convert.ToBase64String(encryted);           
            txtcifrado.Text = (result);
        }
        void inversa()
        {
            int i = 0;
            string juntar = "";          
            string mensaje = txtoriginal.Text;
            string[] cifrado; cifrado = new string[mensaje.Length];       
                foreach (char letra in mensaje)
                {               
                    cifrado[i] = Convert.ToString(letra);                    
                i = i + 1;
                }   
                for ( i =mensaje.Length-1; i >= 0; i = i - 1)
                    {     
                        juntar = juntar + cifrado[i];
                    }
            txtcifrado.Text = (juntar);                    
        }      
        private void button2_Click(object sender, EventArgs e)
        {
            columnar();
        }
        void llave()
        {
            string original = txtoriginal.Text, juntar = "";
            string clave = TXTclave.Text;
            int Vnumericoclave=0,t = 0, i = 0;           
            char[] caracteroriginal = new char[original.Length];
            char[] caracterclave = new char[original.Length];
            int Lclave = TXTclave.Text.Length;
            int pos = 0;
            for (i = 0; i < original.Length; i = i + 1)
            {                       
                Vnumericoclave = (int)clave[pos];
                pos = pos + 1;
                if (pos >= Lclave)
                    { pos = 0; }
                    caracterclave[i] = (char)(Vnumericoclave);                     
                    t = (int)original[i];
                    caracteroriginal[i] = (char)(t + caracterclave[i]);
                    //MessageBox.Show("" + ch[i]);
                    juntar = juntar + caracteroriginal[i];                               
            }
            txtcifrado.Text = (juntar);
        }
        void columnar()
        {
            string clave1 = "", clave2 = "", clave3 = "", clave4 = "", clave5 = "",juntar="";
            int i = 1, j; int col1=0, col2=0, col3=0, col4=0, col5=0;
            string original=txtoriginal.Text, clave = TXTclave.Text;
            string[,] frase; frase = new string[50, 50];
            string[] cifrado; cifrado = new string[50];    
            foreach (char pedro in clave)
            {                
                if (i == 1)  { clave1 = Convert.ToString(pedro);  }
                if (i == 2)  { clave2 = Convert.ToString(pedro);  }
                if (i == 3)  { clave3 = Convert.ToString(pedro);  }
                if (i == 4)  { clave4 = Convert.ToString(pedro);  }
                if (i == 5)  { clave5 = Convert.ToString(pedro);  }
                i = i + 1;               
            }
            List<string> letras = new List<string>()
        {
            clave5,  clave4,   clave2,    clave1,    clave3
        };
            letras.Sort();i = 0;
            foreach (string letra in letras)
            {
                if (i == 1)   { col1 = 1; }
                if (i == 2)   { col2 = 2; }
                if (i == 3)   { col3 = 3; }
                if (i == 4)   { col4 = 4; }
                if (i == 5)   { col5 = 5; }
                i = i + 1;
            }
            for (i = 0; i < txtoriginal.Text.Length/TXTclave.Text.Length; i = i + 1)
            {
                for (j = 0; j < TXTclave.Text.Length; j = j + 1)
                {
                    foreach (char juan in original)
                    {
                        frase[i, j] = Convert.ToString(juan);
                        // juntar = juntar + frase[i, j] + "\t";
                        //lstcifrado.Items.Add(juan);
                        cifrado[col1] = Convert.ToString(juan);
                    }
                }
                // lstcifrado.Items.Add(juntar + "\n");
                //txtcifrado.Text = (juntar);
            }
        }
    }
}
