namespace _3DObjects
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openButton1 = new Button();
            pictureBox1 = new PictureBox();
            scaleUpButoon = new Button();
            scaleDownButoon = new Button();
            rightMoveButton = new Button();
            leftMoveButton = new Button();
            upMoveButoon = new Button();
            downMoveButton = new Button();
            backMoveButton = new Button();
            forwardMoveButton = new Button();
            xRotateButton = new Button();
            yRotateButton = new Button();
            zRotateButton = new Button();
            robertsButton = new Button();
            zbufferButton = new Button();
            label1 = new Label();
            label2 = new Label();
            openButton2 = new Button();
            horizonXRotateButton = new Button();
            horizonYRotateButton = new Button();
            horizonZRotateButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // openButton1
            // 
            openButton1.Location = new Point(72, 604);
            openButton1.Margin = new Padding(3, 4, 3, 4);
            openButton1.Name = "openButton1";
            openButton1.Size = new Size(86, 31);
            openButton1.TabIndex = 0;
            openButton1.TabStop = false;
            openButton1.Text = "Open";
            openButton1.UseVisualStyleBackColor = true;
            openButton1.Click += OpenButton1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Location = new Point(245, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1609, 1196);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // scaleUpButoon
            // 
            scaleUpButoon.Location = new Point(14, 61);
            scaleUpButoon.Margin = new Padding(3, 4, 3, 4);
            scaleUpButoon.Name = "scaleUpButoon";
            scaleUpButoon.Size = new Size(86, 31);
            scaleUpButoon.TabIndex = 2;
            scaleUpButoon.TabStop = false;
            scaleUpButoon.Text = "ScaleUp";
            scaleUpButoon.UseVisualStyleBackColor = true;
            scaleUpButoon.Click += ScaleUpButoon_Click;
            // 
            // scaleDownButoon
            // 
            scaleDownButoon.Location = new Point(129, 61);
            scaleDownButoon.Margin = new Padding(3, 4, 3, 4);
            scaleDownButoon.Name = "scaleDownButoon";
            scaleDownButoon.Size = new Size(86, 31);
            scaleDownButoon.TabIndex = 3;
            scaleDownButoon.TabStop = false;
            scaleDownButoon.Text = "ScaleDown";
            scaleDownButoon.UseVisualStyleBackColor = true;
            scaleDownButoon.Click += ScaleDownButoon_Click;
            // 
            // rightMoveButton
            // 
            rightMoveButton.Location = new Point(129, 187);
            rightMoveButton.Margin = new Padding(3, 4, 3, 4);
            rightMoveButton.Name = "rightMoveButton";
            rightMoveButton.Size = new Size(86, 31);
            rightMoveButton.TabIndex = 4;
            rightMoveButton.TabStop = false;
            rightMoveButton.Text = "RightMove";
            rightMoveButton.UseVisualStyleBackColor = true;
            rightMoveButton.Click += RightMoveButton_Click;
            // 
            // leftMoveButton
            // 
            leftMoveButton.Location = new Point(14, 187);
            leftMoveButton.Margin = new Padding(3, 4, 3, 4);
            leftMoveButton.Name = "leftMoveButton";
            leftMoveButton.Size = new Size(86, 31);
            leftMoveButton.TabIndex = 5;
            leftMoveButton.TabStop = false;
            leftMoveButton.Text = "LeftMove";
            leftMoveButton.UseVisualStyleBackColor = true;
            leftMoveButton.Click += LeftMoveButton_Click;
            // 
            // upMoveButoon
            // 
            upMoveButoon.Location = new Point(14, 123);
            upMoveButoon.Margin = new Padding(3, 4, 3, 4);
            upMoveButoon.Name = "upMoveButoon";
            upMoveButoon.Size = new Size(86, 31);
            upMoveButoon.TabIndex = 6;
            upMoveButoon.TabStop = false;
            upMoveButoon.Text = "UpMove";
            upMoveButoon.UseVisualStyleBackColor = true;
            upMoveButoon.Click += UpMoveButoon_Click;
            // 
            // downMoveButton
            // 
            downMoveButton.Location = new Point(129, 123);
            downMoveButton.Margin = new Padding(3, 4, 3, 4);
            downMoveButton.Name = "downMoveButton";
            downMoveButton.Size = new Size(86, 31);
            downMoveButton.TabIndex = 7;
            downMoveButton.TabStop = false;
            downMoveButton.Text = "DownMove";
            downMoveButton.UseVisualStyleBackColor = true;
            downMoveButton.Click += DownMoveButton_Click;
            // 
            // backMoveButton
            // 
            backMoveButton.Location = new Point(129, 244);
            backMoveButton.Margin = new Padding(3, 4, 3, 4);
            backMoveButton.Name = "backMoveButton";
            backMoveButton.Size = new Size(86, 31);
            backMoveButton.TabIndex = 9;
            backMoveButton.TabStop = false;
            backMoveButton.Text = "BackMove";
            backMoveButton.UseVisualStyleBackColor = true;
            backMoveButton.Click += BackMoveButton_Click;
            // 
            // forwardMoveButton
            // 
            forwardMoveButton.Location = new Point(14, 244);
            forwardMoveButton.Margin = new Padding(3, 4, 3, 4);
            forwardMoveButton.Name = "forwardMoveButton";
            forwardMoveButton.Size = new Size(86, 31);
            forwardMoveButton.TabIndex = 8;
            forwardMoveButton.TabStop = false;
            forwardMoveButton.Text = "ForwardMove";
            forwardMoveButton.UseVisualStyleBackColor = true;
            forwardMoveButton.Click += ForwardMoveButton_Click;
            // 
            // xRotateButton
            // 
            xRotateButton.Location = new Point(129, 344);
            xRotateButton.Margin = new Padding(3, 4, 3, 4);
            xRotateButton.Name = "xRotateButton";
            xRotateButton.Size = new Size(86, 31);
            xRotateButton.TabIndex = 10;
            xRotateButton.TabStop = false;
            xRotateButton.Text = "RotateX";
            xRotateButton.UseVisualStyleBackColor = true;
            xRotateButton.Click += XRotateButton_Click;
            // 
            // yRotateButton
            // 
            yRotateButton.Location = new Point(14, 344);
            yRotateButton.Margin = new Padding(3, 4, 3, 4);
            yRotateButton.Name = "yRotateButton";
            yRotateButton.Size = new Size(86, 31);
            yRotateButton.TabIndex = 11;
            yRotateButton.TabStop = false;
            yRotateButton.Text = "RotateY";
            yRotateButton.UseVisualStyleBackColor = true;
            yRotateButton.Click += YRotateButton_Click;
            // 
            // zRotateButton
            // 
            zRotateButton.Location = new Point(72, 405);
            zRotateButton.Margin = new Padding(3, 4, 3, 4);
            zRotateButton.Name = "zRotateButton";
            zRotateButton.Size = new Size(86, 31);
            zRotateButton.TabIndex = 12;
            zRotateButton.TabStop = false;
            zRotateButton.Text = "RotateZ";
            zRotateButton.UseVisualStyleBackColor = true;
            zRotateButton.Click += ZRotateButton_Click;
            // 
            // robertsButton
            // 
            robertsButton.Location = new Point(14, 481);
            robertsButton.Margin = new Padding(3, 4, 3, 4);
            robertsButton.Name = "robertsButton";
            robertsButton.Size = new Size(201, 31);
            robertsButton.TabIndex = 13;
            robertsButton.TabStop = false;
            robertsButton.Text = "Roberts Method";
            robertsButton.UseVisualStyleBackColor = true;
            robertsButton.Click += RobertsButton_Click;
            // 
            // zbufferButton
            // 
            zbufferButton.Location = new Point(14, 536);
            zbufferButton.Margin = new Padding(3, 4, 3, 4);
            zbufferButton.Name = "zbufferButton";
            zbufferButton.Size = new Size(201, 31);
            zbufferButton.TabIndex = 14;
            zbufferButton.TabStop = false;
            zbufferButton.Text = "Z-Buffer Method";
            zbufferButton.UseVisualStyleBackColor = true;
            zbufferButton.Click += ZbufferButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 16);
            label1.Name = "label1";
            label1.Size = new Size(150, 20);
            label1.TabIndex = 16;
            label1.Text = "Work with 3D objects";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 703);
            label2.Name = "label2";
            label2.Size = new Size(189, 20);
            label2.TabIndex = 17;
            label2.Text = "Work with floating horizon ";
            // 
            // openButton2
            // 
            openButton2.Location = new Point(72, 921);
            openButton2.Margin = new Padding(3, 4, 3, 4);
            openButton2.Name = "openButton2";
            openButton2.Size = new Size(86, 31);
            openButton2.TabIndex = 18;
            openButton2.TabStop = false;
            openButton2.Text = "Open";
            openButton2.UseVisualStyleBackColor = true;
            openButton2.Click += OpenButton2_Click;
            // 
            // horizonXRotateButton
            // 
            horizonXRotateButton.Location = new Point(72, 751);
            horizonXRotateButton.Margin = new Padding(3, 4, 3, 4);
            horizonXRotateButton.Name = "horizonXRotateButton";
            horizonXRotateButton.Size = new Size(86, 31);
            horizonXRotateButton.TabIndex = 19;
            horizonXRotateButton.TabStop = false;
            horizonXRotateButton.Text = "RotateX";
            horizonXRotateButton.UseVisualStyleBackColor = true;
            horizonXRotateButton.Click += HorizonXRotateButton_Click;
            // 
            // horizonYRotateButton
            // 
            horizonYRotateButton.Location = new Point(72, 809);
            horizonYRotateButton.Margin = new Padding(3, 4, 3, 4);
            horizonYRotateButton.Name = "horizonYRotateButton";
            horizonYRotateButton.Size = new Size(86, 31);
            horizonYRotateButton.TabIndex = 20;
            horizonYRotateButton.TabStop = false;
            horizonYRotateButton.Text = "RotateY";
            horizonYRotateButton.UseVisualStyleBackColor = true;
            horizonYRotateButton.Click += HorizonYRotateButton_Click;
            // 
            // horizonZRotateButton
            // 
            horizonZRotateButton.Location = new Point(72, 864);
            horizonZRotateButton.Margin = new Padding(3, 4, 3, 4);
            horizonZRotateButton.Name = "horizonZRotateButton";
            horizonZRotateButton.Size = new Size(86, 31);
            horizonZRotateButton.TabIndex = 21;
            horizonZRotateButton.TabStop = false;
            horizonZRotateButton.Text = "RotateZ";
            horizonZRotateButton.UseVisualStyleBackColor = true;
            horizonZRotateButton.Click += HorizonZRotateButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1867, 1055);
            Controls.Add(horizonZRotateButton);
            Controls.Add(horizonYRotateButton);
            Controls.Add(horizonXRotateButton);
            Controls.Add(openButton2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(zbufferButton);
            Controls.Add(robertsButton);
            Controls.Add(zRotateButton);
            Controls.Add(yRotateButton);
            Controls.Add(xRotateButton);
            Controls.Add(backMoveButton);
            Controls.Add(forwardMoveButton);
            Controls.Add(downMoveButton);
            Controls.Add(upMoveButoon);
            Controls.Add(leftMoveButton);
            Controls.Add(rightMoveButton);
            Controls.Add(scaleDownButoon);
            Controls.Add(scaleUpButoon);
            Controls.Add(pictureBox1);
            Controls.Add(openButton1);
            KeyPreview = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            MouseWheel += Form1_MouseWheel;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button openButton1;
        private PictureBox pictureBox1;
        private Button scaleUpButoon;
        private Button scaleDownButoon;
        private Button rightMoveButton;
        private Button leftMoveButton;
        private Button upMoveButoon;
        private Button downMoveButton;
        private Button backMoveButton;
        private Button forwardMoveButton;
        private Button xRotateButton;
        private Button yRotateButton;
        private Button zRotateButton;
        private Button robertsButton;
        private Button zbufferButton;
        private Label label1;
        private Label label2;
        private Button openButton2;
        private Button horizonXRotateButton;
        private Button horizonYRotateButton;
        private Button horizonZRotateButton;
    }
}
