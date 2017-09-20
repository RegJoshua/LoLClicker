using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoLClicker
{
    public partial class Results : Form
    {
        public Results(Player player, int timer)
        {
            InitializeComponent();
            clickLabel.Text = "# of Clicks: " + player.Clicks;
            tLabel.Text = "Time: " + TimeSpan.FromSeconds(timer).ToString();
        }

        private void Results_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenuForm mm = new mainMenuForm();
            mm.Show();
        }
    }
}
