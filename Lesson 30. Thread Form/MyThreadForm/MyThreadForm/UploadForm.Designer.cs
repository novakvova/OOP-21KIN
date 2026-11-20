namespace MyThreadForm
{
    partial class UploadForm
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
            label1 = new Label();
            label2 = new Label();
            txtUrl = new TextBox();
            label3 = new Label();
            txtCount = new TextBox();
            label4 = new Label();
            txtDirPath = new TextBox();
            btnSelectFolder = new Button();
            btnStartDownload = new Button();
            pbDownloads = new ProgressBar();
            lCountDownloads = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(434, 9);
            label1.Name = "label1";
            label1.Size = new Size(282, 48);
            label1.TabIndex = 0;
            label1.Text = "Загрузка файлів";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.FromArgb(0, 0, 192);
            label2.Location = new Point(27, 88);
            label2.Name = "label2";
            label2.Size = new Size(139, 32);
            label2.TabIndex = 1;
            label2.Text = "Url до фото";
            // 
            // txtUrl
            // 
            txtUrl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtUrl.Location = new Point(27, 134);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(695, 39);
            txtUrl.TabIndex = 2;
            txtUrl.Text = "https://i.pravatar.cc/1200";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.FromArgb(0, 0, 192);
            label3.Location = new Point(749, 88);
            label3.Name = "label3";
            label3.Size = new Size(171, 32);
            label3.TabIndex = 1;
            label3.Text = "Кількість фото";
            // 
            // txtCount
            // 
            txtCount.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtCount.Location = new Point(753, 132);
            txtCount.Name = "txtCount";
            txtCount.Size = new Size(312, 39);
            txtCount.TabIndex = 3;
            txtCount.Text = "10";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.FromArgb(0, 0, 192);
            label4.Location = new Point(27, 196);
            label4.Name = "label4";
            label4.Size = new Size(330, 32);
            label4.TabIndex = 1;
            label4.Text = "Папка для збереження фото";
            // 
            // txtDirPath
            // 
            txtDirPath.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtDirPath.Location = new Point(27, 242);
            txtDirPath.Name = "txtDirPath";
            txtDirPath.Size = new Size(903, 39);
            txtDirPath.TabIndex = 2;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new Point(955, 231);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(110, 50);
            btnSelectFolder.TabIndex = 4;
            btnSelectFolder.Text = "...";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // btnStartDownload
            // 
            btnStartDownload.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnStartDownload.Location = new Point(229, 336);
            btnStartDownload.Name = "btnStartDownload";
            btnStartDownload.Size = new Size(289, 57);
            btnStartDownload.TabIndex = 5;
            btnStartDownload.Text = "Почати завантаження";
            btnStartDownload.UseVisualStyleBackColor = true;
            btnStartDownload.Click += btnStartDownload_Click;
            // 
            // pbDownloads
            // 
            pbDownloads.Location = new Point(12, 445);
            pbDownloads.Name = "pbDownloads";
            pbDownloads.Size = new Size(933, 34);
            pbDownloads.TabIndex = 6;
            // 
            // lCountDownloads
            // 
            lCountDownloads.AutoSize = true;
            lCountDownloads.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lCountDownloads.Location = new Point(998, 445);
            lCountDownloads.Name = "lCountDownloads";
            lCountDownloads.Size = new Size(49, 32);
            lCountDownloads.TabIndex = 7;
            lCountDownloads.Text = "0/0";
            // 
            // UploadForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 482);
            Controls.Add(lCountDownloads);
            Controls.Add(pbDownloads);
            Controls.Add(btnStartDownload);
            Controls.Add(btnSelectFolder);
            Controls.Add(txtCount);
            Controls.Add(txtDirPath);
            Controls.Add(txtUrl);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UploadForm";
            Text = "Завантаження файлів";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUrl;
        private Label label3;
        private TextBox txtCount;
        private Label label4;
        private TextBox txtDirPath;
        private Button btnSelectFolder;
        private Button btnStartDownload;
        private ProgressBar pbDownloads;
        private Label lCountDownloads;
    }
}
