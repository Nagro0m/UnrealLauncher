using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnrealLauncher.Models;

namespace UnrealLauncher.ViewModels
{
    class SamplePageViewModel : ViewModelBase
    {
        public ICommand ItemClickCommand { get; }

        SampleItemList sampleItemList = new SampleItemList();

        public ObservableCollection<SampleItem> HeroItems { get; set; } = new ObservableCollection<SampleItem>();
        public ObservableCollection<SampleItem> FeatureSamples { get; set; } = new ObservableCollection<SampleItem>();
        public ObservableCollection<SampleItem> GameSamples { get; set; } = new ObservableCollection<SampleItem>();

        public SamplePageViewModel()
        {
            sampleItemList = DataReader.GetData<SampleItemList>("../../../Data/DB/SamplesData.json");
            foreach (SampleItem _item in sampleItemList.Hero)
            {
                HeroItems.Add(_item);
            }
            foreach (SampleItem _item in sampleItemList.Feature)
            {
                FeatureSamples.Add(_item);
            }
            foreach (SampleItem _item in sampleItemList.Game)
            {
                GameSamples.Add(_item);
            }

            ItemClickCommand = new RelayCommand(OnItemClicked);
        }

        void OnItemClicked(object _obj)
        {
            string _link = _obj as string;
            if (_link == null) return;
            OpenLink(_link);
        }

        void OpenLink(string _link)
        {
            ProcessStartInfo _psi = new ProcessStartInfo(_link);
            _psi.UseShellExecute = true;
            Process.Start(_psi);
        }
    }
}
