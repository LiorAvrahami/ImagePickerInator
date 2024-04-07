namespace SemiPhilter {
    partial class NewSessionForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btn_load = new Button();
            btn_new = new Button();
            label1 = new Label();
            btn_how_it_works = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            openFileDialog1 = new OpenFileDialog();
            progressBar1 = new ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // btn_load
            // 
            btn_load.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_load.Location = new Point(0, 86);
            btn_load.Name = "btn_load";
            btn_load.Size = new Size(214, 59);
            btn_load.TabIndex = 0;
            btn_load.Text = "Load Session";
            btn_load.UseVisualStyleBackColor = true;
            btn_load.Click += btn_load_Click;
            // 
            // btn_new
            // 
            btn_new.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_new.Location = new Point(233, 86);
            btn_new.Name = "btn_new";
            btn_new.Size = new Size(283, 59);
            btn_new.TabIndex = 1;
            btn_new.Text = "New Session";
            btn_new.UseVisualStyleBackColor = true;
            btn_new.Click += btn_new_Click;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(751, 83);
            label1.TabIndex = 2;
            label1.Text = "SemiPhilter - A semi automatic photo filter\r\nversion 1, 2024 written by Lior Avrahami";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_how_it_works
            // 
            btn_how_it_works.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_how_it_works.Location = new Point(537, 86);
            btn_how_it_works.Name = "btn_how_it_works";
            btn_how_it_works.Size = new Size(214, 59);
            btn_how_it_works.TabIndex = 3;
            btn_how_it_works.Text = "How It Works";
            btn_how_it_works.UseVisualStyleBackColor = true;
            btn_how_it_works.Click += btn_how_it_works_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "json";
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "SemiPhilter Files|*.json";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(0, 151);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(751, 29);
            progressBar1.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // NewSessionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(751, 184);
            Controls.Add(progressBar1);
            Controls.Add(btn_how_it_works);
            Controls.Add(label1);
            Controls.Add(btn_new);
            Controls.Add(btn_load);
            Name = "NewSessionForm";
            Text = "NewSessionForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_load;
        private Button btn_new;
        private Label label1;
        private Button btn_how_it_works;
        private FolderBrowserDialog folderBrowserDialog1;
        private OpenFileDialog openFileDialog1;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}