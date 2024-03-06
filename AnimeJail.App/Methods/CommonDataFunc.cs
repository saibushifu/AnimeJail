using AnimeJail.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using AnimeJail.App.Controls;
using AnimeJail.App.Pages.PopupPages;
using AnimeJail.App.Windows;
using System.Reflection;

namespace AnimeJail.App.Methods;

public class CommonDataFunc<T> where T : class
{
    public static void DeleteObjFromDb(object sender, ObservableCollection<T> Collection)
    {
        var item = (T)((Button)sender).DataContext;
        try
        {
            App.Context.Remove(item);
            App.Context.SaveChanges();
            Collection.Remove(item);
        }
        catch (Exception ex) { MessageBox.Show($"При удалении произошла следующая ошибка: " + ex.Message); }
    }

    public static T TypeFromSender(object sender) => (T)((Button)sender).DataContext;
}

public class CommonPageFunc
{
    public static void OpenPage(Page page) => new PopupWindow(page).Show();
    
}
