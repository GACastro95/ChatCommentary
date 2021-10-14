
namespace ChatCommentaryApp
{
    partial class ChatCommentaryForm
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
            this.directoryListBox = new System.Windows.Forms.ListBox();
            this.addDirectoryButton = new System.Windows.Forms.Button();
            this.removeDirectoryButton = new System.Windows.Forms.Button();
            this.enableRewardCheckbox = new System.Windows.Forms.CheckBox();
            this.costLabel = new System.Windows.Forms.Label();
            this.costBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.updateRewardButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // directoryListBox
            // 
            this.directoryListBox.FormattingEnabled = true;
            this.directoryListBox.Location = new System.Drawing.Point(13, 13);
            this.directoryListBox.Name = "directoryListBox";
            this.directoryListBox.Size = new System.Drawing.Size(428, 95);
            this.directoryListBox.TabIndex = 0;
            // 
            // addDirectoryButton
            // 
            this.addDirectoryButton.Location = new System.Drawing.Point(13, 114);
            this.addDirectoryButton.Name = "addDirectoryButton";
            this.addDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.addDirectoryButton.TabIndex = 1;
            this.addDirectoryButton.Text = "Add Directory";
            this.addDirectoryButton.UseVisualStyleBackColor = true;
            this.addDirectoryButton.Click += new System.EventHandler(this.AddDirectoryButton_Clicked);
            // 
            // removeDirectoryButton
            // 
            this.removeDirectoryButton.Location = new System.Drawing.Point(94, 114);
            this.removeDirectoryButton.Name = "removeDirectoryButton";
            this.removeDirectoryButton.Size = new System.Drawing.Size(75, 23);
            this.removeDirectoryButton.TabIndex = 2;
            this.removeDirectoryButton.Text = "Remove Directory";
            this.removeDirectoryButton.UseVisualStyleBackColor = true;
            this.removeDirectoryButton.Click += new System.EventHandler(this.RemoveDirectoryButton_Clicked);
            // 
            // enableRewardCheckbox
            // 
            this.enableRewardCheckbox.AutoSize = true;
            this.enableRewardCheckbox.Location = new System.Drawing.Point(376, 114);
            this.enableRewardCheckbox.Name = "enableRewardCheckbox";
            this.enableRewardCheckbox.Size = new System.Drawing.Size(65, 17);
            this.enableRewardCheckbox.TabIndex = 3;
            this.enableRewardCheckbox.Text = "Enabled";
            this.enableRewardCheckbox.UseVisualStyleBackColor = true;
            this.enableRewardCheckbox.CheckedChanged += new System.EventHandler(this.EnabledCheckbox_Changed);
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Location = new System.Drawing.Point(12, 181);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(28, 13);
            this.costLabel.TabIndex = 4;
            this.costLabel.Text = "Cost";
            // 
            // costBox
            // 
            this.costBox.Location = new System.Drawing.Point(47, 178);
            this.costBox.Name = "costBox";
            this.costBox.Size = new System.Drawing.Size(394, 20);
            this.costBox.TabIndex = 5;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 155);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.Text = "Title";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(47, 152);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(394, 20);
            this.titleBox.TabIndex = 5;
            // 
            // updateRewardButton
            // 
            this.updateRewardButton.Location = new System.Drawing.Point(366, 204);
            this.updateRewardButton.Name = "updateRewardButton";
            this.updateRewardButton.Size = new System.Drawing.Size(75, 23);
            this.updateRewardButton.TabIndex = 6;
            this.updateRewardButton.Text = "Update";
            this.updateRewardButton.UseVisualStyleBackColor = true;
            this.updateRewardButton.Click += new System.EventHandler(this.UpdateButton_Clicked);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 206);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Clicked);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(175, 114);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(21, 23);
            this.btnSettings.TabIndex = 14;
            this.btnSettings.Text = "⚙️";
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // ChatCommentaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 241);
            this.ControlBox = false;
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.updateRewardButton);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.costBox);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.enableRewardCheckbox);
            this.Controls.Add(this.removeDirectoryButton);
            this.Controls.Add(this.addDirectoryButton);
            this.Controls.Add(this.directoryListBox);
            this.Name = "ChatCommentaryForm";
            this.Text = "Chat Commentary";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox directoryListBox;
        private System.Windows.Forms.Button addDirectoryButton;
        private System.Windows.Forms.Button removeDirectoryButton;
        private System.Windows.Forms.CheckBox enableRewardCheckbox;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.TextBox costBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Button updateRewardButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button btnSettings;
    }
}

