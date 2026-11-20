namespace MyThreadForm
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
        }

        private void btnStartDownload_Click(object sender, EventArgs e)
        {
            int count = int.Parse(txtCount.Text);
            lCountDownloads.Text = $"0/{count}";
            pbDownloads.Maximum = count;
            pbDownloads.Value = 0;
            //Це основний потік
            Thread myThread = new Thread(RunDownloadThread);
            myThread.Start(count);
        }

        private void RunDownloadThread(object count)
        {
            //Інший потік, який буде завантажувати фото
            int countInt = (int)count; //Кількість елементів для завантаження
            for (int i = 0; i < countInt; i++)
            {
                this.Invoke(new Action(() =>
                {
                    lCountDownloads.Text = $"{i + 1}/{count}";
                    pbDownloads.Value = i + 1;
                }));
                Thread.Sleep(1000);
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog myDialog = new FolderBrowserDialog();
            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                string folder = myDialog.SelectedPath;
                txtDirPath.Text = folder;
            }
        }
    }
}
