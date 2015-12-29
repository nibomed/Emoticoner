namespace Installer
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
            this.tableLayoutPanelRoot = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelCenter = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLeft = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxShortcut = new System.Windows.Forms.CheckBox();
            this.checkBoxRegister = new System.Windows.Forms.CheckBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.tableLayoutPanelPath = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonTheme1 = new System.Windows.Forms.RadioButton();
            this.radioButtonTheme2 = new System.Windows.Forms.RadioButton();
            this.pictureBoxTheme2 = new System.Windows.Forms.PictureBox();
            this.labelTheme = new System.Windows.Forms.Label();
            this.pictureBoxTheme1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLicense = new System.Windows.Forms.Button();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanelRoot.SuspendLayout();
            this.tableLayoutPanelCenter.SuspendLayout();
            this.tableLayoutPanelLeft.SuspendLayout();
            this.tableLayoutPanelPath.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme1)).BeginInit();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelRoot
            // 
            this.tableLayoutPanelRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelRoot.ColumnCount = 1;
            this.tableLayoutPanelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRoot.Controls.Add(this.tableLayoutPanelCenter, 0, 1);
            this.tableLayoutPanelRoot.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelRoot.Controls.Add(this.tableLayoutPanelBottom, 0, 2);
            this.tableLayoutPanelRoot.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelRoot.Name = "tableLayoutPanelRoot";
            this.tableLayoutPanelRoot.RowCount = 3;
            this.tableLayoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelRoot.Size = new System.Drawing.Size(558, 529);
            this.tableLayoutPanelRoot.TabIndex = 0;
            // 
            // tableLayoutPanelCenter
            // 
            this.tableLayoutPanelCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelCenter.ColumnCount = 2;
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanelCenter.Controls.Add(this.tableLayoutPanelLeft, 0, 0);
            this.tableLayoutPanelCenter.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.tableLayoutPanelCenter.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanelCenter.Name = "tableLayoutPanelCenter";
            this.tableLayoutPanelCenter.RowCount = 1;
            this.tableLayoutPanelCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCenter.Size = new System.Drawing.Size(552, 423);
            this.tableLayoutPanelCenter.TabIndex = 0;
            // 
            // tableLayoutPanelLeft
            // 
            this.tableLayoutPanelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelLeft.ColumnCount = 1;
            this.tableLayoutPanelLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Controls.Add(this.checkBoxShortcut, 0, 4);
            this.tableLayoutPanelLeft.Controls.Add(this.checkBoxRegister, 0, 3);
            this.tableLayoutPanelLeft.Controls.Add(this.labelPath, 0, 0);
            this.tableLayoutPanelLeft.Controls.Add(this.tableLayoutPanelPath, 0, 1);
            this.tableLayoutPanelLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelLeft.Name = "tableLayoutPanelLeft";
            this.tableLayoutPanelLeft.RowCount = 7;
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLeft.Size = new System.Drawing.Size(246, 417);
            this.tableLayoutPanelLeft.TabIndex = 0;
            // 
            // checkBoxShortcut
            // 
            this.checkBoxShortcut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxShortcut.AutoSize = true;
            this.checkBoxShortcut.Checked = true;
            this.checkBoxShortcut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShortcut.Location = new System.Drawing.Point(3, 113);
            this.checkBoxShortcut.Name = "checkBoxShortcut";
            this.checkBoxShortcut.Size = new System.Drawing.Size(240, 29);
            this.checkBoxShortcut.TabIndex = 0;
            this.checkBoxShortcut.Text = "Create desctop shortcut";
            this.checkBoxShortcut.UseVisualStyleBackColor = true;
            // 
            // checkBoxRegister
            // 
            this.checkBoxRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRegister.AutoSize = true;
            this.checkBoxRegister.Checked = true;
            this.checkBoxRegister.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRegister.Location = new System.Drawing.Point(3, 78);
            this.checkBoxRegister.Name = "checkBoxRegister";
            this.checkBoxRegister.Size = new System.Drawing.Size(240, 29);
            this.checkBoxRegister.TabIndex = 1;
            this.checkBoxRegister.Text = "Register app in Control Panel";
            this.checkBoxRegister.UseVisualStyleBackColor = true;
            // 
            // labelPath
            // 
            this.labelPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(3, 0);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(240, 30);
            this.labelPath.TabIndex = 2;
            this.labelPath.Text = "Installation Path";
            this.labelPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelPath
            // 
            this.tableLayoutPanelPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelPath.ColumnCount = 2;
            this.tableLayoutPanelPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPath.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelPath.Controls.Add(this.textBoxPath, 0, 0);
            this.tableLayoutPanelPath.Controls.Add(this.buttonOpen, 1, 0);
            this.tableLayoutPanelPath.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanelPath.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelPath.Name = "tableLayoutPanelPath";
            this.tableLayoutPanelPath.RowCount = 1;
            this.tableLayoutPanelPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPath.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanelPath.Size = new System.Drawing.Size(246, 35);
            this.tableLayoutPanelPath.TabIndex = 3;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPath.Location = new System.Drawing.Point(3, 6);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(200, 22);
            this.textBoxPath.TabIndex = 0;
            this.textBoxPath.Text = "C:\\Program Files";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.Location = new System.Drawing.Point(209, 3);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(34, 29);
            this.buttonOpen.TabIndex = 1;
            this.buttonOpen.Text = ">>";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonTheme1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonTheme2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxTheme2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelTheme, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxTheme1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(255, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(294, 417);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // radioButtonTheme1
            // 
            this.radioButtonTheme1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonTheme1.AutoSize = true;
            this.radioButtonTheme1.Checked = true;
            this.radioButtonTheme1.Location = new System.Drawing.Point(3, 38);
            this.radioButtonTheme1.Name = "radioButtonTheme1";
            this.radioButtonTheme1.Size = new System.Drawing.Size(288, 29);
            this.radioButtonTheme1.TabIndex = 0;
            this.radioButtonTheme1.TabStop = true;
            this.radioButtonTheme1.Text = "Water breath";
            this.radioButtonTheme1.UseVisualStyleBackColor = true;
            // 
            // radioButtonTheme2
            // 
            this.radioButtonTheme2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonTheme2.AutoSize = true;
            this.radioButtonTheme2.Location = new System.Drawing.Point(3, 223);
            this.radioButtonTheme2.Name = "radioButtonTheme2";
            this.radioButtonTheme2.Size = new System.Drawing.Size(288, 29);
            this.radioButtonTheme2.TabIndex = 1;
            this.radioButtonTheme2.Text = "Basket of peaches and cherries";
            this.radioButtonTheme2.UseVisualStyleBackColor = true;
            // 
            // pictureBoxTheme2
            // 
            this.pictureBoxTheme2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTheme2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTheme2.Image")));
            this.pictureBoxTheme2.Location = new System.Drawing.Point(3, 258);
            this.pictureBoxTheme2.Name = "pictureBoxTheme2";
            this.pictureBoxTheme2.Size = new System.Drawing.Size(288, 144);
            this.pictureBoxTheme2.TabIndex = 2;
            this.pictureBoxTheme2.TabStop = false;
            // 
            // labelTheme
            // 
            this.labelTheme.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTheme.AutoSize = true;
            this.labelTheme.Location = new System.Drawing.Point(3, 0);
            this.labelTheme.Name = "labelTheme";
            this.labelTheme.Size = new System.Drawing.Size(288, 35);
            this.labelTheme.TabIndex = 3;
            this.labelTheme.Text = "Pick your theme";
            this.labelTheme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxTheme1
            // 
            this.pictureBoxTheme1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxTheme1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxTheme1.Image")));
            this.pictureBoxTheme1.Location = new System.Drawing.Point(3, 73);
            this.pictureBoxTheme1.Name = "pictureBoxTheme1";
            this.pictureBoxTheme1.Size = new System.Drawing.Size(288, 144);
            this.pictureBoxTheme1.TabIndex = 4;
            this.pictureBoxTheme1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(552, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to Emoticoner installer.\r\nEmoticoner is a simple smart way to use emoji.\r" +
    "\nHave fun. (⌒‿⌒)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelBottom.ColumnCount = 4;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanelBottom.Controls.Add(this.buttonLicense, 0, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.buttonInstall, 2, 0);
            this.tableLayoutPanelBottom.Controls.Add(this.buttonExit, 3, 0);
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(3, 492);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 1;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(552, 34);
            this.tableLayoutPanelBottom.TabIndex = 2;
            // 
            // buttonLicense
            // 
            this.buttonLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLicense.Location = new System.Drawing.Point(3, 3);
            this.buttonLicense.Name = "buttonLicense";
            this.buttonLicense.Size = new System.Drawing.Size(94, 28);
            this.buttonLicense.TabIndex = 0;
            this.buttonLicense.Text = "Licecnse";
            this.buttonLicense.UseVisualStyleBackColor = true;
            this.buttonLicense.Click += new System.EventHandler(this.buttonLicense_Click);
            // 
            // buttonInstall
            // 
            this.buttonInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonInstall.Location = new System.Drawing.Point(355, 3);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(94, 28);
            this.buttonInstall.TabIndex = 1;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(455, 3);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(94, 28);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.tableLayoutPanelRoot);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Form1";
            this.Text = "bl";
            this.tableLayoutPanelRoot.ResumeLayout(false);
            this.tableLayoutPanelRoot.PerformLayout();
            this.tableLayoutPanelCenter.ResumeLayout(false);
            this.tableLayoutPanelLeft.ResumeLayout(false);
            this.tableLayoutPanelLeft.PerformLayout();
            this.tableLayoutPanelPath.ResumeLayout(false);
            this.tableLayoutPanelPath.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTheme1)).EndInit();
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRoot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCenter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.Button buttonLicense;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.CheckBox checkBoxShortcut;
        private System.Windows.Forms.CheckBox checkBoxRegister;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPath;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.RadioButton radioButtonTheme1;
        private System.Windows.Forms.RadioButton radioButtonTheme2;
        private System.Windows.Forms.PictureBox pictureBoxTheme2;
        private System.Windows.Forms.Label labelTheme;
        private System.Windows.Forms.PictureBox pictureBoxTheme1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

