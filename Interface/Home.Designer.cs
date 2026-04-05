namespace Poker
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.Name = new System.Windows.Forms.TextBox();
            this.Balance = new System.Windows.Forms.TextBox();
            this.addplayer = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Name
            // 
            this.Name.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.Location = new System.Drawing.Point(324, 176);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(155, 20);
            this.Name.TabIndex = 2;
            // 
            // Balance
            // 
            this.Balance.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Balance.Location = new System.Drawing.Point(325, 218);
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(153, 20);
            this.Balance.TabIndex = 3;
            // 
            // addplayer
            // 
            this.addplayer.BackColor = System.Drawing.Color.DarkRed;
            this.addplayer.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.addplayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addplayer.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addplayer.Location = new System.Drawing.Point(542, 193);
            this.addplayer.Name = "addplayer";
            this.addplayer.Size = new System.Drawing.Size(75, 23);
            this.addplayer.TabIndex = 4;
            this.addplayer.Text = "Add player";
            this.addplayer.UseVisualStyleBackColor = false;
            this.addplayer.Click += new System.EventHandler(this.addplayer_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Gold;
            this.textBox1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(223, 176);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(95, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Player name:";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.Color.DarkRed;
            this.start.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.start.FlatAppearance.BorderSize = 3;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Font = new System.Drawing.Font("Georgia", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start.Location = new System.Drawing.Point(313, 343);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(143, 48);
            this.start.TabIndex = 6;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Gold;
            this.textBox2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(223, 218);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox2.Size = new System.Drawing.Size(95, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "Balance:";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Poker.Properties.Resources.blackjackbackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.start);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.addplayer);
            this.Controls.Add(this.Balance);
            this.Controls.Add(this.Name);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            
            this.Text = "Home";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.TextBox Balance;
        private System.Windows.Forms.Button addplayer;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox textBox2;
    }
}