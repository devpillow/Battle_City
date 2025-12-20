using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City
{
    public partial class Form1 : Form
    {

        //Object - BackColor

        //Tank Player - Black
        //Bullet - Silver

        //Brick Wall - OrangeRed
        //Steel Wall - Gainsboro
        //Water - MediumBlue
        //Tree - Lime
        //Ice - Snow

        bool Tank_Movement_Boolean = true;

        bool Tank_Up = true;
        bool Tank_Down = false;
        bool Tank_Left = false;
        bool Tank_Right = false;

        bool Tank_Bullet_Up = false;
        bool Tank_Bullet_Down = false;
        bool Tank_Bullet_Left = false;
        bool Tank_Bullet_Right = false;
        bool Tank_Bullet_Shooted = false;

        bool Water_Movement_Boolean = true;

        public Form1()
        {
            InitializeComponent();

            Timer Water_Timer = new Timer();
            Water_Timer.Interval = 500;
            Water_Timer.Tick += new EventHandler(Water_Timer_Tick);
            Water_Timer.Start();
        }

        public void Water_Timer_Tick(object sender, EventArgs e)
        {
            foreach (Control c in Main_panel1.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.BackColor == Color.MediumBlue)
                    {
                        if (Water_Movement_Boolean)
                        {
                            pb.BackgroundImage = Properties.Resources.Battle_City_water;
                        }
                        else
                        {
                            pb.BackgroundImage = Properties.Resources.Battle_City_water;
                        }
                    }
                }
            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                Image img = null;

                if(Tank_Movement_Boolean)
                {
                    img = Properties.Resources.Battle_City_Tank_Player1;
                    Tank_Movement_Boolean = false;
                }
                else
                {
                    img = Properties.Resources.Battle_City_Tank_Player1;
                    Tank_Movement_Boolean = true;
                }


                if (e.KeyCode == Keys.Up)
                {
                    Tank_Down = false;
                    Tank_Left = false;
                    Tank_Right = false;
                    Tank_Up = true;

                    if (!Up_Limits())
                    {
                        Tank_pictureBox1.Top = Tank_pictureBox1.Top - 5;
                    }
                }

                if (e.KeyCode == Keys.Down)
                {
                    Tank_Up = false;
                    Tank_Left = false;
                    Tank_Right = false;
                    Tank_Down = true;

                    img.RotateFlip(RotateFlipType.Rotate180FlipNone);

                    if (!Down_Limits())
                    {
                        Tank_pictureBox1.Top = Tank_pictureBox1.Top + 5;
                    }
                }

                if (e.KeyCode == Keys.Left)
                {
                    Tank_Up = false;
                    Tank_Down = false;
                    Tank_Right = false;
                    Tank_Left = true;

                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);

                    if (!Left_Limits())
                    {
                        Tank_pictureBox1.Left = Tank_pictureBox1.Left - 5;
                    }
                }

                if (e.KeyCode == Keys.Right)
                {
                    Tank_Up = false;
                    Tank_Down = false;
                    Tank_Left = false;
                    Tank_Right = true;

                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    if (!Right_Limits())
                    {
                        Tank_pictureBox1.Left = Tank_pictureBox1.Left + 5;
                    }
                }

                Tank_pictureBox1.BackgroundImage = img;
            }

            if (e.KeyCode == Keys.Space)
            {
                if (!Tank_Bullet_Shooted)
                {
                    Tank_Bullet_Shooted = true;
                    Tank_Shoot();
                }
            }
        }

        public bool Up_Limits()
        {
            bool Limit = false;

            if (Tank_pictureBox1.Top < 1)
            {
                Limit = true;
            }

            if (!Limit)
            {
                foreach (Control c in Main_panel1.Controls)
                {
                    if (c.GetType() == typeof(PictureBox))
                    {
                        PictureBox pb = c as PictureBox;

                        if (pb.Visible && (pb.BackColor == Color.OrangeRed || pb.BackColor == Color.Gainsboro || pb.BackColor == Color.MediumBlue)
                            && Tank_pictureBox1.Location.X < pb.Location.X + 25
                            && Tank_pictureBox1.Location.X > pb.Location.X - 50
                            && Tank_pictureBox1.Location.Y == pb.Location.Y + 25)
                        {
                            Limit = true;
                        }
                    }
                }
            }
            return Limit;
        }

        public bool Down_Limits()
        {
            bool Limit = false;

            if (Tank_pictureBox1.Top > 599)
            {
                Limit = true;
            }

            if (!Limit)
            {
                foreach (Control c in Main_panel1.Controls)
                {
                    if (c.GetType() == typeof(PictureBox))
                    {
                        PictureBox pb = c as PictureBox;

                        if (pb.Visible && (pb.BackColor == Color.OrangeRed || pb.BackColor == Color.Gainsboro || pb.BackColor == Color.MediumBlue)
                            && Tank_pictureBox1.Location.X < pb.Location.X + 25
                            && Tank_pictureBox1.Location.X > pb.Location.X - 50
                            && Tank_pictureBox1.Location.Y == pb.Location.Y - 50)
                        {
                            Limit = true;
                        }
                    }
                }
            }
            return Limit;
        }

        public bool Left_Limits()
        {
            bool Limit = false;

            if (Tank_pictureBox1.Left < 1)
            {
                Limit = true;
            }

            if (!Limit)
            {
                foreach (Control c in Main_panel1.Controls)
                {
                    if (c.GetType() == typeof(PictureBox))
                    {
                        PictureBox pb = c as PictureBox;

                        if (pb.Visible && (pb.BackColor == Color.OrangeRed || pb.BackColor == Color.Gainsboro || pb.BackColor == Color.MediumBlue)
                            && Tank_pictureBox1.Location.Y < pb.Location.Y + 25
                            && Tank_pictureBox1.Location.Y > pb.Location.Y - 50
                            && Tank_pictureBox1.Location.X == pb.Location.X + 25)
                        {
                            Limit = true;
                        }
                    }
                }
            }
            return Limit;
        }

        public bool Right_Limits()
        {
            bool Limit = false;

            if (Tank_pictureBox1.Left > 599)
            {
                Limit = true;
            }

            if (!Limit)
            {
                foreach (Control c in Main_panel1.Controls)
                {
                    if (c.GetType() == typeof(PictureBox))
                    {
                        PictureBox pb = c as PictureBox;

                        if (pb.Visible && (pb.BackColor == Color.OrangeRed || pb.BackColor == Color.Gainsboro || pb.BackColor == Color.MediumBlue)
                            && Tank_pictureBox1.Location.Y < pb.Location.Y + 25
                            && Tank_pictureBox1.Location.Y > pb.Location.Y - 50
                            && Tank_pictureBox1.Location.X == pb.Location.X - 50)
                        {
                            Limit = true;
                        }
                    }
                }
            }
            return Limit;
        }

        public void Tank_Shoot()
        {
            PictureBox Bullet_Picturebox = new PictureBox();

            Image img = Properties.Resources.Bullet;

            Tank_Bullet_Up = false;
            Tank_Bullet_Down = false;
            Tank_Bullet_Left = false;
            Tank_Bullet_Right = false;
            Tank_Bullet_Shooted = false;

            if (Tank_Up)
            {
                Bullet_Picturebox.Size = new Size(6, 10);
                Bullet_Picturebox.Location = new Point(Tank_pictureBox1.Left + 22, Tank_pictureBox1.Top - 8);
                Tank_Bullet_Up = true;
            }
            if (Tank_Down)
            {
                Bullet_Picturebox.Size = new Size(6, 10);
                Bullet_Picturebox.Location = new Point(Tank_pictureBox1.Left + 22, Tank_pictureBox1.Top + 50);
                img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                Tank_Bullet_Down = true;
            }
            if (Tank_Left)
            {
                Bullet_Picturebox.Size = new Size(10, 6);
                Bullet_Picturebox.Location = new Point(Tank_pictureBox1.Left - 8, Tank_pictureBox1.Top + 22);
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                Tank_Bullet_Left = true;
            }
            if (Tank_Right)
            {
                Bullet_Picturebox.Size = new Size(10, 6);
                Bullet_Picturebox.Location = new Point(Tank_pictureBox1.Left + 50, Tank_pictureBox1.Top + 22);
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                Tank_Bullet_Right = true;
            }

            Bullet_Picturebox.BackgroundImage = img;
            Bullet_Picturebox.BackgroundImageLayout = ImageLayout.Stretch;
            Bullet_Picturebox.Name = "Tank_Bullet_pictureBox1";
            Bullet_Picturebox.BackColor = Color.Silver;

            Main_panel1.Controls.Add(Bullet_Picturebox);

            Bullet_Picturebox.BringToFront();

            foreach (Control c in Main_panel1.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.BackColor == Color.Lime)
                    {
                        pb.BringToFront();
                    }
                }
            }

            Timer Tank_Bullet_Timer = new Timer();
            Tank_Bullet_Timer.Interval = 40;
            Tank_Bullet_Timer.Tick += new EventHandler(Tank_Bullet_timer1_Tick);
            Tank_Bullet_Timer.Start();

        }

        public void Tank_Bullet_timer1_Tick(object sender, EventArgs e)
        {
            foreach (Control c in Main_panel1.Controls)
            {
                if (c.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = c as PictureBox;

                    if (pb.BackColor == Color.Silver)
                    {
                        if (Tank_Bullet_Up)
                        {
                            pb.Top = pb.Top - 10;
                        }
                        if (Tank_Bullet_Down)
                        {
                            pb.Top = pb.Top + 10;
                        }
                        if (Tank_Bullet_Left)
                        {
                            pb.Left = pb.Left - 10;
                        }
                        if (Tank_Bullet_Right)
                        {
                            pb.Left = pb.Left + 10;
                        }

                        if (pb.Top < 0 || pb.Top > 642 || pb.Left < 0 || pb.Left > 642)
                        {
                            Tank_Bullet_Up = false;
                            Tank_Bullet_Down = false;
                            Tank_Bullet_Left = false;
                            Tank_Bullet_Right = false;
                            Tank_Bullet_Shooted = false;

                            Timer tm = (Timer)sender;
                            tm.Dispose();
                            pb.Dispose();
                        }

                        foreach (Control d in Main_panel1.Controls)
                        {
                            if (d.GetType() == typeof(PictureBox))
                            {
                                PictureBox pb2 = d as PictureBox;

                                if (pb2.Visible && pb2.BackColor == Color.OrangeRed
                                    && pb.Bounds.IntersectsWith(pb2.Bounds))
                                {
                                    Tank_Bullet_Up = false;
                                    Tank_Bullet_Down = false;
                                    Tank_Bullet_Left = false;
                                    Tank_Bullet_Right = false;
                                    Tank_Bullet_Shooted = false;

                                    Timer tm = (Timer)sender;
                                    tm.Dispose();
                                    pb.Dispose();
                                    if (pb2.BackColor == Color.OrangeRed)
                                    {
                                        pb2.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void pictureBox200_Click(object sender, EventArgs e)
        {

        }

        private void Main_panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox220_Click(object sender, EventArgs e)
        {

        }
    }
}
