using SaaedCo.KeyMaker.Enums;
using System;

namespace SaaedCo.KeyMaker.Logic
{
    public static class Settings
    {
        const string SETTINGS_FILENAME = "settings";

        static readonly KeyValueSettings _settings = new KeyValueSettings(SETTINGS_FILENAME);

        public static void Save()
        {
            _settings.Save();
        }

        public static OpenSslModes OpenSslMode
        {
            get
            {
                if (Enum.TryParse<OpenSslModes>(_settings[nameof(OpenSslMode)], true, out var value))
                {
                    return value;
                }
                else
                {
                    return OpenSslModes.ExePath;
                }
            }
            set
            {
                _settings[nameof(OpenSslMode)] = value.ToString();
            }
        }

        public static string Path
        {
            get
            {
                return _settings[nameof(Path)];
            }
            set
            {
                _settings[nameof(Path)] = value;
            }
        }
    }
}
