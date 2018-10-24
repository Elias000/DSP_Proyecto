using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Inicio
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam,int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112,0xf012,0);
        }


        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if((textUsuario.Text != "") && (textContra.Text != "")){

                if((textUsuario.Text == "Elias") && (textContra.Text == "1234")){

                    Interfaz interfaz = new Interfaz();
                    interfaz.Show();
                    interfaz.nombre.Text = textUsuario.Text;
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Usuario Y/O Contraseña incorrectas");
                    textContra.Clear();
                }
            }


        }

        private void Mostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (Mostrar.Checked == true)
            {
                textContra.UseSystemPasswordChar = false;
            }
            else
            {
                textContra.UseSystemPasswordChar = true;
            }
        }

      

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

      
      
    }
}
