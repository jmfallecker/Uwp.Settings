Thanks for choosing Uwp.Settings!

Main use is through the static Settings class. Basic functionality is Read/Write/Clear. Initial data store is defaulted to Local data store.

To Write a setting use Settings.Write(string settingName, object settingValue)

To Read a setting use Settings.Read<T>(string settingName) where T is the expected type for the returned setting.

Write/Read both have an overload to allow passing a DataStore enum value. This will alter the data-store that is used.

Use Settings.SetDefaultDataStore(DataStore dataStore) to change the default data store.