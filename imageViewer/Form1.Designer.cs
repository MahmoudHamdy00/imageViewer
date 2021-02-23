
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
            this.path = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ShowAllButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.SlideShowButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slideShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SingleMode_ContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiMode_ContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.SlideShowMode_ContextMenuStrip = new System.Windows.Forms.ToolStripMenuItem();
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
            this.path.Location = new System.Drawing.Point(175, 34);
            this.path.Margin = new System.Windows.Forms.Padding(2);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(395, 20);
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
            this.mainPanel.Location = new System.Drawing.Point(175, 63);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(2);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(560, 317);
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
            this.listBox1.Size = new System.Drawing.Size(170, 324);
            this.listBox1.TabIndex = 2;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseClick);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // ShowAllButton
            // 
            this.ShowAllButton.Location = new System.Drawing.Point(2, 34);
            this.ShowAllButton.Margin = new System.Windows.Forms.Padding(2);
            this.ShowAllButton.Name = "ShowAllButton";
            this.ShowAllButton.Size = new System.Drawing.Size(169, 19);
            this.ShowAllButton.TabIndex = 3;
            this.ShowAllButton.Text = "Show All";
            this.ShowAllButton.UseVisualStyleBackColor = true;
            this.ShowAllButton.Click += new System.EventHandler(this.ShowAllButton_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.Location = new System.Drawing.Point(574, 35);
            this.BrowseButton.Margin = new System.Windows.Forms.Padding(2);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(79, 19);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NextButton.Location = new System.Drawing.Point(462, 382);
            this.NextButton.Margin = new System.Windows.Forms.Padding(2);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(58, 19);
            this.NextButton.TabIndex = 5;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PreviousButton.Location = new System.Drawing.Point(345, 382);
            this.PreviousButton.Margin = new System.Windows.Forms.Padding(2);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(58, 19);
            this.PreviousButton.TabIndex = 6;
            this.PreviousButton.Text = "Previous";
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // SlideShowButton
            // 
            this.SlideShowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SlideShowButton.Location = new System.Drawing.Point(657, 35);
            this.SlideShowButton.Margin = new System.Windows.Forms.Padding(2);
            this.SlideShowButton.Name = "SlideShowButton";
            this.SlideShowButton.Size = new System.Drawing.Size(76, 19);
            this.SlideShowButton.TabIndex = 7;
            this.SlideShowButton.Text = "SlideShow";
            this.SlideShowButton.UseVisualStyleBackColor = true;
            this.SlideShowButton.Click += new System.EventHandler(this.SlideShowButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 404);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(744, 22);
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
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(0, 382);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(744, 22);
            this.statusStrip2.TabIndex = 9;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.modesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(744, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem1});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(93, 22);
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
            // RotateButton
            // 
            this.RotateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RotateButton.Location = new System.Drawing.Point(407, 382);
            this.RotateButton.Margin = new System.Windows.Forms.Padding(2);
            this.RotateButton.Name = "RotateButton";
            this.RotateButton.Size = new System.Drawing.Size(51, 19);
            this.RotateButton.TabIndex = 11;
            this.RotateButton.Text = "Rotate";
            this.RotateButton.UseVisualStyleBackColor = true;
            this.RotateButton.Click += new System.EventHandler(this.RotateButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SingleMode_ContextMenuStrip,
            this.MultiMode_ContextMenuStrip,
            this.SlideShowMode_ContextMenuStrip});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 92);
            // 
            // SingleMode_ContextMenuStrip
            // 
            this.SingleMode_ContextMenuStrip.Name = "SingleMode_ContextMenuStrip";
            this.SingleMode_ContextMenuStrip.Size = new System.Drawing.Size(180, 22);
            this.SingleMode_ContextMenuStrip.Text = "Single Mode";
            this.SingleMode_ContextMenuStrip.Click += new System.EventHandler(this.SingleMode_Click);
            // 
            // MultiMode_ContextMenuStrip
            // 
            this.MultiMode_ContextMenuStrip.Name = "MultiMode_ContextMenuStrip";
            this.MultiMode_ContextMenuStrip.Size = new System.Drawing.Size(180, 22);
            this.MultiMode_ContextMenuStrip.Text = "Multi Mode";
            this.MultiMode_ContextMenuStrip.Click += new System.EventHandler(this.MultiMode_Click);
            // 
            // SlideShowMode_ContextMenuStrip
            // 
            this.SlideShowMode_ContextMenuStrip.Name = "SlideShowMode_ContextMenuStrip";
            this.SlideShowMode_ContextMenuStrip.Size = new System.Drawing.Size(180, 22);
            this.SlideShowMode_ContextMenuStrip.Text = "SlideShow";
            this.SlideShowMode_ContextMenuStrip.Click += new System.EventHandler(this.SlideShowButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(744, 426);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.RotateButton);
            this.Controls.Add(this.NextButton);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Image Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button SlideShowButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.Button RotateButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem modesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slideShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SingleMode_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MultiMode_ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem SlideShowMode_ContextMenuStrip;
    }
}

