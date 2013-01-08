namespace Labirinth
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
            this.btnCreateMaze = new System.Windows.Forms.Button();
            this.pbScreen = new System.Windows.Forms.PictureBox();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.lbX = new System.Windows.Forms.Label();
            this.lbY = new System.Windows.Forms.Label();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.btnSolveMaze = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateMaze
            // 
            this.btnCreateMaze.Location = new System.Drawing.Point(75, 453);
            this.btnCreateMaze.Name = "btnCreateMaze";
            this.btnCreateMaze.Size = new System.Drawing.Size(50, 49);
            this.btnCreateMaze.TabIndex = 0;
            this.btnCreateMaze.Text = "Create maze";
            this.btnCreateMaze.UseVisualStyleBackColor = true;
            this.btnCreateMaze.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbScreen
            // 
            this.pbScreen.BackColor = System.Drawing.Color.Black;
            this.pbScreen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbScreen.Location = new System.Drawing.Point(7, 7);
            this.pbScreen.Name = "pbScreen";
            this.pbScreen.Size = new System.Drawing.Size(640, 440);
            this.pbScreen.TabIndex = 1;
            this.pbScreen.TabStop = false;
            // 
            // nudX
            // 
            this.nudX.Location = new System.Drawing.Point(27, 453);
            this.nudX.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.nudX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(42, 20);
            this.nudX.TabIndex = 2;
            this.nudX.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(11, 455);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(15, 13);
            this.lbX.TabIndex = 3;
            this.lbX.Text = "x:";
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(11, 484);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(15, 13);
            this.lbY.TabIndex = 4;
            this.lbY.Text = "y:";
            // 
            // nudY
            // 
            this.nudY.Location = new System.Drawing.Point(27, 482);
            this.nudY.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(42, 20);
            this.nudY.TabIndex = 5;
            this.nudY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnSolveMaze
            // 
            this.btnSolveMaze.Enabled = false;
            this.btnSolveMaze.Location = new System.Drawing.Point(131, 453);
            this.btnSolveMaze.Name = "btnSolveMaze";
            this.btnSolveMaze.Size = new System.Drawing.Size(50, 49);
            this.btnSolveMaze.TabIndex = 6;
            this.btnSolveMaze.Text = "Solve maze";
            this.btnSolveMaze.UseVisualStyleBackColor = true;
            this.btnSolveMaze.Click += new System.EventHandler(this.btnSolveMaze_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 511);
            this.Controls.Add(this.btnSolveMaze);
            this.Controls.Add(this.nudY);
            this.Controls.Add(this.lbY);
            this.Controls.Add(this.lbX);
            this.Controls.Add(this.nudX);
            this.Controls.Add(this.pbScreen);
            this.Controls.Add(this.btnCreateMaze);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Labirinth";
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateMaze;
        private System.Windows.Forms.PictureBox pbScreen;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.Button btnSolveMaze;
    }
}

