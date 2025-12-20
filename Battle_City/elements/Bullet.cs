using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Battle_City.elements
{
    public class Bullet:PictureBox
    {
        public int facing_dir;
        public int atk;
        public int speed;
        public int shooted_by; //0-enemy . 1-player1 , 2-player2

        public Tank tank;
 
       


        //constructor
        public Bullet(int atk_,int speed_,int facing_dir_,int shooted_by) {
            facing_dir = facing_dir_;
            speed = speed_;
            atk = atk_;

            rotate_bullet_img();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.Silver;

        }
        public Bullet(Tank tank_,Panel panel1)
        {
            facing_dir = tank_.facing_dir;
            speed = tank_.bullet_speed;
            atk = tank_.atk;
            tank = tank_;
            shooted_by = tank_.shooter_type;
            rotate_bullet_img();
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Name = "Tank_Bullet_pictureBox1";
            this.BackColor = Color.Silver;
            rotate_bullet_img();


        }


        // 0-left ,1-right ,2-top,3bottom}
        public void move_fired_bullet(Panel panel) {
            this.BringToFront();
            if (facing_dir == 0)// move in left
            { this.Location = new Point(this.Location.X - speed, this.Location.Y); }
            else if (facing_dir == 1) { this.Location = new Point(this.Location.X + speed, this.Location.Y); }
            else if (facing_dir == 2) { this.Location = new Point(this.Location.X , this.Location.Y-speed); }
            else if (facing_dir == 3) { this.Location = new Point(this.Location.X, this.Location.Y + speed); }
            out_of_bound_handler(panel);
        }

        public void rotate_bullet_img()
        {
            this.Image = Properties.Resources.Bullet;

            // 0-left ,1-right ,2-top,3bottom}
            Console.WriteLine(facing_dir);
            if (facing_dir == 0)
            {
                this.Size = new Size(10, 6);
                this.Location = new Point(tank.Location.X+5, tank.Location.Y+27);
            }
            else if (facing_dir == 1) {

                this.Size = new Size(10, 6);
                this.Location = new Point(tank.Location.X+55, tank.Location.Y+27);
            }
            else if (facing_dir == 2)
            {

                this.Size = new Size(6, 10) ;

                this.Location = new Point(tank.Location.X+27, tank.Location.Y-5);
            }
        
            else if (facing_dir == 3)
            {
                this.Size = new Size(6, 10);
                this.Location = new Point(tank.Location.X+27, tank.Location.Y+55);
            }
        }
     

        public void dealt_dmg(Wall wall) {
            wall.take_dmg(atk);
            destroy_and_giveback_bullet();
        }

        public void dealt_dmg(Tank tank)
        {
            tank.take_dmg(atk);
            destroy_and_giveback_bullet();
        }
        public void dealt_dmg(Bullet bullet)
        {
            destroy_and_giveback_bullet();
        }
        public void dealt_dmg(HeadQuarter hq)
        {
            hq.take_dmg(atk);
        }

        private void destroy_and_giveback_bullet() {

            if (tank.bullet_amount < tank.bullet_max){
                tank.bullet_amount += 1; }
            this.Dispose();
            this.Visible = false;
        }

        private void out_of_bound_handler(Panel panel)
        {
            int[] bound = {
                panel.Location.X,
                panel.Size.Width - this.Size.Width,
                panel.Location.Y,
                panel.Size.Height -this.Size.Height};
            if (this.Location.X < bound[0]) { destroy_and_giveback_bullet(); }
            else if (this.Location.X > bound[1]) { destroy_and_giveback_bullet(); }
            else if (this.Location.Y < bound[2]) { destroy_and_giveback_bullet(); }
            else if (this.Location.Y > bound[3]) { destroy_and_giveback_bullet(); }
        }


        public bool is_collide_with_something(Control something)
        {
            Rectangle bulletRect = new Rectangle(this.Location, this.Size);
            Rectangle wallRect = new Rectangle(something.Location, something.Size);

            return bulletRect.IntersectsWith(wallRect);
        }
    }
}