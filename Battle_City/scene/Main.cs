using Battle_City.control;
using Battle_City.elements;
using Battle_City.elements.item;
using Battle_City.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace Battle_City.scene
{

    public partial class Main : Form
    {
        //declear
        public int level; //<- need to be assign
        BattleField battle_field;
        public int[,] wall_map;

        public PictureBox[,] placed_wall_map = new PictureBox[25, 25];
        public PlayerTank player1;
        public int player1_life = 2;
        //public PlayerTank player2;
        public int player2_life = 0;
        public Timer gametick;
        public bool is_ticking;

        public Timer gametic2;
        public bool is_tic2ing;

        public int[] enemy_first_set;
        public int[] enemy_second_set;

        public Main()
        {
            InitializeComponent();
            battle_field = new BattleField();

        }

        // declear variable


        private void Main_Load(object sender, EventArgs e)
        {



            Loadwallmap(wall_map);

            create_headquarter();

            //Timer  Create game tick , so that we can run game by runtime
            gametick = new Timer();
            is_ticking = true;
            gametick.Interval = 1;
            gametick.Tick += new EventHandler(runtime_gametick);
            gametick.Start();

            gametic2 = new Timer();
            is_tic2ing = true;
            gametic2.Interval = 2000;
            gametic2.Tick += new EventHandler(check_for_remaining_enemy_runtime_gametick2);
            gametic2.Start();

            spawn_enemy_tank();

            spawn_player_tank();




            panel1.Visible = true;



            // array_test()
           // item_spawn_test();

            update_label();
        }



        public void Loadwallmap(int[,] wallmap)
        {
            int idx_x = 0;
            int idx_y = 0;

            for (int y = 0; y < panel1.Size.Height; y += 30)
            {
                idx_x = 0;
                for (int x = 0; x < panel1.Size.Width; x += 30)
                {
                    int type_ = wallmap[idx_y, idx_x];

                    if (type_ == 0) { }
                    else if (type_ == 1 || type_ == 2) //create wall
                    {


                        Wall inst_wall = new Wall(type_);
                        panel1.Controls.Add(inst_wall);
                        inst_wall.Location = new Point(x, y);
                        inst_wall.Size = new Size(30, 30);

                        inst_wall.SizeMode = PictureBoxSizeMode.StretchImage;
                        inst_wall.BringToFront();
                        placed_wall_map[idx_y, idx_x] = inst_wall;
                    }
                    else if (type_ == 4)
                    {
                            Water inst_water = new Water();
                            panel1.Controls.Add(inst_water);
                            inst_water.Location = new Point(x, y);
                            inst_water.Size = new Size(30, 30);

                            inst_water.SizeMode = PictureBoxSizeMode.StretchImage;
                            //     inst_water.BringToFront();
                            placed_wall_map[idx_y, idx_x] = inst_water;

                    }
                    else if (type_ == 3) //create tree
                    {
                        Tree inst_tree = new Tree();
                        panel1.Controls.Add(inst_tree);
                        inst_tree.Location = new Point(x, y);
                        inst_tree.Size = new Size(30, 30);

                        inst_tree.SizeMode = PictureBoxSizeMode.StretchImage;
                        panel1.Controls.SetChildIndex(inst_tree, panel1.Controls.Count - 1);
                    }

                    idx_x += 1;
                }
                idx_y += 1;
            }

        }




        void spawn_enemy_tank()
        {
            int[] first_half = enemy_first_set;
            int[] second_half = enemy_second_set;

            gen_enemy_first_half(first_half);
            gen_enemy_last_half(second_half);


        }

        void spawn_player_tank()
        {


            player1 = new PlayerTank(this);


            player1.Location = new Point(9*30
                , 20 * 30);
            player1.Size = new Size(56, 56);
            panel1.Controls.Add(player1);

        }
        HeadQuarter hq;
        public void create_headquarter()
        {
            int x = 13;
            int y = 23;

            hq = new HeadQuarter(this);
            hq.Location = new Point(30 * x, 30 * y);
            hq.Size = new Size(56, 56);
            panel1.Controls.Add(hq);
            hq.SendToBack();
            int[,] map_brick = new int[25, 25];
            map_brick[24, 12] = 1;
            map_brick[23, 12] = 1;
            map_brick[22, 12] = 1;

            map_brick[22, 13] = 1;
            map_brick[22, 14] = 1;
            map_brick[22, 15] = 1;

            map_brick[23, 15] = 1;
            map_brick[24, 15] = 1;
            Loadwallmap(map_brick);

        }

        //runtime rendering
        void runtime_gametick(object sender, EventArgs e)
        {

            if (player1.is_moving && player1.Visible == true)
            {
                Point Original_Location = player1.Location;
                //with this player can move without go out of screen
                player1.move_x_y(panel1);

                //re-position for player of overlapping to wall or tank
                check_player_wall_collisions(Original_Location);
                player1.Location = player1.next_tick_location;

            }


            //method for checking if player collide with wall
            void check_player_wall_collisions(Point original_location)
            {
                foreach (Control control in panel1.Controls)
                {
                    if (control is Wall wall)
                    {
                        if (player1.IsColliding(wall))
                        {

                            player1.Location = original_location;
                            player1.next_tick_location = original_location;
                            return; // Exit if a collision is detected
                        }

                    }
                    else if (control is Water water)
                    {
                        if (player1.IsColliding(water))
                        {

                            player1.Location = original_location;
                            player1.next_tick_location = original_location;
                            return; // Exit if a collision is detected
                        }

                    }

                    // player + enemy/otherplayer
                    else if (control is Tank tank)
                    {
                        if (player1.IsColliding(tank) && player1 != tank && player1.Visible == true)
                        {

                            player1.Location = original_location;
                            player1.next_tick_location = original_location;
                            return; // Exit if a collision is detected
                        }

                    }
                }
            }

            //bullet-handler
            foreach (Control control in panel1.Controls)
            {
                if (control is Bullet bullet)
                {
                    bullet.move_fired_bullet(panel1);
                }
            }



            foreach (Control control in panel1.Controls) //bullet + wall
            {
                if (control is Bullet bullet)
                {
                    foreach (Control control2 in panel1.Controls)
                    {
                        if (control2 is Wall wall)
                        {
                            if (bullet.is_collide_with_something(wall))
                            {
                                bullet.dealt_dmg(wall);
                          
                                if(wall.type == 1 &&( bullet.shooted_by ==1||bullet.shooted_by == 2)){ Sound.FireBrickWall(); }
                                else if (wall.type == 2 && (bullet.shooted_by == 1 || bullet.shooted_by == 2)){ Sound.FireBrick(); }
                            }

                        }
                    }
                }
            }
            foreach (Control control in panel1.Controls) // bullet+bullet
            {
                if (control is Bullet bullet1)
                {
                    foreach (Control control2 in panel1.Controls)
                    {
                        if (control2 is Bullet bullet2)
                        {
                            if (bullet1.is_collide_with_something(bullet2) && bullet1.shooted_by != bullet2.shooted_by)
                            {
                                bullet1.dealt_dmg(bullet2);
                                bullet2.dealt_dmg(bullet1);
                            }
                        }
                    }
                }
            }
            foreach (Control control in panel1.Controls) // bullet+head quarter
            {
                if (control is Bullet bullet)
                {
                    foreach (Control control2 in panel1.Controls)
                    {
                        if (control2 is HeadQuarter headq)
                        {
                            if (bullet.is_collide_with_something(headq) && headq.Visible == true)
                            {
                                bullet.dealt_dmg(headq);

                            }
                        }
                    }
                }
            }

            foreach (Control control in panel1.Controls) // bullet+player/enemy
            {
                if (control is Bullet bullet1)
                {
                    foreach (Control control2 in panel1.Controls)
                    {
                        if (control2 is Tank tank)
                        {
                            if (bullet1.is_collide_with_something(tank) && bullet1.shooted_by != tank.shooter_type && tank.Visible == true)
                            {
                                if (tank is EnemyTank enemy)
                                {
                                    if (enemy.item_drop) { enemy.drop_item(); }
                                }
                                bullet1.dealt_dmg(tank);

                            }
                        }
                    }
                }
            }



            //Enemy Ai and everything about EnemyTank
            foreach (Control control in panel1.Controls)
            {
                if (control is EnemyTank enemy)
                {
                    if (enemy.is_moving)
                    {
                        Point Original_Location = enemy.Location;
                       
                        enemy.move_x_y(panel1);

                   
                        check_enemy_wall_collisions(Original_Location);
                        enemy.Location = enemy.next_tick_location;

                    }


                    //method for checking if enemy collide with wall
                    void check_enemy_wall_collisions(Point original_location)
                    {
                        foreach (Control control1 in panel1.Controls)
                        {
                            if (control1 is Wall wall)
                            {
                                if (enemy.IsColliding(wall))
                                {

                                    enemy.Location = original_location;
                                    enemy.next_tick_location = original_location;
                                    return; // Exit if a collision is detected
                                }

                            }

                            // else if (control is Tank tank)
                            else if (control1 is EnemyTank otherEnemy && otherEnemy != enemy)
                            {
                                if (enemy.IsColliding(otherEnemy) && enemy != otherEnemy)
                                {

                                    enemy.Location = original_location;
                                    enemy.next_tick_location = original_location;
                                    return; // Exit if a collision is detected
                                }

                            }
                            else if (control1 is PlayerTank playerTank) // Make sure PlayerTank is included here
                            {
                                if (enemy.IsColliding(playerTank) && player1.Visible == true)
                                {
                                    enemy.Location = original_location;
                                    enemy.next_tick_location = original_location;
                                    return; // Exit if a collision with the player tank is detected
                                }
                            }
                            else if (control1 is Water water) // enemy + water
                            {
                                if (enemy.IsColliding(water))
                                {
                                    //                  
                                    enemy.Location = original_location;
                                    enemy.next_tick_location = original_location;
                                    return; // Exit if a collision with the player tank is detected
                                }
                            }
                        }
                    }
                }
            }

            foreach (Control control in panel1.Controls)
            {
                if (control is Item_Drop item)
                {
                    if (player1.IsColliding(item))
                    {
                        if (item is HQShield)
                        {
                            create_hq_shield();Sound.ItemObtein();
                        }
                        item.collected(player1, panel1, hq);

                    }
                    async void create_hq_shield()
                    {

                        int[,] map_brick = new int[25, 25];
                        map_brick[24, 12] = 2;
                        map_brick[23, 12] = 2;
                        map_brick[22, 12] = 2;

                        map_brick[22, 13] = 2;
                        map_brick[22, 14] = 2;
                        map_brick[22, 15] = 2;

                        map_brick[23, 15] = 2;
                        map_brick[24, 15] = 2;
                        Loadwallmap(map_brick);
                        //this is unbreakable wall

                        //check to breakable wall after 10 sec
                        await WaitForSeconds(10f);
                      /*  if (cancel_hq) {cancel_hq = false;return; }

                        is_wall_being_wall = false;*/
                        remove_wallmap(placed_wall_map, map_brick);
                        map_brick[24, 12] = 1;
                        map_brick[23, 12] = 1;
                        map_brick[22, 12] = 1;

                        map_brick[22, 13] = 1;
                        map_brick[22, 14] = 1;
                        map_brick[22, 15] = 1;

                        map_brick[23, 15] = 1;
                        map_brick[24, 15] = 1;
                        Loadwallmap(map_brick);
                    }

                }
            }
        }

        //for enemy spawn / about enemy
        async private void gen_enemy_first_half(int[] array)//spawn enemy immediatly
        {
            await WaitForSeconds(0.3f);

            List<EnemyTank> spawnedEnemies = new List<EnemyTank>();
            RandomIndexGenerator random_index_generator = new RandomIndexGenerator();
            int[] list_of_enemy_type_order = random_index_generator.GenerateRandomIndices(array);

            SpawnPointGenerator generator = new SpawnPointGenerator(wall_map, spawnedEnemies);
            for (int i = 0; i < list_of_enemy_type_order.Length; i += 1)
            {
                
                Point? spawnPoint = generator.GetRandomSpawnPoint(15); // more number => more bottom
                if (spawnPoint.HasValue)
                {
                    EnemyTank enemy = new EnemyTank(list_of_enemy_type_order[i] + 1); // Use the random type order

                    enemy.Location = new Point(spawnPoint.Value.X * 30, spawnPoint.Value.Y * 30);
                    enemy.Size = new Size(56, 56);
                    enemy.field = this;
                    //enemy.BringToFront();

                    Random random = new Random();
                    if (random.NextDouble() < 0.16)
                    {
                        enemy.item_drop = true; // put item in enemy for 16% chance
                        enemy.sub_field = panel1;
                        enemy.field = this;
                    }

                    panel1.Controls.Add(enemy);
                    spawnedEnemies.Add(enemy);

                    enemy.enable_ai();
                    enemy.auto_fire(panel1);
                }
             
            }
        }
      //

        private async void gen_enemy_last_half(int[] array) // spawn every 3.4 second
        {
            List<EnemyTank> spawnedEnemies = new List<EnemyTank>();

            RandomIndexGenerator random_index_generator = new RandomIndexGenerator();
            int[] list_of_enemy_type_order = random_index_generator.GenerateRandomIndices(array);

            SpawnPointGenerator generator = new SpawnPointGenerator(wall_map, spawnedEnemies);
            for (int i = 0; i < list_of_enemy_type_order.Length; i += 1)
            {
                await WaitForSeconds(3.40f);
                
                //write by hand
                Random r = new Random();
                EnemyTank enemy = new EnemyTank(list_of_enemy_type_order[i] + 1); // Use the random type order
                if (r.NextDouble() < 0.16)
                {
                    enemy.item_drop = true; // put item in enemy for 16% chance

                }

                panel1.Controls.Add(enemy);
                spawnedEnemies.Add(enemy);
                enemy.field = this;
                enemy.sub_field = panel1;
                enemy.enable_ai();
                enemy.auto_fire(panel1);

                LocaterFineSpawnPoint locFS = new LocaterFineSpawnPoint(16);
                Point loc = locFS.find_fine_spawn_point(wall_map);
                enemy.Location = new Point(loc.X * 30, loc.Y * 30);

            }
            is_every_tanks_spawned = true;

        }
        //timer function
        private async Task WaitForSeconds(float seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
        }

        public void item_spawn_test()
        {
            TankShield tank_shield = new TankShield();
            tank_shield.Size = new Size(60, 60);
            tank_shield.Location = new Point(150, 600);
            panel1.Controls.Add(tank_shield);

            TankShield tank_shield2 = new TankShield();
            tank_shield2.Size = new Size(60, 60);
            tank_shield2.Location = new Point(150, 660);
            panel1.Controls.Add(tank_shield2);
            TankShield tank_shield3 = new TankShield();
            tank_shield3.Size = new Size(60, 60);
            tank_shield3.Location = new Point(110, 600);
            panel1.Controls.Add(tank_shield3);


            HQShield hq_wall_item = new HQShield();
            hq_wall_item.Size = new Size(60, 60);
            hq_wall_item.Location = new Point(180, 660);
            panel1.Controls.Add(hq_wall_item);
            HQShield hq_wall_item2 = new HQShield();
            hq_wall_item2.Size = new Size(60, 60);
            hq_wall_item2.Location = new Point(120, 690);
            panel1.Controls.Add(hq_wall_item2);
            HQShield hq_wall_item3= new HQShield();
            hq_wall_item3.Size = new Size(60, 60);
            hq_wall_item3.Location = new Point(60, 690);
            panel1.Controls.Add(hq_wall_item3);
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                player1.move_y_axis = 0;


            }
            else if (e.KeyCode == Keys.Down)
            {
                player1.move_y_axis = 0;

            }
            else if (e.KeyCode == Keys.Right)
            {
                player1.move_x_axis = 0;

            }
            else if (e.KeyCode == Keys.Left)
            {
                player1.move_x_axis = 0;

            }
        }


        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                player1.move_y_axis = -1;
                player1.facing_dir = 2;
                player1.update_tank_img();
            }
            else if (e.KeyCode == Keys.Down)
            {
                player1.move_y_axis = 1;
                player1.facing_dir = 3;
                player1.update_tank_img();
            }
            else if (e.KeyCode == Keys.Right)
            {
                player1.move_x_axis = 1;
                player1.facing_dir = 1;
                player1.update_tank_img();
            }
            else if (e.KeyCode == Keys.Left)
            {
                player1.move_x_axis = -1;
                player1.facing_dir = 0;
                player1.update_tank_img();
            }
            else if (e.KeyCode == Keys.Z)
            {
                if (player1.bullet_amount <= 0 || player1.Visible == false) { return; }
                Bullet P1_bullet = player1.shooted_bullet(panel1);
                P1_bullet.SendToBack();
                panel1.Controls.Add(P1_bullet);
                Sound.Fire();
            }
        }


        public void remove_wallmap(PictureBox[,] placed_wallmap, int[,] remove_wall_map)
        {
            int idx_x = 0;
            int idx_y = 0;

            for (int y = 0; y < panel1.Size.Height; y += 30)
            {
                idx_x = 0;
                for (int x = 0; x < panel1.Size.Width; x += 30)
                {

                    int wall_remove = remove_wall_map[idx_x, idx_y];

                    if (wall_remove != 0) { placed_wallmap[idx_x, idx_y].Dispose(); placed_wallmap[idx_x, idx_y].Visible = false; }

                    idx_x += 1;
                }
                idx_y += 1;
            }

        }

        public void update_label()
        {
            lbl_level.Text = level.ToString();
            lbl_p1_life.Text = player1_life.ToString();
            lbl_p1_hp.Text = player1.hp.ToString();

        }
        async public void respawn_player()
        {
            player1.Dispose();
            await WaitForSeconds(3f);
            spawn_player_tank();
            update_label();
        }
        async public void check_if_game_over()//ผู้เล่นเกิดใหม่ได้ / ป้อมไม่แตก   //////เช็คสองที่
        {
         
            if ((player1_life == 0 && player2_life == 0) || hq.hp <= 0)
            {
                if (is_tic2ing == false) { return; }// can't lost if won

                //MessageBox.Show("Game Over");
                gametick.Stop();
                is_ticking = false;


                await WaitForSeconds(1f);
                save_score();
                lbl_game_over.Visible = true;
                lbl_game_over.BringToFront();
                await WaitForSeconds(3f);
                GameControler.reset_level();
                this.Close();
            }
        }



        public bool is_every_tanks_spawned = false;
        async private void check_for_remaining_enemy_runtime_gametick2(object sender, EventArgs e)
        {
            if (is_every_tanks_spawned == false)
            {
                return; //impossible to win because there are still remaing tanks in order to spawn }

            }
            foreach (Control control in panel1.Controls)
            {
                if (control is EnemyTank)
                {
                    return; //tank found, game isn't end

                }

            }

            gametic2.Stop();
            is_tic2ing = false;
            //no more enemy tank remaining
            //win
            if (level < 3)
            {
                await WaitForSeconds(1f);
                lbl_game_over.Text = "Preparing for next level";
                lbl_game_over.BringToFront();
                lbl_game_over.Visible = true;
                await WaitForSeconds(3f);
                GameControler.next_level();
            }
            else { lbl_game_over.Text = "You won";
                lbl_game_over.Visible = true;
                lbl_game_over.BringToFront();
                save_score();
                GameControler.reset_level();
                await WaitForSeconds(2f);
                CongratPage cp = new CongratPage();
                cp.Show();
                this.Close();
            }


        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // GameControler.reset_level();
            //Application.Exit();
            GameControler.main_scene = null;
                    gametick = null;
          is_ticking= false;

        gametic2= null;
         is_tic2ing= false;

         enemy_first_set= null;
        enemy_second_set= null;
            is_every_tanks_spawned = false;
    }



        //highscore section
        private void save_score()
        {
            ScoreBoard score_board = new ScoreBoard();
            score_board.SaveHighscore(GameControler.playername, GameControler.kill_count);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
        //    GameControler.reset_level();
        }
    }
}
