﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imageViewer
{
    public partial class Form1 : Form
    {
        private readonly string imageExtentions = "*.jpg;*.png;*.jpeg";  //extinsions to be shown
        private readonly string initialFolderToBrowse = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        private readonly List<Panel> panels;                 //to store the selected images 
        private readonly List<PictureBox> pictureBoxes;              //to preview the selected images

        private readonly System.Windows.Forms.Timer timer;           //to be used in slideshow mode
        private readonly SortedDictionary<string, string> data;      //to link the path of the pic with the its index in the listbox
        private readonly Button StopSlidShowButton;                  //to exit slideshow mode
        private bool IsSlideShow;                           //to know which elements to be shown  e.g rotate button  doesn't need to be shown in slideshow mod

        private int x, y;                                   //to store the width and the highet of the main panel to reset it after slideshow ends
        private Point point;                                //to store the location of the main panel to relocate it after slideshow ends
        public Form1()
        {
            InitializeComponent();
            //set the width and the height of the form window to fit the screan
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 50;
            this.StartPosition = FormStartPosition.CenterScreen;

            //Initialization 
            panels = new List<Panel>();
            pictureBoxes = new List<PictureBox>();
            data = new SortedDictionary<string, string>();

            IsSlideShow = false;
            statusStrip1.Visible = false;                   //to show the progress and the name of the pic during slideshow mode


            //set StopSlidShowButton attributes
            StopSlidShowButton = new Button();
            this.Controls.Add(StopSlidShowButton);
            StopSlidShowButton.Visible = false;
            StopSlidShowButton.Text = "x";
            StopSlidShowButton.BackColor = Color.Red;
            StopSlidShowButton.Click += StopSlidShowButton_Click;
            StopSlidShowButton.Width = 30;
            StopSlidShowButton.Location = new Point(Screen.PrimaryScreen.Bounds.Width - StopSlidShowButton.Width - 15, Screen.PrimaryScreen.Bounds.Y);
            StopSlidShowButton.BringToFront();

            //slideshow mode timer
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;          //change image every 1 sec

            path.Text = initialFolderToBrowse;
            ToolTip showAllToolTip = new ToolTip();
            showAllToolTip.SetToolTip(ShowAllButton, "Show All image in the specified directory\nNote: all images in the ListBox will be removed");

            UpdatePanel();                          //preview the images in the picture folder on startup              
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowAllButton.Enabled = false;
                UpdatePanel();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                ShowAllButton.Enabled = true;
            }
        }
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                BrowseButton.Enabled = false;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = $"Image Files({imageExtentions})|{imageExtentions}";
                openFileDialog.Title = "Select Images To preview";
                openFileDialog.InitialDirectory = initialFolderToBrowse;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path.Text = Directory.GetParent(openFileDialog.FileName).ToString();
                    //add images to the listbox
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(openFileDialog.SafeFileNames);

                    List<string> selectedImages = new List<string>();
                    selectedImages.AddRange(openFileDialog.FileNames);
                    AddPictureToPanel(selectedImages);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                BrowseButton.Enabled = true;
            }
        }
        private void UpdatePanel()
        {
            try
            {
                path.Text = path.Text.Trim();   //remove extra spaces at starting and ending
                toolStripStatusLabel2.Text = path.Text; //set the location in the status strip
                listBox1.Items.Clear();                    //remove privios images
                if (Directory.Exists(path.Text))
                {
                    mainPanel.Controls.Clear();             //remove privious images
                    List<string> images = new List<string>();

                    string[] searchPatterns = imageExtentions.Split(';');
                    List<string> files = new List<string>();
                    foreach (string sp in searchPatterns)
                    {
                        files.AddRange(Directory.GetFiles(path.Text, sp, SearchOption.TopDirectoryOnly));
                    }
                    foreach (string curFile in files)
                    {
                        listBox1.Items.Add(curFile.Substring(curFile.LastIndexOf('\\') + 1));
                        images.Add(curFile);
                    }
                    AddPictureToPanel(images);
                }
                else
                {
                    ShowError("The directory you entered does not exist");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddPictureToPanel(GetSelectedImages());
        }
        private List<string> GetSelectedImages()
        {
            List<string> images = new List<string>();
            try
            {
                foreach (var image in listBox1.SelectedItems)
                {
                    var selectedImage = image.ToString();
                    if (!String.IsNullOrEmpty(selectedImage) && !String.IsNullOrEmpty(path.Text))
                    {
                        string fullPath = Path.Combine(path.Text, selectedImage);
                        images.Add(fullPath);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            return images;
        }

        private void AddPictureToPanel(List<string> s)
        {
            //    try
            //  {
            data.Clear();
            mainPanel.Controls.Clear();
            pictureBoxes.Clear();
            panels.Clear();
            if (s.Count() == 1)
            {
                if (!IsSlideShow)
                {
                    RotateButton.Visible = true;
                    NextButton.Visible = true;
                    PreviousButton.Visible = true;
                }
                panels.Add(new Panel());
                pictureBoxes.Add(new PictureBox());

                data[0 + ""] = s[0];
                pictureBoxes[0] = new PictureBox()
                {
                    Name = 0 + "",
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.White
                };
                pictureBoxes[0].Load(s[0]);

                panels[0].Dock = DockStyle.Fill;
                pictureBoxes[0].Dock = DockStyle.Fill;
                panels[0].Controls.Add(pictureBoxes[0]);
                mainPanel.Controls.Add(panels[0]);
                toolStripStatusLabel2.Text = s[0];
                return;
            }
            RotateButton.Visible = false;
            NextButton.Visible = false;
            PreviousButton.Visible = false;
            toolStripStatusLabel2.Text = path.Text;

            int imageWidth = 325, imageHeight = 200;
            for (int i = 0, top = 5, left = 5; i < s.Count; i++)
            {
                panels.Add(new Panel());
                pictureBoxes.Add(new PictureBox());

                data[i + ""] = s[i];
                pictureBoxes[i] = new PictureBox()
                {
                    Name = i + "",
                    Width = imageWidth,
                    Height = imageHeight,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Left = 2,
                    Top = 2,
                    BackColor = mainPanel.BackColor,
                };
                //  pictureBoxes[i].Image = new Bitmap(s[i]);
                pictureBoxes[i].Load(s[i]);

                pictureBoxes[i].MouseHover += PictureBoxes_MouseHover;
                pictureBoxes[i].MouseLeave += PictureBoxes_MouseLeave;
                pictureBoxes[i].MouseClick += PictureBoxes_MouseClick;

                panels[i] = new Panel()
                {
                    Width = imageWidth + 4,
                    Height = imageHeight + 4,
                    Left = left,
                    Top = top
                };
                left += pictureBoxes[i].Width + 5;
                if ((i + 1) % 4 == 0)
                {
                    top += imageHeight + 5;
                    left = 5;
                }

                FileInfo file_info = new FileInfo(s[i]);

                //getSelectedImages the size of the file
                var units = new[] { "B", "KB", "MB", "GB", "TB" };
                var index = 0;
                long size = file_info.Length;
                while (size > 1024)
                {
                    size /= 1024;
                    index++;
                }
                string sz = $"{size} {units[index]}";

                // Add a tooltip.
                ToolTip tipPicture = new ToolTip();
                tipPicture.SetToolTip(
                    pictureBoxes[i],
                    file_info.Name +
                    "\nItem type: " + file_info.Extension.Substring(1).ToUpper() +
                    "\nDimensions: " + pictureBoxes[i].Image.Width + " x " + pictureBoxes[i].Image.Height +
                    "\nSize: " + sz +
                    "\nCreated: " + file_info.CreationTime.ToShortDateString()
                    );

                pictureBoxes[i].Tag = file_info;
                panels[i].Controls.Add(pictureBoxes[i]);
                mainPanel.Controls.Add(panels[i]);
            }
            //}
            /*catch (Exception ex)
            {
                ShowError(ex.Message);
            }*/
        }

        //events on the shown images
        private void PictureBoxes_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                PictureBox p = sender as PictureBox;
                int idx = Convert.ToInt32(p.Name);
                if (idx >= panels.Count)
                    return;
                panels[idx].BackColor = mainPanel.BackColor;
                /*   panels[idx].Width = panelWidthsNormal;
                   panels[idx].Height = panelsHeightNormal;
                   pictureBoxes[idx].Width = pictureBoxesWidthNormal;
                   pictureBoxes[idx].Height = pictureBoxesHeightNormal;*/
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        private void PictureBoxes_MouseHover(object sender, EventArgs e)
        {
            try
            {
                PictureBox p = sender as PictureBox;
                int idx = Convert.ToInt32(p.Name);
                if (idx >= panels.Count)
                    return;
                panels[idx].BackColor = Color.Black;
                /*   panels[idx].Width = panelWidthsNormal+10;
                   panels[idx].Height = panelsHeightNormal+10;
                   pictureBoxes[idx].Width = pictureBoxesWidthNormal+10;
                   pictureBoxes[idx].Height = pictureBoxesHeightNormal+10;*/
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

        }
        private void PictureBoxes_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            PictureBox p = sender as PictureBox;
            List<string> images = new List<string>();
            string fullPath = data[p.Name];
            images.Add(fullPath);
            AddPictureToPanel(images);
            /*}
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }*/
        }
        private void ListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            AddPictureToPanel(GetSelectedImages());
        }
        private void NextButton_Click(object sender, EventArgs e)
        {
            NextPicture();
        }
        //seperste the NextPicture because the nextbutton is hidden and can't use 'performclick'
        private void NextPicture()
        {
            //try
            //{
            int idx = listBox1.SelectedIndex;
            idx++;
            if (idx == listBox1.Items.Count)
            {
                StopSlidShowButton.PerformClick();
            }
            if (idx == listBox1.Items.Count)
                idx = 0;

            listBox1.ClearSelected();
            listBox1.SelectedIndex = idx;

            toolStripStatusLabel1.Text = listBox1.Items[idx].ToString();
            // toolStripProgressBar1.Value = ((idx+1) * 100 / listBox1.Items.Count);
            /*}
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }*/
        }
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            int idx = listBox1.SelectedIndex;
            idx--;
            idx = Math.Max(idx, -1);
            if (idx == -1)
                idx = listBox1.Items.Count - 1;

            listBox1.ClearSelected();
            listBox1.SelectedIndex = idx;
            /*}
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }*/
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            pictureBoxes[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.Refresh();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            NextPicture();
            toolStripProgressBar1.PerformStep();
        }

        //SlideShowSection
        private void SlideShowButton_Click(object sender, EventArgs e)
        {
            StartSlidShow();

        }
        private void StopSlidShowButton_Click(object sender, EventArgs e)
        {
            StopSlidShow();
        }
        private void StartSlidShow()
        {
            IsSlideShow = true;
            listBox1.ClearSelected();
            listBox1.SelectedIndex = 0;
            x = mainPanel.Width;
            y = mainPanel.Height;
            point = mainPanel.Location;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.WindowState = FormWindowState.Maximized;

            modesToolStripMenuItem.Visible = false;
            statusStrip2.Visible = false;
            listBox1.Visible = false;
            ShowAllButton.Visible = false;
            BrowseButton.Visible = false;
            NextButton.Visible = false;
            PreviousButton.Visible = false;
            RotateButton.Visible = false;
            SlideShowButton.Visible = false;

            statusStrip1.Visible = true;
            StopSlidShowButton.Visible = true;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Step = (100 / listBox1.Items.Count);
            toolStripProgressBar1.PerformStep();
            path.Visible = false;

            timer.Start();
        }
        private void StopSlidShow()
        {
            modesToolStripMenuItem.Visible = true;
            IsSlideShow = false;
            statusStrip2.Visible = true;
            statusStrip1.Visible = false;
            mainPanel.Dock = DockStyle.None;
            timer.Stop();
            mainPanel.Width = x;
            mainPanel.Height = y;
            mainPanel.Location = point;
            listBox1.Visible = true;
            ShowAllButton.Visible = true;
            BrowseButton.Visible = true;
            NextButton.Visible = true;
            PreviousButton.Visible = true;
            RotateButton.Visible = true;
            SlideShowButton.Visible = true;

            path.Visible = true;

            StopSlidShowButton.Visible = false;
        }

        private void SingleMode_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.One;
        }

        private void MultiMode_Click(object sender, EventArgs e)
        {
            listBox1.SelectionMode = SelectionMode.MultiExtended;
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you want to exit..?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
