using Battle_City.control;
using Battle_City.elements.item;
using Battle_City.scene;
using Battle_City.utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City.elements
{

    public class EnemyTank : Tank
    {
        public int type_of_enemy;
        public bool item_drop;
        public Panel sub_field; //this variable is for that when enemy drop item, will drop in this panel
        public Main field;

        public EnemyTank(int type_of_enemy_)
        {
            if (type_of_enemy_ == 1) {
                hp = 1;
                atk = 2;
                speed = 3;
                life = 0;
                speed_scale = 1;

                bullet_max = 1;
                bullet_amount = 1;
                bullet_speed = 4;
                shooter_type = 0;

                type_of_enemy = type_of_enemy_;
                this.Size = new Size(60, 60);
                this.Image = Properties.Resources.Battle_City_Tank_Enemy1;
                this.SizeMode = PictureBoxSizeMode.StretchImage;

                if (this.Image == null)
                {
                    Console.WriteLine("Enemy tank Image not loaded!");
                }
            }
            if (type_of_enemy_ == 2)
            {
                hp = 1;
                atk = 1;
                speed = 5;
                life = 0;
                speed_scale = 1;

                bullet_max = 5;
                bullet_amount = 5;
                bullet_speed = 6;
                shooter_type = 0;

                type_of_enemy = type_of_enemy_;
                this.Size = new Size(60, 60);
                this.Image = Properties.Resources.Battle_City_Tank_Enemy2;
                this.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (type_of_enemy_ == 3)
            {
                hp = 1;
                atk = 4;
                speed = 2;
                life = 0;
                speed_scale = 1;

                bullet_max = 2;
                bullet_amount = 2;
                bullet_speed = 18;
                shooter_type = 0;

                type_of_enemy = type_of_enemy_;
                this.Size = new Size(60, 60);
                this.Image = Properties.Resources.Battle_City_Tank_Enemy3;
                this.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            if (type_of_enemy_ == 4)
            {
                hp = 6;
                atk = 1;
                speed = 2;
                life = 0;
                speed_scale = 1;

                bullet_max = 1;
                bullet_amount = 1;
                bullet_speed = 6;
                shooter_type = 0;

                type_of_enemy = type_of_enemy_;
                this.Size = new Size(60, 60);
                this.Image = Properties.Resources.Battle_City_Tank_Enemy4;
                this.SizeMode = PictureBoxSizeMode.StretchImage;
            }
    }
        //
        //ItemDrop
        public void drop_item()
        {
            item_drop = false;
            
            Random random = new Random();

            LocaterFineSpawnPoint LFSP = new LocaterFineSpawnPoint(20);
            Point item_spawn_loc = LFSP.find_fine_spawn_point_for_item(field.wall_map);

            if (random.NextDouble() < 0.24)
            {
                Sound.ItemAppeared2();
                HQShield inst_item = new HQShield();
                inst_item_with_locate_in_field(inst_item);
            }
            else if (random.NextDouble() < 0.5)
            {
                Sound.ItemAppeared2();
                StarUpgrade inst_item = new StarUpgrade();
                inst_item_with_locate_in_field(inst_item);
            }
            else
            {
                Sound.ItemAppeared1();
                TankShield inst_item = new TankShield();
                inst_item_with_locate_in_field(inst_item);

            }
            void inst_item_with_locate_in_field(Item_Drop item_instanc)
            {

                item_instanc.Size = new Size(60, 60);
                item_instanc.Location = new Point(item_spawn_loc.X*30 , item_spawn_loc.Y * 30);
                sub_field.Controls.Add(item_instanc);
            }
     
        }



        //AI enemy part

        void change_dir()
        {
            RandomNumber randomN = new RandomNumber();
            facing_dir = randomN.GetRandomNumber(0, 4);

            if (facing_dir == 0) { move_x_axis = -1; }
            if (facing_dir == 1) { move_x_axis = 1; }
            if (facing_dir == 2) { move_x_axis = 0; move_y_axis = -1; }
            if (facing_dir == 3) { move_x_axis = 0; move_y_axis = 1; }
            update_tank_img(type_of_enemy);
        }


        Random rng = new Random();
        public async void enable_ai()
        {
            await WaitForSeconds(0.1f);
            while (field.is_ticking)
               // while (true)
            {
;
                float random_time = (float)rng.NextDouble();
                await WaitForSeconds(random_time);
                change_dir();

            }
        }

        public async void auto_fire(Panel panel1) {
            await WaitForSeconds(0.4f);
            while (field.is_ticking)
            {
                float random_time = (float)rng.NextDouble();
                await WaitForSeconds(random_time);
                if (bullet_amount <= 0 || Visible == false) { return; }

                Bullet inst_bullet = new Bullet(this, panel1);
                panel1.Controls.Add(inst_bullet);

            }
        }

        public void update_tank_img(int type_)
        {

            Image originalImage = null;

            // Set the appropriate tank image based on type_
            if (type_ == 1)
            {
                originalImage = Properties.Resources.Battle_City_Tank_Enemy1;
            }
            else if (type_ == 2)
            {
                originalImage = Properties.Resources.Battle_City_Tank_Enemy2;
            }
            else if (type_ == 3)
            {
                originalImage = Properties.Resources.Battle_City_Tank_Enemy3;
            }
            else if (type_ == 4)
            {
                originalImage = Properties.Resources.Battle_City_Tank_Enemy4;
            }

            // Set the image to the original one
            Console.WriteLine(type_of_enemy);
            this.Image = (Image)originalImage.Clone();

            // 0-left ,1-right ,2-top,3bottom}
            if (facing_dir == 0)
                {
                    this.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                else if (facing_dir == 1) { this.Image.RotateFlip(RotateFlipType.Rotate90FlipNone); }
                else if (facing_dir == 2) { }
                else if (facing_dir == 3) { this.Image.RotateFlip(RotateFlipType.Rotate180FlipNone); }
            
        }
            //timer function
            private async Task WaitForSeconds(float seconds)
            {
                await Task.Delay(TimeSpan.FromSeconds(seconds));
            }

        public override void take_dmg(int dmg)
        {
            base.take_dmg(dmg);
            if (type_of_enemy == 4) { Sound.FireBigEnemy(); }
            if (hp<= 0)
            {
                this.Visible = false;
                this.Dispose();

                GameControler.kill_count += 1;

                Sound.FireEnemy(); 
               
            }
        }

    }
    } 
