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
    public partial class Interfaz : Form
    {
        public Interfaz()
        {
            InitializeComponent();
        }

        private void Interfaz_Load(object sender, EventArgs e)
        {
            mostrarLogo();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            OpenFileDialog Abrir = new OpenFileDialog();
            Abrir.Filter = " Archivos JPEG(*.jpg) |*.jpg";
            Abrir.InitialDirectory = "C:/Users/elias/Documents";

            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                String Dir = Abrir.FileName;
                perfil.SizeMode = PictureBoxSizeMode.StretchImage;
                Bitmap Picture = new Bitmap(Dir);

                perfil.Image = (Image)Picture;
            }


        }

        private void AbrirFormInPnal(object Formhijo)
        {
            if(this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
    
        }



        private void mostrarLogo()
        {
            AbrirFormInPnal(new Logo());
        }

        private void mostrarLogoAlCerrar(object sender, FormClosedEventArgs e)
        {
            mostrarLogo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio frm = new Inicio();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrar);
            AbrirFormInPnal(frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Categorias frm = new Categorias();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrar);
            AbrirFormInPnal(frm);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Facturas frm = new Facturas();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrar);
            AbrirFormInPnal(frm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Informacion frm = new Informacion();
            frm.FormClosed += new FormClosedEventHandler(mostrarLogoAlCerrar);
            AbrirFormInPnal(frm);
        }


     
    }
}
