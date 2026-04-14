using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealLauncher.Models
{
    public class ProjectModel
    {
        public string Name { get; set; } = "";
        public string EngineVersion { get; set; } = "";
        public string ProjectPath { get; set; } = "";
        public string UProjectFilePath { get; set; } = "";
        public string ImagePath { get; set; } = "";
    }
}
