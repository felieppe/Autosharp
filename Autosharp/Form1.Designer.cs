namespace Autosharp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            folderDialogButton = new Button();
            logoPictureBox = new PictureBox();
            projectNameLabel = new Label();
            projectTextBox = new TextBox();
            folderPathTextBox = new TextBox();
            label1 = new Label();
            openVSCheckBox = new CheckBox();
            codeTemplateCheckBox = new CheckBox();
            versionLabel = new Label();
            progressBar = new ProgressBar();
            extrasCheckBox = new CheckBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // folderDialogButton
            // 
            resources.ApplyResources(folderDialogButton, "folderDialogButton");
            folderDialogButton.Name = "folderDialogButton";
            folderDialogButton.UseVisualStyleBackColor = true;
            folderDialogButton.Click += folderDialogButton_Click;
            // 
            // logoPictureBox
            // 
            logoPictureBox.BackColor = SystemColors.Control;
            resources.ApplyResources(logoPictureBox, "logoPictureBox");
            logoPictureBox.Image = Properties.Resources.autosharp;
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.TabStop = false;
            // 
            // projectNameLabel
            // 
            resources.ApplyResources(projectNameLabel, "projectNameLabel");
            projectNameLabel.Name = "projectNameLabel";
            // 
            // projectTextBox
            // 
            resources.ApplyResources(projectTextBox, "projectTextBox");
            projectTextBox.Name = "projectTextBox";
            // 
            // folderPathTextBox
            // 
            resources.ApplyResources(folderPathTextBox, "folderPathTextBox");
            folderPathTextBox.Name = "folderPathTextBox";
            folderPathTextBox.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // openVSCheckBox
            // 
            resources.ApplyResources(openVSCheckBox, "openVSCheckBox");
            openVSCheckBox.Checked = true;
            openVSCheckBox.CheckState = CheckState.Checked;
            openVSCheckBox.Name = "openVSCheckBox";
            openVSCheckBox.UseVisualStyleBackColor = true;
            // 
            // codeTemplateCheckBox
            // 
            resources.ApplyResources(codeTemplateCheckBox, "codeTemplateCheckBox");
            codeTemplateCheckBox.Checked = true;
            codeTemplateCheckBox.CheckState = CheckState.Checked;
            codeTemplateCheckBox.Name = "codeTemplateCheckBox";
            codeTemplateCheckBox.UseVisualStyleBackColor = true;
            // 
            // versionLabel
            // 
            resources.ApplyResources(versionLabel, "versionLabel");
            versionLabel.Name = "versionLabel";
            // 
            // progressBar
            // 
            progressBar.BackColor = SystemColors.Control;
            resources.ApplyResources(progressBar, "progressBar");
            progressBar.Name = "progressBar";
            // 
            // extrasCheckBox
            // 
            resources.ApplyResources(extrasCheckBox, "extrasCheckBox");
            extrasCheckBox.Name = "extrasCheckBox";
            extrasCheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(button1, "button1");
            button1.Name = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += startButton_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(extrasCheckBox);
            Controls.Add(progressBar);
            Controls.Add(versionLabel);
            Controls.Add(codeTemplateCheckBox);
            Controls.Add(openVSCheckBox);
            Controls.Add(folderDialogButton);
            Controls.Add(folderPathTextBox);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(projectTextBox);
            Controls.Add(projectNameLabel);
            Controls.Add(logoPictureBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox logoPictureBox;
        private Label projectNameLabel;
        private TextBox projectTextBox;
        private TextBox folderPathTextBox;
        private Label label1;
        private Button folderDialogButton;
        private CheckBox openVSCheckBox;
        private CheckBox codeTemplateCheckBox;
        private Label versionLabel;
        private ProgressBar progressBar;
        private CheckBox extrasCheckBox;
        private Button button1;
    }
}