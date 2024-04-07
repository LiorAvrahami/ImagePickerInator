namespace SemiPhilter {
    partial class MasterForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            image_batch_list = new DataGridView();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            Lock_subimage_button = new PictureBox();
            btn_prev_batch = new Button();
            btn_next_batch = new Button();
            btn_save_progress_to_file = new Button();
            btn_mark_to_keep = new Button();
            btn_mark_to_remove = new Button();
            Buttons_Pannel = new Panel();
            CheckBox_Year_Subfolders = new CheckBox();
            total_progress_indicator = new Label();
            total_progress_indicator_border = new PictureBox();
            btn_exicute_filtration = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            progressBar1 = new ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)image_batch_list).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Lock_subimage_button).BeginInit();
            Buttons_Pannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)total_progress_indicator_border).BeginInit();
            SuspendLayout();
            // 
            // image_batch_list
            // 
            image_batch_list.AllowUserToAddRows = false;
            image_batch_list.AllowUserToDeleteRows = false;
            image_batch_list.AllowUserToResizeRows = false;
            image_batch_list.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            image_batch_list.Location = new Point(6, 5);
            image_batch_list.MultiSelect = false;
            image_batch_list.Name = "image_batch_list";
            image_batch_list.ReadOnly = true;
            image_batch_list.RowHeadersWidth = 4;
            image_batch_list.RowTemplate.Height = 25;
            image_batch_list.Size = new Size(263, 526);
            image_batch_list.TabIndex = 0;
            image_batch_list.SelectionChanged += image_batch_list_SelectionChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(275, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(562, 853);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(843, 111);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(464, 747);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // Lock_subimage_button
            // 
            Lock_subimage_button.BorderStyle = BorderStyle.FixedSingle;
            Lock_subimage_button.Image = Properties.Resources.unlocked_icon;
            Lock_subimage_button.Location = new Point(1259, 111);
            Lock_subimage_button.Name = "Lock_subimage_button";
            Lock_subimage_button.Size = new Size(48, 46);
            Lock_subimage_button.SizeMode = PictureBoxSizeMode.Zoom;
            Lock_subimage_button.TabIndex = 3;
            Lock_subimage_button.TabStop = false;
            Lock_subimage_button.Click += Lock_subimage_button_Click;
            // 
            // btn_prev_batch
            // 
            btn_prev_batch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_prev_batch.Location = new Point(3, 70);
            btn_prev_batch.Name = "btn_prev_batch";
            btn_prev_batch.Size = new Size(126, 60);
            btn_prev_batch.TabIndex = 4;
            btn_prev_batch.Text = "Previous Batch";
            btn_prev_batch.UseVisualStyleBackColor = true;
            btn_prev_batch.Click += btn_prev_batch_Click;
            // 
            // btn_next_batch
            // 
            btn_next_batch.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_next_batch.Location = new Point(138, 70);
            btn_next_batch.Name = "btn_next_batch";
            btn_next_batch.Size = new Size(119, 60);
            btn_next_batch.TabIndex = 5;
            btn_next_batch.Text = "Next Batch";
            btn_next_batch.UseVisualStyleBackColor = true;
            btn_next_batch.Click += btn_next_batch_Click;
            // 
            // btn_save_progress_to_file
            // 
            btn_save_progress_to_file.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_save_progress_to_file.Location = new Point(3, 164);
            btn_save_progress_to_file.Name = "btn_save_progress_to_file";
            btn_save_progress_to_file.Size = new Size(254, 60);
            btn_save_progress_to_file.TabIndex = 6;
            btn_save_progress_to_file.Text = "Save Progress To File";
            btn_save_progress_to_file.UseVisualStyleBackColor = true;
            btn_save_progress_to_file.Click += btn_save_progress_to_file_Click;
            // 
            // btn_mark_to_keep
            // 
            btn_mark_to_keep.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_mark_to_keep.ForeColor = Color.Green;
            btn_mark_to_keep.Location = new Point(3, 3);
            btn_mark_to_keep.Name = "btn_mark_to_keep";
            btn_mark_to_keep.Size = new Size(126, 60);
            btn_mark_to_keep.TabIndex = 8;
            btn_mark_to_keep.Text = "Mark To Be\r\nKept";
            btn_mark_to_keep.UseVisualStyleBackColor = true;
            btn_mark_to_keep.Click += btn_mark_to_keep_Click;
            // 
            // btn_mark_to_remove
            // 
            btn_mark_to_remove.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_mark_to_remove.ForeColor = Color.Maroon;
            btn_mark_to_remove.Location = new Point(138, 3);
            btn_mark_to_remove.Name = "btn_mark_to_remove";
            btn_mark_to_remove.Size = new Size(119, 60);
            btn_mark_to_remove.TabIndex = 9;
            btn_mark_to_remove.Text = "Mark To Be Removed";
            btn_mark_to_remove.UseVisualStyleBackColor = true;
            btn_mark_to_remove.Click += btn_mark_to_remove_Click;
            // 
            // Buttons_Pannel
            // 
            Buttons_Pannel.Controls.Add(CheckBox_Year_Subfolders);
            Buttons_Pannel.Controls.Add(total_progress_indicator);
            Buttons_Pannel.Controls.Add(total_progress_indicator_border);
            Buttons_Pannel.Controls.Add(btn_mark_to_keep);
            Buttons_Pannel.Controls.Add(btn_prev_batch);
            Buttons_Pannel.Controls.Add(btn_mark_to_remove);
            Buttons_Pannel.Controls.Add(btn_exicute_filtration);
            Buttons_Pannel.Controls.Add(btn_next_batch);
            Buttons_Pannel.Controls.Add(btn_save_progress_to_file);
            Buttons_Pannel.Location = new Point(6, 537);
            Buttons_Pannel.Name = "Buttons_Pannel";
            Buttons_Pannel.Size = new Size(263, 321);
            Buttons_Pannel.TabIndex = 11;
            // 
            // CheckBox_Year_Subfolders
            // 
            CheckBox_Year_Subfolders.BackColor = Color.FromArgb(224, 224, 224);
            CheckBox_Year_Subfolders.Checked = true;
            CheckBox_Year_Subfolders.CheckState = CheckState.Checked;
            CheckBox_Year_Subfolders.FlatStyle = FlatStyle.Popup;
            CheckBox_Year_Subfolders.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            CheckBox_Year_Subfolders.Location = new Point(3, 287);
            CheckBox_Year_Subfolders.Name = "CheckBox_Year_Subfolders";
            CheckBox_Year_Subfolders.Size = new Size(257, 31);
            CheckBox_Year_Subfolders.TabIndex = 13;
            CheckBox_Year_Subfolders.Text = "Sort Into Year Folders";
            CheckBox_Year_Subfolders.TextAlign = ContentAlignment.MiddleCenter;
            CheckBox_Year_Subfolders.UseVisualStyleBackColor = false;
            // 
            // total_progress_indicator
            // 
            total_progress_indicator.BackColor = Color.FromArgb(128, 255, 128);
            total_progress_indicator.BorderStyle = BorderStyle.FixedSingle;
            total_progress_indicator.Location = new Point(3, 136);
            total_progress_indicator.Name = "total_progress_indicator";
            total_progress_indicator.Size = new Size(174, 22);
            total_progress_indicator.TabIndex = 12;
            total_progress_indicator.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // total_progress_indicator_border
            // 
            total_progress_indicator_border.BorderStyle = BorderStyle.FixedSingle;
            total_progress_indicator_border.Location = new Point(3, 136);
            total_progress_indicator_border.Name = "total_progress_indicator_border";
            total_progress_indicator_border.Size = new Size(254, 22);
            total_progress_indicator_border.TabIndex = 10;
            total_progress_indicator_border.TabStop = false;
            // 
            // btn_exicute_filtration
            // 
            btn_exicute_filtration.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_exicute_filtration.Location = new Point(6, 230);
            btn_exicute_filtration.Name = "btn_exicute_filtration";
            btn_exicute_filtration.Size = new Size(251, 51);
            btn_exicute_filtration.TabIndex = 7;
            btn_exicute_filtration.Text = "Exicute Filtration";
            btn_exicute_filtration.UseVisualStyleBackColor = true;
            btn_exicute_filtration.Click += btn_exicute_filtration_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(308, 288);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(958, 23);
            progressBar1.TabIndex = 12;
            progressBar1.Visible = false;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // MasterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1313, 861);
            Controls.Add(progressBar1);
            Controls.Add(Buttons_Pannel);
            Controls.Add(Lock_subimage_button);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(image_batch_list);
            KeyPreview = true;
            Name = "MasterForm";
            Text = "SemiPhilter";
            Load += MasterForm_Load;
            SizeChanged += MasterForm_SizeChanged;
            KeyDown += MasterForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)image_batch_list).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)Lock_subimage_button).EndInit();
            Buttons_Pannel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)total_progress_indicator_border).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView image_batch_list;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox Lock_subimage_button;
        private Button btn_prev_batch;
        private Button btn_next_batch;
        private Button btn_save_progress_to_file;
        private Button btn_mark_to_keep;
        private Button btn_mark_to_remove;
        private Panel Buttons_Pannel;
        private PictureBox total_progress_indicator_border;
        private Label total_progress_indicator;
        private FolderBrowserDialog folderBrowserDialog1;
        private ProgressBar progressBar1;
        private CheckBox CheckBox_Year_Subfolders;
        private Button btn_exicute_filtration;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}