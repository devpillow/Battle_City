using Battle_City.scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City.elements
{
    public class HeadQuarter: PictureBox
    {
        public int hp;
        Main field;
        public HeadQuarter(Main field_) { this.Image = Properties.Resources.battle_city_headquarter;
            hp = 1;
            this.SendToBack();
            field = field_;
        }

        public void take_dmg(int dmg) { hp-=dmg;
            if (hp <= 0) { 
               // this.Dispose();
                this.Visible = false;
                // MessageBox.Show("game over");


                field.check_if_game_over();

            }
        }
    }
}
