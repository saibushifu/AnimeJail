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
}
