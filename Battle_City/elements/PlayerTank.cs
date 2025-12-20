using Battle_City.scene;
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
    public class PlayerTank : Tank {

        public Main field; //this is for respawn when play dies
        //constructor
        public PlayerTank(Main field)
        {
            hp = 5;
            atk = 1;
            speed = 4;

            speed_scale = 1;

            bullet_max = 1
                ;
            bullet_speed = 6;
            bullet_amount = bullet_max;
            shooter_type = 1;

            this.Size = new Size(60, 60);
            this.Image = Properties.Resources.Battle_City_Tank_Player1;

            if (this.Image == null)
            {
                Console.WriteLine("Image not loaded!");
            }
            else
            {
                Console.WriteLine("Image loaded successfully.");
            }

            this.SizeMode = PictureBoxSizeMode.StretchImage;
            Console.WriteLine("this is in constructor'splayer ");
            this.field = field;
        }

      
        public void update_tank_img()
        {
            this.Image = Properties.Resources.Battle_City_Tank_Player1;

            // 0-left ,1-right ,2-top,3bottom}
            Console.WriteLine(facing_dir);
            if (facing_dir == 0)
            {
                this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            else if (facing_dir == 1) { this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone); }
            else if (facing_dir == 2) {  }
            else if (facing_dir == 3) { this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone); }
        }

        public void getting_upgrade()
        {
            Sound.GettingUpgrade();

            atk += 1;
            hp += 1;
            bullet_speed += 6;
        }
        //timer function
        private async Task WaitForSeconds(float seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
        }

        PictureBox temp_shield;
        bool cancel;
        public async void activate_shield(Panel panel1)
        {
            Sound.ItemObtein();
            if (temp_shield != null)
            {
                temp_shield.Visible = false;
                temp_shield.Dispose();
                temp_shield = null;
                cancel = true;
            }
            temp_shield= new PictureBox();
            is_immune = true;
           
            temp_shield.Image = Properties.Resources.circle_white_black;
            temp_shield.Size = new Size((int)Math.Floor(this.Size.Width * 1.5), (int)Math.Floor(this.Size.Height * 1.5));
            temp_shield.SizeMode = PictureBoxSizeMode.StretchImage;
            temp_shield.Location = new Point(this.Location.X - ( (temp_shield.Size.Width - this.Size.Width)/2), this.Location.Y - ((temp_shield.Size.Height - this.Size.Height) / 2));
            temp_shield.BackColor = Color.Transparent;
        
            panel1.Controls.Add(temp_shield);
            temp_shield.SendToBack();

            is_immune = true;
            await WaitForSeconds(10f);
            if (cancel || temp_shield == null) { cancel =false ; return; }
            is_immune = false;
            temp_shield.Visible = false;
            temp_shield.Dispose();
            temp_shield = null;

        }

        public override void move_x_y(Panel panel)
        {
            Sound.PlayerMove();
            base.move_x_y(panel);
            if (is_immune) { 
            temp_shield.Location = new Point(this.Location.X - ((temp_shield.Size.Width - this.Size.Width) / 2), this.Location.Y - ((temp_shield.Size.Height - this.Size.Height) / 2));
            }
        }

        public override void take_dmg(int dmg)
        {
            base.take_dmg(dmg);

            field.update_label();
            if (hp<= 0) { field.check_if_game_over(); }
            if (hp <=0 && field.player1_life > 0)
            {
                
                field.respawn_player();
                field.player1_life -= 1;



            }
        }

      

        }

    }

