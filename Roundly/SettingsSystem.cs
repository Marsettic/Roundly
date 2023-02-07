using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roundly
{
    class SettingsSystem
    {

        RegistryKey CreationKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Roundly");
        RegistryKey ReadKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Roundly");

        public void SaveSettings(string RegistryName, string result)
        {
            CreationKey.SetValue(RegistryName, result);
            //CreationKey.Close();
        }

        public string ReadSettings(string RegistryName)
        {
            return (string)CreationKey.GetValue(RegistryName);
        }

    }
}
