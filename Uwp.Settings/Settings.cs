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
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidCastException"></exception>
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
        /// <param name="dataStore">The storage to read from. e.g. Local, Roaming, etc.</param> 
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidCastException"></exception>
        /// <returns>Value of the setting.</returns>
        public static T Read<T>(string settingName, DataStore dataStore)
        {
            ISettingsService service = new SettingsService(dataStore);
            return service.Read<T>(settingName);
        }

        /// <summary>
        /// Attempts to read the value for given <paramref name="settingName"/>
        /// </summary>
        /// <typeparam name="T">The expected type of the setting.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="settingValue">Will be default(<typeparamref name="T"/>) if no value found.</param>
        /// <returns>Value of the setting.</returns>
        public static bool TryRead<T>(string settingName, out T settingValue)
        {
            try
            {
                settingValue = _settingsService.Read<T>(settingName);
                return true;
            }
            catch (Exception)
            {
                settingValue = default(T);
                return false;
            }
        }

        /// <summary>
        /// Attempts to read the value from the given <paramref name="dataStore"/> for given <paramref name="settingName"/>
        /// </summary>
        /// <typeparam name="T">The expected type of the setting.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="settingValue">Will be default(<typeparamref name="T"/>) if no value found.</param>
        /// <param name="dataStore">The storage to read from. e.g. Local, Roaming, etc.</param> 
        /// <returns>Value of the setting.</returns>
        public static bool TryRead<T>(string settingName, out T settingValue, DataStore dataStore)
        {
            try
            {
                var service = new SettingsService(dataStore);

                settingValue = service.Read<T>(settingName);
                return true;
            }
            catch (Exception)
            {
                settingValue = default(T);
                return false;
            }
        }

        /// <summary>
        /// Returns <paramref name="fallbackValue"/> if setting value is not found.
        /// </summary>
        /// <typeparam name="T">The expected type of the setting.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="fallbackValue">Value to return if no setting value is found.</param>
        /// <returns></returns>
        public static T SafeRead<T>(string settingName, T fallbackValue)
        {
            if (TryRead(settingName, out T settingValue))
            {
                return settingValue;
            }
            else
            {
                return fallbackValue;
            }
        }

        /// <summary>
        /// Returns <paramref name="fallbackValue"/> if setting value is not found.
        /// </summary>
        /// <typeparam name="T">The expected type of the setting.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="fallbackValue">Value to return if no setting value is found.</param>
        /// <param name="dataStore">The storage to read from. e.g. Local, Roaming, etc.</param>
        /// <returns></returns>
        public static T SafeRead<T>(string settingName, T fallbackValue, DataStore dataStore)
        {
            if (TryRead(settingName, out T settingValue, dataStore))
            {
                return settingValue;
            }
            else
            {
                return fallbackValue;
            }
        }

        /// <summary>
        /// Write the setting to Local Settings.
        /// </summary>
        /// <typeparam name="T">The type of the setting's value.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="settingValue">The value of the setting.</param>
        /// <returns>True if written, false if write failed.</returns>
        public static void Write<T>(string settingName, T settingValue)
        {
            _settingsService.Write(settingName, settingValue);
        }

        /// <summary>
        /// Write the setting to Local Settings.
        /// </summary>
        /// <typeparam name="T">The type of the setting's value.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="settingValue">The value of the setting.</param>
        /// <param name="dataStore">The storage to write to. e.g. Local, Roaming, etc.</param>
        /// <returns>True if written, false if write failed.</returns>
        public static void Write<T>(string settingName, T settingValue, DataStore dataStore)
        {
            ISettingsService service = new SettingsService(dataStore);
            service.Write(settingName, settingValue);
        }

        /// <summary>
        /// Attempts to write the setting and value.
        /// </summary>
        /// <typeparam name="T">The type of the setting's value.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="settingValue">The value of the setting.</param>
        /// <returns>True if setting is written, false otherwise.</returns>
        public static bool TryWrite<T>(string settingName, T settingValue)
        {
            try
            {
                Write(settingName, settingValue);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Attempts to write the setting and value.
        /// </summary>
        /// <typeparam name="T">The type of the setting's value.</typeparam>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="settingValue">The value of the setting.</param>
        /// <param name="dataStore">The storage to write to. e.g. Local, Roaming, etc.</param>
        /// <returns>True if setting is written, false otherwise.</returns>
        public static bool TryWrite<T>(string settingName, T settingValue, DataStore dataStore)
        {
            try
            {
                Write(settingName, settingValue, dataStore);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Clear all data from the given <see cref="DataStore"/>
        /// </summary>
        /// <param name="dataStore"></param>
        /// <returns></returns>
        public static void Clear(DataStore dataStore)
        {
            var task = Task.Run(async () => await ClearAsync(dataStore));
            task.Wait();
        }

        /// <summary>
        /// Clear all data from the given <see cref="DataStore"/> asyncronously
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
