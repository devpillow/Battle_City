using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battle_City.utility
{

    public static class Sound
    {
        private static bool isSoundPlaying = false;  // Flag to check if sound is already playing
        private static readonly object lockObj = new object();  // Object for thread safety in concurrent environments

        public static void PlayerMove()
        {
            // Ensure that only one instance of the sound is playing at a time
            lock (lockObj)
            {
                if (!isSoundPlaying)
                {
                    isSoundPlaying = true;

                    // Create the SoundPlayer instance and play the sound asynchronously
                    SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_playermove);
                    player.Play();

                    // Use a timer to reset the flag after the sound duration has passed
                    Timer timer = new Timer(_ =>
                    {
                        isSoundPlaying = false;  // Reset flag to allow the sound to play again
                    }, null, 200, Timeout.Infinite); // Adjust 200 ms to match the sound duration
                }
            }
        }

        /*public static void AnotherSound()
    {
        lock (lockObj)
        {
            if (!isSoundPlaying)
            {
                isSoundPlaying = true;

                SoundPlayer player = new SoundPlayer(Properties.Resources.Another_Sound_Resource);
                player.Play();

                Timer timer = new Timer(_ =>
                {
                    isSoundPlaying = false;  // Reset flag after sound finishes
                }, null, 250, Timeout.Infinite);  // Adjust this timer based on sound duration
            }
        }
    }*/
        public static void Fire()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_fire);

            player.Play();
        }
        public static void FireBrick()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_fire_brick);
            player.Play();
        }
        public static void FireBrickWall()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_firebrickwall);
            player.Play();
        }
        public static void FireEnemy()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_enemydestyo);
            player.Play();
        }
        public static void FireBigEnemy() {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_firesbigtank);
            player.Play();
        }
        public static void ItemAppeared1()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_itemappear);
            player.Play();
        }
        public static void ItemAppeared2()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_item_appeared);
            player.Play();
        }
        public static void ItemObtein()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_item_obtain);
            player.Play();
        }
        public static void GettingUpgrade()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Battle_City_SFX_upgrade);
            player.Play();
        }
    }


    
}