namespace Battle_City.scene
{
    partial class Lobby
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
            this.buttonscore = new System.Windows.Forms.Button();
            this.buttonplay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PlayerNametxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonscore
            // 
            this.buttonscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonscore.Location = new System.Drawing.Point(99, 240);
            this.buttonscore.Name = "buttonscore";
            this.buttonscore.Size = new System.Drawing.Size(177, 32);
            this.buttonscore.TabIndex = 5;
            this.buttonscore.Text = "LeaderBoard";
            this.buttonscore.UseVisualStyleBackColor = true;
            this.buttonscore.Click += new System.EventHandler(this.buttonscore_Click);
            // 
            // buttonplay
            // 
            this.buttonplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonplay.Location = new System.Drawing.Point(77, 94);
            this.buttonplay.Name = "buttonplay";
            this.buttonplay.Size = new System.Drawing.Size(217, 68);
            this.buttonplay.TabIndex = 4;
            this.buttonplay.Text = "Play";
            this.buttonplay.UseVisualStyleBackColor = true;
            this.buttonplay.Click += new System.EventHandler(this.buttonplay_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(377, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 178);
            this.label1.TabIndex = 3;
            this.label1.Text = "Super Battle City";
            // 
            // PlayerNametxt
            // 
            this.PlayerNametxt.BackColor = System.Drawing.Color.Black;
            this.PlayerNametxt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.PlayerNametxt.ForeColor = System.Drawing.SystemColors.Window;
            this.PlayerNametxt.Location = new System.Drawing.Point(661, 332);
            this.PlayerNametxt.Name = "PlayerNametxt";
            this.PlayerNametxt.ReadOnly = true;
            this.PlayerNametxt.Size = new System.Drawing.Size(100, 20);
            this.PlayerNametxt.TabIndex = 6;
            this.PlayerNametxt.DoubleClick += new System.EventHandler(this.PlayerNametxt_DoubleClick);
            this.PlayerNametxt.Enter += new System.EventHandler(this.PlayerNametxt_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(482, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 9);
            this.label2.TabIndex = 7;
            this.label2.Text = "double click to write your name here ->";
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 387);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PlayerNametxt);
            this.Controls.Add(this.buttonscore);
            this.Controls.Add(this.buttonplay);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Lobby";
            this.Text = "Lobby";
            this.Load += new System.EventHandler(this.Lobby_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonscore;
        private System.Windows.Forms.Button buttonplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PlayerNametxt;
        private System.Windows.Forms.Label label2;
    }
}