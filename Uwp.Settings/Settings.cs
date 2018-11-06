using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace Uwp.Settings
{
    public static class Settings
    {
        private static ISettingsService _settingsService;

        static Settings()
        {
            _settingsService = new SettingsService(DataStore.Local);
        }

        /// <summary>
        /// Read the setting from Local Settings.
        /// </summary>
        /// <typeparam name="T">The expected type of the setting.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <returns>Value of the setting.</returns>
        public static T Read<T>(string settingName)
        {
            return _settingsService.Read<T>(settingName);
        }

        /// <summary>
        /// Read the setting from the given <see cref="DataStore"/>.
        /// </summary>
        /// <typeparam name="T">The expected type of the setting.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="dataStore">The type of the setting. e.g. Local, Roaming, etc.</param>
        /// <returns>Value of the setting.</returns>
        public static T Read<T>(string settingName, DataStore dataStore)
        {
            ISettingsService service = new SettingsService(dataStore);
            return service.Read<T>(settingName);
        }

        /// <summary>
        /// Write the setting to Local Settings.
        /// </summary>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="settingValue">The value of the setting.</param>
        /// <returns>True if written, false if write failed.</returns>
        public static void Write(string settingName, object settingValue)
        {
            _settingsService.Write(settingName, settingValue);
        }

        /// <summary>
        /// Write the setting to Local Settings.
        /// </summary>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="settingValue">The value of the setting.</param>
        /// <param name="dataStore">The type of the setting. e.g. Local, Roaming, etc.</param>
        /// <returns>True if written, false if write failed.</returns>
        public static void Write(string settingName, object settingValue, DataStore dataStore)
        {
            ISettingsService service = new SettingsService(dataStore);
            service.Write(settingName, settingValue);
        }

        /// <summary>
        /// Clear all data from the given <see cref="DataStore"/>
        /// </summary>
        /// <param name="dataStore"></param>
        /// <returns></returns>
        public static async Task ClearAsync(DataStore dataStore)
        {
            ApplicationDataLocality locality;
            switch (dataStore)
            {
                case DataStore.Local:
                    locality = ApplicationDataLocality.Local;
                    break;
                case DataStore.Roaming:
                    locality = ApplicationDataLocality.Roaming;
                    break;
                default:
                    return;
            }

            await ApplicationData.Current.ClearAsync(locality);
        }

        public static void SetDefaultDataStore(DataStore dataStore)
        {
            _settingsService = new SettingsService(dataStore);
        }
    }
}
