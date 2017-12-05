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
            if (!Directory.Exists(folderPath))
                return;
            DirectoryInfo di = new DirectoryInfo(folderPath);
            foreach (FileInfo file in di.GetFiles())
                file.Delete();
            foreach (DirectoryInfo dir in di.GetDirectories())
                dir.Delete(true);
        }
    }
}
