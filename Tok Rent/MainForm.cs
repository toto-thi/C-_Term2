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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tmCalTime_Tick_1(object sender, EventArgs e)
            
        {
            DateTime dt = DateTime.Now;
            this.lbShowTime.Text = dt.ToString("hh:mm:ss tt");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            //show date and time
            lbShowDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            tmCalTime.Start();


            //UI
            pnNav.Height = btnDashboard.Height;
            pnNav.Top = btnDashboard.Top;
            pnNav.Left = btnDashboard.Left;
            btnDashboard.FillColor = Color.FromArgb(0, 205, 172);
            btnDashboard.ForeColor = Color.White;

            pnDashboard.Show();
            pnRental.Hide();
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            //nav-track control
            pnNav.Height = btnDashboard.Height;
            pnNav.Top = btnDashboard.Top;
            pnNav.Left = btnDashboard.Left;

            //fill color control
            btnDashboard.FillColor = Color.FromArgb(0, 205, 172);
            btnBill.FillColor = Color.Transparent;
            btnRent.FillColor = Color.Transparent; 
            btnManage.FillColor = Color.Transparent;
            btnLogOut.FillColor = Color.Transparent;

            //text color control
            btnDashboard.ForeColor = Color.White;
            btnRent.ForeColor = Color.Black;
            btnBill.ForeColor = Color.Black;
            btnManage.ForeColor = Color.Black;

            pnDashboard.Show();

        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            //nav-track control
            pnNav.Height = btnRent.Height;
            pnNav.Top = btnRent.Top;
            
            //fill color control
            btnDashboard.FillColor = Color.Transparent;
            btnBill.FillColor = Color.Transparent;
            btnLogOut.FillColor = Color.Transparent;
            btnManage.FillColor = Color.Transparent;
            btnRent.FillColor = Color.FromArgb(0, 205, 172);

            //text color control
            btnRent.ForeColor = Color.White;
            btnDashboard.ForeColor = Color.Black;
            btnBill.ForeColor = Color.Black;
            btnManage.ForeColor = Color.Black;

            pnRental.Show();
            pnDashboard.Hide();

        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            //nav-track control
            pnNav.Height = btnBill.Height;
            pnNav.Top = btnBill.Top;

            //fill color control
            btnDashboard.FillColor = Color.Transparent;
            btnRent.FillColor = Color.Transparent;
            btnLogOut.FillColor = Color.Transparent;
            btnManage.FillColor= Color.Transparent;
            btnBill.FillColor = Color.FromArgb(0, 205, 172);

            //text color control
            btnBill.ForeColor = Color.White;
            btnDashboard.ForeColor = Color.Black;
            btnRent.ForeColor = Color.Black;
            btnManage.ForeColor = Color.Black;

            pnDashboard.Hide();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            //nav-track control
            pnNav.Height = btnManage.Height;
            pnNav.Top = btnManage.Top;

            //fill color control
            btnDashboard.FillColor = Color.Transparent;
            btnRent.FillColor = Color.Transparent;
            btnLogOut.FillColor = Color.Transparent;
            btnBill.FillColor = Color.Transparent;
            btnManage.FillColor = Color.FromArgb(0, 205, 172);

            //text color control
            btnBill.ForeColor = Color.Black;
            btnDashboard.ForeColor = Color.Black;
            btnRent.ForeColor = Color.Black;
            btnManage.ForeColor = Color.White;

            pnDashboard.Hide();
        }

        
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmCalTime_Tick(object sender, EventArgs e)
        {
            lbShowTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }


    }
}
