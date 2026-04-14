using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UnrealLauncher.Models;

namespace UnrealLauncher.Utils
{
    public static class UnrealProjectsFinder
    {
        public static List<ProjectModel> FindProjects(IEnumerable<string> roots)
        {
            List<ProjectModel> _projects = new List<ProjectModel>();

            foreach (string root in roots)
            {
                if (!Directory.Exists(root))
                    continue;

                try
                {
                    IEnumerable<string> _files = Directory.EnumerateFiles(root, "*.uproject", SearchOption.AllDirectories);

                    foreach (string _file in _files)
                    {
                        string? _directory = Path.GetDirectoryName(_file);
                        string _name = Path.GetFileNameWithoutExtension(_file);
                        string _imagePath = GetProjectThumbnailPath(_file);
                        string _engineVersion = GetEngineVersion(_file);

                        _projects.Add(new ProjectModel
                        {
                            Name = _name,
                            ProjectPath = _directory ?? string.Empty,
                            UProjectFilePath = _file,
                            ImagePath = _imagePath,
                            EngineVersion = _engineVersion,

                        });
                    }
                }
                catch
                {
                    //print "auucn fichier trouver"
                }
            }

            return _projects
                .GroupBy(p => p.UProjectFilePath)
                .Select(g => g.First())
                .OrderBy(p => p.Name)
                .ToList();
        }

        public static string? GetProjectThumbnailPath(string uprojectPath)
        {
            var projectFolder = Path.GetDirectoryName(uprojectPath);
            if (string.IsNullOrEmpty(projectFolder))
                return null;

            var autoScreenshotPath = Path.Combine(projectFolder, "Saved", "AutoScreenshot.png");

            return File.Exists(autoScreenshotPath) ? autoScreenshotPath : "";
        }

        public static string GetEngineVersion(string uprojectPath)
        {
            if (!File.Exists(uprojectPath))
                return "Unknown";

            var json = File.ReadAllText(uprojectPath);

            using var doc = JsonDocument.Parse(json);

            if (doc.RootElement.TryGetProperty("EngineAssociation", out var engineProp))
            {
                var value = engineProp.GetString();

                if (string.IsNullOrEmpty(value))
                    return "Unknown";

                // Si c'est un GUID → build custom
                if (value.StartsWith("{"))
                    return "Custom Engine";

                return $"UE {value}";
            }

            return "Unknown";
        }

        public static void LaunchProject(ProjectModel _model)
        {
            if(File.Exists(_model.UProjectFilePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = _model.UProjectFilePath,
                    UseShellExecute = true,
                });
            }
        }
    }
}
