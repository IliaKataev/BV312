namespace WindowsFormsApp1
{
    partial class Form1
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
            this.ActiveAssemblies = new System.Windows.Forms.ListBox();
            this.AvailableAssemblies = new System.Windows.Forms.ListBox();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.closeWindowButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.notebookButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ActiveAssemblies
            // 
            this.ActiveAssemblies.FormattingEnabled = true;
            this.ActiveAssemblies.Location = new System.Drawing.Point(12, 62);
            this.ActiveAssemblies.Name = "ActiveAssemblies";
            this.ActiveAssemblies.Size = new System.Drawing.Size(270, 316);
            this.ActiveAssemblies.TabIndex = 0;
            this.ActiveAssemblies.SelectedIndexChanged += new System.EventHandler(this.Active_Selected);
            // 
            // AvailableAssemblies
            // 
            this.AvailableAssemblies.FormattingEnabled = true;
            this.AvailableAssemblies.Location = new System.Drawing.Point(498, 62);
            this.AvailableAssemblies.Name = "AvailableAssemblies";
            this.AvailableAssemblies.Size = new System.Drawing.Size(290, 316);
            this.AvailableAssemblies.TabIndex = 1;
            this.AvailableAssemblies.SelectedIndexChanged += new System.EventHandler(this.Available_Selected);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Location = new System.Drawing.Point(354, 62);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(88, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(354, 113);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(88, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // closeWindowButton
            // 
            this.closeWindowButton.Enabled = false;
            this.closeWindowButton.Location = new System.Drawing.Point(354, 170);
            this.closeWindowButton.Name = "closeWindowButton";
            this.closeWindowButton.Size = new System.Drawing.Size(88, 23);
            this.closeWindowButton.TabIndex = 4;
            this.closeWindowButton.Text = "CloseWindow";
            this.closeWindowButton.UseVisualStyleBackColor = true;
            this.closeWindowButton.Click += new System.EventHandler(this.closeWindowButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Enabled = false;
            this.refreshButton.Location = new System.Drawing.Point(354, 222);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(88, 23);
            this.refreshButton.TabIndex = 5;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // notebookButton
            // 
            this.notebookButton.Location = new System.Drawing.Point(354, 277);
            this.notebookButton.Name = "notebookButton";
            this.notebookButton.Size = new System.Drawing.Size(88, 35);
            this.notebookButton.TabIndex = 6;
            this.notebookButton.Text = "Open Notebook";
            this.notebookButton.UseVisualStyleBackColor = true;
            this.notebookButton.Click += new System.EventHandler(this.notebookButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.notebookButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.closeWindowButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.AvailableAssemblies);
            this.Controls.Add(this.ActiveAssemblies);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClose);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ActiveAssemblies;
        private System.Windows.Forms.ListBox AvailableAssemblies;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button closeWindowButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button notebookButton;
    }
}

