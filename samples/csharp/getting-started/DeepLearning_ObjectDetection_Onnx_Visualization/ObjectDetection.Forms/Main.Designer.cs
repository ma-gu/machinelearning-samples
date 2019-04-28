namespace ObjectDetection.Forms
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.VideoImage = new Emgu.CV.UI.ImageBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ProcessButton = new System.Windows.Forms.Button();
            this.ProcessImageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoImage)).BeginInit();
            this.SuspendLayout();
            // 
            // VideoImage
            // 
            this.VideoImage.Location = new System.Drawing.Point(49, 75);
            this.VideoImage.Name = "VideoImage";
            this.VideoImage.Size = new System.Drawing.Size(717, 349);
            this.VideoImage.TabIndex = 2;
            this.VideoImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Video";
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(101, 25);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.Size = new System.Drawing.Size(488, 22);
            this.FileNameTextBox.TabIndex = 4;
            this.FileNameTextBox.Text = "D:\\Video\\raw.mp4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ProcessButton
            // 
            this.ProcessButton.Location = new System.Drawing.Point(641, 25);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(74, 23);
            this.ProcessButton.TabIndex = 6;
            this.ProcessButton.Text = "Process";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_Click);
            // 
            // ProcessImageButton
            // 
            this.ProcessImageButton.Location = new System.Drawing.Point(721, 25);
            this.ProcessImageButton.Name = "ProcessImageButton";
            this.ProcessImageButton.Size = new System.Drawing.Size(74, 23);
            this.ProcessImageButton.TabIndex = 7;
            this.ProcessImageButton.Text = "Image";
            this.ProcessImageButton.UseVisualStyleBackColor = true;
            this.ProcessImageButton.Click += new System.EventHandler(this.ProcessImageButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProcessImageButton);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VideoImage);
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.VideoImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox VideoImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.Button ProcessImageButton;
    }
}

