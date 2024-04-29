using Newtonsoft.Json;
using SupermarketApp.Model;
using System.IO;

namespace SupermarketApp.Utilities
{
    internal class FileHelper
    {

        #region Properties and members

        private static readonly string _themeJsonPath = "..\\..\\Resources\\Theme.json";

        #endregion

        #region Methods
        public static void ReadFromJson<T>(ref T parameter, string path)
        {
            if (File.Exists(path))
            {
                string jsonString = File.ReadAllText(path);
                parameter = JsonConvert.DeserializeObject<T>(jsonString);
            }
        }

        public static void InitTheme(ref Theme theme)
        {
            ReadFromJson<Theme>(ref theme, _themeJsonPath);
        }

        #endregion


    }
}
