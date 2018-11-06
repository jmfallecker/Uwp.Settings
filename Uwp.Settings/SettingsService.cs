using System;
using System.ComponentModel;

namespace Uwp.Settings
{
    internal sealed class SettingsService : ISettingsService
    {
        private readonly ISettingsAccess _settingsAccess;

        internal SettingsService(DataStore dataStore)
        {
            _settingsAccess = new SettingsAccess(dataStore);
        }

        public T Read<T>(string settingName)
        {
            var value = _settingsAccess.Read(settingName);
            return Convert<T>(value.ToString());
        }

        public void Write(string settingName, object settingValue)
        {
            _settingsAccess.Write(settingName, settingValue);
        }

        private T Convert<T>(string value)
        {
            return (T) System.Convert.ChangeType(value, typeof(T));
        }
    }
}
