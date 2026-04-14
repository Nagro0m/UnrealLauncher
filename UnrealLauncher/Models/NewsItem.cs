using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealLauncher.Models
{
    public class NewsItem
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public string Link { get; set; } = "";
        public string Category { get; set; } = "";
        
        public NewsItem() { }
        public NewsItem(string _title, string _description, string _link)
        {
            Title = _title;
            Description = _description;
            Link = _link;
        }
    }
}
