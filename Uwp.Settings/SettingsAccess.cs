using Windows.Storage;

namespace Uwp.Settings
{
    internal sealed class SettingsAccess : ISettingsAccess
    {
        private ApplicationDataContainer _applicationDataContainer;

        internal SettingsAccess(DataStore dataStore)
        {
            switch (dataStore)
            {
                case DataStore.Local:
                    _applicationDataContainer = ApplicationData.Current.LocalSettings;
                    break;
                case DataStore.Roaming:
                    _applicationDataContainer = ApplicationData.Current.RoamingSettings;
                    break;
            }
        }

        public object Read(string settingName)
        {
            return _applicationDataContainer.Values[settingName];
        }

        public void Write(string settingName, object settingValue)
        {
            _applicationDataContainer.Values[settingName] = settingValue.ToString();
        }
    }
}
