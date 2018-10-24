using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inicio
{
    public partial class Logo : Form
    {
        public Logo()
        {
            InitializeComponent();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            labelhora.Text = DateTime.Now.ToString("hh:mm:ss");
            labelfecha.Text = DateTime.Now.ToString("dddd MMM yyy");
        }
    }
}
