using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SemiPhilter {
    public partial class NewSessionForm : Form {

        FilterSession filter_session;

        public NewSessionForm() {
            InitializeComponent();
        }

        private void btn_how_it_works_Click(object sender, EventArgs e) {
            // TODO
        }

        private void btn_new_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                if (!backgroundWorker1.IsBusy) {
                    backgroundWorker1.RunWorkerAsync();
                }

            } else {
                return;
            }
        }

        private void btn_load_Click(object sender, EventArgs e) {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                FilterSession filterSession = FilterSession.load_from_file(openFileDialog1.FileName);
                this.filter_session = filterSession;
                this.Close();
            } else {
                return;
            }
        }

        public FilterSession get_session() {
            return this.filter_session;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
            FilterSession filterSession = FilterSession.make_new_session(folderBrowserDialog1.SelectedPath, backgroundWorker1);
            this.filter_session = filterSession;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            this.Close();
        }
    }
}
