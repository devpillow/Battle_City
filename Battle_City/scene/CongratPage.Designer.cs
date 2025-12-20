namespace Battle_City.scene
{
    partial class CongratPage
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
            this.lbl_game_over = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_game_over
            // 
            this.lbl_game_over.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_game_over.ForeColor = System.Drawing.Color.Cornsilk;
            this.lbl_game_over.Location = new System.Drawing.Point(38, 119);
            this.lbl_game_over.Name = "lbl_game_over";
            this.lbl_game_over.Size = new System.Drawing.Size(723, 208);
            this.lbl_game_over.TabIndex = 8;
            this.lbl_game_over.Text = "Congratalution";
            this.lbl_game_over.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_game_over.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(723, 30);
            this.label1.TabIndex = 9;
            this.label1.Text = "you will be moved leaderboard in 4 seconds";
            this.label1.Visible = false;
            // 
            // CongratPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_game_over);
            this.Name = "CongratPage";
            this.Text = "CongratPage";
            this.Load += new System.EventHandler(this.CongratPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_game_over;
        private System.Windows.Forms.Label label1;
    }
}