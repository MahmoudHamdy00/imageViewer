using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imageViewer
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();

        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\Mahmoud Hamdy\OneDrive - Assuit University - Staff\Documents\GitHub\imageViewer\imageViewer\Resources\Personal Photo.jpg");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/MahmoudH.Morsy/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/mahmoudhmorsy/");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/MahmoudHamdy00");
        }
    }
}
