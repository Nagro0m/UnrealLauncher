using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealLauncher.Models
{
    public class SampleItemList
    {
        public List<SampleItem> Hero { get; set; } = new List<SampleItem>();
        public List<SampleItem> Feature { get; set; } = new List<SampleItem>();
        public List<SampleItem> Game { get; set; } = new List<SampleItem>();
    }
}
