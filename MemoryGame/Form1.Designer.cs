
namespace MemoryGame
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.flipTimer = new System.Windows.Forms.Timer(this.components);
            this.player1 = new System.Windows.Forms.Label();
            this.player2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flipTimer
            // 
            this.flipTimer.Interval = 1000;
            this.flipTimer.Tick += new System.EventHandler(this.flipTimer_Tick);
            // 
            // player1
            // 
            this.player1.AutoSize = true;
            this.player1.Location = new System.Drawing.Point(503, 95);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(59, 17);
            this.player1.TabIndex = 0;
            this.player1.Text = "player 1";
            // 
            // player2
            // 
            this.player2.AutoSize = true;
            this.player2.Location = new System.Drawing.Point(506, 276);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(59, 17);
            this.player2.TabIndex = 1;
            this.player2.Text = "player 2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 566);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer flipTimer;
        private System.Windows.Forms.Label player1;
        private System.Windows.Forms.Label player2;
    }
}

