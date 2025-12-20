using Battle_City.elements.item;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City.elements
{
    public class HQShield : Item_Drop
    {

        public HQShield()
        {
            this.Image = Properties.Resources.Battle_City_Powerup_Shovel;

        }
        public override void collected(PlayerTank player, Panel panel1, HeadQuarter hq)
        {
            this.Dispose();
            this.Visible = false;
        }

    }
}