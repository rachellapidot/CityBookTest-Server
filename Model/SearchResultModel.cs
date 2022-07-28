using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.App.Model
{
    public class SearchResultModel
    {

        public SearchResultModel(string version, string key, string type, int rank, string localizedName, Localization country, Localization administrativeArea)
        {
            Version = version;
            Key = key;
            Type = type;
            Rank = rank;
            LocalizedName = localizedName;
            Country = country;
            AdministrativeArea = administrativeArea;
        }

        public string Version { get; set; }

        public string Key { get; set; }

        public string Type { get; set; }

        public int Rank { get; set; }

        public string LocalizedName { get; set; }

        public Localization Country { get; set; }

        public Localization AdministrativeArea { get; set; }
    }
}
