using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City.elements.item
{
    public class StarUpgrade:Item_Drop
    {
        public StarUpgrade()
        {
            this.Image = Properties.Resources.Battle_City_Powerup_Star;

        }
        public override void collected(PlayerTank player , Panel panel , HeadQuarter hq)
        { 
            player.getting_upgrade();

            this.Dispose();
            this.Visible = false;
        }
    }
  
}
