using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiPhilter {
    public class ImageBatch : List<ImageData>{

    }

    public class ImageData {

        public string file_path;
        public DateTime datetime_of_capture;
        public bool b_keep;

        public ImageData(string file_path, DateTime datetime_of_capture) {
            this.file_path = file_path;
            this.datetime_of_capture = datetime_of_capture;
            this.b_keep = false;
        }
    }
}
