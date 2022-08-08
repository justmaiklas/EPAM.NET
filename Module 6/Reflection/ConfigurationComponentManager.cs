using System.ComponentModel;
using System.Configuration;
using Reflection.Attributes;
using Reflection.Models;

namespace Reflection;

class ConfigurationComponentManager
{
    public ConfigurationComponentBase Configuration;
    public ConfigurationComponentManager()
    {
        Configuration = new ConfigurationComponentBase();
        ReadSettings();
    }

    public static string ReadSetting(string key)
    {
        try
        {
            var appSettings = ConfigurationManager.AppSettings;
            if (appSettings.Count == 0)
            {
                Console.WriteLine("App settings is empty! Creating new settings file");
                SetDefaultValues();
            }
            var result = appSettings[key] ?? "0";
            Console.WriteLine($"Readed key {key} value is: {result}");
            return result;
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error reading app settings");
            return "";
        }
    }

    public static void AddUpdateAppSettings(string key, string? value)
    {
        try
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key].Value == value)
            {
                return;
            }
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }

            Console.WriteLine($"Updating {key} to {value}");
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
        catch (ConfigurationErrorsException)
        {
            Console.WriteLine("Error writing app settings");
        }
    }

    public static void SetDefaultValues()
    {
        try
        {
            var properties = typeof(ConfigurationComponentBase).GetProperties();
            foreach (var property in properties)
            {
                AddUpdateAppSettings(property.Name, "0");
            }
        }
        catch (ConfigurationErrorsException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public void SaveSettings()
    {
        var properties = typeof(ConfigurationComponentBase).GetProperties();
        foreach (var prop in properties)
        {
            var attributes = prop.GetCustomAttributes(typeof(ReadAttribute), false);
            foreach (var t in attributes)
            {
                if (t is not WriteAttribute writeAttribute) continue;
                var key = writeAttribute.Key;
                var value = prop.GetValue(Configuration)?.ToString();
                AddUpdateAppSettings(key, value);
            }
        }
    }
    public void ReadSettings()
    {
        var properties = typeof(ConfigurationComponentBase).GetProperties();
        foreach (var prop in properties)
        {
            var attributes = prop.GetCustomAttributes(typeof(ReadAttribute), false);
            foreach (var t in attributes)
            {
                if (t is not ReadAttribute readAttribute) continue;
                var key = readAttribute.Key;
                var valueAsString = ReadSetting(key);
                var converter = TypeDescriptor.GetConverter(prop.PropertyType);
                var canConvert = converter.CanConvertFrom(typeof(string));
                object? value = "";
                if (canConvert) value = converter.ConvertFrom(valueAsString);
                prop.SetValue(Configuration, value);
            }
        }
    }
}