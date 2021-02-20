using System;
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

        // private Thread thread;
        private List<Panel> panels;
        List<PictureBox> pictureBoxes;

        System.Windows.Forms.Timer timer;
        SortedDictionary<string, string> data;
        Button StopSlidShowButton;
        bool IsSlideShow;

        int x, y;
        //  int panelWidthsNormal, panelsHeightNormal, pictureBoxesWidthNormal, pictureBoxesHeightNormal;
        Point point;
        public Form1()
        {

            InitializeComponent();
            IsSlideShow = false;
            panels = new List<Panel>();
            statusStrip1.Visible = false;
            pictureBoxes = new List<PictureBox>();
            data = new SortedDictionary<string, string>();

            //  thread = new Thread(UpdatePanel);
            StopSlidShowButton = new Button();
            this.Controls.Add(StopSlidShowButton);
            StopSlidShowButton.Visible = false;
            StopSlidShowButton.Text = "x";
            StopSlidShowButton.BackColor = Color.Red;
            StopSlidShowButton.Click += StopSlidShowButton_Click;
            StopSlidShowButton.Width = 30;
            StopSlidShowButton.Location = new Point(Screen.PrimaryScreen.Bounds.Width - StopSlidShowButton.Width - 15, Screen.PrimaryScreen.Bounds.Y);
            StopSlidShowButton.BringToFront();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;
            //  path.Text = Environment.SpecialFolder.MyPictures.ToString();
            path.Text = @"C:\Users\Mahmoud Hamdy\OneDrive - Assuit University - Staff\Pictures\Saved Pictures\Backgrounds";
            UpdatePanel();
        }
        private void Form1_Load1(object sender, EventArgs e)
        {
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 50;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            addPictureToPanel(getSelectedImages());
        }

        private void UpdatePanel()
        {
            try
            {
                path.Text = path.Text.Trim();
                toolStripStatusLabel2.Text = path.Text;
                listBox1.Items.Clear();
                if (Directory.Exists(path.Text))
                {
                    mainPanel.Controls.Clear();
                    List<string> images = new List<string>();
                    string[] s = Directory.GetFiles(path.Text);
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (s[i].Contains(".jpg") || s[i].Contains(".jpeg") || s[i].Contains(".png"))
                        {
                            listBox1.Items.Add(s[i].Substring(s[i].LastIndexOf('\\') + 1));
                            images.Add(s[i]);
                        }
                    }
                    // thread.Start();
                    addPictureToPanel(images);
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
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public List<string> getSelectedImages()
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
        public void addPictureToPanel(List<string> s)
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

               // Image img = Image.FromFile(s[0]);
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
            int cnt = 6;
            for (int i = 0, top = 5, left = 5; i < s.Count; i++)
            {
                panels.Add(new Panel());
                pictureBoxes.Add(new PictureBox());

                //   Image img = Image.FromFile(s[i]);
                data[i + ""] = s[i];
                pictureBoxes[i] = new PictureBox()
                {
                    Name = i + "",
                    Width = 325,
                    //Width = img.Width / cnt,
                    Height = 200,
                    //Height = img.Height / cnt,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Left = 2,
                    Top = 2,
                    BackColor = mainPanel.BackColor,
                };
                //  pictureBoxes[i].Image = new Bitmap(s[i]);
                pictureBoxes[i].Load(s[i]);
                pictureBoxes[i].MouseHover += Form1_MouseHover;
                pictureBoxes[i].MouseLeave += Form1_MouseLeave;
                pictureBoxes[i].MouseClick += Form1_MouseClick;

                panels[i] = new Panel()
                {
                    Width = 329,
                    Height = 204,
                    //    Width = (img.Width / cnt) + 4,
                    //   Height = (img.Height / cnt) + 4,
                    Left = left,
                    Top = top
                };
                panels[i].Controls.Add(pictureBoxes[i]);
                left += pictureBoxes[i].Width + 5;
                if ((i + 1) % 4 == 0)
                {
                    int w = 200;
                    //    for (int k = 0; k <= i; k++)
                    //      w = Math.Max(w, pictureBoxes[k].Height);
                    top += w + 5;
                    left = 5;
                    int maxHeight = 0;

                    for (int k = i - 3; k <= i; k++)
                        maxHeight = Math.Max(maxHeight, pictureBoxes[k].Height);

                    for (int k = i - 3; k <= i; k++)
                    {
                        int borders = maxHeight - pictureBoxes[k].Height;
                        borders /= 2;
                        pictureBoxes[k].Top = borders;
                        //pictureBoxes[k].botom = borders;
                    }
                }


                // Add a tooltip.
                FileInfo file_info = new FileInfo(s[i]);
                var units = new[] { "B", "KB", "MB", "GB", "TB" };
                var index = 0;
                long size = file_info.Length;
                while (size > 1024)
                {
                    size /= 1024;
                    index++;
                }
                string sz = string.Format("{0} {1}", size, units[index]);

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


                mainPanel.Controls.Add(panels[i]);
            }
            //}
            /*catch (Exception ex)
            {
                ShowError(ex.Message);
            }*/
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
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
        private void Form1_MouseHover(object sender, EventArgs e)
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
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            PictureBox p = sender as PictureBox;
            List<string> images = new List<string>();
            string fullPath = data[p.Name];
            images.Add(fullPath);
            addPictureToPanel(images);
            /*}
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }*/
        }
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
            toolStripProgressBar1.Value = ((idx) * 100 / listBox1.Items.Count) % 100;
            /*}
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }*/
        }
        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            addPictureToPanel(getSelectedImages());
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you want to exit..?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
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
        private void NextButton_Click(object sender, EventArgs e)
        {
            NextPicture();

        }
        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                ShowAllButton.Enabled = false;

                //thread.Start();
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
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    path.Text = folderBrowserDialog.SelectedPath;
                    UpdatePanel();
                    //    thread.Start();
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
        private void RotateButton_Click(object sender, EventArgs e)
        {
            //  for (int i = 0; i < pictureBoxes.Count; i++)
            //{
            pictureBoxes[0].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            //}
            this.Refresh();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            NextPicture();
            // progressBar1.PerformStep();
        }

        //SlideShowSection
        private void StopSlidShowButton_Click(object sender, EventArgs e)
        {
            StopSlidShow();
        }
        private void SlideShowButton_Click(object sender, EventArgs e)
        {
            StartSlidShow();

        }

        private void StopSlidShow()
        {
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
            SlideShowButton.Visible = true;

            path.Visible = true;

            StopSlidShowButton.Visible = false;
        }
        private void StartSlidShow()
        {
            IsSlideShow = true;
            listBox1.ClearSelected();
            listBox1.SelectedIndex = 0;
            statusStrip2.Visible = false;
            statusStrip1.Visible = true;
            StopSlidShowButton.Visible = false;
            x = mainPanel.Width;
            y = mainPanel.Height;
            //   mainPanel.Dock = DockStyle.Fill;
            point = mainPanel.Location;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.WindowState = FormWindowState.Maximized;
            timer.Start();
            listBox1.Visible = false;
            ShowAllButton.Visible = false;
            BrowseButton.Visible = false;
            NextButton.Visible = false;
            PreviousButton.Visible = false;
            SlideShowButton.Visible = false;
            StopSlidShowButton.Visible = true;
            toolStripProgressBar1.Value = 0;
            // progressBar1.Step = (100 + listBox1.Items.Count - 1) / listBox1.Items.Count;
            path.Visible = false;


        }
    }
}
