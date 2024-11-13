using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using definitions;
using ReactiveUI;

namespace Anwesenheitsrechner
{
    internal class DataHandler
    {

        struct Settings
        {
            public String language;
        }

        private const String dataFilepath = "%documents%/Anwesenheitsrechner/data.json";
        private const String settingsFilepath = "%documents%/Anwesenheitsrechner/settings.json";
        private String data;
        private String settings;

        public DataHandler()
        {
            openSettingsFile(settingsFilepath);
            openDataFile(dataFilepath);
        }

        public Entry[] getEntryList(DateTime TimeRange)
        {
            Entry[] entry = new Entry[31];
            return entry;
        }

        private void openSettingsFile(String path)
        {
            if (File.Exists(path))
            {
                settings = File.ReadAllText(path);
            }
            else
            {
                Settings settings = new Settings();
                settings.language = "de-DE";
                File.Create(path);
                File.WriteAllText(path, JsonConvert.SerializeObject(settings));
            }
            return;
        }

        private void openDataFile(String path)
        {
            if (File.Exists(path))
            {
                data = File.ReadAllText(path);
            }
            else
            {
                return;
            }
            return;
        }


    }
}
