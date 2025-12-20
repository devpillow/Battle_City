using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City.elements.item
{
    public class TankShield:Item_Drop
    {
        public TankShield() {
            this.Image = Properties.Resources.Battle_City_Powerup_Helmet;
        }
        public override void collected(PlayerTank player, Panel panel1, HeadQuarter hq)
        {
            player.activate_shield(panel1);

            this.Dispose();
            this.Visible = false;
        }

    }
}
