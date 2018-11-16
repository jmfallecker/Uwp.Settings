Thanks for choosing Uwp.Settings!

Main use is through the static Settings class. Basic functionality is Read/Write/Clear. Initial data store is defaulted to Local data store.

- To Write a setting use Settings.Write(string settingName, object settingValue)

- To Read a setting use Settings.Read<T>(string settingName) where T is the expected type for the returned setting.

- Write/Read both have an overload to allow passing a DataStore enum value. This will alter the data-store that is used.

- TryWrite returns a boolean denoting if the write is successful. Use Settings.TryWrite(string settingName, T settingValue)

- TryRead returns a boolean denoting if the read is successful, and will return the value of the setting read through the out parameter. Note that if TryRead returns false, the out parameter will be set to default(T). Use Settings.TryRead(string settingName, out T settingValue)

- TryWrite/TryRead both have an overload to allow passing a DataStore enum value. This will alter the data-store that is used.

- SafeRead returns the value of the setting, or if the value is not found or anything goes wrong, will return the fallbackValue.

- SafeRead has an overload to allow passing a DataStore enum value. This will alter the data-store that is read from. 

Use Settings.SetDefaultDataStore(DataStore dataStore) to change the default data store.