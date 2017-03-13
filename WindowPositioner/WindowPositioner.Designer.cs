namespace WindowPositioner
{
    partial class WindowPositioner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowPositioner));
            this.label1 = new System.Windows.Forms.Label();
            this.layoutsComboBox = new System.Windows.Forms.ComboBox();
            this.windowsListBox = new System.Windows.Forms.ListBox();
            this.windowSettingsBox = new System.Windows.Forms.GroupBox();
            this.translateCheckbox = new System.Windows.Forms.CheckBox();
            this.refreshWindowButton = new System.Windows.Forms.Button();
            this.authorLabel = new System.Windows.Forms.Label();
            this.saveWindowButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yField = new System.Windows.Forms.TextBox();
            this.widthField = new System.Windows.Forms.TextBox();
            this.heightField = new System.Windows.Forms.TextBox();
            this.xField = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.removeWindowButton = new System.Windows.Forms.Button();
            this.newLayoutButton = new System.Windows.Forms.Button();
            this.deleteLayoutButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.windowsComboBox = new System.Windows.Forms.ComboBox();
            this.applyLayoutButton = new System.Windows.Forms.Button();
            this.windowSettingsBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "My Layouts:";
            // 
            // layoutsComboBox
            // 
            this.layoutsComboBox.FormattingEnabled = true;
            this.layoutsComboBox.Location = new System.Drawing.Point(84, 13);
            this.layoutsComboBox.Name = "layoutsComboBox";
            this.layoutsComboBox.Size = new System.Drawing.Size(134, 21);
            this.layoutsComboBox.TabIndex = 1;
            this.layoutsComboBox.SelectedIndexChanged += new System.EventHandler(this.layoutsComboBox_SelectedIndexChanged);
            // 
            // windowsListBox
            // 
            this.windowsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.windowsListBox.FormattingEnabled = true;
            this.windowsListBox.Location = new System.Drawing.Point(9, 19);
            this.windowsListBox.Name = "windowsListBox";
            this.windowsListBox.Size = new System.Drawing.Size(153, 134);
            this.windowsListBox.TabIndex = 2;
            this.windowsListBox.SelectedIndexChanged += new System.EventHandler(this.windowsListBox_SelectedIndexChanged);
            this.windowsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.windowsListBox_MouseDoubleClick);
            // 
            // windowSettingsBox
            // 
            this.windowSettingsBox.Controls.Add(this.translateCheckbox);
            this.windowSettingsBox.Controls.Add(this.refreshWindowButton);
            this.windowSettingsBox.Controls.Add(this.authorLabel);
            this.windowSettingsBox.Controls.Add(this.saveWindowButton);
            this.windowSettingsBox.Controls.Add(this.label6);
            this.windowSettingsBox.Controls.Add(this.label5);
            this.windowSettingsBox.Controls.Add(this.label4);
            this.windowSettingsBox.Controls.Add(this.label3);
            this.windowSettingsBox.Controls.Add(this.yField);
            this.windowSettingsBox.Controls.Add(this.widthField);
            this.windowSettingsBox.Controls.Add(this.heightField);
            this.windowSettingsBox.Controls.Add(this.xField);
            this.windowSettingsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.windowSettingsBox.Location = new System.Drawing.Point(181, 90);
            this.windowSettingsBox.Name = "windowSettingsBox";
            this.windowSettingsBox.Size = new System.Drawing.Size(383, 150);
            this.windowSettingsBox.TabIndex = 4;
            this.windowSettingsBox.TabStop = false;
            this.windowSettingsBox.Text = "Window Settings";
            // 
            // translateCheckbox
            // 
            this.translateCheckbox.AutoSize = true;
            this.translateCheckbox.Location = new System.Drawing.Point(16, 90);
            this.translateCheckbox.Name = "translateCheckbox";
            this.translateCheckbox.Size = new System.Drawing.Size(100, 17);
            this.translateCheckbox.TabIndex = 11;
            this.translateCheckbox.Text = "Interior Window";
            this.translateCheckbox.UseVisualStyleBackColor = true;
            // 
            // refreshWindowButton
            // 
            this.refreshWindowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.refreshWindowButton.Location = new System.Drawing.Point(132, 119);
            this.refreshWindowButton.Name = "refreshWindowButton";
            this.refreshWindowButton.Size = new System.Drawing.Size(96, 23);
            this.refreshWindowButton.TabIndex = 10;
            this.refreshWindowButton.Text = "Refresh";
            this.refreshWindowButton.UseVisualStyleBackColor = true;
            this.refreshWindowButton.Click += new System.EventHandler(this.refreshWindowButton_Click);
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(334, 129);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(43, 13);
            this.authorLabel.TabIndex = 9;
            this.authorLabel.Text = "            ";
            this.authorLabel.DoubleClick += new System.EventHandler(this.authorLabel_DoubleClick);
            // 
            // saveWindowButton
            // 
            this.saveWindowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.saveWindowButton.Location = new System.Drawing.Point(16, 119);
            this.saveWindowButton.Name = "saveWindowButton";
            this.saveWindowButton.Size = new System.Drawing.Size(96, 23);
            this.saveWindowButton.TabIndex = 8;
            this.saveWindowButton.Text = "Save";
            this.saveWindowButton.UseVisualStyleBackColor = true;
            this.saveWindowButton.Click += new System.EventHandler(this.saveWindowButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(13, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Height:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(13, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Width:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(222, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(222, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "X:";
            // 
            // yField
            // 
            this.yField.Location = new System.Drawing.Point(252, 60);
            this.yField.Name = "yField";
            this.yField.Size = new System.Drawing.Size(43, 20);
            this.yField.TabIndex = 3;
            // 
            // widthField
            // 
            this.widthField.Location = new System.Drawing.Point(67, 28);
            this.widthField.Name = "widthField";
            this.widthField.Size = new System.Drawing.Size(43, 20);
            this.widthField.TabIndex = 2;
            // 
            // heightField
            // 
            this.heightField.Location = new System.Drawing.Point(67, 60);
            this.heightField.Name = "heightField";
            this.heightField.Size = new System.Drawing.Size(43, 20);
            this.heightField.TabIndex = 1;
            // 
            // xField
            // 
            this.xField.Location = new System.Drawing.Point(252, 28);
            this.xField.Name = "xField";
            this.xField.Size = new System.Drawing.Size(43, 20);
            this.xField.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeWindowButton);
            this.groupBox1.Controls.Add(this.windowsListBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(6, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 191);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layout Windows";
            // 
            // removeWindowButton
            // 
            this.removeWindowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.removeWindowButton.Location = new System.Drawing.Point(29, 160);
            this.removeWindowButton.Name = "removeWindowButton";
            this.removeWindowButton.Size = new System.Drawing.Size(109, 23);
            this.removeWindowButton.TabIndex = 9;
            this.removeWindowButton.Text = "Remove Window";
            this.removeWindowButton.UseVisualStyleBackColor = true;
            this.removeWindowButton.Click += new System.EventHandler(this.removeWindowButton_Click);
            // 
            // newLayoutButton
            // 
            this.newLayoutButton.Location = new System.Drawing.Point(350, 12);
            this.newLayoutButton.Name = "newLayoutButton";
            this.newLayoutButton.Size = new System.Drawing.Size(96, 23);
            this.newLayoutButton.TabIndex = 6;
            this.newLayoutButton.Text = "New Layout";
            this.newLayoutButton.UseVisualStyleBackColor = true;
            this.newLayoutButton.Click += new System.EventHandler(this.newLayoutButton_Click);
            // 
            // deleteLayoutButton
            // 
            this.deleteLayoutButton.Location = new System.Drawing.Point(465, 12);
            this.deleteLayoutButton.Name = "deleteLayoutButton";
            this.deleteLayoutButton.Size = new System.Drawing.Size(96, 23);
            this.deleteLayoutButton.TabIndex = 7;
            this.deleteLayoutButton.Text = "Delete Layout";
            this.deleteLayoutButton.UseVisualStyleBackColor = true;
            this.deleteLayoutButton.Click += new System.EventHandler(this.deleteLayoutButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(180, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Window:";
            // 
            // windowsComboBox
            // 
            this.windowsComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.windowsComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.windowsComboBox.FormattingEnabled = true;
            this.windowsComboBox.Location = new System.Drawing.Point(235, 49);
            this.windowsComboBox.Name = "windowsComboBox";
            this.windowsComboBox.Size = new System.Drawing.Size(329, 21);
            this.windowsComboBox.TabIndex = 1;
            this.windowsComboBox.TextChanged += new System.EventHandler(this.windowsComboBox_TextChanged);
            this.windowsComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.windowsComboBox_KeyDown);
            // 
            // applyLayoutButton
            // 
            this.applyLayoutButton.Location = new System.Drawing.Point(236, 12);
            this.applyLayoutButton.Name = "applyLayoutButton";
            this.applyLayoutButton.Size = new System.Drawing.Size(96, 23);
            this.applyLayoutButton.TabIndex = 9;
            this.applyLayoutButton.Text = "Apply Layout";
            this.applyLayoutButton.UseVisualStyleBackColor = true;
            this.applyLayoutButton.Click += new System.EventHandler(this.applyLayoutButton_Click);
            // 
            // WindowPositioner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 246);
            this.Controls.Add(this.applyLayoutButton);
            this.Controls.Add(this.windowsComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteLayoutButton);
            this.Controls.Add(this.newLayoutButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.windowSettingsBox);
            this.Controls.Add(this.layoutsComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WindowPositioner";
            this.Text = "Window Positioner";
            this.windowSettingsBox.ResumeLayout(false);
            this.windowSettingsBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox layoutsComboBox;
        private System.Windows.Forms.ListBox windowsListBox;
        private System.Windows.Forms.GroupBox windowSettingsBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button newLayoutButton;
        private System.Windows.Forms.Button deleteLayoutButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox windowsComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yField;
        private System.Windows.Forms.TextBox widthField;
        private System.Windows.Forms.TextBox heightField;
        private System.Windows.Forms.TextBox xField;
        private System.Windows.Forms.Button removeWindowButton;
        private System.Windows.Forms.Button saveWindowButton;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Button applyLayoutButton;
        private System.Windows.Forms.Button refreshWindowButton;
        private System.Windows.Forms.CheckBox translateCheckbox;
    }
}

