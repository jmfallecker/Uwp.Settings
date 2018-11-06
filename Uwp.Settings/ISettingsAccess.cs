namespace Uwp.Settings
{
    internal interface ISettingsAccess
    {
        object Read(string settingName);
        void Write(string settingName, object settingValue);
    }
}
