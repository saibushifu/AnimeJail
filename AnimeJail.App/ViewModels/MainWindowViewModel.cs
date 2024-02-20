using AnimeJail.App.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeJail.App.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// Заголовок окна
        /// </summary>
        private string _Title = "Рабочее окно";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
