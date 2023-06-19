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
    public partial class UC_Home : UserControl
    {
        public CardService cardService { get; set; }
        public UC_Home()
        {
            InitializeComponent();
            cardService = new CardService();
            if(cardService.Count() > 0)
            {
                label2.Text = "Total Income: $" + cardService.GetTotalIncome();
                label3.Text = "In Date Cards: " + cardService.GetInDateCards();
                label4.Text = "Expired Cards: " + cardService.GetExpiredCards();
            }
        }
    }
}
