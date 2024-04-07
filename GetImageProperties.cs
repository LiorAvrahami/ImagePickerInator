﻿using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Shell;

namespace SemiPhilter {
    public class GetImageProperties {
        //we init this once so that if the function is repeatedly called
        //it isn't stressing the garbage man
        private static Regex r = new Regex(":");

        //retrieves the datetime WITHOUT loading the whole image
        public static DateTime GetDateTakenFromImage(string path) {
            try {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (Image myImage = Image.FromStream(fs, false, false)) {
                    PropertyItem propItem = myImage.GetPropertyItem(36867);
                    string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
                    return DateTime.Parse(dateTaken);
                }
            } catch {
                ShellObject shell = ShellObject.FromParsingName(path);
                DateTime? date = shell.Properties.System.Media.DateEncoded.Value;
                if (date == null) {
                    return DateTime.UnixEpoch;
                } else {
                    return date.Value;
                }
            }
        }
    }
}
