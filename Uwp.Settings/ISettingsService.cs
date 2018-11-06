namespace Uwp.Settings
{
    internal interface ISettingsService
    {
        T Read<T>(string settingName);
        void Write(string settingName, object settingValue);
    }
}
