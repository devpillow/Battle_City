using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Battle_City.control;
namespace Battle_City.scene
{
    public partial class Lobby : Form
    {
        public Lobby()
        {
            InitializeComponent();
        }

        private void buttonplay_Click(object sender, EventArgs e)
        {
            GameControler.reset_level();
            GameControler.next_level();
            GameControler.playername = PlayerNametxt.Text;
        }

        private void Lobby_Load(object sender, EventArgs e)
        {

        }

        private void buttonscore_Click(object sender, EventArgs e)
        {
           ScoreBoard score_board_ = new ScoreBoard();
            score_board_.Show();

        }

        private void PlayerNametxt_DoubleClick(object sender, EventArgs e)
        {
            NameForm nf = new NameForm(this);
            nf.Show();
        }

        private void PlayerNametxt_Enter(object sender, EventArgs e)
        {

        }
    }
}
