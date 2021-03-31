using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace imageViewer
{
    public partial class Form1 : Form
    {
        private readonly string imageExtentions = "*.jpg;*.png;*.jpeg";  //extinsions to be shown
        private readonly string initialFolderToBrowse = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        private string currentPath;

        private readonly List<Panel> panels;                 //to store the selected images 
        private readonly List<PictureBox> pictureBoxes;              //to preview the selected images

        private readonly System.Windows.Forms.Timer timer;           //to be used in slideshow mode
        private readonly SortedDictionary<string, string> data;      //to link the path of the pic with the its index in the listbox
        private readonly Button StopSlidShowButton;                  //to exit slideshow mode
        private bool IsSlideShow;                           //to know which elements to be shown  e.g rotate button  doesn't need to be shown in slideshow mod
        int panelWidths, panelsHeight;


        public Form1()
        {
            InitializeComponent();
            panels = new List<Panel>();
            pictureBoxes = new List<PictureBox>();
            data = new SortedDictionary<string, string>();
            StopSlidShowButton = new Button();
            timer = new System.Windows.Forms.Timer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set the width and the height of the form window to fit the screan
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 50;
            this.StartPosition = FormStartPosition.CenterScreen;
            mainPanel.Location = new Point(path.Location.X, path.Location.Y + path.Height + 10);
            mainPanel.Width = this.Width - listBox1.Width - 50;
            mainPanel.Height = NextButton.Location.Y - (path.Location.Y + path.Height) - 20;
            listBox1.Height = NextButton.Location.Y - (path.Location.Y + path.Height) - 20;
            NavigationButtonsLocations();


            IsSlideShow = false;
            toolStripProgressBar1.Visible = false;                   //to show the progress and the name of the pic during slideshow mode


            //set StopSlidShowButton attributes
            this.Controls.Add(StopSlidShowButton);
            StopSlidShowButton.Visible = false;
            StopSlidShowButton.Text = "❌";
            StopSlidShowButton.BackColor = Color.Red;
            StopSlidShowButton.Click += StopSlidShowButton_Click;
            StopSlidShowButton.Width = 30;
            StopSlidShowButton.Location = new Point(Screen.PrimaryScreen.Bounds.Width - StopSlidShowButton.Width - 15, Screen.PrimaryScreen.Bounds.Y);
            StopSlidShowButton.BringToFront();

            //slideshow mode timer
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;          //change image every 1 sec

            currentPath = initialFolderToBrowse;
            path.Text = initialFolderToBrowse;
            UpdatePanel();                          //preview the images in the picture folder on startup              


        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool ShowWarning(string message)
        {
            return MessageBox.Show(message, "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        /// <summary>
        /// Show All images in the current folder
        /// </summary>
  
        private void ShowAllButton_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < pictureBoxes.Count; i++)
                {

                    pictureBoxes[i].Dispose();

                }
                // return;

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
        /// <summary>
        /// to choose pics to be viwed
        /// </summary>
        /// <remarks>
        /// it will remove the current viewd pics
        /// </remarks>
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
                    currentPath = path.Text;
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
                currentPath = path.Text;
                toolStripStatusLabel1.Text = path.Text; //set the location in the status strip
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
            try
            {
                List<string> images = new List<string>();
                foreach (var image in listBox1.SelectedItems)
                {
                    var selectedImage = image.ToString();
                    if (!String.IsNullOrEmpty(selectedImage) && !String.IsNullOrEmpty(path.Text))
                    {
                        string fullPath = Path.Combine(path.Text, selectedImage);
                        images.Add(fullPath);
                    }
                }
                return images;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                return new List<string>();
            }
        }
      
        private void AddPictureToPanel(List<string> s)
        {
            try
            {


                data.Clear();
                mainPanel.Controls.Clear();
                pictureBoxes.Clear();
                panels.Clear();
                if (s.Count == 1)
                {
                  
                    panels.Add(new Panel());
                    pictureBoxes.Add(new PictureBox());

                    data[0 + ""] = s[0];
                    pictureBoxes[0] = new PictureBox()
                    {
                        Name = 0 + "",
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = IsDarkModeEnable.Checked ? Color.Black : Color.LightGray
                    };
                    pictureBoxes[0].Load(s[0]);

                    panels[0].Dock = DockStyle.Fill;
                    pictureBoxes[0].Dock = DockStyle.Fill;
                    panels[0].Controls.Add(pictureBoxes[0]);
                    mainPanel.Controls.Add(panels[0]);

                    if (s[0].LastIndexOf('\\') != -1)
                        toolStripStatusLabel1.Text = s[0].Substring(s[0].LastIndexOf('\\') + 1);
                    else
                        toolStripStatusLabel1.Text = s[0];

                    mainPanel.BackColor = this.BackColor;
                    return;
                }
               
                toolStripStatusLabel1.Text = path.Text;
                mainPanel.BackColor = IsDarkModeEnable.Checked ? Color.Black : Color.Silver;
                int imageWidth = mainPanel.Width / 4 - 10, imageHeight = imageWidth * 3 / 4;
                panelWidths = imageWidth;
                panelsHeight = imageHeight;
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
                        BackColor = IsDarkModeEnable.Checked ? Color.Black
                        : mainPanel.BackColor,
                    };
                    // pictureBoxes[i].Image = CompressImage(s[i], 100);
                    pictureBoxes[i].Image = new Bitmap(s[i]);
                    //var thumbnail = new Thumbnail();
                    // pictureBoxes[i].Load(s[i]);

                    pictureBoxes[i].MouseHover += PictureBoxes_MouseHover;
                    pictureBoxes[i].MouseLeave += PictureBoxes_MouseLeave;
                    pictureBoxes[i].MouseClick += PictureBoxes_MouseClick;

                    panels[i] = new Panel()
                    {
                        Width = imageWidth + 4,
                        Height = imageHeight + 4,
                        Left = left,
                        Top = top,
                        BackColor = IsDarkModeEnable.Checked ? Color.Black : mainPanel.BackColor,

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
                    while (size >= 1024)
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
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
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
                //not working
                /*
                panels[idx].Width = panelWidths;
                panels[idx].Height = panelsHeight;
                pictureBoxes[idx].Width = panelWidths + 4;
                pictureBoxes[idx].Height = panelsHeight + 4;*/
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
                panels[idx].BackColor = IsDarkModeEnable.Checked ? Color.White : Color.Black;
                //not working
                /*      panels[idx].BringToFront();
                      pictureBoxes[idx].BringToFront();
                     panels[idx].Width = panelWidths + 10;
                      panels[idx].Height = panelsHeight + 10;
                      pictureBoxes[idx].Width = panelWidths + 4 + 10;
                      pictureBoxes[idx].Height = panelsHeight + 4 + 10;*/
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }

        }
        private void PictureBoxes_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                PictureBox p = sender as PictureBox;
                List<string> images = new List<string>();
                string fullPath = data[p.Name];
                images.Add(fullPath);
                AddPictureToPanel(images);
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
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
            try
            {
                int idx = listBox1.SelectedIndex;
                idx++;
                if (IsSlideShow && idx == listBox1.Items.Count)
                {
                    if (LoopImages.Checked)
                    {
                        toolStripProgressBar1.Value = 0;
                        listBox1.SelectedIndex = 0;
                    }
                    else
                        StopSlidShowButton.PerformClick();
                }
                if (idx == listBox1.Items.Count)
                {
                    if (LoopImages.Checked)
                        idx = 0;
                    else
                        return;
                }
                listBox1.ClearSelected();
                listBox1.SelectedIndex = idx;

                toolStripStatusLabel1.Text = listBox1.Items[idx].ToString();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
        private void PreviousButton_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = listBox1.SelectedIndex;
                idx--;
                idx = Math.Max(idx, -1);
                if (idx == -1)
                {
                    if (LoopImages.Checked)
                        idx = listBox1.Items.Count - 1;
                    else
                        return;
                }

                listBox1.ClearSelected();
                listBox1.SelectedIndex = idx;
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void RotateButton_Click(object sender, EventArgs e)
        {
            pictureBoxes[0].Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.Refresh();
        }

        //SlideShowSection

        private void SlideShowButton_Click(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            menuStrip1.Visible = false;
            numOfSeconds.Visible = true;
            secSlideShowLabel.Visible = true;
            LoopImages.Visible = true;

            IsSlideShow = true;
            listBox1.ClearSelected();
            listBox1.SelectedIndex = 0;
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.WindowState = FormWindowState.Maximized;

            modesToolStripMenuItem.Visible = false;
            listBox1.Visible = false;
            ShowAllButton.Visible = false;
            HideShowListButton.Visible = false;
            BrowseButton.Visible = false;
            NextButton.Visible = false;
            PreviousButton.Visible = false;
            RotateButton.Visible = false;
            SlideShowButton.Visible = false;

            statusStrip1.Visible = true;
            toolStripProgressBar1.Visible = true;
            CurrentMode.Visible = false;
            StopSlidShowButton.Visible = true;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Step = (100 / listBox1.Items.Count);
            toolStripProgressBar1.PerformStep();
            path.Visible = false;

            timer.Start();

        }
        private void StopSlidShowButton_Click(object sender, EventArgs e)
        {
            IsSlideShow = false;
            menuStrip1.Visible = true;

            numOfSeconds.Visible = false;
            secSlideShowLabel.Visible = false;
            LoopImages.Visible = false;
            timer.Stop();
            modesToolStripMenuItem.Visible = true;
            CurrentMode.Visible = true;
            toolStripProgressBar1.Visible = false;
            mainPanel.Dock = DockStyle.None;
            HideShowListButton_Click(this, new EventArgs());
            listBox1.Visible = true;
            ShowAllButton.Visible = true;
            HideShowListButton.Visible = true;
            BrowseButton.Visible = true;
            if (CurrentMode.Text == "Single Mode")
            {
                NextButton.Visible = true;
                PreviousButton.Visible = true;
                RotateButton.Visible = true;
            }
            SlideShowButton.Visible = true;

            path.Visible = true;

            StopSlidShowButton.Visible = false;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            NextPicture();
            toolStripProgressBar1.PerformStep();
        }

        private void numOfSeconds_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = Convert.ToInt32(numOfSeconds.Value);
        }
        private void SingleMode_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible)
                HideShowListButton.PerformClick();
            LoopImages.Visible = true;
            RotateButton.Visible = true;
            NextButton.Visible = true;
            PreviousButton.Visible = true;

            ShowAllButton.Enabled = false;
            listBox1.SelectionMode = SelectionMode.One;
            if (listBox1.SelectedIndex == -1)
                listBox1.SelectedIndex = 0;
            if (pictureBoxes.Count != 1)
            {
                listBox1.SelectedIndex = 0;
            }
            CurrentMode.Text = "Single Mode";
        }

        private void MultiMode_Click(object sender, EventArgs e)
        {
            LoopImages.Visible = false;
            RotateButton.Visible = false;
            NextButton.Visible = false;
            PreviousButton.Visible = false;

            if (!listBox1.Visible)
                HideShowListButton.PerformClick();
            ShowAllButton.Enabled = true;
            listBox1.SelectionMode = SelectionMode.MultiExtended;
            CurrentMode.Text = "Multi Mode";
            if (pictureBoxes.Count == 1)
                ShowAllButton.PerformClick();
        }

        private void HideShowListButton_Click(object sender, EventArgs e)
        {
            listBox1.Visible = !listBox1.Visible;
            if (listBox1.Visible)
            {
                HideShowListButton.Text = "Hide Image List";
                mainPanel.Location = new Point(path.Location.X, path.Location.Y + path.Height + 10);
                mainPanel.Width = this.Width - listBox1.Width - 50;

            }
            else
            {
                HideShowListButton.Text = "Show Image List";
                mainPanel.Location = new Point(HideShowListButton.Location.X, HideShowListButton.Location.Y + HideShowListButton.Height + 10);
                mainPanel.Width = this.Width - 30;

            }
            mainPanel.Height = NextButton.Location.Y - (path.Location.Y + path.Height) - 20;
            listBox1.Height = NextButton.Location.Y - (path.Location.Y + path.Height) - 20;
            ReloadContent();
            NavigationButtonsLocations();
        }
        private void NavigationButtonsLocations()
        {
            int width = this.Width - NextButton.Width - PreviousButton.Width - RotateButton.Width;
            if (listBox1.Visible)
            {
                width += listBox1.Width;
            }
            width >>= 1;
            PreviousButton.Location = new Point(width, PreviousButton.Location.Y);
            width += PreviousButton.Width + 5;
            RotateButton.Location = new Point(width, PreviousButton.Location.Y);
            width += RotateButton.Width + 5;
            NextButton.Location = new Point(width, PreviousButton.Location.Y);
        }
        private void apoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm(IsDarkModeEnable.Checked);
            infoForm.Visible = true;

        }
        private void IsDarkModeEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (IsDarkModeEnable.Checked)
            {
                //not working
                /*foreach (var cur in this.Controls)
                {
                    if (cur.GetType().ToString().Equals("System.Windows.Forms.Button"))
                    {
                        ((Button)(cur)).BackColor = Color.Black;
                    }

                }*/
                this.BackColor = Color.Black;
                statusStrip1.BackColor = Color.Black;
                listBox1.BackColor = Color.Black;
                path.BackColor = Color.Black;
                mainPanel.BackColor = Color.Black;
                menuStrip1.BackColor = Color.Black;
                ShowAllButton.BackColor = Color.DarkGray;
                BrowseButton.BackColor = Color.DarkGray;
                SlideShowButton.BackColor = Color.DarkGray;
                HideShowListButton.BackColor = Color.DarkGray;
                NextButton.BackColor = Color.DarkGray;
                PreviousButton.BackColor = Color.DarkGray;
                RotateButton.BackColor = Color.DarkGray;
                numOfSeconds.BackColor = Color.Black;


                this.ForeColor = Color.White;
                statusStrip1.ForeColor = Color.White;
                listBox1.ForeColor = Color.White;
                numOfSeconds.ForeColor = Color.White;

                path.ForeColor = Color.White;
                mainPanel.ForeColor = Color.DarkGray;
                menuStrip1.ForeColor = Color.White;
                ShowAllButton.ForeColor = Color.Black;
                BrowseButton.ForeColor = Color.Black;
                SlideShowButton.ForeColor = Color.Black;
                HideShowListButton.ForeColor = Color.Black;
            }
            else
            {
                this.BackColor = Color.Gainsboro;
                statusStrip1.BackColor = Color.White;
                listBox1.BackColor = Color.White;
                path.BackColor = Color.White;
                mainPanel.BackColor = Color.Silver;
                menuStrip1.BackColor = Color.White;
                ShowAllButton.BackColor = Color.Gainsboro;
                BrowseButton.BackColor = Color.Gainsboro;
                SlideShowButton.BackColor = Color.Gainsboro;
                HideShowListButton.BackColor = Color.Gainsboro;
                NextButton.BackColor = Color.Gainsboro;
                PreviousButton.BackColor = Color.Gainsboro;
                RotateButton.BackColor = Color.Gainsboro;
                numOfSeconds.BackColor = Color.White;

                this.ForeColor = Color.Black;
                statusStrip1.ForeColor = Color.Black;
                listBox1.ForeColor = Color.Black;
                path.ForeColor = Color.Black;
                mainPanel.ForeColor = Color.DarkGray;
                menuStrip1.ForeColor = Color.Black;
                numOfSeconds.ForeColor = Color.Black;
            }

            ReloadContent();
        }
        private void ReloadContent()
        {
            if (listBox1.SelectedItems.Count == 0)
            {
                List<string> tmp = new List<string>();
                foreach (string item in listBox1.Items)
                {
                    tmp.Add(Path.Combine(path.Text, item));
                }
                AddPictureToPanel(tmp);
                return;
            }
            ListBox1_SelectedIndexChanged(this, new EventArgs());
        }
        private void path_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(path.Text))
            {
                errorProvider1.SetError(path, "The Path Isn't Valid");
            }
            else
            {
                errorProvider1.Clear();
                if (currentPath == path.Text || path.Text == "")
                    return;
                if (ShowWarning("Do you want to change current dirictory?\nif yes it will remove all imeges in the list box"))
                {
                    currentPath = path.Text;
                    ShowAllButton.PerformClick();
                }
                else
                {
                    path.Text = currentPath;
                }
            }
        }
        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you want to exit..?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }
    }
}
