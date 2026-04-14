using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealLauncher.Models
{
    public class NewsItemList
    {
        public List<NewsItem> Featured { get; set; } = new List<NewsItem>();
        public List<NewsItem> Blog { get; set; } = new List<NewsItem>();
        public List<NewsItem> Spotlight { get; set; } = new List<NewsItem>();
    }
}
