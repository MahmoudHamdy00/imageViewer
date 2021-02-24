
namespace imageViewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.path = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slideShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SingleMode_ContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiMode_ContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SlideShowMode_ContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.HideShowListButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.RotateButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.ShowAllButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.SlideShowButton = new System.Windows.Forms.Button();
            this.IsDarkModeEnable = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // path
            // 
            this.path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.path.Location = new System.Drawing.Point(191, 34);
            this.path.Margin = new System.Windows.Forms.Padding(2);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(512, 20);
            this.path.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.Silver;
            this.mainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mainPanel.Location = new System.Drawing.Point(191, 63);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(677, 324);
            this.mainPanel.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("MV Boli", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(2, 64);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(185, 324);
            this.listBox1.TabIndex = 2;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseClick);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(877, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentMode,
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(0, 428);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(877, 22);
            this.statusStrip2.TabIndex = 9;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // CurrentMode
            // 
            this.CurrentMode.Margin = new System.Windows.Forms.Padding(5, 3, 20, 2);
            this.CurrentMode.Name = "CurrentMode";
            this.CurrentMode.Size = new System.Drawing.Size(69, 17);
            this.CurrentMode.Text = "Multi Mode";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.modesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(877, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apoutToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "File";
            // 
            // apoutToolStripMenuItem
            // 
            this.apoutToolStripMenuItem.Name = "apoutToolStripMenuItem";
            this.apoutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.apoutToolStripMenuItem.Text = "About";
            this.apoutToolStripMenuItem.Click += new System.EventHandler(this.apoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
            // 
            // modesToolStripMenuItem
            // 
            this.modesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleModeToolStripMenuItem,
            this.multiModeToolStripMenuItem,
            this.slideShowToolStripMenuItem});
            this.modesToolStripMenuItem.Name = "modesToolStripMenuItem";
            this.modesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.modesToolStripMenuItem.Text = "Modes";
            // 
            // singleModeToolStripMenuItem
            // 
            this.singleModeToolStripMenuItem.Name = "singleModeToolStripMenuItem";
            this.singleModeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.singleModeToolStripMenuItem.Text = "Single Mode";
            this.singleModeToolStripMenuItem.Click += new System.EventHandler(this.SingleMode_Click);
            // 
            // multiModeToolStripMenuItem
            // 
            this.multiModeToolStripMenuItem.Name = "multiModeToolStripMenuItem";
            this.multiModeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.multiModeToolStripMenuItem.Text = "Multi Mode";
            this.multiModeToolStripMenuItem.Click += new System.EventHandler(this.MultiMode_Click);
            // 
            // slideShowToolStripMenuItem
            // 
            this.slideShowToolStripMenuItem.Name = "slideShowToolStripMenuItem";
            this.slideShowToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.slideShowToolStripMenuItem.Text = "SlideShow";
            this.slideShowToolStripMenuItem.Click += new System.EventHandler(this.SlideShowButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SingleMode_ContextMenuStrip,
            this.MultiMode_ContextMenuStrip,
            this.SlideShowMode_ContextMenuStrip});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 70);
            // 
            // SingleMode_ContextMenuStrip
            // 
            this.SingleMode_ContextMenuStrip.Name = "SingleMode_ContextMenuStrip";
            this.SingleMode_ContextMenuStrip.Size = new System.Drawing.Size(140, 22);
            this.SingleMode_ContextMenuStrip.Text = "Single Mode";
            this.SingleMode_ContextMenuStrip.Click += new System.EventHandler(this.SingleMode_Click);
            // 
            // MultiMode_ContextMenuStrip
            // 
            this.MultiMode_ContextMenuStrip.Name = "MultiMode_ContextMenuStrip";
            this.MultiMode_ContextMenuStrip.Size = new System.Drawing.Size(140, 22);
            this.MultiMode_ContextMenuStrip.Text = "Multi Mode";
            this.MultiMode_ContextMenuStrip.Click += new System.EventHandler(this.MultiMode_Click);
            // 
            // SlideShowMode_ContextMenuStrip
            // 
            this.SlideShowMode_ContextMenuStrip.Name = "SlideShowMode_ContextMenuStrip";
            this.SlideShowMode_ContextMenuStrip.Size = new System.Drawing.Size(140, 22);
            this.SlideShowMode_ContextMenuStrip.Text = "SlideShow";
            this.SlideShowMode_ContextMenuStrip.Click += new System.EventHandler(this.SlideShowButton_Click);
            // 
            // HideShowListButton
            // 
            this.HideShowListButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HideShowListButton.Location = new System.Drawing.Point(5, 32);
            this.HideShowListButton.Margin = new System.Windows.Forms.Padding(2);
            this.HideShowListButton.Name = "HideShowListButton";
            this.HideShowListButton.Size = new System.Drawing.Size(99, 28);
            this.HideShowListButton.TabIndex = 12;
            this.HideShowListButton.Text = "Hide Image List";
            this.toolTip1.SetToolTip(this.HideShowListButton, "Show All image in the specified directory\r\nNote: all images in the ListBox will b" +
        "e removed");
            this.HideShowListButton.UseVisualStyleBackColor = true;
            this.HideShowListButton.Click += new System.EventHandler(this.HideShowListButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NextButton.Image = ((System.Drawing.Image)(resources.GetObject("NextButton.Image")));
            this.NextButton.Location = new System.Drawing.Point(487, 391);
            this.NextButton.Margin = new System.Windows.Forms.Padding(2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(58, 34);
            this.NextButton.TabIndex = 5;
            this.NextButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.NextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip1.SetToolTip(this.NextButton, "Next Picture");
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // RotateButton
            // 
            this.RotateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RotateButton.Image = ((System.Drawing.Image)(resources.GetObject("RotateButton.Image")));
            this.RotateButton.Location = new System.Drawing.Point(432, 392);
            this.RotateButton.Margin = new System.Windows.Forms.Padding(2);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(51, 34);
            this.RotateButton.TabIndex = 11;
            this.toolTip1.SetToolTip(this.RotateButton, "Rotate Current Image");
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("PreviousButton.Image")));
            this.PreviousButton.Location = new System.Drawing.Point(370, 391);
            this.PreviousButton.Margin = new System.Windows.Forms.Padding(2);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(58, 34);
            this.PreviousButton.TabIndex = 6;
            this.toolTip1.SetToolTip(this.PreviousButton, "Previous Picture");
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // ShowAllButton
            // 
            this.ShowAllButton.Image = global::imageViewer.Properties.Resources.ShowAll;
            this.ShowAllButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ShowAllButton.Location = new System.Drawing.Point(108, 31);
            this.ShowAllButton.Margin = new System.Windows.Forms.Padding(2);
            this.ShowAllButton.Name = "ShowAllButton";
            this.ShowAllButton.Size = new System.Drawing.Size(76, 28);
            this.ShowAllButton.TabIndex = 3;
            this.ShowAllButton.Text = "Show All";
            this.ShowAllButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.ShowAllButton, "Show All image in the specified directory\r\nNote: all images in the ListBox will b" +
        "e removed");
            this.ShowAllButton.UseVisualStyleBackColor = true;
            this.ShowAllButton.Click += new System.EventHandler(this.ShowAllButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Image = global::imageViewer.Properties.Resources.browse;
            this.BrowseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BrowseButton.Location = new System.Drawing.Point(707, 31);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(66, 28);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // SlideShowButton
            // 
            this.SlideShowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SlideShowButton.Image = global::imageViewer.Properties.Resources.slideshow;
            this.SlideShowButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SlideShowButton.Location = new System.Drawing.Point(777, 31);
            this.SlideShowButton.Margin = new System.Windows.Forms.Padding(2);
            this.SlideShowButton.Name = "SlideShowButton";
            this.SlideShowButton.Size = new System.Drawing.Size(89, 28);
            this.SlideShowButton.TabIndex = 7;
            this.SlideShowButton.Text = "SlideShow";
            this.SlideShowButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SlideShowButton.UseVisualStyleBackColor = true;
            this.SlideShowButton.Click += new System.EventHandler(this.SlideShowButton_Click);
            // 
            // IsDarkModeEnable
            // 
            this.IsDarkModeEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IsDarkModeEnable.AutoSize = true;
            this.IsDarkModeEnable.Location = new System.Drawing.Point(12, 401);
            this.IsDarkModeEnable.Name = "IsDarkModeEnable";
            this.IsDarkModeEnable.Size = new System.Drawing.Size(79, 17);
            this.IsDarkModeEnable.TabIndex = 13;
            this.IsDarkModeEnable.Text = "Dark Mode";
            this.IsDarkModeEnable.UseVisualStyleBackColor = true;
            this.IsDarkModeEnable.CheckedChanged += new System.EventHandler(this.IsDarkModeEnable_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(877, 472);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.IsDarkModeEnable);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.RotateButton);
            this.Controls.Add(this.HideShowListButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.path);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.SlideShowButton);
            this.Controls.Add(this.ShowAllButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Image Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ShowAllButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button SlideShowButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slideShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SingleMode_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MultiMode_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SlideShowMode_ContextMenuStrip;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button HideShowListButton;
        private System.Windows.Forms.ToolStripStatusLabel CurrentMode;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button RotateButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.ToolStripMenuItem apoutToolStripMenuItem;
        private System.Windows.Forms.CheckBox IsDarkModeEnable;
    }
}

