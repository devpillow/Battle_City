using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City.elements.item
{
    public class Item_Drop : PictureBox
    {
        public virtual void collected(PlayerTank player, Panel panel1, HeadQuarter hq) { }
        public bool is_collide_with_player(PlayerTank player)
        {
            Rectangle itemrec = new Rectangle(this.Location, this.Size);
            Rectangle playerec = new Rectangle(player.Location, player.Size);

            return itemrec.IntersectsWith(playerec);
        }

    }
}
