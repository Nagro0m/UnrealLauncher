using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealLauncher
{
    public class DataReader
    {
        public static T GetData<T>(string _dataPath)
        {
            string _data = File.ReadAllText(_dataPath);
            return JsonConvert.DeserializeObject<T>(_data);
        }
    }
}
