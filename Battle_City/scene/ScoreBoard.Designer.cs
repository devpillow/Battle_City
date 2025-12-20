namespace Battle_City.scene
{
    partial class ScoreBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.lbl_4 = new System.Windows.Forms.Label();
            this.lbl_3 = new System.Windows.Forms.Label();
            this.lbl_6 = new System.Windows.Forms.Label();
            this.lbl_5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(739, 73);
            this.label1.TabIndex = 4;
            this.label1.Text = "Leaderboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_1
            // 
            this.lbl_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_1.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_1.Location = new System.Drawing.Point(12, 122);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(739, 60);
            this.lbl_1.TabIndex = 5;
            this.lbl_1.Text = "-";
            this.lbl_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_2
            // 
            this.lbl_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_2.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_2.Location = new System.Drawing.Point(12, 202);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(739, 60);
            this.lbl_2.TabIndex = 6;
            this.lbl_2.Text = "-";
            this.lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_4
            // 
            this.lbl_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_4.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_4.Location = new System.Drawing.Point(12, 364);
            this.lbl_4.Name = "lbl_4";
            this.lbl_4.Size = new System.Drawing.Size(739, 60);
            this.lbl_4.TabIndex = 8;
            this.lbl_4.Text = "-";
            this.lbl_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_3
            // 
            this.lbl_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_3.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_3.Location = new System.Drawing.Point(12, 284);
            this.lbl_3.Name = "lbl_3";
            this.lbl_3.Size = new System.Drawing.Size(739, 60);
            this.lbl_3.TabIndex = 7;
            this.lbl_3.Text = "-";
            this.lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_3.Click += new System.EventHandler(this.lbl_3_Click);
            // 
            // lbl_6
            // 
            this.lbl_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_6.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_6.Location = new System.Drawing.Point(12, 529);
            this.lbl_6.Name = "lbl_6";
            this.lbl_6.Size = new System.Drawing.Size(739, 60);
            this.lbl_6.TabIndex = 10;
            this.lbl_6.Text = "-";
            this.lbl_6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_5
            // 
            this.lbl_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_5.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_5.Location = new System.Drawing.Point(12, 446);
            this.lbl_5.Name = "lbl_5";
            this.lbl_5.Size = new System.Drawing.Size(739, 60);
            this.lbl_5.TabIndex = 9;
            this.lbl_5.Text = "-";
            this.lbl_5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(766, 637);
            this.Controls.Add(this.lbl_6);
            this.Controls.Add(this.lbl_5);
            this.Controls.Add(this.lbl_4);
            this.Controls.Add(this.lbl_3);
            this.Controls.Add(this.lbl_2);
            this.Controls.Add(this.lbl_1);
            this.Controls.Add(this.label1);
            this.Name = "ScoreBoard";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HighScore_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Label lbl_4;
        private System.Windows.Forms.Label lbl_3;
        private System.Windows.Forms.Label lbl_6;
        private System.Windows.Forms.Label lbl_5;
    }
}