using HotelManager.DAO;
using HotelManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fManagement: Form
    {
        private string userName;
        public fManagement(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            fLoad();
        }
        public bool IsAdmin()
        {
            return AccountTypeDAO.Instance.GetStaffTypeByUserName(userName).Id == 1;
        }
        void fLoad()
        {

            panelLeft.Width = 177;
            
        }
        private bool CheckAccess(string nameform)
        {
            return AccessDAO.Instance.CheckAccess(userName, nameform);
        }
       
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

 

       
        private void btnNavigationPanel_Click_1(object sender, EventArgs e)
        {
            if (panelLeft.Width == 42)
            {
                panelLeft.Width = 177;
                panelRight.Width = 939;
                this.Width = 1116;
            }
            else
            {
                panelLeft.Width = 42;
                panelRight.Width = 807;
                this.Width = 981;
            }
        }

        private void titleSignUpRoom_Click(object sender, EventArgs e)
        {

            if (CheckAccess("fBookRoom"))
            {
                Hide();
                fBookRoom f = new fBookRoom();
                f.ShowDialog();
                Show();
            }
            else MessageBox.Show("Bạn không quyền truy cập.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            fLogin login = new fLogin();
            login.ShowDialog();
        }

        private void titleRecieveRoom_Click(object sender, EventArgs e)
        {
           
        }

        private void titleSendRoom_Click(object sender, EventArgs e)
        {
          
        }

        private void titlePay_Click(object sender, EventArgs e)
        {
           

        }

        private void titleManageRoom_Click(object sender, EventArgs e)
        {
          

        }
        private void btnAccountProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            fProfile fProfile = new fProfile(userName);
            fProfile.ShowDialog();
            this.Show();
        }

        private void metroTile17_Click(object sender, EventArgs e)
        {
           
           
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
           
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
         
        }

        private void metroTile2_Click(object sender, EventArgs e)
        { 
          
        }

        private void btnIntroduce_Click(object sender, EventArgs e)
        {
            this.Hide();
            fAbout fAbout = new fAbout();
            fAbout.ShowDialog();
            this.Show();
        }

        private void title_Click(object sender, EventArgs e)
        {
           
          
        }

        private void metroTile16_Click(object sender, EventArgs e)
        {
          
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
