namespace Emoticoner
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanelRoot = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelDown = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.tableLayoutPanelUp = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelRoot.SuspendLayout();
            this.tableLayoutPanelDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotyfiIconMouseClickHandler);
            // 
            // tableLayoutPanelRoot
            // 
            this.tableLayoutPanelRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelRoot.ColumnCount = 1;
            this.tableLayoutPanelRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRoot.Controls.Add(this.tableLayoutPanelDown, 0, 1);
            this.tableLayoutPanelRoot.Controls.Add(this.tableLayoutPanelUp, 0, 0);
            this.tableLayoutPanelRoot.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelRoot.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelRoot.Name = "tableLayoutPanelRoot";
            this.tableLayoutPanelRoot.RowCount = 2;
            this.tableLayoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelRoot.Size = new System.Drawing.Size(467, 515);
            this.tableLayoutPanelRoot.TabIndex = 0;
            // 
            // tableLayoutPanelDown
            // 
            this.tableLayoutPanelDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelDown.ColumnCount = 2;
            this.tableLayoutPanelDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanelDown.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanelDown.Controls.Add(this.buttonMenu, 1, 0);
            this.tableLayoutPanelDown.Location = new System.Drawing.Point(2, 485);
            this.tableLayoutPanelDown.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.tableLayoutPanelDown.Name = "tableLayoutPanelDown";
            this.tableLayoutPanelDown.RowCount = 1;
            this.tableLayoutPanelDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDown.Size = new System.Drawing.Size(463, 28);
            this.tableLayoutPanelDown.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(2, 2);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(399, 22);
            this.textBox1.TabIndex = 0;
            // 
            // buttonMenu
            // 
            this.buttonMenu.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonMenu.Location = new System.Drawing.Point(403, 2);
            this.buttonMenu.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(56, 22);
            this.buttonMenu.TabIndex = 1;
            this.buttonMenu.Text = "Menu";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenuClick);
            // 
            // tableLayoutPanelUp
            // 
            this.tableLayoutPanelUp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelUp.ColumnCount = 1;
            this.tableLayoutPanelUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelUp.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelUp.Name = "tableLayoutPanelUp";
            this.tableLayoutPanelUp.RowCount = 1;
            this.tableLayoutPanelUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 479F));
            this.tableLayoutPanelUp.Size = new System.Drawing.Size(461, 479);
            this.tableLayoutPanelUp.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 527);
            this.Controls.Add(this.tableLayoutPanelRoot);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "hello";
            this.tableLayoutPanelRoot.ResumeLayout(false);
            this.tableLayoutPanelDown.ResumeLayout(false);
            this.tableLayoutPanelDown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelRoot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDown;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUp;
    }
}

