using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City.scene
{
    public partial class CongratPage : Form
    {
        public CongratPage()
        {
            InitializeComponent();
        }

        private async void CongratPage_Load(object sender, EventArgs e)
        {
            label1.Visible = true;
            lbl_game_over.Visible = true;
            await WaitForSeconds(1f);
            label1.Text = "you will be moved to leaderboard in 3 secounds";
            await WaitForSeconds(1f);
            label1.Text = "you will be moved to leaderboard in 2 secounds";
            await WaitForSeconds(1f);
            label1.Text = "you will be moved to leaderboard in 1 secound";
            await WaitForSeconds(1f);
            ScoreBoard lb = new ScoreBoard();
            lb.Show();
            this.Close();
        }


        private async Task WaitForSeconds(float seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
        }


    }
}
