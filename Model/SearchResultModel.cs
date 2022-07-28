using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.App.Model
{
    public class SearchResultModel
    {

        public SearchResultModel(string key,string localizedName)
        {
            Key = key;
            LocalizedName = localizedName;      
        }

        public string Key { get; set; }

        public string LocalizedName { get; set; }
    }
}
