namespace WinFormEvent
{
    partial class Form1
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
            btnOk = new Button();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(39, 55);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(166, 53);
            btnOk.TabIndex = 0;
            btnOk.Text = "Хочу борщ";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += MyButtonClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnOk);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        

        #endregion

        private Button btnOk;
    }
}
