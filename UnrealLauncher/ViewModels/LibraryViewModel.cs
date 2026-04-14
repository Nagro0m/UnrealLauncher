using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UnrealLauncher.Models;
using UnrealLauncher.Utils;

namespace UnrealLauncher.ViewModels
{
    public class LibraryViewModel : ViewModelBase
    {
        public RelayCommand LaunchCommand => new RelayCommand(_execute => LaunchProject(_execute as ProjectModel));
        public ObservableCollection<ProjectModel> Projects { get; set; }


        public LibraryViewModel()
        {

            //LaunchCommand = new RelayCommand(
            //param => LaunchProject(param as ProjectModel),
            //param => param is ProjectModel);

            IEnumerable<string> roots = new[]
            {
                @"D:\Morgan_P2\Unreal"
            };

            List<ProjectModel> foundProjects = UnrealProjectsFinder.FindProjects(roots);
            Projects = new ObservableCollection<ProjectModel>(foundProjects);
        }

        void LaunchProject(ProjectModel project)
        {
            if (project == null)
            {
                MessageBox.Show("project not found");
                return;
            }

            UnrealProjectsFinder.LaunchProject(project);
        }

    }
}
