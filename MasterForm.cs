using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace SemiPhilter {
    public partial class MasterForm : Form {

        string CHAR_FOR_X = "\u274C";
        string CHAR_FOR_V = "\u2713";

        FilterSession filter_session;
        DataTable current_batch_data;

        int current_batch_index;

        /*dynamic re-sizeing fields*/
        int controll_margins = 0;

        bool b_lock_subimage = false;

        public MasterForm() {
            InitializeComponent();

            controll_margins = this.pictureBox1.Top;
        }

        public void assosiate_with_SemiPhilter_session(FilterSession filter_session) {
            this.filter_session = filter_session;
            current_batch_index = filter_session.current_batch_index;
        }


        public void reset_visuals() {
            this.total_progress_indicator.Width =
                (int)(total_progress_indicator_border.Width * (float)(current_batch_index + 1) / (this.filter_session.image_batches.Count));
            this.total_progress_indicator.Text = (current_batch_index + 1).ToString() + "/" + this.filter_session.image_batches.Count.ToString();

            reset_image_batch_list();
        }

        private void reset_image_batch_list() {
            current_batch_data = new DataTable();
            current_batch_data.Columns.Add("OrigionalIndex");
            current_batch_data.Columns.Add("Keep_binary");

            current_batch_data.Columns.Add(CHAR_FOR_X + "/" + CHAR_FOR_V);
            current_batch_data.Columns.Add("File name");
            current_batch_data.Columns.Add("Time Of Capture");
            current_batch_data.Columns.Add("Path To File");

            // fill rows
            ImageBatch current_batch = this.filter_session.image_batches[current_batch_index];
            for (int i = 0; i < current_batch.Count; i++) {
                ImageData current_image_data = current_batch[i];
                DataRow row = current_batch_data.NewRow();
                row[0] = i.ToString();
                if (current_image_data.b_keep) {
                    row[1] = "1";
                    row[2] = CHAR_FOR_V;
                } else {
                    row[1] = "0";
                    row[2] = CHAR_FOR_X;
                }
                row[3] = Path.GetFileName(current_image_data.file_path);
                row[4] = current_image_data.datetime_of_capture.ToString();
                row[5] = current_image_data.file_path;
                current_batch_data.Rows.Add(row);
            }

            image_batch_list.DataSource = current_batch_data;
            image_batch_list.Columns[0].Visible = false;
            image_batch_list.Columns[1].Visible = false;

            foreach (DataGridViewColumn col in image_batch_list.Columns) {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            image_batch_list.Columns[0].Width = 0;
            image_batch_list.Columns[1].Width = 0;

            image_batch_list.Columns[2].Width = 40;
            image_batch_list.Columns[3].Width = 60;
            image_batch_list.Columns[4].Width = 110;
            image_batch_list.Columns[5].Width = 80;
        }
        private int batch_images_get_selected_index() {
            if (image_batch_list.SelectedCells.Count == 0) { return -1; }
            return image_batch_list.SelectedCells[0].RowIndex;
        }

        private void MasterForm_Load(object sender, EventArgs e) {
            reset_visuals();
            MasterForm_SizeChanged(null, null);
        }

        private void MasterForm_SizeChanged(object sender, EventArgs e) {
            int form_width = this.ClientSize.Width;
            int form_height = this.ClientSize.Height;

            if (pictureBox2.Visible == true) {
                this.pictureBox1.Width = (form_width - 2 * controll_margins - pictureBox1.Left) * 5 / 8;
                this.pictureBox2.Width = (form_width - 2 * controll_margins - pictureBox1.Left) * 3 / 8;
                this.pictureBox2.Location = new Point(this.pictureBox1.Right + controll_margins, this.pictureBox2.Top);
            } else {
                this.pictureBox1.Width = form_width - 2 * controll_margins - pictureBox1.Left;
            }

            this.pictureBox1.Height = form_height - controll_margins - pictureBox1.Top;
            this.pictureBox2.Height = form_height - controll_margins - pictureBox2.Top;

            this.Lock_subimage_button.Location = new Point(this.pictureBox2.Right - Lock_subimage_button.Width, this.pictureBox2.Top);

            this.image_batch_list.Height = form_height - controll_margins * 2 - image_batch_list.Top - Buttons_Pannel.Height;
            this.Buttons_Pannel.Location = new Point(Buttons_Pannel.Left, image_batch_list.Bottom + controll_margins);

            /*
            this.btn_exicute_filtration.Location = new Point(this.pictureBox2.Left, btn_exicute_filtration.Top);
            this.CheckBox_Year_Subfolders.Location = new Point(this.pictureBox2.Left, CheckBox_Year_Subfolders.Top);
            */
        }

        public void change_keep_status(int image_index, bool keep) {
            if (keep) {
                current_batch_data.Rows[image_index][1] = "1";
                current_batch_data.Rows[image_index][2] = CHAR_FOR_V;
            } else {
                current_batch_data.Rows[image_index][1] = "0";
                current_batch_data.Rows[image_index][2] = CHAR_FOR_X;
            }
            filter_session.image_batches[current_batch_index][image_index].b_keep = keep;
        }

        private void btn_mark_to_keep_Click(object sender, EventArgs e) {
            int selectted_index = batch_images_get_selected_index();
            change_keep_status(selectted_index, true);
            KeyDown_priv(Keys.Down);
        }

        private void btn_mark_to_remove_Click(object sender, EventArgs e) {
            int selectted_index = batch_images_get_selected_index();
            change_keep_status(selectted_index, false);
        }

        private void btn_prev_batch_Click(object sender, EventArgs e) {
            current_batch_index -= 1;
            if (current_batch_index <= 0) {
                current_batch_index = 0;
            }
            filter_session.current_batch_index = current_batch_index;
            reset_visuals();
        }

        private void btn_next_batch_Click(object sender, EventArgs e) {
            current_batch_index += 1;
            if (current_batch_index >= this.filter_session.image_batches.Count) {
                current_batch_index = this.filter_session.image_batches.Count - 1;
            }
            filter_session.current_batch_index = current_batch_index;
            reset_visuals();
        }

        private void btn_save_progress_to_file_Click(object sender, EventArgs e) {
            this.filter_session.save_to_file();
        }

        private void btn_exicute_filtration_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                progressBar1.Visible = true;
                if (!backgroundWorker1.IsBusy) {
                    backgroundWorker1.RunWorkerAsync();
                }
            } else {
                return;
            }

        }

        private void image_batch_list_SelectionChanged(object sender, EventArgs e) {
            int image_index = batch_images_get_selected_index();
            if (image_index == -1) {
                return;
            }
            string new_image_path = filter_session.image_batches[current_batch_index][image_index].file_path;
            Image new_image;
            try {
                new_image = Image.FromFile(new_image_path);
            } catch {
                return;
            }
            if (!b_lock_subimage) {
                if (pictureBox2.Image != null)
                    pictureBox2.Image.Dispose();
                pictureBox2.Image = pictureBox1.Image;
                pictureBox1.Image = new_image;
            } else {
                if (pictureBox1.Image != null)
                    pictureBox1.Image.Dispose();
                pictureBox1.Image = new_image;
            }
        }

        private void Lock_subimage_button_Click(object sender, EventArgs e) {
            if (b_lock_subimage) {
                b_lock_subimage = false;
                Lock_subimage_button.Image = Properties.Resources.unlocked_icon;
            } else {
                b_lock_subimage = true;
                Lock_subimage_button.Image = Properties.Resources.locked_icon;
            }
        }

        private void MasterForm_KeyDown(object sender, KeyEventArgs e) {
            KeyDown_priv(e.KeyData);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Enter || keyData == Keys.Space) {
                KeyDown_priv(keyData);
                //Check the keyData and do your custom processing
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void KeyDown_priv(Keys KeyCode) {
            bool isCtrl = (KeyCode & Keys.Control) == Keys.Control;
            KeyCode &= ~Keys.Control;
            if (KeyCode == Keys.Left) {
                btn_prev_batch_Click(null, null);
            }
            if (KeyCode == Keys.Right) {
                btn_next_batch_Click(null, null);
            }
            if (KeyCode == Keys.Up) {
                int selectted_index = batch_images_get_selected_index();
                selectted_index = selectted_index - 1;
                if (selectted_index < 0) {
                    btn_prev_batch_Click(null, null);
                    selectted_index = image_batch_list.Rows.Count - 1;

                }
                image_batch_list.ClearSelection();
                image_batch_list.Rows[selectted_index].Selected = true;
            }
            if (KeyCode == Keys.Down) {
                int selectted_index = batch_images_get_selected_index();
                selectted_index = selectted_index + 1;
                if (selectted_index >= image_batch_list.Rows.Count) {
                    btn_next_batch_Click(null, null);
                    selectted_index = 0;
                }
                image_batch_list.ClearSelection();
                image_batch_list.Rows[selectted_index].Selected = true;
            }
            if (KeyCode == Keys.Delete || KeyCode == Keys.Back) {
                btn_mark_to_remove_Click(null, null);
            }
            if (KeyCode == Keys.Enter || KeyCode == Keys.Space) {
                btn_mark_to_keep_Click(null, null);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            pictureBox2.Visible = !pictureBox2.Visible;
            Lock_subimage_button.Visible = pictureBox2.Visible;
            this.MasterForm_SizeChanged(null, null);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            this.filter_session.Apply_Filtration(folderBrowserDialog1.SelectedPath, backgroundWorker1, CheckBox_Year_Subfolders.Checked);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            progressBar1.Visible = false;
        }
    }
}
