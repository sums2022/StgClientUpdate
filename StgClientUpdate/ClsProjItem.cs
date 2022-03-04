using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StgClientUpdater
{
    public class ClsProjItem
    {
        public string appID;
        public string version;
        public string url;
        public string projPath;
        public string description;
        public string sha256;
    }

    public class Global
    {
        public static List<ClsProjItem> listItems = new List<ClsProjItem>();

        internal static ClsProjItem getItem(string pname)
        {
            foreach (var item in listItems)
            {
                if (item.appID == pname) return item;
            }

            return null;
        }
    }
}
