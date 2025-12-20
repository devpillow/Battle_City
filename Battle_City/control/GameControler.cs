using Battle_City.scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Battle_City.elements;
namespace Battle_City.control
{
    public static class GameControler
    {
        //level control
        static int current_level = 0;
        public static Main main_scene;



        async public static void next_level()
        {
            if (main_scene != null) { main_scene.Close(); }
            current_level += 1;
            main_scene = new Main();
            main_scene.level = current_level;


            BattleField battle_field = new BattleField();
            main_scene.wall_map = battle_field.get_wall_map(current_level);
            main_scene.enemy_first_set = battle_field.get_enemy_list1(current_level);
            main_scene.enemy_second_set = battle_field.get_enemy_list2(current_level);
            main_scene.is_every_tanks_spawned = false;
            await WaitForSeconds(0.1f);
            main_scene.Show();
        }
        public static void clear_main_map()
        {
            
        }
        public static void reset_level()
        {
            current_level = 0;
            
            main_scene = null;

        }

        //timer function
        private static async Task WaitForSeconds(float seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(seconds));
        }



        //score
        public static int kill_count = 0;

        //highscore section
        public static string playername;
        
    }
}
