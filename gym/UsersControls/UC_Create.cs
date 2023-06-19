using Guna.UI2.WinForms;
using gym.Data;
using gym.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gym.UsersControls
{
    public partial class UC_Create : UserControl
    {
        public CardService cardService { get; set; }
        public Guna.UI2.WinForms.Guna2Button btn { get; set; }
        public UC_Create(Guna.UI2.WinForms.Guna2Button home)
        {
            InitializeComponent();
            cardService = new CardService();
            guna2RadioButton2.Checked = true;
            btn = home;
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(userControl);
            this.BringToFront();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.cardService.Create(guna2TextBox1.Text,
                                    guna2TextBox2.Text,
                                    guna2TextBox3.Text,
                                    double.Parse(guna2TextBox4.Text),
                                    guna2RadioButton1.Checked,
                                    guna2RadioButton2.Checked);
            UC_Home uc = new UC_Home();
            addUserControl(uc);
            this.btn.Checked = true;
        }
    }
}
