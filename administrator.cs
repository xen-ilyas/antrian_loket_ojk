using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace antrian_loket
{
    public partial class administrator : Form
    {
        private string settingsFile = Path.Combine(Application.StartupPath, "settings.cfg");
        private AppSettings settings;

        public administrator()
        {
            InitializeComponent();
            LoadSettings();
        }

        public class AppSettings
        {
            public string VideoURL { get; set; }
        }

        void LoadSettings()
        {
            settings = new AppSettings();

            if (!File.Exists(settingsFile))
                return;

            try
            {
                var lines = File.ReadAllLines(settingsFile);

                foreach (var line in lines)
                {
                    if (line.StartsWith("VideoURL="))
                    {
                        settings.VideoURL = line.Substring("VideoURL=".Length).Trim();
                    }
                }
                txtURLVideo.Text = settings.VideoURL;
            }
            catch
            {
              
            }
        }

        void btnBrowseVideo_Click(object sender, EventArgs e)
        {
            openFileVideo.Filter = "Video Files|*.mp4;*.avi;*.mkv";
            if (openFileVideo.ShowDialog() == DialogResult.OK)
            {
                txtURLVideo.Text = openFileVideo.FileName;
            }
        }

        void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines =
                {
                    "VideoURL=" + txtURLVideo.Text
                };

                File.WriteAllLines(settingsFile, lines);
            }
            catch
            {
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
