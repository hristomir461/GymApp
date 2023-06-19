using gym.UsersControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UC_Home uc = new UC_Home();
            addUserControl(uc);
            home.Checked = true;
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            panelContainer.BringToFront();
        }

        private void home_Click_1(object sender, EventArgs e)
        {
            UC_Home uc = new UC_Home();
            addUserControl(uc);
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            UC_Create uc = new UC_Create(home);
            addUserControl(uc);
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            UC_Cards uc = new UC_Cards(home);
            addUserControl(uc);
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
