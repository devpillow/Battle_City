using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battle_City.scene
{
    public partial class ScoreBoard : Form
    {
        public ScoreBoard()
        {
            InitializeComponent();
        }

        public void HighScore_Load(object sender, EventArgs e)
        {
            ShowHighscores();
        }

        public void SaveHighscore(string player, int score)
        {
            if (player == "") { player = "Unknown"; }
            // สร้างข้อมูลคะแนนและชื่อผู้เล่น
            string highscoreData = $"{player}:{score}";
            Console.WriteLine("before encode : " + highscoreData);
            // เข้ารหัสข้อมูลก่อนการบันทึกลงในไฟล์
            highscoreData = Encode(highscoreData);
            Console.WriteLine("after encode : " + highscoreData);
            // เปิดหรือสร้างแฟ้มข้อมูล Highscores.txt เพื่อบันทึกข้อมูล
            using (StreamWriter writer = new StreamWriter("Highscores.txt", true))
            {
                writer.WriteLine(highscoreData);
            }
            Console.WriteLine("converted score to file");
            Console.WriteLine("Current working directory: " + Directory.GetCurrentDirectory());
        }
        public string Encode(string input)
        {
            StringBuilder encoded = new StringBuilder();
            foreach (char character in input)
            {
                if (char.IsLetter(character))
                {
                    char shifted = (char)(character + 11);
                    if ((char.IsLower(character) && shifted > 'z') || (char.IsUpper(character) && shifted > 'Z'))
                    {
                        shifted = (char)(character - (26 - 11));
                    }
                    encoded.Append(shifted);
                }
                else
                {
                    encoded.Append(character);
                }
            }
            return encoded.ToString();
        }

        // ฟังก์ชันถอดรหัสข้อมูลด้วย Shift Cipher
        public string Decode(string input)
        {
            StringBuilder decoded = new StringBuilder();
            foreach (char character in input)
            {
                if (char.IsLetter(character))
                {
                    char shifted = (char)(character - 11);
                    if ((char.IsLower(character) && shifted < 'a') || (char.IsUpper(character) && shifted < 'A'))
                    {
                        shifted = (char)(character + (26 - 11));
                    }
                    decoded.Append(shifted);
                }
                else
                {
                    decoded.Append(character);
                }
            }
            return decoded.ToString();
        }
        private void ShowHighscores()
        {
            string str = "HIGHSCORES" + Environment.NewLine;
            try
            {
                // อ่านข้อมูลจากแฟ้ม Highscores.txt
                List<string> highscores = File.ReadAllLines("Highscores.txt").ToList();

                // เรียงลำดับคะแนนและชื่อผู้เล่นตามคะแนน
                highscores.Sort((a, b) =>
                {
                    int scoreA, scoreB;
                    string[] splitA = a.Split(':');
                    string[] splitB = b.Split(':');

                    // ตรวจสอบว่าสตริงที่แยกออกมามีสองส่วนหรือไม่
                    if (splitA.Length == 2 && splitB.Length == 2)
                    {
                        // แปลงสตริงที่เป็นคะแนนเป็นตัวเลขและเปรียบเทียบ
                        if (int.TryParse(splitA[1].Trim(), out scoreA) && int.TryParse(splitB[1].Trim(), out scoreB))
                        {
                            return scoreB.CompareTo(scoreA);
                        }
                    }

                    // หากไม่สามารถแปลงเป็นตัวเลขได้หรือข้อมูลไม่ครบถ้วน ให้คืนค่า 0
                    return 0;
                });

                // เก็บคะแนน เเละชื่อใน string array topfive
                string[] top_five = new string[6];
                int iii = 0;
                foreach (string highscore in highscores.Take(6))
                {
                    //.WriteLine("highscore at " +i +" is : " +highscore);

                    // ถอดรหัสข้อมูลก่อนแสดงผล
                    string decodedHighscore = Decode(highscore);
                    top_five[iii] = decodedHighscore;
                    iii = iii + 1;
                    Console.WriteLine("highscoreat " + iii + " is : " + decodedHighscore);
                }


                //แสดงผล
                //Label[] name_labels = { label4, label5, label6, label7, label8 };
                //Label[] score_labels = { label9, label10, label11, label12, label13 };

                Label[] score_labels = {lbl_1, lbl_2, lbl_3, lbl_4, lbl_5, lbl_6 };


                for (int i = 0; i < top_five.Length; i++)
                {
                    Console.WriteLine("Topfive at" + i + " : " + top_five[i]);
                    if (top_five[i] != null)
                    {
                        string[] split = (top_five[i].ToString()).Split(':');
                        string name = split[0];
                        string score = split[1];
                        //  name_labels[i].Text = name;
                        //  score_labels[i].Text = score;
                        score_labels[i].Text = name + " - " + score;
                        Console.WriteLine("Show score at line " + i);
                    }

                }
                //4-8 9-13


            }
            catch (Exception ex)
            {
                // แสดงข้อความข้อผิดพลาดหากเกิดข้อผิดพลาดในการอ่านข้อมูล
                MessageBox.Show("Error reading highscores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_3_Click(object sender, EventArgs e)
        {

        }
    }
}
