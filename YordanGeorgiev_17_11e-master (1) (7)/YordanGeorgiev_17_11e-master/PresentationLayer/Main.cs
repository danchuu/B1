using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User potrebiteli = new User();
            potrebiteli.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Interest interesi = new Interest();
            interesi.Show();
            this.Close();
        }
    }
}
