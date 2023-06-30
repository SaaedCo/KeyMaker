using System.Collections.Generic;
using System.IO;

namespace SaaedCo.KeyMaker.Logic
{
    public class KeyValueSettings
    {
        private readonly Dictionary<string, string> _settings;
        private readonly string _filePath;

        public KeyValueSettings(string filePath)
        {
            _filePath = filePath;
            _settings = new Dictionary<string, string>();

            if (File.Exists(_filePath))
            {
                string[] lines = File.ReadAllLines(_filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('=');
                    if (parts.Length == 2)
                    {
                        _settings[parts[0]] = parts[1];
                    }
                }
            }
        }

        public string this[string key]
        {
            get
            {
                _settings.TryGetValue(key, out var value);
                return value;
            }
            set
            {
                _settings[key] = value;
            }
        }

        public void Save()
        {
            var lines = new List<string>();
            foreach (var setting in _settings)
            {
                lines.Add(setting.Key + "=" + setting.Value);
            }
            File.WriteAllLines(_filePath, lines);
        }
    }
}
