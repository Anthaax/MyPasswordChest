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
        [field: NonSerialized]
        UserManager _userManager;
        public ChestContext()
        {
            _users = new Dictionary<string, string>();
            Initialize();
            _userManager = new UserManager(this);
            UserManager.UserHasBeenCreated += (s, e) => AddUser(s as User);
        }

        private void Initialize()
        {
            if (!Directory.Exists(Constants.SaveFolderPath))
                Directory.CreateDirectory(Constants.SaveFolderPath);
            if (!File.Exists(Constants.SaveFilePath))
            {
                SaveContext();
                return;
            }
            ChestContext loadContext = LoadContext();
            if (loadContext != null)
                _users = loadContext._users;
        }

        public IEnumerable<string> UsersName => _users.Keys;

        public UserManager Manager => _userManager;

        private void SaveContext()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream (Constants.SaveFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(fs, this);
            }
        }

        private ChestContext LoadContext()
        {
            ChestContext chestContext;
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream sr = new FileStream(Constants.SaveFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                chestContext = formatter.Deserialize(sr) as ChestContext;
            }
            return chestContext;
        }

        private void AddUser(User user)
        {
            _users.Add(user.FullName, user.GetHashCode().ToString());
        }
    }
}
