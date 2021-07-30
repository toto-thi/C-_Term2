using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tok_Rent
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            pnSlide.Width += 2;

            if (pnSlide.Width > 445)
            {
                pnSlide.Width = 0;
            }
            if (pnSlide.Width < 0)
            {
                pnSlide.Width += 2;
            }
        }

       
    }
}
