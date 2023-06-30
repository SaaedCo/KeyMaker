using SaaedCo.KeyMaker.Enums;

namespace SaaedCo.KeyMaker.Logic
{
    public class SettingsData
    {
        public OpenSslModes OpenSslMode { get; set; } = OpenSslModes.SystemPath;
        public string Path { get; set; }
    }
}
