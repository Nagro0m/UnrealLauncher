using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnrealLauncher.Views;

namespace UnrealLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NewsPage newsPage = new NewsPage();
        SamplesPage samplesPage = new SamplesPage();
        LibraryPage libraryPage = new LibraryPage();
        TwinmotionPage twinmotionPage = new TwinmotionPage();
        RealityScanPage realityScanPage = new RealityScanPage();
        public MainWindow()
        {
            InitializeComponent();

            NewsTab.Navigate(newsPage);   
            SamplesTab.Navigate(samplesPage);   
            LibraryTab.Navigate(libraryPage);   
            TwinmotionTab.Navigate(twinmotionPage);   
            RealityScanTab.Navigate(realityScanPage);   
        }
    }
}