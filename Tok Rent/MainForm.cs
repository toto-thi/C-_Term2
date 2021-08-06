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

            //load data
            loadVehicleType();
            loadCustomer();
            loadVehicleReg();

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

        //start retrieve data from db
        dbconnect db = new dbconnect();
        string query;

        //load data to rent section

        private void loadVehicleType()
        {
            query = "select * from tb_vehicle_type";

            db.EXE(query);

            cbVehivleType.ValueMember = "type_id";
            cbVehivleType.DisplayMember = "type_name";
            cbVehivleType.DataSource = db.dt;
        }

        private void loadVehicleReg()
        {
            db.addParams("@typeCar", cbVehivleType.SelectedValue.ToString());
            query = "select * from tb_vehicle where v_type = @typeCar and v_status = 1";
            db.EXE(query);

            cbVReg.ValueMember = "v_id";
            cbVReg.DisplayMember = "v_vehicle_registration";
            cbVReg.DataSource = db.dt;
        }

        //private void ShowRate()
        //{
        //    db.addParams("@typeCar", cbVehivleType.SelectedValue.ToString());
        //    query = ("select * from tb_rate where vehicle_type = @typeCar");
        //    db.EXE(query);

        //    cbRate.ValueMember = "rate_id";
        //    cbRate.DisplayMember = "rate_price";
        //    cbRate.DataSource = db.dt;
        //}
        private void loadCustomer()
        {
            query = "select c_id, c_name from tb_customer";
            db.EXE(query);

            cbCustomer.ValueMember = "c_id";
            cbCustomer.DisplayMember = "c_name";
            cbCustomer.DataSource = db.dt;
        }

        private void cbVehivleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadVehicleReg();
            //ShowRate();
        }
    }
}
