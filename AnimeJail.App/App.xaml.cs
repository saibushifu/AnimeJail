using AnimeJail.App.Data;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AnimeJail.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SharpProjectsContext Context = new SharpProjectsContext();
    }   
}
