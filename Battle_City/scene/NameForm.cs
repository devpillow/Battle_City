using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Battle_City.scene
{
    public partial class NameForm : Form
    {

        Lobby Lobby;
        public NameForm(Lobby lobby)
        {
            InitializeComponent();
            Lobby = lobby;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
 
        }

        private void txt_nameform_TextChanged(object sender, EventArgs e)
        {
            foreach (Control c in Lobby.Controls)
            {
                if (c is TextBox) { if (c.Name == "PlayerNametxt") { c.Text = txt_nameform.Text; } }
           

            }
        }
    }
}
