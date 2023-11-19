
namespace FileWatcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.configBtn = new System.Windows.Forms.Button();
            this.filePathLbl = new System.Windows.Forms.Label();
            this.filePathTxt = new System.Windows.Forms.TextBox();
            this.logTxt = new System.Windows.Forms.TextBox();
            this.watchBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // configBtn
            // 
            this.configBtn.Location = new System.Drawing.Point(26, 24);
            this.configBtn.Name = "configBtn";
            this.configBtn.Size = new System.Drawing.Size(114, 29);
            this.configBtn.TabIndex = 0;
            this.configBtn.Text = "Configuration";
            this.configBtn.UseVisualStyleBackColor = true;
            this.configBtn.Click += new System.EventHandler(this.configBtn_Click);
            // 
            // filePathLbl
            // 
            this.filePathLbl.AutoSize = true;
            this.filePathLbl.Location = new System.Drawing.Point(25, 72);
            this.filePathLbl.Name = "filePathLbl";
            this.filePathLbl.Size = new System.Drawing.Size(67, 17);
            this.filePathLbl.TabIndex = 1;
            this.filePathLbl.Text = "File Path:";
            // 
            // filePathTxt
            // 
            this.filePathTxt.Location = new System.Drawing.Point(28, 109);
            this.filePathTxt.Name = "filePathTxt";
            this.filePathTxt.Size = new System.Drawing.Size(746, 22);
            this.filePathTxt.TabIndex = 2;
            this.filePathTxt.TextChanged += new System.EventHandler(this.filePathTxt_TextChanged);
            // 
            // logTxt
            // 
            this.logTxt.Location = new System.Drawing.Point(28, 151);
            this.logTxt.Multiline = true;
            this.logTxt.Name = "logTxt";
            this.logTxt.ReadOnly = true;
            this.logTxt.Size = new System.Drawing.Size(746, 247);
            this.logTxt.TabIndex = 3;
            // 
            // watchBtn
            // 
            this.watchBtn.Location = new System.Drawing.Point(341, 415);
            this.watchBtn.Name = "watchBtn";
            this.watchBtn.Size = new System.Drawing.Size(75, 23);
            this.watchBtn.TabIndex = 4;
            this.watchBtn.Text = "Start";
            this.watchBtn.UseVisualStyleBackColor = true;
            this.watchBtn.Click += new System.EventHandler(this.watchBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.watchBtn);
            this.Controls.Add(this.logTxt);
            this.Controls.Add(this.filePathTxt);
            this.Controls.Add(this.filePathLbl);
            this.Controls.Add(this.configBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Watcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button configBtn;
        private System.Windows.Forms.Label filePathLbl;
        private System.Windows.Forms.TextBox filePathTxt;
        private System.Windows.Forms.Button watchBtn;
        public System.Windows.Forms.TextBox logTxt;
    }
}

