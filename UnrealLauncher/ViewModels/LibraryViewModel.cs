using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UnrealLauncher.Models;
using UnrealLauncher.Utils;

namespace UnrealLauncher.ViewModels
{
    public class LibraryViewModel : ViewModelBase
    {
        public RelayCommand LaunchProjectCommand => new RelayCommand(_execute => LaunchProject(_execute as ProjectModel));
        public RelayCommand LaunchEngineCommand => new RelayCommand(_execute => LaunchEngine(_execute as EngineVersionModel));
        public ObservableCollection<ProjectModel> Projects { get; set; }
        public ObservableCollection<EngineVersionModel> EngineVersions { get; set; }
        public ObservableCollection<FabModel> FabItems { get; set; }

        public LibraryViewModel()
        {

            //LaunchCommand = new RelayCommand(
            //param => LaunchProject(param as ProjectModel),
            //param => param is ProjectModel);

            IEnumerable<string> roots = new[]
            {
                @"D:\2025-2026\Unreal\Cours"
            };

            List<ProjectModel> foundProjects = UnrealManager.FindProjects(roots);
            Projects = new ObservableCollection<ProjectModel>(foundProjects);

            List<EngineVersionModel> _foundEngines = UnrealManager.FindInstalledEngines();
            EngineVersions = new ObservableCollection<EngineVersionModel>(_foundEngines);

            FabItems = new ObservableCollection<FabModel>
            {
                new FabModel
                {
                    Name = "Abandoned Factory",
                    ImagePath = "Images/factory.png",
                    ActionText = "Add To Project"
                },
                new FabModel
                {
                    Name = "City Sample",
                    ImagePath = "Images/city.png",
                    ActionText = "Create Project"
                }
            };
        }

        void LaunchProject(ProjectModel project)
        {
            if (project == null)
            {
                MessageBox.Show("project not found");
                return;
            }

            UnrealManager.LaunchProject(project);
        }

        void LaunchEngine(EngineVersionModel version)
        {
            if (version == null)
            {
                MessageBox.Show("Engine Version not found");
                return;
            }

                MessageBox.Show("Engine Version  found");
            UnrealManager.LaunchEngine(version);
        }

    }
}
