using PasswordChest.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChest.Tests
{
    public class Extension
    {
        public static void DeleteSave()
        {
            string folderPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + Constants.SAVE_FOLDER_NAME;
            string savePath = folderPath + Path.DirectorySeparatorChar + Constants.SAVE_FILE_NAME;
            if (!File.Exists(savePath))
                return;
            File.Delete(savePath);
        }
    }
}
