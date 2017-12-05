using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChest.Core
{
    public class Constants
    {
        public const string SAVE_FOLDER_NAME = "DataSave";
        public const string SAVE_CHESTCONTEXT_FILE_NAME = "Data.sav";
        public const string SEPARATOR_KEY = "§";

        public static string SaveFolderPath => Environment.CurrentDirectory + Path.DirectorySeparatorChar + SAVE_FOLDER_NAME;
        public static string SaveFilePath => SaveFolderPath + Path.DirectorySeparatorChar + SAVE_CHESTCONTEXT_FILE_NAME;
    }
}
