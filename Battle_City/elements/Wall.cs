using Battle_City.utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Battle_City.elements
{
    public class Wall : PictureBox
    {


        int hp = 1; //1-brick , 2-iron , 3-bush , 4-water
        bool unbreakable = false;
        public int type;

        public Wall(int type_) //load hp unbreakable varaible and type of wall for texture ,
        {
            this.hp = 1;
            this.type = type_;
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            if (this.type == 1)
            {
                this.Image = Properties.Resources.battle_city_brick_signlee;
            }
            else if (this.type == 2)
            {
                unbreakable = true;
                this.Image = Properties.Resources.Battle_City_wall_Single;
            }
            else { return; }
        }

        public void take_dmg(int dmg){

            if (!unbreakable) { hp -= dmg; ; }
            if (hp <= 0)
            {
                getDestroyed();
                Console.WriteLine("Wall destroyed");
            }
        }
        public void getDestroyed()
        {
           this.Dispose();
        }

       
    }
       
    }

