using System;

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

            if (value is null)
                throw new ArgumentException(
                    $@"No setting exists for name ""{settingName}""",
                    nameof(settingName));

            return Convert<T>(value.ToString());
        }

        public void Write(string settingName, object settingValue)
        {
            _settingsAccess.Write(settingName, settingValue);
        }

        private T Convert<T>(string value)
        {
            try
            {
                return (T) System.Convert.ChangeType(value, typeof(T));
            }
            catch (FormatException e)
            {
                throw new InvalidCastException(
                    $@"Value ""{value}"" is not of type {typeof(T)}",
                    e);
            }
        }
    }
}
