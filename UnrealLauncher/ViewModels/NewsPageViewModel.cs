using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using UnrealLauncher.Models;

namespace UnrealLauncher.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        public ICommand ItemClickCommand { get; }

        public RelayCommand NewsCommand => new RelayCommand(_c => OpenLink("https://www.unrealengine.com/feed"));
        public RelayCommand YoutubeCommand => new RelayCommand(_c => OpenLink("https://www.youtube.com/unrealengine"));
        public RelayCommand QACommand => new RelayCommand(_c => OpenLink("https://forums.unrealengine.com/tags/intersection/unreal-engine/question"));
        public RelayCommand ForumsCommand => new RelayCommand(_c => OpenLink("https://forums.unrealengine.com/"));
        public RelayCommand RoadmapCommand => new RelayCommand(_c => OpenLink("https://portal.productboard.com/epicgames/1-unreal-engine-public-roadmap/tabs/46-unreal-engine-5-0"));

        NewsItemList newsItemList = new NewsItemList();
        public ObservableCollection<NewsItem> FeaturedItems { get; set; } = new ObservableCollection<NewsItem>();
        public ObservableCollection<NewsItem> BlogItems { get; set; } = new ObservableCollection<NewsItem>();
        public ObservableCollection<NewsItem> SpotlightItems { get; set; } = new ObservableCollection<NewsItem>();

        public NewsPageViewModel()
        {
            newsItemList = DataReader.GetData<NewsItemList>("../../../Data/DB/NewsDatas.json");
            foreach (NewsItem _item in newsItemList.Featured)
            {
                FeaturedItems.Add(_item);
            }
            foreach (NewsItem _item in newsItemList.Blog)
            {
                BlogItems.Add(_item);
            }
            foreach (NewsItem _item in newsItemList.Spotlight)
            {
                SpotlightItems.Add(_item);
            }

            ItemClickCommand = new RelayCommand(OnItemClicked);

            //FeaturedItems.Add(new NewsItem("Fab spring creator sale on now", "Description", "https://www.fab.com/search?min_discount_percentage=1"));
            //FeaturedItems.Add(new NewsItem("Test2", "Description2", "https://www.unrealengine.com/events/indie-games-week-2026"));
            //FeaturedItems.Add(new NewsItem("Jeu", "Description2", "https://www.fab.com/listings/d79d7bcc-d5a1-4233-8234-fcb61a95db1c"));
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
