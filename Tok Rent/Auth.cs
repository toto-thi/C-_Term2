using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tok_Rent
{
    public partial class Auth : Form
    {
        public Auth()
        {
            Thread trd = new Thread(new ThreadStart(frmRun));
            trd.Start();
            Thread.Sleep(3000);
            InitializeComponent();
            trd.Abort();
        }

        public void frmRun()
        {
            Application.Run(new LoadingScreen());
        }
        
        private void Auth_Load(object sender, EventArgs e)
        {
            
        }

        private void lbResetPass_MouseHover(object sender, EventArgs e)
        {
            lbResetPass.ForeColor = Color.PaleGreen;
        }

        private void lbResetPass_MouseLeave(object sender, EventArgs e)
        {
            lbResetPass.ForeColor = Color.Black;
        }

        public MainForm mf = new MainForm();
        dbconnect db = new dbconnect();
        string query;
        
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                MessageBox.Show("ກະລູນາປອ້ນ Username ຂອງທ່ານ!");
            }
            else if( txtPassword.Text == "")
            {
                MessageBox.Show("ກະລູນາປອ້ນ Password ຂອງທ່ານ!");
            }
            else
            {
                query = "select * from tb_Auth where user_name = '" + txtUser.Text.Trim() + " 'and password = '" + txtPassword.Text.Trim() + "'";

                db.EXE(query);

                if (db.dt.Rows.Count > 0)
                {
                    mf.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username ຫລື Password ຂອງທ່ານບໍ່ຖືກຕ້ອງ,​ ກະລຸນາປ້ອນໃໝ່!");
                    txtUser.Text = "";
                    txtUser.Focus();
                    txtPassword.Text = "";
                }
            }
            
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
