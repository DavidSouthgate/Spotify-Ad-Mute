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

namespace Spotify_Ad_Mute
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs when the form is loaded
        /// </summary>
        private void frmAbout_Load(object sender, EventArgs e)
        {

            //Position window in centre of owner window
            this.Top = Owner.Top + (Owner.Height - this.Height) / 2;
            this.Left = Owner.Left + (Owner.Width - this.Width) / 2;

            //Display version
            lblVersion.Text = "Version " + this.ProductVersion;
        }

        /// <summary>
        /// When hopepage link is clicked, open homepage in browser.
        /// </summary>
        private void HomepageLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://davidsouthgate.co.uk");
        }
    }
}
