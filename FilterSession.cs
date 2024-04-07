using Newtonsoft.Json;
using System.ComponentModel;

namespace SemiPhilter {
    public class FilterSession {

        public static SearchOption FOLDER_SEARCH_OPTION = SearchOption.AllDirectories;

        static TimeSpan MAX_TIME_DELTA_BETWEAN_BATCHES = new TimeSpan(hours:0,minutes:1,seconds:0);

        public static string[] IMAGE_EXTENTIONS = { ".bmp", ".gif", ".jpg", ".jpeg", ".png", ".tif", ".tiff" };

        /* Fileds */
        public string path_to_images_folder; // path to root
        public List<ImageBatch> image_batches;
        public int current_batch_index = 0;

        public static FilterSession load_from_file(string path_to_file) {
            string json_text = File.ReadAllText(path_to_file);
            FilterSession ret = JsonConvert.DeserializeObject<FilterSession>(json_text);
            return ret;
        }

        public void save_to_file() {
            string progress_file_path = Path.Join(path_to_images_folder,"SemiPhilter_Progress.json");
            File.WriteAllText(progress_file_path, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public static FilterSession make_new_session(string path_to_images_folder, BackgroundWorker backgroundWorker1) {
            /** this function mainly bunches the photos in the given folder into batches.
             * the bunching criteria is automatic and is based on the timestamp of the image */
            string[] all_files = Directory.GetFiles(path_to_images_folder, "*.*", FOLDER_SEARCH_OPTION);
            
            List<string> files_temp = new List<string>();
            for (int i = 0; i < all_files.Length; i++) {
                if (IMAGE_EXTENTIONS.Contains(Path.GetExtension(all_files[i]).ToLower())) {
                    files_temp.Add(all_files[i]);
                }
                backgroundWorker1.ReportProgress(100 * i / all_files.Length);
            }
            string[] files = files_temp.ToArray();

            DateTime[] file_datetimes = new DateTime[files.Length];
            for (int i = 0; i < files.Length; i++) {
                file_datetimes[i] = GetImageProperties.GetDateTakenFromImage(files[i]);
                backgroundWorker1.ReportProgress(100 * i / files.Length);
            }
            
            // sort files by order of date taken
            Array.Sort(file_datetimes, files);

            List<ImageBatch> image_batches = new List<ImageBatch>();
            image_batches.Add(new ImageBatch());
            image_batches[0].Add(new ImageData(files[0], file_datetimes[0]));

            for (int i = 1; i < files.Length; i++) {
                TimeSpan time_delta = file_datetimes[i] - file_datetimes[i-1];
                if (time_delta > MAX_TIME_DELTA_BETWEAN_BATCHES) {
                    image_batches.Add(new ImageBatch());
                }
                image_batches.Last().Add(new ImageData(files[i], file_datetimes[i]));

                backgroundWorker1.ReportProgress(100 * i / files.Length);
            }

            FilterSession ret = new FilterSession();

            ret.image_batches = image_batches;
            ret.path_to_images_folder = path_to_images_folder;
            return ret;

        }

        public int get_total_number_images() {
            int ret = 0;
            for (int i = 0; i < image_batches.Count; i++) {
                ret += image_batches[i].Count;
            }
            return ret;
        }

        public void Apply_Filtration(string target_path, BackgroundWorker backgroundWorker, bool sort_into_year_subfolders) {
            int total_number_images = this.get_total_number_images();
            int image_index = 0;
            for (int i = 0; i < image_batches.Count; i++) {
                string current_target_path;
                if (sort_into_year_subfolders) {
                    string year_str;
                    if (image_batches[i][0].datetime_of_capture == DateTime.UnixEpoch)
                        year_str = "YearUnknown";
                    else
                        year_str = image_batches[i][0].datetime_of_capture.Year.ToString();
                    current_target_path = Path.Join(target_path, year_str);
                } else
                    current_target_path = target_path;
                for (int j = 0; j < image_batches[i].Count; j++) {
                    if (image_batches[i][j].b_keep) {
                        string target_file_path = Path.Join(current_target_path, Path.GetFileName(image_batches[i][j].file_path));
                        Directory.CreateDirectory(Path.GetDirectoryName(target_file_path));
                        File.Copy(image_batches[i][j].file_path, target_file_path, overwrite: true);
                    }
                    backgroundWorker.ReportProgress(100 * image_index / total_number_images);
                    image_index += 1;
                }
            }

            image_index = 0;
            List<string> unaccountted_for_files = get_list_of_files_that_are_not_accountted_for(backgroundWorker);
            foreach (string unaccountted_file in unaccountted_for_files) {
                string target_file_path = Path.Join(target_path,"Others", Path.GetFileName(unaccountted_file));
                Directory.CreateDirectory(Path.GetDirectoryName(target_file_path));
                File.Copy(unaccountted_file, target_file_path, overwrite: true);
                backgroundWorker.ReportProgress(100 * image_index / total_number_images);
                image_index += 1;
            }
        }

        public List<string> get_list_of_files_that_are_not_accountted_for(BackgroundWorker backgroundWorker) {
            List<string> unaccountted_for_files = new List<string>();
            string[] all_files = Directory.GetFiles(path_to_images_folder, "*.*", FOLDER_SEARCH_OPTION);
            SortedSet<string> all_accountted_for_files = new SortedSet<string>();
            for (int i = 0; i < image_batches.Count; i++) {
                for (int j = 0; j < image_batches[i].Count; j++) {
                    all_accountted_for_files.Add(image_batches[i][j].file_path);
                }
            }

            foreach (string file_path in all_files) {
                if (!all_accountted_for_files.Contains(file_path)) {
                    unaccountted_for_files.Add(file_path);
                }
            }

            return unaccountted_for_files;
        }
    }
}
