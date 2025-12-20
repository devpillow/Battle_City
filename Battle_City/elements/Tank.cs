using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City.elements
{
    public class Tank:PictureBox
    {

        public int move_y_axis;
        public int move_x_axis;
        public int facing_dir; // 0-left ,1-right ,2-top,3bottom}

        public bool is_moving
        {
            get
            {
                return move_y_axis != 0 || move_x_axis != 0;
            }
        }

        public int hp;
        public int atk;
        public int bullet_speed;
        public int speed;
        public int speed_scale;
        public int shooter_type;//0-enemy , 1-player1 , 2-player2
        public int life;

        public bool is_immune;

        public int bullet_max;
        public int bullet_amount;



        public Point next_tick_location;
        public virtual void move_x_y(Panel panel)
        {
           //this.BringToFront();
            // {left , right , top,bottom}
            int[] bound = {
                panel.Location.X,
                panel.Size.Width - this.Size.Width,
                panel.Location.Y,
                panel.Size.Height -this.Size.Height};


            //With this code below the tank will not go out of screen
            int leftBound = panel.Location.X;
            int rightBound = panel.Location.X + panel.Size.Width - this.Size.Width;
            int topBound = panel.Location.Y;
            int bottomBound = panel.Location.Y + panel.Size.Height - this.Size.Height;

            if (move_x_axis != 0)
            {
                Point position = limit_by_bound(leftBound, rightBound, topBound, bottomBound, new Point(this.Location.X + this.move_x_axis * this.speed * this.speed_scale, this.Location.Y));

                next_tick_location = position;
            }
            else if (move_y_axis != 0)
            {
                Point position = limit_by_bound(leftBound, rightBound, topBound, bottomBound,
            new Point(this.Location.X, this.Location.Y + this.move_y_axis * this.speed * this.speed_scale));

                next_tick_location = position;

            }
        }

        public Point limit_by_bound(int[] bound, Point posiiton)
        {
     
            Point new_position = posiiton;
            // out of bound-left
            if (posiiton.X < bound[0]) { new_position = new Point(bound[0], posiiton.Y); }

            // out of bound-right
            else if (posiiton.X > bound[1]) { new_position = new Point(bound[1], posiiton.Y); }

            // out of bound-top
            if (posiiton.Y < bound[2]) { new_position = new Point(posiiton.X, bound[2]); }

            // out of bound-bot
            else if (posiiton.Y > bound[3]) { new_position = new Point(posiiton.X, bound[3]); }

            return new_position;
        }


        public Point limit_by_bound(int left, int right, int top, int bottom, Point position)
        {

            Point new_position = position;
            int magic_number = 0;
            // Out of bounds - left
            if (position.X < left)
            {
                new_position.X = left;
            }
            // Out of bounds - right
            else if (position.X > right)
            {
                new_position.X = right;
            }
            // Out of bounds - top
            if (position.Y < top)
            {
                new_position.Y = top;
            }
            // Out of bounds - bottom

            else if (position.Y > bottom - magic_number)
            {

                new_position.Y = bottom;
            }
            
            return new_position;
        }
        public bool IsColliding(Control wall)
        {
            Rectangle playerRect = new Rectangle(this.next_tick_location, this.Size);
            Rectangle wallRect = new Rectangle(wall.Location, wall.Size);


            return playerRect.IntersectsWith(wallRect);
        }




        public virtual void take_dmg(int dmg)
        {
            if (this.is_immune == false)
            {
                hp -= dmg;
                if (hp <= 0)
                {
                    Console.WriteLine("tank get destroyed");
                    this.Visible = false;

                }
            }
           
        }

        public Bullet shooted_bullet(Panel panel1)
        {
            
            Bullet inst_bullet = new Bullet(this, panel1);
            this.bullet_amount -= 1;
            return inst_bullet;
        }

             }



    }

