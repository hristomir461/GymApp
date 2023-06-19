using Guna.UI2.WinForms;
using gym.Data;
using gym.Services;
using Microsoft.IdentityModel.Tokens;
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
    public partial class UC_Cards : UserControl
    {
        public CardService cardService { get; set; }

        public int SelectedId { get; set; }
        public Guna.UI2.WinForms.Guna2Button btn { get; set; }
        public UC_Cards(Guna.UI2.WinForms.Guna2Button home)
        {
            InitializeComponent();
            cardService = new CardService();

            if (cardService.Count() > 0)
            {
                guna2TextBox1.Text = cardService.GetFirst().FirstName.ToString();
                this.SelectedId = cardService.GetFirst().Id;
                foreach (var card in cardService.getAll())
                {
                    card.ExpiresAt = DateTime.Parse(card.ExpiresAt.ToLongDateString());
                    cardBindingSource.Add(card);
                }
            }

            btn = home;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                guna2TextBox1.Text = guna2DataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                this.SelectedId = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            }

        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(userControl);
            this.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (this.SelectedId != null)
            {

                cardService.Renew(this.SelectedId,
                              guna2RadioButton1.Checked,
                              guna2RadioButton2.Checked);
            }
            UC_Home uc = new UC_Home();
            addUserControl(uc);
            btn.Checked = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (this.SelectedId != null)
            {
                cardService.Delete(this.SelectedId);
                UC_Home uc = new UC_Home();
                addUserControl(uc);
                btn.Checked = true;
            }
        }
    }
}
