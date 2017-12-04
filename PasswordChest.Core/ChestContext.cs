using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChest.Core
{
    [Serializable]
    public class ChestContext
    {
        Dictionary<string,string> _users;
        UserManager _userManager;
        public ChestContext()
        {
            _users = new Dictionary<string, string>();
            LoadData();
        }

        private void LoadData()
        {
            string folderPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + Constants.SAVE_FOLDER_NAME;
            string savePath = folderPath + Path.DirectorySeparatorChar + Constants.SAVE_FILE_NAME;
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            if (!File.Exists(savePath))
            {
                File.Create(savePath);
                return;
            }
            using (Stream sr = new FileStream(savePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                if (formatter.Deserialize(sr) is ChestContext context)
                    _users = context._users;
            }
        }

        public IEnumerable<string> UsersName => _users.Keys;
    }
}
